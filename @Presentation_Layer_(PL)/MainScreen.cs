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
                AppSession.TitlePath += " / People Management";
                frm.ShowDialog(this);
            }

        }
        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
            using (frmUserManagement userManagement = new())
            {
                AppSession.TitlePath += " / Users Management";
                userManagement.ShowDialog();
            }

        }
        private void btnDriversManagement_Click(object sender, EventArgs e)
        {
            using (frmDriverManagement driverManagement = new())
            {
                AppSession.TitlePath += " / Drivers Management";
                driverManagement.ShowDialog();
            }

        }
    }
}