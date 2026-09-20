using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Theme;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmDeletePersonForm : BaseForm
    {
        #region Fields & Events
        private readonly int _personId;
        private readonly PersonService? _personService;
        private ToolTip? _toolTips;

        public event Action? DeletedSuccessfully;

        #endregion

        #region Constructors & Initialization
        public frmDeletePersonForm() : this(-1)
        {
        }

        public frmDeletePersonForm(int personId)
        {
            InitializeComponent();
            SetContextTitle("Delete Person");
            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;

            _personId = personId;

            if (UIUtility.IsDesignMode)
                return;

            _personService = new PersonService();

            RegisterEvents();
            SetupToolTips();
            base.ApplyTheme();
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 350,
                ReshowDelay = 100,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnDelete, "Permanently delete this record");
            _toolTips.SetToolTip(btnCancel, "Cancel and close this window");
        }

        #endregion

        #region Form Lifecycle Events

        private async void frmDeletePersonForm_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode)
                return;

            if (!ValidatePersonId())
                return;

            await LoadPersonCardDataAsync();
        }

        private bool ValidatePersonId()
        {
            if (_personId <= 0)
            {
                NotificationTheme.ShowErrorToast("Invalid person identifier.");
                this.Close();
                return false;
            }

            return true;
        }

        private async Task LoadPersonCardDataAsync()
        {
            await ctrlPersonCard1.LoadPersonInfoAsync(_personId);
        }

        #endregion

        #region Deletion Workflow

        private async Task PerformDeleteAsync()
        {
            if (_personService == null) return;

            SetActionButtonsState(isEnabled: false);

            OperationResult<bool> result = await _personService.DeleteAsync(_personId);
            HandleDeleteResult(result);

            SetActionButtonsState(isEnabled: true);
        }

        private void HandleDeleteResult(OperationResult<bool> result)
        {
            if (result.IsSuccess)
            {
                OnDeleteSuccess();
            }
            else
            {
                OnDeleteFailure(result.Message);
            }
        }

        private void OnDeleteSuccess()
        {
            NotificationTheme.ShowSuccessToast("Person deleted successfully.");
            DeletedSuccessfully?.Invoke();
            this.Close();
        }

        private void OnDeleteFailure(string? errorMessage)
        {
            NotificationTheme.ShowWarningToast(errorMessage, "Delete Failed");
        }

        private void SetActionButtonsState(bool isEnabled)
        {
            btnDelete.IsLoading = !isEnabled;
            btnDelete.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
        }

        #endregion

        #region Event Subscriptions

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnDelete.Click += async (s, e) => await PerformDeleteAsync();
        }

        #endregion
    }
}