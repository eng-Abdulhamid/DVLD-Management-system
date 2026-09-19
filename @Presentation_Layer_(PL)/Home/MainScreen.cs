using CustomizeControls;
using DVLD.PL.DriversManagement;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.PeopleManagement;
using DVLD.PL.Theme;
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
            ApplyTheme();
        }

        #region Header & Session Integration

        private void SetupHeaderIntegration()
        {
            headerControl.ShowUserProfile = true;
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
            card.Cursor = Cursors.Hand;

            void OnHoverEnter(object? s, EventArgs e)
            {
                Color hoverBg = ThemeManager.Current.DisabledBackground;
                card.BackColor = hoverBg;

                foreach (Control ctrl in card.Controls)
                {
                    if (ctrl is not Panel)
                    {
                        ctrl.BackColor = hoverBg;
                    }
                }
            }

            void OnHoverLeave(object? s, EventArgs e)
            {
                Point mouseInCard = card.PointToClient(Cursor.Position);
                if (!card.ClientRectangle.Contains(mouseInCard))
                {
                    Color defaultBg = ThemeManager.Current.Surface;
                    card.BackColor = defaultBg;

                    foreach (Control ctrl in card.Controls)
                    {
                        if (ctrl is not Panel)
                        {
                            ctrl.BackColor = defaultBg;
                        }
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

        private frmPeopleManagement? _frmPeopleManagementInstance;
        private frmUserManagement? _frmUserManagementInstance;
        private frmDriverManagement? _frmDriverManagementInstance;

        private void OpenFormSingleton<T>(ref T? formInstance, Func<T> formFactory) where T : Form
        {
            if (formInstance == null || formInstance.IsDisposed)
            {
                formInstance = formFactory();
                formInstance.Show();
            }
            else
            {
                if (formInstance.WindowState == FormWindowState.Minimized)
                {
                    formInstance.WindowState = FormWindowState.Normal;
                }

                formInstance.BringToFront();
                formInstance.Activate();
            }
        }

        public void OpenPeopleManagement() => OpenFormSingleton(ref _frmPeopleManagementInstance, () => new frmPeopleManagement());

        public void OpenUsersManagement() => OpenFormSingleton(ref _frmUserManagementInstance, () => new frmUserManagement());

        public void OpenDriversManagement() => OpenFormSingleton(ref _frmDriverManagementInstance, () => new frmDriverManagement());

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

        #endregion

        #region Menu Click Handlers

        private void btnPeopleManagement_Click(object sender, EventArgs e) => OpenPeopleManagement();
        private void btnUsersManagement_Click(object sender, EventArgs e) => OpenUsersManagement();
        private void btnDriversManagement_Click(object sender, EventArgs e) => OpenDriversManagement();
        private void btnCurrentUserInfo_Click(object sender, EventArgs e) => OpenCurrentUserInfo();
        private void btnChangePassword_Click(object sender, EventArgs e) => OpenChangePassword();

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}