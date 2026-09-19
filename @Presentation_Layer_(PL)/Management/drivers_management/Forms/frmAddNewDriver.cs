using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using DVLD.PL.Theme;
namespace DVLD.PL.DriversManagement
{
    public partial class frmSaveDriver : frmBase
    {
        #region Properties and the Constructor
        private int _selectedPersonId = -1;
        private readonly DriverService _driverService;
        public event Action<int>? DriverSaved;
        public frmSaveDriver()
        {
            InitializeComponent();

            SetContextTitle("Add New Driver");
            SetButtonsType();
            _driverService = new DriverService();
            
            ApplyTheme();
            ConfigureWizardUI();
            RegisterEvents();
        }
        private void SetButtonsType()
        {
            btnNext.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnBack.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnCancel.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnSave.ButtonType = CustomizeControls.enButtonType.Primary;
            btnSearchPerson.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnAddNewPerson.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnSelectPerson.ButtonType = CustomizeControls.enButtonType.Secondary;
        }

        private void ConfigureWizardUI()
        {
            // Enforce strictly guided wizard flow by hiding default tab headers
            tcWizard.Appearance = TabAppearance.FlatButtons;
            tcWizard.ItemSize = new Size(0, 1);
            tcWizard.SizeMode = TabSizeMode.Fixed;
            tcWizard.TabStop = false;
        }
        #region Register Events
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
                    NotificationTheme.ShowWarningToast("Please select a valid person first to proceed.");
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
        #endregion
        #endregion
        #region Events
        private void frmSaveDriver_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            tcWizard.SelectedTab = tpPersonSelection;
            btnSave.Enabled = false;
            lnkEditPerson.Visible = false;

            lblCreatedDateValue.Text = DateTime.Now.ToString("dd MMM yyyy - hh:mm tt");
            lblCreatedByValue.Text = AppSession.CurrentUser?.UserName ?? "System";
        }
        #endregion
        private async Task PerformSaveAsync()
        {
            if (_selectedPersonId <= 0)
            {
                NotificationTheme.ShowWarningToast("Valid person context lost. Please re-select a person.");
                tcWizard.SelectedTab = tpPersonSelection;
                return;
            }

            UpdateSaveButtonStatus(false);

            int currentUserId = AppSession.CurrentUser?.UserID > 0 ? AppSession.CurrentUser.UserID : 1;
            var dto = new DriverAddDTO(_selectedPersonId, currentUserId, DateTime.Now);

            var result = await _driverService.AddAsync(dto);

            if (result.IsSuccess)
            {
                NotificationTheme.ShowSuccessToast("Driver registered successfully.");
                DriverSaved?.Invoke(result.Data);
                this.Close();
            }
            else
            {
                // BLL restricts duplicate drivers linked to the same PersonID. The message surfaces here.
                NotificationTheme.ShowWarningToast(result.Message ?? "Failed to save driver.", "Registration Failed");
                UpdateSaveButtonStatus(true);
            }
        }
        private void UpdateSaveButtonStatus(bool isEnabled)
        {
            btnSave.IsLoading = !isEnabled;
            btnSave.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
            btnBack.Enabled = isEnabled;
        }
    }
}