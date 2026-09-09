using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    public partial class ctrlDriverCard : UserControl
    {
        private int _driverId = -1;
        private DriverService? _driverService;

        // Lazy initialization for designer stability
        private DriverService DriverServiceInstance => _driverService ??= new DriverService();

        public int DriverID => _driverId;
        public DriverReadDTO? SelectedDriverInfo { get; private set; }

        public ctrlDriverCard()
        {
            InitializeComponent();
            ResetCard();
        }

        public async Task LoadDriverInfoAsync(int driverId)
        {
            if (UIUtility.IsDesignMode) return;

            _driverId = driverId;

            if (driverId <= 0)
            {
                ResetCard();
                return;
            }

            var result = await DriverServiceInstance.GetByIdAsync(driverId);

            if (result.IsSuccess && result.Data != null)
            {
                await LoadDriverInfoAsync(result.Data);
            }
            else
            {
                ResetCard();
            }
        }

        public async Task LoadDriverInfoAsync(DriverReadDTO driver)
        {
            if (UIUtility.IsDesignMode) return;

            if (driver == null)
            {
                ResetCard();
                return;
            }

            _driverId = driver.DriverID;
            SelectedDriverInfo = driver;

            // Load encapsulated person details
            await ctrlPersonCard1.LoadPersonInfoAsync(SelectedDriverInfo.PersonID);

            PopulateDriverDetails();
        }

        private void PopulateDriverDetails()
        {
            if (SelectedDriverInfo == null) return;

            lblDriverID.Text = SelectedDriverInfo.DriverID.ToString();
            lblCreatedByUserID.Text = SelectedDriverInfo.CreatedByUserID.ToString();
            lblCreatedDate.Text = SelectedDriverInfo.CreatedDate.ToString("dd MMM yyyy");
        }

        public void ResetCard()
        {
            _driverId = -1;
            SelectedDriverInfo = null;

            ctrlPersonCard1.ResetCard();

            lblDriverID.Text = "[????]";
            lblCreatedByUserID.Text = "[????]";
            lblCreatedDate.Text = "[????]";
        }
    }
}