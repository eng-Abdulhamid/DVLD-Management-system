using DVLD.PL.DriversManagement;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using DVLD.PL.UsersManagement;
using System;
using System.Windows.Forms;

namespace DVLD.PL
{
    public partial class frmMainScreen : frmBase
    {
        private ToolTip? _navToolTips;

        public frmMainScreen()
        {
            InitializeComponent();
            this.Text = "DVLD/Home";

            SetupToolTips();
        }

        private void SetupToolTips()
        {
            _navToolTips = new ToolTip
            {
                InitialDelay = 300,
                ReshowDelay = 100,
                AutoPopDelay = 5000,
                UseAnimation = true,
                UseFading = true
            };
        }
        private void btnPeopleManagement_Click(object sender, EventArgs e)
        {
            using (frmPeopleManagement frm = new frmPeopleManagement())
            {
                frm.ShowDialog(this);
            }

        }
        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
            using (frmUserManagement userManagement = new())
            {
                userManagement.ShowDialog();
            }

        }
        private void btnDriversManagement_Click(object sender, EventArgs e)
        {
            using (frmDriverManagement driverManagement = new())
            {
                driverManagement.ShowDialog();
            }

        }
    }
}