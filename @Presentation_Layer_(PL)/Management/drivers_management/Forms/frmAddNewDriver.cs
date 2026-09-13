using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using System;
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
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            btnNext.ApplyPrimaryStyle();
            btnSearchPerson.ApplySecondaryStyle();
            btnAddNewPerson.ApplySecondaryStyle();
            btnSelectPerson.ApplySecondaryStyle();

            txtSearchNationalNo.ApplyStandardStyle();
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
                if (ctrlPersonCard1.PersonID > 0)
                {
                    _selectedPersonId = ctrlPersonCard1.PersonID;
                    lnkEditPerson.Visible = true;
                }
            };

            btnSelectPerson.Click += (s, e) =>
            {
                using var selectPersonForm = new frmPeopleManagement(frmPeopleManagement.enMode.SelectPerson);
                selectPersonForm.OnPersonSelected += async (personId) =>
                {
                    await LoadPersonInfoAsync(personId);
                };
                selectPersonForm.ShowDialog(this);
            };

            btnAddNewPerson.Click += (s, e) =>
            {
                using frmSavePerson frm = new frmSavePerson();
                frm.PersonSaved += async (personId) =>
                {
                    await LoadPersonInfoAsync(personId);
                };
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
                    UITheme.ShowWarningToast("Please select a valid person first.");
                    return;
                }

                lblConfirmPersonName.Text = ctrlPersonCard1.SelectedPersonInfo?.FullName ?? "[Unknown]";
                lblPersonIdValue.Text = _selectedPersonId.ToString();
                tcWizard.SelectedTab = tpDriverConfirmation;
                btnSave.Enabled = true;
            };

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();
        }

        private async Task LoadPersonInfoAsync(int personId)
        {
            _selectedPersonId = personId;
            await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            lnkEditPerson.Visible = true;
        }
        private void UpdateSaveButtonStatus(bool Enabled)
        {
            btnSave.IsLoading = !Enabled;
            btnSave.Enabled = Enabled;
            btnCancel.Enabled = Enabled;

        }
        private async Task PerformSaveAsync()
        {
            if (_selectedPersonId <= 0)
            {
                UITheme.ShowWarningToast("Please select a person before saving.");
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
                UITheme.ShowWarningToast(result.Message ?? "Failed to save driver.", "Registration Failed");
            }

            UpdateSaveButtonStatus(true);

        }
    }
}