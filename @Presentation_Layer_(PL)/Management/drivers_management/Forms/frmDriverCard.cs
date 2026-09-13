using DVLD.PL.Global;
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
        }

        private async void frmDriverCard_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_driverId <= 0)
            {
                UITheme.ShowErrorToast("Invalid Driver ID.");
                this.Close();
                return;
            }

            await ctrlDriverCard1.LoadDriverInfoAsync(_driverId);
        }
    }
}