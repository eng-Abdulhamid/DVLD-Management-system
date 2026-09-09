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

            txtSearchNationalNo.ApplyStandardStyle();
        }

        private void frmSaveDriver_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            tcWizard.SelectedTab = tpPersonSelection;
            btnSave.Enabled = false;
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
                }
            };

            btnAddNewPerson.Click += (s, e) =>
            {
                using frmSavePerson frm = new frmSavePerson();
                frm.PersonSaved += async (personId) =>
                {
                    _selectedPersonId = personId;
                    await ctrlPersonCard1.LoadPersonInfoAsync(personId);
                };
                frm.ShowDialog();
            };

            btnNext.Click += (s, e) =>
            {
                if (_selectedPersonId <= 0)
                {
                    UITheme.ShowWarningToast("Please select a person before continuing.");
                    return;
                }

                lblConfirmPersonName.Text = ctrlPersonCard1.SelectedPersonInfo?.FullName ?? "[Unknown]";
                tcWizard.SelectedTab = tpDriverConfirmation;
                btnSave.Enabled = true;
            };

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();
        }

        private async Task PerformSaveAsync()
        {
            btnSave.IsLoading = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            try
            {
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
            }
            finally
            {
                btnSave.IsLoading = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
    }
}