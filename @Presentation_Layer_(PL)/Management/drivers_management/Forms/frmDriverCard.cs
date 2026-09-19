using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using DVLD.PL.Theme;
namespace DVLD.PL.DriversManagement
{
    public partial class frmDriverCard : frmBase
    {
        private readonly int _driverId;
        public frmDriverCard(int driverId)
        {
            InitializeComponent();
            SetContextTitle("Driver Details");

            _driverId = driverId;

            RegisterEvents();
            base.ApplyTheme();
        }
        #region Register Events
        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => this.Close();

            btnEditPerson.Click += (s, e) => OpenEditPersonForm();
        }
        private void OpenEditPersonForm()
        {
            var driverInfo = ctrlDriverCard1.SelectedDriverInfo;

            if (driverInfo == null || driverInfo.PersonID <= 0)
            {
                NotificationTheme.ShowErrorToast("Valid person context is missing.");
                return;
            }

            using frmSavePerson frm = new frmSavePerson(driverInfo.PersonID);
            frm.PersonSaved += async (personId) =>
            {
                // Reload the card to reflect any updated personal details (e.g., Name, Image)
                await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);
                NotificationTheme.ShowSuccessToast("Driver's personal information updated successfully.");
            };

            frm.ShowDialog(this);
        }
        #endregion
        #region Events
        private async void frmDriverCard_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_driverId <= 0)
            {
                NotificationTheme.ShowErrorToast("Invalid Driver ID provided.");
                this.Close();
                return;
            }

            // Disable interaction until the data is fully loaded and verified
            btnEditPerson.Enabled = false;

            await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);

            if (ctrlDriverCard1.SelectedDriverInfo == null)
            {
                NotificationTheme.ShowWarningToast("Driver not found. The record may have been deleted.");
                this.Close();
                return;
            }

            btnEditPerson.Enabled = true;
        }
        #endregion
    }
}