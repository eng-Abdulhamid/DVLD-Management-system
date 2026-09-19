using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Theme;
namespace DVLD.PL.DriversManagement
{
    public partial class frmDeleteDriver : frmBase
    {
        #region Properties and the Constructor
        private readonly int _driverId;
        private readonly DriverService _driverService;
        public event Action? DeletedSuccessfully;
        public frmDeleteDriver(int driverId)
        {
            InitializeComponent();
           
            SetContextTitle("Delete Driver");

            _driverId = driverId;
            _driverService = new DriverService();

            base.ApplyTheme();
            SetupToolTips();
            RegisterEvents();
        }
        private void SetupToolTips()
        {
            // Leveraged the designer-managed toolTip1 component to ensure automatic disposal 
            // and prevent memory leaks instead of instantiating an unmanaged ToolTip instance.
            toolTip1.InitialDelay = 300;
            toolTip1.UseAnimation = true;
            toolTip1.UseFading = true;

            toolTip1.SetToolTip(btnDelete, "Permanently delete this driver record");
            toolTip1.SetToolTip(btnCancel, "Cancel and close window");
        }
        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnDelete.Click += async (s, e) => await PerformDeleteAsync();
        }
        #endregion
        #region Events
        private async void frmDeleteDriver_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_driverId <= 0)
            {
                NotificationTheme.ShowErrorToast("Invalid driver ID provided.");
                this.Close();
                return;
            }

            // Defense in depth: Disable deletion until context is fully verified from the BLL
            UpdateDeleteButtonEnabled(false);

            await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);

            // Verify the driver actually exists and loaded successfully before enabling the delete action
            if (ctrlDriverCard1.SelectedDriverInfo == null)
            {
                lblWarning.Text = "⚠ Driver not found or has already been deleted.";
                return;
            }

            UpdateDeleteButtonEnabled(true);
        }
        #endregion
        private void UpdateDeleteButtonEnabled(bool isEnabled)
        {
            btnDelete.IsLoading = !isEnabled;
            btnDelete.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
        }
        private async Task PerformDeleteAsync()
        {
            // UI validation: Require explicit final confirmation for destructive BLL operations
            if (MessageBox.Show("Are you absolutely sure you want to delete this driver? This action cannot be undone.",
                                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            UpdateDeleteButtonEnabled(false);

            var result = await _driverService.DeleteAsync(_driverId);

            if (result.IsSuccess)
            {
                NotificationTheme.ShowSuccessToast("Driver deleted successfully.");
                DeletedSuccessfully?.Invoke();
                this.Close();
            }
            else
            {
                // BLL restricts deletion if the driver is linked to active licenses or constraints.
                NotificationTheme.ShowWarningToast(result.Message ?? "Unable to delete driver due to linked constraints.", "Deletion Rejected");
                UpdateDeleteButtonEnabled(true);
            }
        }
    }
}