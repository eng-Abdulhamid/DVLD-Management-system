using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmDeletePersonForm : frmBase
    {
        private readonly int _personId;
        private readonly PersonService? _personService;
        private ToolTip? _toolTips;

        public event Action? DeletedSuccessfully;

        public frmDeletePersonForm() : this(-1)
        {
        }

        public frmDeletePersonForm(int personId)
        {
            InitializeComponent();

            this.ApplyStandardFormTheme();
            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;

            _personId = personId;

            if (UIUtility.IsDesignMode)
                return;

            _personService = new PersonService();

            ApplyStyles();
            RegisterEvents();
            SetupToolTips();
        }

        private void ApplyStyles()
        {
            btnDelete.ApplyDangerStyle();
            btnCancel.ApplySecondaryStyle();
        }

        private async void frmDeletePersonForm_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode)
                return;

            if (_personId <= 0)
            {
                UITheme.ShowErrorToast("Invalid person identifier.");
                this.Close();
                return;
            }

            await ctrlPersonCard1.LoadPersonInfoAsync(_personId);
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

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnDelete.Click += async (s, e) => await PerformDeleteAsync();
        }

        private async Task PerformDeleteAsync()
        {
            if (_personService == null) return;

            btnDelete.IsLoading = true;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;

            try
            {
                OperationResult<bool> result = await _personService.DeleteAsync(_personId);

                if (result.IsSuccess)
                {
                    UITheme.ShowSuccessToast("Person deleted successfully.");
                    DeletedSuccessfully?.Invoke();
                    this.Close();
                }
                else
                {
                    UITheme.ShowWarningToast(result.Message, "Delete Failed");
                }
            }
            finally
            {
                btnDelete.IsLoading = false;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
    }
}