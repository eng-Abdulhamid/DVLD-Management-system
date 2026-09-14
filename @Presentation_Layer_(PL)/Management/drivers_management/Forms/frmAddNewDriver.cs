using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    public partial class frmSaveDriver : frmBase
    {
        private int _selectedPersonId = -1;
        private readonly DriverService _driverService;

        public event Action<int>? DriverSaved;

        public frmSaveDriver()
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();
            SetContextTitle("Add New Driver");

            _driverService = new DriverService();

            ApplyStyles();
            ConfigureWizardUI();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            btnNext.ApplyPrimaryStyle();
            btnBack.ApplySecondaryStyle();
            btnSearchPerson.ApplySecondaryStyle();
            btnAddNewPerson.ApplySecondaryStyle();
            btnSelectPerson.ApplySecondaryStyle();

            txtSearchNationalNo.ApplyStandardStyle();
        }

        private void ConfigureWizardUI()
        {
            // Enforce strictly guided wizard flow by hiding default tab headers
            tcWizard.Appearance = TabAppearance.FlatButtons;
            tcWizard.ItemSize = new Size(0, 1);
            tcWizard.SizeMode = TabSizeMode.Fixed;
            tcWizard.TabStop = false;
        }

        private void frmSaveDriver_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            tcWizard.SelectedTab = tpPersonSelection;
            btnSave.Enabled = false;
            lnkEditPerson.Visible = false;

            lblCreatedDateValue.Text = DateTime.Now.ToString("dd MMM yyyy - hh:mm tt");
            lblCreatedByValue.Text = AppSession.CurrentUser?.UserName ?? "System";
        }

        private void RegisterEvents()
        {
            btnSearchPerson.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchNationalNo.Text)) return;
                
                await ctrlPersonCard1.LoadPersonInfoByNationalNoAsync(txtSearchNationalNo.Text.Trim());
                EvaluatePersonSelection();
            };

            btnSelectPerson.Click += (s, e) =>
            {
                using var selectPersonForm = new frmPeopleManagement(frmPeopleManagement.enMode.SelectPerson);
                selectPersonForm.OnPersonSelected += async (personId) => await LoadPersonInfoAsync(personId);
                selectPersonForm.ShowDialog(this);
            };

            btnAddNewPerson.Click += (s, e) =>
            {
                using frmSavePerson frm = new frmSavePerson();
                frm.PersonSaved += async (personId) => await LoadPersonInfoAsync(personId);
                frm.ShowDialog(this);
            };

            lnkEditPerson.LinkClicked += (s, e) =>
            {
                if (_selectedPersonId <= 0) return;
                using frmSavePerson frm = new frmSavePerson(_selectedPersonId);
                frm.PersonSaved += async (personId) => await LoadPersonInfoAsync(personId);
                frm.ShowDialog(this);
            };

            btnNext.Click += (s, e) =>
            {
                if (_selectedPersonId <= 0)
                {
                    UITheme.ShowWarningToast("Please select a valid person first to proceed.");
                    return;
                }

                lblConfirmPersonName.Text = ctrlPersonCard1.SelectedPersonInfo?.FullName ?? "[Unknown]";
                lblPersonIdValue.Text = _selectedPersonId.ToString();
                
                tcWizard.SelectedTab = tpDriverConfirmation;
                btnSave.Enabled = true;
            };

            btnBack.Click += (s, e) =>
            {
                tcWizard.SelectedTab = tpPersonSelection;
                btnSave.Enabled = false;
            };

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();
        }

        private async Task LoadPersonInfoAsync(int personId)
        {
            await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            EvaluatePersonSelection();
        }

        private void EvaluatePersonSelection()
        {
            if (ctrlPersonCard1.PersonID > 0)
            {
                _selectedPersonId = ctrlPersonCard1.PersonID;
                lnkEditPerson.Visible = true;
            }
            else
            {
                _selectedPersonId = -1;
                lnkEditPerson.Visible = false;
            }
        }

        private void UpdateSaveButtonStatus(bool isEnabled)
        {
            btnSave.IsLoading = !isEnabled;
            btnSave.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
            btnBack.Enabled = isEnabled;
        }

        private async Task PerformSaveAsync()
        {
            if (_selectedPersonId <= 0)
            {
                UITheme.ShowWarningToast("Valid person context lost. Please re-select a person.");
                tcWizard.SelectedTab = tpPersonSelection;
                return;
            }

            UpdateSaveButtonStatus(false);

            int currentUserId = AppSession.CurrentUser?.UserID > 0 ? AppSession.CurrentUser.UserID : 1;
            var dto = new DriverAddDTO(_selectedPersonId, currentUserId, DateTime.Now);

            var result = await _driverService.AddAsync(dto);

            if (result.IsSuccess)
            {
                UITheme.ShowSuccessToast("Driver registered successfully.");
                DriverSaved?.Invoke(result.Data);
                this.Close();
            }
            else
            {
                // BLL restricts duplicate drivers linked to the same PersonID. The message surfaces here.
                UITheme.ShowWarningToast(result.Message ?? "Failed to save driver.", "Registration Failed");
                UpdateSaveButtonStatus(true);
            }
        }
    }
}