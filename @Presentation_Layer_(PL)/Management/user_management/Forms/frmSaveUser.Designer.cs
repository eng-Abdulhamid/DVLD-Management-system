using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;
namespace DVLD.PL.UsersManagement
{
    partial class frmSaveUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSave = new NButton();
            btnCancel = new NButton();
            toolTip1 = new ToolTip(components);
            tcWizard = new NTabControl();
            tpPersonSelection = new TabPage();
            gbSearchFilter = new GroupBox();
            txtSearchNationalNo = new NTextBox();
            btnSearchPerson = new NButton();
            btnSelectPerson = new NButton();
            btnAddNewPerson = new NButton();
            lnkEditPerson = new LinkLabel();
            btnNext = new NButton();
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            tpLoginInfo = new TabPage();
            lblUserName = new Label();
            txtUserName = new NTextBox();
            lblPassword = new Label();
            txtPassword = new NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new NTextBox();
            lnkEditPassword = new LinkLabel();
            chkIsActive = new NCheckBox();
            btnPrev = new NButton();
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
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundEndColor = SystemColors.Control;
            btnSave.BackgroundStartColor = SystemColors.Control;
            btnSave.BorderColor = Color.DarkGray;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 1;
            btnSave.CenterIconWithText = false;
            btnSave.Cursor = Cursors.Hand;
            btnSave.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnSave.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnSave.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnSave.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnSave.Location = new Point(724, 455);
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
            toolTip1.SetToolTip(btnSave, "Save User Info and Close");
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnCancel.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnCancel.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnCancel.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnCancel.Location = new Point(592, 455);
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
            toolTip1.SetToolTip(btnCancel, "Cancel and close");
            // 
            // tcWizard
            // 
            tcWizard.Controls.Add(tpPersonSelection);
            tcWizard.Controls.Add(tpLoginInfo);
            tcWizard.Location = new Point(12, 40);
            tcWizard.Name = "tcWizard";
            tcWizard.SelectedIndex = 0;
            tcWizard.Size = new Size(836, 409);
            tcWizard.TabIndex = 0;
            toolTip1.SetToolTip(tcWizard, "Enter a valid UserName which include English letter and numbers only");
            // 
            // tpPersonSelection
            // 
            tpPersonSelection.BackColor = Color.FromArgb(248, 250, 252);
            tpPersonSelection.Controls.Add(gbSearchFilter);
            tpPersonSelection.Controls.Add(lnkEditPerson);
            tpPersonSelection.Controls.Add(btnNext);
            tpPersonSelection.Controls.Add(ctrlPersonCard1);
            tpPersonSelection.Location = new Point(4, 24);
            tpPersonSelection.Name = "tpPersonSelection";
            tpPersonSelection.Padding = new Padding(3);
            tpPersonSelection.Size = new Size(828, 381);
            tpPersonSelection.TabIndex = 0;
            tpPersonSelection.Text = "1. Person Selection";
            // 
            // gbSearchFilter
            // 
            gbSearchFilter.BackColor = Color.White;
            gbSearchFilter.Controls.Add(txtSearchNationalNo);
            gbSearchFilter.Controls.Add(btnSearchPerson);
            gbSearchFilter.Controls.Add(btnSelectPerson);
            gbSearchFilter.Controls.Add(btnAddNewPerson);
            gbSearchFilter.Font = new Font("Segoe UI", 9F);
            gbSearchFilter.Location = new Point(10, 10);
            gbSearchFilter.Name = "gbSearchFilter";
            gbSearchFilter.Size = new Size(808, 77);
            gbSearchFilter.TabIndex = 0;
            gbSearchFilter.TabStop = false;
            gbSearchFilter.Text = "Filter / Search Person";
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
            txtSearchNationalNo.Location = new Point(15, 22);
            txtSearchNationalNo.MaxLength = 32767;
            txtSearchNationalNo.MaxSuggestItems = 8;
            txtSearchNationalNo.MoveToNextControlOnEnter = true;
            txtSearchNationalNo.Name = "txtSearchNationalNo";
            txtSearchNationalNo.Padding = new Padding(8, 12, 8, 12);
            txtSearchNationalNo.PlaceholderColor = Color.DarkGray;
            txtSearchNationalNo.PlaceholderText = "National No...";
            txtSearchNationalNo.RightIcon = null;
            txtSearchNationalNo.RightIconClickable = false;
            txtSearchNationalNo.ShowClearButton = false;
            txtSearchNationalNo.Size = new Size(220, 36);
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
            btnSearchPerson.BorderRadius = 0;
            btnSearchPerson.BorderSize = 1;
            btnSearchPerson.CenterIconWithText = false;
            btnSearchPerson.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnSearchPerson.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnSearchPerson.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnSearchPerson.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnSearchPerson.IconSize = new Size(20, 20);
            btnSearchPerson.IconSpacing = 5;
            btnSearchPerson.IsLoading = false;
            btnSearchPerson.LeftIcon = null;
            btnSearchPerson.Location = new Point(245, 29);
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
            btnSearchPerson.Size = new Size(37, 36);
            btnSearchPerson.TabIndex = 1;
            btnSearchPerson.TextColor = SystemColors.ControlText;
            btnSearchPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnSearchPerson, "Search for a person using National No.");
            // 
            // btnSelectPerson
            // 
            btnSelectPerson.BackColor = Color.Transparent;
            btnSelectPerson.BackgroundEndColor = SystemColors.Control;
            btnSelectPerson.BackgroundStartColor = SystemColors.Control;
            btnSelectPerson.BorderColor = Color.DarkGray;
            btnSelectPerson.BorderRadius = 0;
            btnSelectPerson.BorderSize = 1;
            btnSelectPerson.CenterIconWithText = false;
            btnSelectPerson.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnSelectPerson.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnSelectPerson.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnSelectPerson.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnSelectPerson.IconSize = new Size(27, 27);
            btnSelectPerson.IconSpacing = 5;
            btnSelectPerson.IsLoading = false;
            btnSelectPerson.LeftIcon = null;
            btnSelectPerson.Location = new Point(703, 29);
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
            btnSelectPerson.Size = new Size(40, 36);
            btnSelectPerson.TabIndex = 2;
            btnSelectPerson.TextColor = SystemColors.ControlText;
            btnSelectPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnSelectPerson, "Select an exists person from the system");
            btnSelectPerson.Click += btnSelectPerson_Click;
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.BackColor = Color.Transparent;
            btnAddNewPerson.BackgroundEndColor = SystemColors.Control;
            btnAddNewPerson.BackgroundStartColor = SystemColors.Control;
            btnAddNewPerson.BorderColor = Color.DarkGray;
            btnAddNewPerson.BorderRadius = 0;
            btnAddNewPerson.BorderSize = 1;
            btnAddNewPerson.CenterIconWithText = false;
            btnAddNewPerson.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnAddNewPerson.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnAddNewPerson.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnAddNewPerson.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnAddNewPerson.IconSize = new Size(20, 20);
            btnAddNewPerson.IconSpacing = 5;
            btnAddNewPerson.IsLoading = false;
            btnAddNewPerson.LeftIcon = null;
            btnAddNewPerson.Location = new Point(749, 29);
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
            btnAddNewPerson.Size = new Size(42, 36);
            btnAddNewPerson.TabIndex = 3;
            btnAddNewPerson.TextColor = SystemColors.ControlText;
            btnAddNewPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnAddNewPerson, "Add new person and select him");
            // 
            // lnkEditPerson
            // 
            lnkEditPerson.AutoSize = true;
            lnkEditPerson.BackColor = Color.White;
            lnkEditPerson.Font = new Font("Segoe UI", 9.5F);
            lnkEditPerson.Location = new Point(698, 109);
            lnkEditPerson.Name = "lnkEditPerson";
            lnkEditPerson.Size = new Size(100, 17);
            lnkEditPerson.TabIndex = 2;
            lnkEditPerson.TabStop = true;
            lnkEditPerson.Text = "Edit Person Info";
            lnkEditPerson.Visible = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.BackgroundEndColor = SystemColors.Control;
            btnNext.BackgroundStartColor = SystemColors.Control;
            btnNext.BorderColor = Color.DarkGray;
            btnNext.BorderRadius = 0;
            btnNext.BorderSize = 1;
            btnNext.CenterIconWithText = false;
            btnNext.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnNext.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnNext.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnNext.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnNext.Enabled = false;
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
            btnNext.IconSize = new Size(20, 20);
            btnNext.IconSpacing = 5;
            btnNext.IsLoading = false;
            btnNext.LeftIcon = null;
            btnNext.Location = new Point(701, 335);
            btnNext.MiddleIcon = null;
            btnNext.Name = "btnNext";
            btnNext.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnNext.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnNext.RightIcon = Properties.Resources.forward;
            btnNext.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnNext.RippleSpeed = 15;
            btnNext.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnNext.ShadowOffset = new Point(1, 1);
            btnNext.ShadowSize = 3;
            btnNext.ShiftOnPress = false;
            btnNext.Size = new Size(120, 38);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.TextColor = SystemColors.ControlText;
            btnNext.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnNext, "Go to confirm User Login Credentails");
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(10, 82);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(808, 247);
            ctrlPersonCard1.TabIndex = 1;
            // 
            // tpLoginInfo
            // 
            tpLoginInfo.BackColor = Color.FromArgb(248, 250, 252);
            tpLoginInfo.Controls.Add(lblUserName);
            tpLoginInfo.Controls.Add(txtUserName);
            tpLoginInfo.Controls.Add(lblPassword);
            tpLoginInfo.Controls.Add(txtPassword);
            tpLoginInfo.Controls.Add(lblConfirmPassword);
            tpLoginInfo.Controls.Add(txtConfirmPassword);
            tpLoginInfo.Controls.Add(lnkEditPassword);
            tpLoginInfo.Controls.Add(chkIsActive);
            tpLoginInfo.Controls.Add(btnPrev);
            tpLoginInfo.Location = new Point(4, 24);
            tpLoginInfo.Name = "tpLoginInfo";
            tpLoginInfo.Padding = new Padding(3);
            tpLoginInfo.Size = new Size(828, 381);
            tpLoginInfo.TabIndex = 1;
            tpLoginInfo.Text = "2. Login Credentials";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.Location = new Point(36, 42);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(80, 19);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Username:";
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
            txtUserName.Location = new Point(186, 35);
            txtUserName.MaxLength = 32767;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PlaceholderColor = Color.DarkGray;
            txtUserName.PlaceholderText = "";
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ShowClearButton = false;
            txtUserName.Size = new Size(250, 36);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 1;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            txtUserName.TextChanged += CheckTextBoxsIfCanSave_TextChange;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.Location = new Point(36, 99);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 19);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.AllowArabicCharacters = true;
            txtPassword.AllowEnglishCharacters = true;
            txtPassword.AllowNumbers = true;
            txtPassword.AllowSpaces = true;
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
            txtPassword.Location = new Point(186, 90);
            txtPassword.MaxLength = 32767;
            txtPassword.MaxSuggestItems = 8;
            txtPassword.MoveToNextControlOnEnter = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(8, 12, 8, 12);
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "";
            txtPassword.RightIcon = null;
            txtPassword.RightIconClickable = false;
            txtPassword.ShowClearButton = false;
            txtPassword.Size = new Size(250, 36);
            txtPassword.SuggestIcon = null;
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.ValidateEmail = false;
            txtPassword.TextChanged += CheckTextBoxsIfCanSave_TextChange;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(36, 156);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(135, 19);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AllowArabicCharacters = true;
            txtConfirmPassword.AllowEnglishCharacters = true;
            txtConfirmPassword.AllowNumbers = true;
            txtConfirmPassword.AllowSpaces = true;
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
            txtConfirmPassword.Location = new Point(186, 145);
            txtConfirmPassword.MaxLength = 32767;
            txtConfirmPassword.MaxSuggestItems = 8;
            txtConfirmPassword.MoveToNextControlOnEnter = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(8, 12, 8, 12);
            txtConfirmPassword.PlaceholderColor = Color.DarkGray;
            txtConfirmPassword.PlaceholderText = "";
            txtConfirmPassword.RightIcon = null;
            txtConfirmPassword.RightIconClickable = false;
            txtConfirmPassword.ShowClearButton = false;
            txtConfirmPassword.Size = new Size(250, 36);
            txtConfirmPassword.SuggestIcon = null;
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.ValidateEmail = false;
            txtConfirmPassword.TextChanged += CheckTextBoxsIfCanSave_TextChange;
            // 
            // lnkEditPassword
            // 
            lnkEditPassword.AutoSize = true;
            lnkEditPassword.Font = new Font("Segoe UI", 9.5F);
            lnkEditPassword.Location = new Point(186, 85);
            lnkEditPassword.Name = "lnkEditPassword";
            lnkEditPassword.Size = new Size(112, 17);
            lnkEditPassword.TabIndex = 6;
            lnkEditPassword.TabStop = true;
            lnkEditPassword.Text = "Change Password";
            toolTip1.SetToolTip(lnkEditPassword, "Change the password. Will open in new window");
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
            chkIsActive.Location = new Point(186, 205);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.RippleColor = Color.FromArgb(40, 0, 120, 215);
            chkIsActive.Size = new Size(120, 24);
            chkIsActive.Style = NCheckBoxStyle.Rounded;
            chkIsActive.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkIsActive.SwitchThumbColor = Color.White;
            chkIsActive.SwitchWidth = 38;
            chkIsActive.TabIndex = 7;
            chkIsActive.Text = "Is Active";
            chkIsActive.TextSpacing = 8;
            chkIsActive.ThreeState = false;
            toolTip1.SetToolTip(chkIsActive, "Select if the user will be active to access the system or not");
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.Transparent;
            btnPrev.BackgroundEndColor = SystemColors.Control;
            btnPrev.BackgroundStartColor = SystemColors.Control;
            btnPrev.BorderColor = Color.DarkGray;
            btnPrev.BorderRadius = 0;
            btnPrev.BorderSize = 1;
            btnPrev.CenterIconWithText = false;
            btnPrev.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnPrev.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnPrev.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnPrev.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnPrev.EnableHoverAnimation = false;
            btnPrev.EnableIconTinting = false;
            btnPrev.EnableRippleEffect = false;
            btnPrev.EnableShadow = false;
            btnPrev.Font = new Font("Segoe UI", 9F);
            btnPrev.ForeColor = SystemColors.ControlText;
            btnPrev.GradientAngle = 90F;
            btnPrev.HoverAnimationSpeed = 20;
            btnPrev.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnPrev.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnPrev.HoverIconColor = Color.White;
            btnPrev.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnPrev.HoverTextColor = SystemColors.ControlText;
            btnPrev.IconColor = Color.White;
            btnPrev.IconMargin = 10;
            btnPrev.IconOffset = new Point(0, 0);
            btnPrev.IconSize = new Size(20, 20);
            btnPrev.IconSpacing = 5;
            btnPrev.IsLoading = false;
            btnPrev.LeftIcon = Properties.Resources.back;
            btnPrev.Location = new Point(7, 336);
            btnPrev.MiddleIcon = null;
            btnPrev.Name = "btnPrev";
            btnPrev.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnPrev.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnPrev.RightIcon = null;
            btnPrev.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnPrev.RippleSpeed = 15;
            btnPrev.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnPrev.ShadowOffset = new Point(1, 1);
            btnPrev.ShadowSize = 3;
            btnPrev.ShiftOnPress = false;
            btnPrev.Size = new Size(120, 38);
            btnPrev.TabIndex = 8;
            btnPrev.Text = "Previous";
            btnPrev.TextColor = SystemColors.ControlText;
            btnPrev.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnPrev, "Return to person selection page");
            // 
            // frmSaveUser
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(860, 502);
            Controls.Add(tcWizard);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSaveUser";
            Text = "DVLD / Users Management / Save User";
            Load += frmSaveUser_Load;
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(tcWizard, 0);
            tcWizard.ResumeLayout(false);
            tpPersonSelection.ResumeLayout(false);
            tpPersonSelection.PerformLayout();
            gbSearchFilter.ResumeLayout(false);
            tpLoginInfo.ResumeLayout(false);
            tpLoginInfo.PerformLayout();
            ResumeLayout(false);
        }

        private ToolTip toolTip1;
        private NButton btnSave;
        private NButton btnCancel;
        private NTabControl tcWizard;
        private TabPage tpPersonSelection;
        private GroupBox gbSearchFilter;
        private NTextBox txtSearchNationalNo;
        private NButton btnSearchPerson;
        private NButton btnSelectPerson;
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
        private NCheckBox chkIsActive;
        private NButton btnPrev;
    }
}