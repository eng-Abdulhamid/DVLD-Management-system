using DVLD.BLL.DTOs;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    public partial class frmDriverCard : frmBase
    {
        private readonly int _driverId;

        public frmDriverCard(int driverId)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();
            SetContextTitle("Driver Details");

            _driverId = driverId;

            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;

            ApplyStyles();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnEditPerson.ApplyPrimaryStyle();
            btnClose.ApplySecondaryStyle();
        }

        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => this.Close();

            btnEditPerson.Click += (s, e) => OpenEditPersonForm();
        }

        private async void frmDriverCard_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_driverId <= 0)
            {
                UITheme.ShowErrorToast("Invalid Driver ID provided.");
                this.Close();
                return;
            }

            // Disable interaction until the data is fully loaded and verified
            btnEditPerson.Enabled = false;

            await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);

            if (ctrlDriverCard1.SelectedDriverInfo == null)
            {
                UITheme.ShowWarningToast("Driver not found. The record may have been deleted.");
                this.Close();
                return;
            }

            btnEditPerson.Enabled = true;
        }

        private void OpenEditPersonForm()
        {
            var driverInfo = ctrlDriverCard1.SelectedDriverInfo;

            if (driverInfo == null || driverInfo.PersonID <= 0)
            {
                UITheme.ShowErrorToast("Valid person context is missing.");
                return;
            }

            using frmSavePerson frm = new frmSavePerson(driverInfo.PersonID);
            frm.PersonSaved += async (personId) =>
            {
                // Reload the card to reflect any updated personal details (e.g., Name, Image)
                await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);
                UITheme.ShowSuccessToast("Driver's personal information updated successfully.");
            };

            frm.ShowDialog(this);
        }
    }
}