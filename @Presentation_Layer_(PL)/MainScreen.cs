using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
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

            btnPeopleManagement.ApplyNavStyle();
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

            _navToolTips.SetToolTip(btnPeopleManagement, "Manage all citizen records, identity data, and personal profiles");
        }

        private void btnPeopleManagement_Click(object sender, EventArgs e)
        {
            using (frmPeopleManagement frm = new frmPeopleManagement())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
        }
    }
}