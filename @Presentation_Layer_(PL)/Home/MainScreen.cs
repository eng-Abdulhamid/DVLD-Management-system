using CustomizeControls;
using DVLD.PL.DriversManagement;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.PeopleManagement;
using DVLD.PL.UsersManagement;

namespace DVLD.PL
{
    public partial class frmMainScreen : frmBase
    {
        private ToolTip? _navToolTips;

        public frmMainScreen()
        {
            InitializeComponent();
            SetContextTitle("Home");

            ApplyCustomMenuRenderer();
            SetupToolTips();
            ConfigureMenuItemsInteraction();
            UpdateCurrentUserInfo();

            AppSession.OnUserSessionChanged += UpdateCurrentUserInfo;
        }

        private void UpdateCurrentUserInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateCurrentUserInfo));
                return;
            }

            if (AppSession.IsAuthenticated)
            {
                btnCurrentUser.Text = $"👤 {AppSession.CurrentUserName}";
                btnCurrentUser.ToolTipText = $"Logged in as: {AppSession.CurrentUserName}";
                btnCurrentUser.Visible = true;
                accountSettingsToolStripMenuItem.Visible = true;
            }
            else
            {
                btnCurrentUser.Text = "👤 Not Logged In";
                btnCurrentUser.Visible = false;
                accountSettingsToolStripMenuItem.Visible = false;
            }
        }

        private void ApplyCustomMenuRenderer()
        {
            var colorTable = new NMenuColorTable
            {
                CustomMenuBorder = Color.Transparent,      
                CustomBackground = Color.White,
                CustomItemSelected = Color.FromArgb(243, 232, 255), 
                CustomSeparator = Color.FromArgb(241, 245, 249)
            };

            var renderer = new NMenuRenderer(colorTable)
            {
                ItemTextColor = Color.FromArgb(30, 41, 59),
                ItemHoverTextColor = Color.FromArgb(124, 58, 237),
                DangerTextColor = Color.FromArgb(239, 68, 68),
                DangerHoverBackground = Color.FromArgb(254, 242, 242),
                ItemBorderRadius = 8
            };

            menuStrip1.Renderer = renderer;
        }

        private void ConfigureMenuItemsInteraction()
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.MouseEnter += (s, e) => Cursor = Cursors.Hand;
                item.MouseLeave += (s, e) => Cursor = Cursors.Default;

                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.DropDown is ToolStripDropDownMenu dropDown)
                    {
                        dropDown.ShowImageMargin = false;
                        dropDown.Padding = new Padding(4);
                    }

                    foreach (ToolStripItem subItem in menuItem.DropDownItems)
                    {
                        subItem.MouseEnter += (s, e) => Cursor = Cursors.Hand;
                        subItem.MouseLeave += (s, e) => Cursor = Cursors.Default;
                    }
                }
            }
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

            btnPeopleManagement.ToolTipText = "Manage registered persons";
            btnUsersManagement.ToolTipText = "Manage system users and credentials";
            btnDriversManagement.ToolTipText = "View and manage drivers records";
            btnCurrentUserInfo.ToolTipText = "View your profile details";
            btnChangePassword.ToolTipText = "Change your account password";
            btnSignOut.ToolTipText = "Sign out from the application";
        }

        #region Management Actions

        private void btnPeopleManagement_Click(object sender, EventArgs e)
        {
            using (frmPeopleManagement frm = new frmPeopleManagement())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
            using (frmUserManagement userManagement = new frmUserManagement())
            {
                userManagement.ShowDialog(this);
            }
        }

        private void btnDriversManagement_Click(object sender, EventArgs e)
        {
            using (frmDriverManagement driverManagement = new frmDriverManagement())
            {
                driverManagement.ShowDialog(this);
            }
        }

        #endregion

        #region Account Actions

        private void btnCurrentUserInfo_Click(object sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated) return;

            using (frmUserCard frm = new frmUserCard(AppSession.CurrentUserID))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated) return;

            using (frmForgetPassword frm = new frmForgetPassword(AppSession.CurrentUserName))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Confirm Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSession.LogOut();
                this.Close();
            }
        }

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppSession.OnUserSessionChanged -= UpdateCurrentUserInfo;
            base.OnFormClosed(e);
        }
    }
}