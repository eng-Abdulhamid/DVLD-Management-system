using DVLD.BLL.Services;
using DVLD.PL.Global;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    public partial class frmDeleteDriver : frmBase
    {
        private readonly int _driverId;
        private readonly DriverService _driverService;
        private ToolTip? _toolTips;

        public event Action? DeletedSuccessfully;

        public frmDeleteDriver(int driverId)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();
            SetContextTitle("Delete Driver");

            _driverId = driverId;
            _driverService = new DriverService();

            ApplyStyles();
            SetupToolTips();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnDelete.ApplyDangerStyle();
            btnCancel.ApplySecondaryStyle();
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 300,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnDelete, "Permanently delete this driver record");
            _toolTips.SetToolTip(btnCancel, "Cancel and close window");
        }

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnDelete.Click += async (s, e) => await PerformDeleteAsync();
        }

        private async void frmDeleteDriver_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_driverId <= 0)
            {
                UITheme.ShowErrorToast("Invalid driver ID.");
                this.Close();
                return;
            }

            await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);
        }
        private void UpdateDeleteButtonEnabled(bool Enabled)
        {
            btnDelete.IsLoading = !Enabled;
            btnDelete.Enabled = Enabled;
            btnCancel.Enabled = Enabled;

        }
        private async Task PerformDeleteAsync()
        {
            UpdateDeleteButtonEnabled(false);
            var result = await _driverService.DeleteAsync(_driverId);

            if (result.IsSuccess)
            {
                UITheme.ShowSuccessToast("Driver deleted successfully.");
                DeletedSuccessfully?.Invoke();
                this.Close();
            }
            else
            {
                UITheme.ShowErrorToast(result.Message);
            }

            UpdateDeleteButtonEnabled(true);
        }
    }
}