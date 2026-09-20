using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
namespace DVLD.PL.DriversManagement
{
    public partial class ctrlDriverCard : UserControl
    {
        #region Properties and the Constructor
        private int _driverId = -1;
        private DriverService? _driverService;

        public int DriverID => _driverId;
        public DriverReadDTO? SelectedDriverInfo { get; private set; }

        public ctrlDriverCard()
        {
            InitializeComponent();
            if (!UIUtility.IsDesignMode)
            {
                ResetCard();
            }
        }
        #endregion
        public async Task LoadDriverInfoAsync(int driverId)
        {
            if (UIUtility.IsDesignMode) return;

            if (driverId <= 0)
            {
                ResetCard();
                SetErrorState();
                return;
            }

            _driverService ??= new DriverService();
            var result = await _driverService.GetByIdAsync(driverId);

            if (result.IsSuccess && result.Data != null)
            {
                await LoadDriverInfoAsync(result.Data);
            }
            else
            {
                ResetCard();
                SetErrorState();
            }
        }
        public async Task LoadDriverInfoAsync(DriverReadDTO driver)
        {
            if (UIUtility.IsDesignMode) return;

            if (driver == null)
            {
                ResetCard();
                SetErrorState();
                return;
            }

            _driverId = driver.DriverID;
            SelectedDriverInfo = driver;

            // Enforce sequential UI loading to prevent race conditions
            await ctrlPersonCard1.LoadPersonInfoAsync(SelectedDriverInfo.PersonID);

            PopulateDriverDetails();
        }
        public void ResetCard()
        {
            _driverId = -1;
            SelectedDriverInfo = null;

            if (!UIUtility.IsDesignMode)
            {
                ctrlPersonCard1.ResetCard();
            }

            lblDriverID.Text = "[????]";
            lblCreatedByUserID.Text = "[????]";
            lblCreatedDate.Text = "[????]";

            lblDriverID.ForeColor = Color.FromArgb(31, 41, 55);
            gbDriverInfo.Text = "Driver Information";
        }
        private void PopulateDriverDetails()
        {
            if (SelectedDriverInfo == null) return;

            lblDriverID.Text = SelectedDriverInfo.DriverID.ToString();
            lblCreatedByUserID.Text = SelectedDriverInfo.CreatedByUserID.ToString();
            lblCreatedDate.Text = SelectedDriverInfo.CreatedDate.ToString("dd MMM yyyy");

            lblDriverID.ForeColor = Color.FromArgb(31, 41, 55);
            gbDriverInfo.Text = "Driver Information (Active)";
        }
        private void SetErrorState()
        {
            lblDriverID.Text = "Not Found";
            lblDriverID.ForeColor = Color.FromArgb(239, 68, 68); // Red color for immediate UX feedback
            gbDriverInfo.Text = "Driver Information (Invalid)";
        }
    }
}