using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.UsersManagement
{
    partial class frmSaveUser
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TabControl tcWizard;
        private TabPage tpPersonSelection;
        private GroupBox gbSearchFilter;
        private NTextBox txtSearchNationalNo;
        private NButton btnSearchPerson;
        private NButton btnAddNewPerson;
        private DVLD.PL.PeopleManagement.ctrlPersonCard ctrlPersonCard1;
        private LinkLabel lnkEditPerson;
        private NButton btnNext;
        private TabPage tpLoginInfo;
        private Label lblUserName;
        private NTextBox txtUserName;
        private Label lblPassword;
        private NTextBox txtPassword;
        private Label lblConfirmPassword;
        private NTextBox txtConfirmPassword;
        private LinkLabel lnkEditPassword;
        private NControls.NCheckBox chkIsActive;
        private NButton btnSave;
        private NButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            tcWizard = new TabControl();
            tpPersonSelection = new TabPage();
            gbSearchFilter = new GroupBox();
            btnSelectPerson = new NButton();
            txtSearchNationalNo = new NTextBox();
            btnSearchPerson = new NButton();
            btnAddNewPerson = new NButton();
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            lnkEditPerson = new LinkLabel();
            btnNext = new NButton();
            tpLoginInfo = new TabPage();
            lblUserName = new Label();
            txtUserName = new NTextBox();
            lblPassword = new Label();
            txtPassword = new NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new NTextBox();
            lnkEditPassword = new LinkLabel();
            chkIsActive = new NCheckBox();
            btnSave = new NButton();
            btnCancel = new NButton();
            toolTip1 = new ToolTip(components);
            tcWizard.SuspendLayout();
            tpPersonSelection.SuspendLayout();
            gbSearchFilter.SuspendLayout();
            tpLoginInfo.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(856, 38);
            headerControl.TitleText = "DVLD / Users Management / Save User";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New User";
            // 
            // tcWizard
            // 
            tcWizard.Controls.Add(tpPersonSelection);
            tcWizard.Controls.Add(tpLoginInfo);
            tcWizard.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tcWizard.Location = new Point(20, 85);
            tcWizard.Name = "tcWizard";
            tcWizard.SelectedIndex = 0;
            tcWizard.Size = new Size(820, 435);
            tcWizard.TabIndex = 1;
            // 
            // tpPersonSelection
            // 
            tpPersonSelection.BackColor = Color.White;
            tpPersonSelection.Controls.Add(gbSearchFilter);
            tpPersonSelection.Controls.Add(ctrlPersonCard1);
            tpPersonSelection.Controls.Add(lnkEditPerson);
            tpPersonSelection.Controls.Add(btnNext);
            tpPersonSelection.Location = new Point(4, 26);
            tpPersonSelection.Name = "tpPersonSelection";
            tpPersonSelection.Padding = new Padding(12);
            tpPersonSelection.Size = new Size(812, 405);
            tpPersonSelection.TabIndex = 0;
            tpPersonSelection.Text = "1. Person Selection";
            // 
            // gbSearchFilter
            // 
            gbSearchFilter.Controls.Add(btnSelectPerson);
            gbSearchFilter.Controls.Add(txtSearchNationalNo);
            gbSearchFilter.Controls.Add(btnSearchPerson);
            gbSearchFilter.Controls.Add(btnAddNewPerson);
            gbSearchFilter.ForeColor = Color.FromArgb(71, 85, 105);
            gbSearchFilter.Location = new Point(16, 8);
            gbSearchFilter.Name = "gbSearchFilter";
            gbSearchFilter.Size = new Size(780, 75);
            gbSearchFilter.TabIndex = 0;
            gbSearchFilter.TabStop = false;
            gbSearchFilter.Text = "Search Person";
            // 
            // btnSelectPerson
            // 
            btnSelectPerson.BackColor = Color.Transparent;
            btnSelectPerson.BackgroundEndColor = SystemColors.Control;
            btnSelectPerson.BackgroundStartColor = SystemColors.Control;
            btnSelectPerson.BorderColor = Color.DarkGray;
            btnSelectPerson.BorderRadius = 8;
            btnSelectPerson.BorderSize = 1;
            btnSelectPerson.CenterIconWithText = false;
            btnSelectPerson.Cursor = Cursors.Hand;
            btnSelectPerson.EnableHoverAnimation = false;
            btnSelectPerson.EnableIconTinting = false;
            btnSelectPerson.EnableRippleEffect = false;
            btnSelectPerson.EnableShadow = false;
            btnSelectPerson.Font = new Font("Segoe UI", 9F);
            btnSelectPerson.ForeColor = SystemColors.ControlText;
            btnSelectPerson.GradientAngle = 90F;
            btnSelectPerson.HoverAnimationSpeed = 20;
            btnSelectPerson.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSelectPerson.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSelectPerson.HoverIconColor = Color.White;
            btnSelectPerson.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSelectPerson.HoverTextColor = SystemColors.ControlText;
            btnSelectPerson.IconColor = Color.White;
            btnSelectPerson.IconMargin = 10;
            btnSelectPerson.IconOffset = new Point(0, 0);
            btnSelectPerson.IconSize = new Size(28, 28);
            btnSelectPerson.IconSpacing = 5;
            btnSelectPerson.IsLoading = false;
            btnSelectPerson.LeftIcon = null;
            btnSelectPerson.Location = new Point(722, 23);
            btnSelectPerson.MiddleIcon = Properties.Resources.SelectPerson;
            btnSelectPerson.Name = "btnSelectPerson";
            btnSelectPerson.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSelectPerson.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSelectPerson.RightIcon = null;
            btnSelectPerson.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSelectPerson.RippleSpeed = 15;
            btnSelectPerson.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSelectPerson.ShadowOffset = new Point(1, 1);
            btnSelectPerson.ShadowSize = 3;
            btnSelectPerson.ShiftOnPress = false;
            btnSelectPerson.Size = new Size(40, 38);
            btnSelectPerson.TabIndex = 3;
            btnSelectPerson.TextColor = SystemColors.ControlText;
            btnSelectPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnSelectPerson, "Select a Person");
            btnSelectPerson.Click += SelectPerson_Click;
            // 
            // txtSearchNationalNo
            // 
            txtSearchNationalNo.AllowArabicCharacters = true;
            txtSearchNationalNo.AllowEnglishCharacters = true;
            txtSearchNationalNo.AllowNumbers = true;
            txtSearchNationalNo.AllowSpaces = true;
            txtSearchNationalNo.AllowSymbols = true;
            txtSearchNationalNo.BackColor = Color.Transparent;
            txtSearchNationalNo.BorderColor = Color.FromArgb(220, 220, 220);
            txtSearchNationalNo.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtSearchNationalNo.BorderRadius = 24;
            txtSearchNationalNo.BorderSize = 1;
            txtSearchNationalNo.CustomAllowedCharacters = "";
            txtSearchNationalNo.EnableIconTinting = false;
            txtSearchNationalNo.EnableSuggest = false;
            txtSearchNationalNo.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtSearchNationalNo.FillColor = Color.White;
            txtSearchNationalNo.HasError = false;
            txtSearchNationalNo.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtSearchNationalNo.IconColor = Color.FromArgb(148, 163, 184);
            txtSearchNationalNo.IconOffsetLeft = 10;
            txtSearchNationalNo.IconOffsetRight = 10;
            txtSearchNationalNo.IconSize = new Size(20, 20);
            txtSearchNationalNo.IconSpacing = 8;
            txtSearchNationalNo.LeftIcon = null;
            txtSearchNationalNo.LeftIconClickable = false;
            txtSearchNationalNo.Location = new Point(16, 24);
            txtSearchNationalNo.MaxLength = 32767;
            txtSearchNationalNo.MaxSuggestItems = 8;
            txtSearchNationalNo.MoveToNextControlOnEnter = true;
            txtSearchNationalNo.Name = "txtSearchNationalNo";
            txtSearchNationalNo.Padding = new Padding(8, 12, 8, 12);
            txtSearchNationalNo.PlaceholderColor = Color.DarkGray;
            txtSearchNationalNo.PlaceholderText = "National Number...";
            txtSearchNationalNo.RightIcon = null;
            txtSearchNationalNo.RightIconClickable = false;
            txtSearchNationalNo.ShowClearButton = false;
            txtSearchNationalNo.Size = new Size(260, 38);
            txtSearchNationalNo.SuggestIcon = null;
            txtSearchNationalNo.TabIndex = 0;
            txtSearchNationalNo.UseSystemPasswordChar = false;
            txtSearchNationalNo.ValidateEmail = false;
            // 
            // btnSearchPerson
            // 
            btnSearchPerson.BackColor = Color.Transparent;
            btnSearchPerson.BackgroundEndColor = SystemColors.Control;
            btnSearchPerson.BackgroundStartColor = SystemColors.Control;
            btnSearchPerson.BorderColor = Color.DarkGray;
            btnSearchPerson.BorderRadius = 8;
            btnSearchPerson.BorderSize = 1;
            btnSearchPerson.CenterIconWithText = false;
            btnSearchPerson.Cursor = Cursors.Hand;
            btnSearchPerson.EnableHoverAnimation = false;
            btnSearchPerson.EnableIconTinting = false;
            btnSearchPerson.EnableRippleEffect = false;
            btnSearchPerson.EnableShadow = false;
            btnSearchPerson.Font = new Font("Segoe UI", 9F);
            btnSearchPerson.ForeColor = SystemColors.ControlText;
            btnSearchPerson.GradientAngle = 90F;
            btnSearchPerson.HoverAnimationSpeed = 20;
            btnSearchPerson.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSearchPerson.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSearchPerson.HoverIconColor = Color.White;
            btnSearchPerson.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSearchPerson.HoverTextColor = SystemColors.ControlText;
            btnSearchPerson.IconColor = Color.White;
            btnSearchPerson.IconMargin = 10;
            btnSearchPerson.IconOffset = new Point(0, 0);
            btnSearchPerson.IconSize = new Size(22, 22);
            btnSearchPerson.IconSpacing = 5;
            btnSearchPerson.IsLoading = false;
            btnSearchPerson.LeftIcon = null;
            btnSearchPerson.Location = new Point(282, 23);
            btnSearchPerson.MiddleIcon = Properties.Resources.search;
            btnSearchPerson.Name = "btnSearchPerson";
            btnSearchPerson.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSearchPerson.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSearchPerson.RightIcon = null;
            btnSearchPerson.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSearchPerson.RippleSpeed = 15;
            btnSearchPerson.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSearchPerson.ShadowOffset = new Point(1, 1);
            btnSearchPerson.ShadowSize = 3;
            btnSearchPerson.ShiftOnPress = false;
            btnSearchPerson.Size = new Size(40, 38);
            btnSearchPerson.TabIndex = 1;
            btnSearchPerson.TextColor = SystemColors.ControlText;
            btnSearchPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnSearchPerson, "Search");
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.BackColor = Color.Transparent;
            btnAddNewPerson.BackgroundEndColor = SystemColors.Control;
            btnAddNewPerson.BackgroundStartColor = SystemColors.Control;
            btnAddNewPerson.BorderColor = Color.DarkGray;
            btnAddNewPerson.BorderRadius = 8;
            btnAddNewPerson.BorderSize = 1;
            btnAddNewPerson.CenterIconWithText = false;
            btnAddNewPerson.Cursor = Cursors.Hand;
            btnAddNewPerson.EnableHoverAnimation = false;
            btnAddNewPerson.EnableIconTinting = false;
            btnAddNewPerson.EnableRippleEffect = false;
            btnAddNewPerson.EnableShadow = false;
            btnAddNewPerson.Font = new Font("Segoe UI", 9F);
            btnAddNewPerson.ForeColor = SystemColors.ControlText;
            btnAddNewPerson.GradientAngle = 90F;
            btnAddNewPerson.HoverAnimationSpeed = 20;
            btnAddNewPerson.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnAddNewPerson.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnAddNewPerson.HoverIconColor = Color.White;
            btnAddNewPerson.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnAddNewPerson.HoverTextColor = SystemColors.ControlText;
            btnAddNewPerson.IconColor = Color.White;
            btnAddNewPerson.IconMargin = 10;
            btnAddNewPerson.IconOffset = new Point(0, 0);
            btnAddNewPerson.IconSize = new Size(24, 24);
            btnAddNewPerson.IconSpacing = 5;
            btnAddNewPerson.IsLoading = false;
            btnAddNewPerson.LeftIcon = null;
            btnAddNewPerson.Location = new Point(676, 23);
            btnAddNewPerson.MiddleIcon = Properties.Resources.add_person;
            btnAddNewPerson.Name = "btnAddNewPerson";
            btnAddNewPerson.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnAddNewPerson.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnAddNewPerson.RightIcon = null;
            btnAddNewPerson.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnAddNewPerson.RippleSpeed = 15;
            btnAddNewPerson.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnAddNewPerson.ShadowOffset = new Point(1, 1);
            btnAddNewPerson.ShadowSize = 3;
            btnAddNewPerson.ShiftOnPress = false;
            btnAddNewPerson.Size = new Size(40, 38);
            btnAddNewPerson.TabIndex = 2;
            btnAddNewPerson.TextColor = SystemColors.ControlText;
            btnAddNewPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnAddNewPerson, "Add new person");
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(16, 90);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(793, 260);
            ctrlPersonCard1.TabIndex = 1;
            // 
            // lnkEditPerson
            // 
            lnkEditPerson.AutoSize = true;
            lnkEditPerson.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkEditPerson.LinkColor = Color.FromArgb(124, 58, 237);
            lnkEditPerson.Location = new Point(18, 365);
            lnkEditPerson.Name = "lnkEditPerson";
            lnkEditPerson.Size = new Size(105, 17);
            lnkEditPerson.TabIndex = 2;
            lnkEditPerson.TabStop = true;
            lnkEditPerson.Text = "Edit Person Info";
            toolTip1.SetToolTip(lnkEditPerson, "Edit this person info in new screen ");
            lnkEditPerson.Visible = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.BackgroundEndColor = SystemColors.Control;
            btnNext.BackgroundStartColor = SystemColors.Control;
            btnNext.BorderColor = Color.DarkGray;
            btnNext.BorderRadius = 8;
            btnNext.BorderSize = 1;
            btnNext.CenterIconWithText = false;
            btnNext.Cursor = Cursors.Hand;
            btnNext.EnableHoverAnimation = false;
            btnNext.EnableIconTinting = false;
            btnNext.EnableRippleEffect = false;
            btnNext.EnableShadow = false;
            btnNext.Font = new Font("Segoe UI", 9F);
            btnNext.ForeColor = SystemColors.ControlText;
            btnNext.GradientAngle = 90F;
            btnNext.HoverAnimationSpeed = 20;
            btnNext.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnNext.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnNext.HoverIconColor = Color.White;
            btnNext.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnNext.HoverTextColor = SystemColors.ControlText;
            btnNext.IconColor = Color.White;
            btnNext.IconMargin = 10;
            btnNext.IconOffset = new Point(0, 0);
            btnNext.IconSize = new Size(16, 16);
            btnNext.IconSpacing = 5;
            btnNext.IsLoading = false;
            btnNext.LeftIcon = null;
            btnNext.Location = new Point(686, 355);
            btnNext.MiddleIcon = null;
            btnNext.Name = "btnNext";
            btnNext.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnNext.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnNext.RightIcon = null;
            btnNext.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnNext.RippleSpeed = 15;
            btnNext.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnNext.ShadowOffset = new Point(1, 1);
            btnNext.ShadowSize = 3;
            btnNext.ShiftOnPress = false;
            btnNext.Size = new Size(110, 38);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next >";
            btnNext.TextColor = SystemColors.ControlText;
            btnNext.TextOffset = new Point(0, 0);
            // 
            // tpLoginInfo
            // 
            tpLoginInfo.BackColor = Color.White;
            tpLoginInfo.Controls.Add(lblUserName);
            tpLoginInfo.Controls.Add(txtUserName);
            tpLoginInfo.Controls.Add(lblPassword);
            tpLoginInfo.Controls.Add(txtPassword);
            tpLoginInfo.Controls.Add(lblConfirmPassword);
            tpLoginInfo.Controls.Add(txtConfirmPassword);
            tpLoginInfo.Controls.Add(lnkEditPassword);
            tpLoginInfo.Controls.Add(chkIsActive);
            tpLoginInfo.Location = new Point(4, 26);
            tpLoginInfo.Name = "tpLoginInfo";
            tpLoginInfo.Padding = new Padding(24);
            tpLoginInfo.Size = new Size(812, 405);
            tpLoginInfo.TabIndex = 1;
            tpLoginInfo.Text = "2. Login Credentials";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.ForeColor = Color.FromArgb(71, 85, 105);
            lblUserName.Location = new Point(36, 32);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 17);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.AllowArabicCharacters = false;
            txtUserName.AllowEnglishCharacters = true;
            txtUserName.AllowNumbers = true;
            txtUserName.AllowSpaces = false;
            txtUserName.AllowSymbols = false;
            txtUserName.BackColor = Color.Transparent;
            txtUserName.BorderColor = Color.FromArgb(220, 220, 220);
            txtUserName.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtUserName.BorderRadius = 24;
            txtUserName.BorderSize = 1;
            txtUserName.CustomAllowedCharacters = "";
            txtUserName.EnableIconTinting = false;
            txtUserName.EnableSuggest = false;
            txtUserName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtUserName.FillColor = Color.White;
            txtUserName.HasError = false;
            txtUserName.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtUserName.IconColor = Color.FromArgb(148, 163, 184);
            txtUserName.IconOffsetLeft = 10;
            txtUserName.IconOffsetRight = 10;
            txtUserName.IconSize = new Size(20, 20);
            txtUserName.IconSpacing = 8;
            txtUserName.LeftIcon = null;
            txtUserName.LeftIconClickable = false;
            txtUserName.Location = new Point(36, 55);
            txtUserName.MaxLength = 20;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PlaceholderColor = Color.DarkGray;
            txtUserName.PlaceholderText = "Enter unique username...";
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ShowClearButton = false;
            txtUserName.Size = new Size(320, 38);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 0;
            toolTip1.SetToolTip(txtUserName, "You can only use English letters and numbers");
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(36, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.AllowArabicCharacters = false;
            txtPassword.AllowEnglishCharacters = true;
            txtPassword.AllowNumbers = true;
            txtPassword.AllowSpaces = false;
            txtPassword.AllowSymbols = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.FromArgb(220, 220, 220);
            txtPassword.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtPassword.BorderRadius = 24;
            txtPassword.BorderSize = 1;
            txtPassword.CustomAllowedCharacters = "";
            txtPassword.EnableIconTinting = false;
            txtPassword.EnableSuggest = false;
            txtPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPassword.FillColor = Color.White;
            txtPassword.HasError = false;
            txtPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtPassword.IconOffsetLeft = 10;
            txtPassword.IconOffsetRight = 10;
            txtPassword.IconSize = new Size(20, 20);
            txtPassword.IconSpacing = 8;
            txtPassword.LeftIcon = null;
            txtPassword.LeftIconClickable = false;
            txtPassword.Location = new Point(36, 133);
            txtPassword.MaxLength = 20;
            txtPassword.MaxSuggestItems = 8;
            txtPassword.MoveToNextControlOnEnter = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(8, 12, 8, 12);
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "Enter password...";
            txtPassword.RightIcon = null;
            txtPassword.RightIconClickable = false;
            txtPassword.ShowClearButton = false;
            txtPassword.Size = new Size(320, 38);
            txtPassword.SuggestIcon = null;
            txtPassword.TabIndex = 2;
            toolTip1.SetToolTip(txtPassword, "You can only use English Letters, Number and Symbols");
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.ValidateEmail = false;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblConfirmPassword.Location = new Point(36, 188);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(118, 17);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AllowArabicCharacters = false;
            txtConfirmPassword.AllowEnglishCharacters = true;
            txtConfirmPassword.AllowNumbers = true;
            txtConfirmPassword.AllowSpaces = false;
            txtConfirmPassword.AllowSymbols = true;
            txtConfirmPassword.BackColor = Color.Transparent;
            txtConfirmPassword.BorderColor = Color.FromArgb(220, 220, 220);
            txtConfirmPassword.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtConfirmPassword.BorderRadius = 24;
            txtConfirmPassword.BorderSize = 1;
            txtConfirmPassword.CustomAllowedCharacters = "";
            txtConfirmPassword.EnableIconTinting = false;
            txtConfirmPassword.EnableSuggest = false;
            txtConfirmPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtConfirmPassword.FillColor = Color.White;
            txtConfirmPassword.HasError = false;
            txtConfirmPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.IconOffsetLeft = 10;
            txtConfirmPassword.IconOffsetRight = 10;
            txtConfirmPassword.IconSize = new Size(20, 20);
            txtConfirmPassword.IconSpacing = 8;
            txtConfirmPassword.LeftIcon = null;
            txtConfirmPassword.LeftIconClickable = false;
            txtConfirmPassword.Location = new Point(36, 211);
            txtConfirmPassword.MaxLength = 20;
            txtConfirmPassword.MaxSuggestItems = 8;
            txtConfirmPassword.MoveToNextControlOnEnter = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(8, 12, 8, 12);
            txtConfirmPassword.PlaceholderColor = Color.DarkGray;
            txtConfirmPassword.PlaceholderText = "Repeat password...";
            txtConfirmPassword.RightIcon = null;
            txtConfirmPassword.RightIconClickable = false;
            txtConfirmPassword.ShowClearButton = false;
            txtConfirmPassword.Size = new Size(320, 38);
            txtConfirmPassword.SuggestIcon = null;
            txtConfirmPassword.TabIndex = 4;
            toolTip1.SetToolTip(txtConfirmPassword, "You can only use English Letters, Number and Symbols");
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.ValidateEmail = false;
            // 
            // lnkEditPassword
            // 
            lnkEditPassword.AutoSize = true;
            lnkEditPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lnkEditPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkEditPassword.LinkColor = Color.FromArgb(124, 58, 237);
            lnkEditPassword.Location = new Point(36, 115);
            lnkEditPassword.Name = "lnkEditPassword";
            lnkEditPassword.Size = new Size(157, 19);
            lnkEditPassword.TabIndex = 6;
            lnkEditPassword.TabStop = true;
            lnkEditPassword.Text = "Change / Edit Password";
            lnkEditPassword.Visible = false;
            // 
            // chkIsActive
            // 
            chkIsActive.AnimationSpeed = 25;
            chkIsActive.AutoCheck = true;
            chkIsActive.BackColor = Color.Transparent;
            chkIsActive.BorderRadius = 4;
            chkIsActive.BorderSize = 1;
            chkIsActive.BoxBackColor = Color.White;
            chkIsActive.BoxBorderColor = Color.FromArgb(200, 205, 212);
            chkIsActive.BoxSize = 18;
            chkIsActive.CheckAlign = NCheckAlign.Left;
            chkIsActive.Checked = true;
            chkIsActive.CheckedColor = Color.FromArgb(0, 120, 215);
            chkIsActive.CheckMarkColor = Color.White;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.CheckThickness = 2F;
            chkIsActive.DisabledColor = Color.FromArgb(220, 224, 230);
            chkIsActive.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkIsActive.EnableAnimation = true;
            chkIsActive.EnableRipple = false;
            chkIsActive.Font = new Font("Segoe UI", 9.5F);
            chkIsActive.ForeColor = Color.FromArgb(30, 41, 59);
            chkIsActive.HoverBorderColor = Color.FromArgb(0, 120, 215);
            chkIsActive.Location = new Point(36, 275);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.RippleColor = Color.FromArgb(40, 0, 120, 215);
            chkIsActive.Size = new Size(160, 24);
            chkIsActive.Style = NCheckBoxStyle.Rounded;
            chkIsActive.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkIsActive.SwitchThumbColor = Color.White;
            chkIsActive.SwitchWidth = 38;
            chkIsActive.TabIndex = 5;
            chkIsActive.Text = "Is Active User";
            chkIsActive.TextSpacing = 8;
            chkIsActive.ThreeState = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundEndColor = SystemColors.Control;
            btnSave.BackgroundStartColor = SystemColors.Control;
            btnSave.BorderColor = Color.DarkGray;
            btnSave.BorderRadius = 8;
            btnSave.BorderSize = 1;
            btnSave.CenterIconWithText = false;
            btnSave.Cursor = Cursors.Hand;
            btnSave.EnableHoverAnimation = false;
            btnSave.EnableIconTinting = false;
            btnSave.EnableRippleEffect = false;
            btnSave.EnableShadow = false;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = SystemColors.ControlText;
            btnSave.GradientAngle = 90F;
            btnSave.HoverAnimationSpeed = 20;
            btnSave.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSave.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverIconColor = Color.White;
            btnSave.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverTextColor = SystemColors.ControlText;
            btnSave.IconColor = Color.White;
            btnSave.IconMargin = 10;
            btnSave.IconOffset = new Point(0, 0);
            btnSave.IconSize = new Size(16, 16);
            btnSave.IconSpacing = 5;
            btnSave.IsLoading = false;
            btnSave.LeftIcon = null;
            btnSave.Location = new Point(716, 530);
            btnSave.MiddleIcon = null;
            btnSave.Name = "btnSave";
            btnSave.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSave.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSave.RightIcon = null;
            btnSave.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSave.RippleSpeed = 15;
            btnSave.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSave.ShadowOffset = new Point(1, 1);
            btnSave.ShadowSize = 3;
            btnSave.ShiftOnPress = false;
            btnSave.Size = new Size(124, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save User";
            btnSave.TextColor = SystemColors.ControlText;
            btnSave.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.EnableHoverAnimation = false;
            btnCancel.EnableIconTinting = false;
            btnCancel.EnableRippleEffect = false;
            btnCancel.EnableShadow = false;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = SystemColors.ControlText;
            btnCancel.GradientAngle = 90F;
            btnCancel.HoverAnimationSpeed = 20;
            btnCancel.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnCancel.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverIconColor = Color.White;
            btnCancel.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverTextColor = SystemColors.ControlText;
            btnCancel.IconColor = Color.White;
            btnCancel.IconMargin = 10;
            btnCancel.IconOffset = new Point(0, 0);
            btnCancel.IconSize = new Size(16, 16);
            btnCancel.IconSpacing = 5;
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(584, 530);
            btnCancel.MiddleIcon = null;
            btnCancel.Name = "btnCancel";
            btnCancel.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnCancel.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnCancel.RightIcon = null;
            btnCancel.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnCancel.RippleSpeed = 15;
            btnCancel.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnCancel.ShadowOffset = new Point(1, 1);
            btnCancel.ShadowSize = 3;
            btnCancel.ShiftOnPress = false;
            btnCancel.Size = new Size(124, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            // 
            // frmSaveUser
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(860, 585);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(tcWizard);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSaveUser";
            Text = "DVLD / Users Management / Save User";
            Load += frmSaveUser_Load;
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(tcWizard, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            tcWizard.ResumeLayout(false);
            tpPersonSelection.ResumeLayout(false);
            tpPersonSelection.PerformLayout();
            gbSearchFilter.ResumeLayout(false);
            tpLoginInfo.ResumeLayout(false);
            tpLoginInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private NButton btnSelectPerson;
        private ToolTip toolTip1;
    }
}