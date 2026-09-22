using CustomizeControls;
using DVLD.PL.DriversManagement;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.PeopleManagement;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using DVLD.PL.UsersManagement;

namespace DVLD.PL
{
    public partial class frmMainForm : BaseForm
    {
        private ToolTip? _navToolTips;

        public frmMainForm()
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
            SetCardsColours(Color.Silver, Color.Black);
            flowCards.Padding = new Padding(30, 20, 30, 20);
            this.Icon = Resources.home;
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }
        private void SetCardsColours(Color IconColor, Color HoverColor)
        {
            cardPeople.IconColor = IconColor;
            cardDrivers.IconColor = IconColor;
            cardUsers.IconColor = IconColor;

            cardPeople.IconHoverColor = HoverColor;
            cardDrivers.IconHoverColor = HoverColor;
            cardUsers.IconHoverColor = HoverColor;
        }
        private void ThemeManager_ThemeChanged(object? sender, ThemeManager.ModeEventsArgs e)
        {
            ThemePalette theme = ThemeManager.Current;

            SetCardsColours(theme.TextSecondary, theme.PrimaryHover);
            flowCards.Padding = new Padding(30, 20, 30, 20);

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
                lblGreetingTitle.Text =
                    $"Welcome back, {AppSession.CurrentUserName}";
            }
            else
            {
                lblGreetingTitle.Text =
                    "Welcome to DVLD Portal";
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
                item.MouseEnter += (s, e) =>
                    Cursor = Cursors.Hand;

                item.MouseLeave += (s, e) =>
                    Cursor = Cursors.Default;

                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.DropDown
                        is ToolStripDropDownMenu dropDown)
                    {
                        dropDown.ShowImageMargin = false;
                        dropDown.Padding = new Padding(4);
                    }

                    foreach (ToolStripItem subItem
                             in menuItem.DropDownItems)
                    {
                        subItem.MouseEnter += (s, e) =>
                            Cursor = Cursors.Hand;

                        subItem.MouseLeave += (s, e) =>
                            Cursor = Cursors.Default;
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
            cardPeople.Click +=
                (s, e) => OpenPeopleManagement();

            cardDrivers.Click +=
                (s, e) => OpenDriversManagement();

            cardUsers.Click +=
                (s, e) => OpenUsersManagement();
        }

        #endregion

        #region Centralized Navigation Actions (Single Source of Truth)

        private frmPeopleManagement? _frmPeopleManagementInstance;
        private frmUserManagement? _frmUserManagementInstance;
        private frmDriverManagement? _frmDriverManagementInstance;

        private void OpenFormSingleton<T>(
            ref T? formInstance,
            Func<T> formFactory)
            where T : Form
        {
            if (formInstance == null || formInstance.IsDisposed)
            {
                formInstance = formFactory();
                formInstance.Show();
            }
            else
            {
                if (formInstance.WindowState ==
                    FormWindowState.Minimized)
                {
                    formInstance.WindowState =
                        FormWindowState.Normal;
                }

                formInstance.BringToFront();
                formInstance.Activate();
            }
        }

        public void OpenPeopleManagement() =>
            OpenFormSingleton(
                ref _frmPeopleManagementInstance,
                () => new frmPeopleManagement());

        public void OpenUsersManagement() =>
            OpenFormSingleton(
                ref _frmUserManagementInstance,
                () => new frmUserManagement());

        public void OpenDriversManagement() =>
            OpenFormSingleton(
                ref _frmDriverManagementInstance,
                () => new frmDriverManagement());
        #endregion
        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}