using System;
using System.Drawing;
using System.Windows.Forms;
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
            SetupHeaderIntegration();
            SetupDashboardCards();
            UpdateDashboardInfo();

            AppSession.OnUserSessionChanged += UpdateDashboardInfo;
        }

        #region Header & Session Integration

        private void SetupHeaderIntegration()
        {
            headerControl.ShowUserProfile = true;

            headerControl.OnCurrentUserInfoClicked += (s, e) => OpenCurrentUserInfo();
            headerControl.OnChangePasswordClicked += (s, e) => OpenChangePassword();
            headerControl.OnSignOutClicked += (s, e) => PerformSignOut();
        }

        private void UpdateDashboardInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateDashboardInfo));
                return;
            }

            if (AppSession.IsAuthenticated)
            {
                lblGreetingTitle.Text = $"Welcome back, {AppSession.CurrentUserName}";
            }
            else
            {
                lblGreetingTitle.Text = "Welcome to DVLD Portal";
            }
        }

        #endregion

        #region UI Styling & Custom Renderer

        private void ApplyCustomMenuRenderer()
        {
            var colorTable = new NMenuColorTable
            {
                CustomBorder = Color.Transparent, 
                CustomBackground = Color.White,
                CustomItemSelected = Color.FromArgb(241, 245, 249), 
                CustomSeparator = Color.FromArgb(226, 232, 240)
            };

            var renderer = new NMenuRenderer(colorTable)
            {
                ItemTextColor = Color.FromArgb(30, 41, 59),
                ItemHoverTextColor = Color.FromArgb(15, 23, 42),
                AccentColor = Color.FromArgb(124, 58, 237),
                DangerTextColor = Color.FromArgb(220, 38, 38),
                DangerHoverBackground = Color.FromArgb(254, 242, 242)
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
        }

        #endregion

        #region Quick Dashboard Cards Setup

        private void SetupDashboardCards()
        {
            ConfigureCardHover(cardPeople, OpenPeopleManagement);
            ConfigureCardHover(cardDrivers, OpenDriversManagement);
            ConfigureCardHover(cardUsers, OpenUsersManagement);
        }
        private static void ConfigureCardHover(Panel card, Action onClick)
        {
            Color defaultBg = Color.FromArgb(248, 250, 252);
            Color hoverBg = Color.FromArgb(241, 245, 249);

            card.Cursor = Cursors.Hand;

            void OnHoverEnter(object? s, EventArgs e)
            {
                card.BackColor = hoverBg;
                foreach (Control ctrl in card.Controls)
                {
                    if (ctrl is not Panel) ctrl.BackColor = hoverBg;
                }
            }

            void OnHoverLeave(object? s, EventArgs e)
            {
                Point mouseInCard = card.PointToClient(Cursor.Position);
                if (!card.ClientRectangle.Contains(mouseInCard))
                {
                    card.BackColor = defaultBg;
                    foreach (Control ctrl in card.Controls)
                    {
                        if (ctrl is not Panel) ctrl.BackColor = defaultBg;
                    }
                }
            }

            card.MouseEnter += OnHoverEnter;
            card.MouseLeave += OnHoverLeave;
            card.Click += (s, e) => onClick();

            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.MouseEnter += OnHoverEnter;
                child.MouseLeave += OnHoverLeave;
                child.Click += (s, e) => onClick();
            }
        }

        #endregion

        #region Centralized Navigation Actions (Single Source of Truth)

        public void OpenPeopleManagement()
        {
            using (frmPeopleManagement frm = new frmPeopleManagement())
            {
                frm.ShowDialog(this);
            }
        }

        public void OpenUsersManagement()
        {
            using (frmUserManagement userManagement = new frmUserManagement())
            {
                userManagement.ShowDialog(this);
            }
        }

        public void OpenDriversManagement()
        {
            using (frmDriverManagement driverManagement = new frmDriverManagement())
            {
                driverManagement.ShowDialog(this);
            }
        }

        public void OpenCurrentUserInfo()
        {
            if (!AppSession.IsAuthenticated) return;

            using (frmUserCard frm = new frmUserCard(AppSession.CurrentUserID))
            {
                frm.ShowDialog(this);
            }
        }

        public void OpenChangePassword()
        {
            if (!AppSession.IsAuthenticated) return;

            using (frmForgetPassword frm = new frmForgetPassword(AppSession.CurrentUserName))
            {
                frm.ShowDialog(this);
            }
        }

        public void PerformSignOut()
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

        #region Menu Click Handlers

        private void btnPeopleManagement_Click(object sender, EventArgs e) => OpenPeopleManagement();
        private void btnUsersManagement_Click(object sender, EventArgs e) => OpenUsersManagement();
        private void btnDriversManagement_Click(object sender, EventArgs e) => OpenDriversManagement();
        private void btnCurrentUserInfo_Click(object sender, EventArgs e) => OpenCurrentUserInfo();
        private void btnChangePassword_Click(object sender, EventArgs e) => OpenChangePassword();
        private void btnSignOut_Click(object sender, EventArgs e) => PerformSignOut();

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppSession.OnUserSessionChanged -= UpdateDashboardInfo;
            base.OnFormClosed(e);
        }
    }
}