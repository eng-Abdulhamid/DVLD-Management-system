using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmSaveDriver
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TabControl tcWizard;
        private TabPage tpPersonSelection;
        private GroupBox gbSearchFilter;
        private NTextBox txtSearchNationalNo;
        private NButton btnSearchPerson;
        private NButton btnSelectPerson;
        private NButton btnAddNewPerson;
        private DVLD.PL.PeopleManagement.ctrlPersonCard ctrlPersonCard1;
        private LinkLabel lnkEditPerson;
        private NButton btnNext;
        private TabPage tpDriverConfirmation;
        private Label lblConfirmTitle;
        private Label lblPersonNameHeader;
        private Label lblConfirmPersonName;
        private Label lblPersonIdHeader;
        private Label lblPersonIdValue;
        private Label lblCreatedDateHeader;
        private Label lblCreatedDateValue;
        private Label lblCreatedByHeader;
        private Label lblCreatedByValue;
        private NButton btnSave;
        private NButton btnCancel;
        private NButton btnBack;

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
            txtSearchNationalNo = new NTextBox();
            btnSearchPerson = new NButton();
            btnSelectPerson = new NButton();
            btnAddNewPerson = new NButton();
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            lnkEditPerson = new LinkLabel();
            btnNext = new NButton();
            tpDriverConfirmation = new TabPage();
            lblConfirmTitle = new Label();
            lblPersonNameHeader = new Label();
            lblConfirmPersonName = new Label();
            lblPersonIdHeader = new Label();
            lblPersonIdValue = new Label();
            lblCreatedDateHeader = new Label();
            lblCreatedDateValue = new Label();
            lblCreatedByHeader = new Label();
            lblCreatedByValue = new Label();
            btnBack = new NButton();
            btnSave = new NButton();
            btnCancel = new NButton();
            toolTip1 = new ToolTip(components);
            tcWizard.SuspendLayout();
            tpPersonSelection.SuspendLayout();
            gbSearchFilter.SuspendLayout();
            tpDriverConfirmation.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.BackColor = Color.FromArgb(248, 250, 252);
            headerControl.Size = new Size(856, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Add New Driver";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(179, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Driver";
            // 
            // tcWizard
            // 
            tcWizard.Controls.Add(tpPersonSelection);
            tcWizard.Controls.Add(tpDriverConfirmation);
            tcWizard.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tcWizard.Location = new Point(20, 85);
            tcWizard.Multiline = true;
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
            tpPersonSelection.Text = "Person Selection";
            tpPersonSelection.ToolTipText = "Select Person For this Driver Record";
            // 
            // gbSearchFilter
            // 
            gbSearchFilter.Controls.Add(txtSearchNationalNo);
            gbSearchFilter.Controls.Add(btnSearchPerson);
            gbSearchFilter.Controls.Add(btnSelectPerson);
            gbSearchFilter.Controls.Add(btnAddNewPerson);
            gbSearchFilter.ForeColor = Color.FromArgb(71, 85, 105);
            gbSearchFilter.Location = new Point(16, 8);
            gbSearchFilter.Name = "gbSearchFilter";
            gbSearchFilter.Size = new Size(780, 75);
            gbSearchFilter.TabIndex = 0;
            gbSearchFilter.TabStop = false;
            gbSearchFilter.Text = "Search Person";
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
            btnSearchPerson.ButtonType = enButtonType.Secondary;
            btnSearchPerson.CenterIconWithText = false;
            btnSearchPerson.Cursor = Cursors.Hand;
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
            btnSearchPerson.IconSize = new Size(24, 24);
            btnSearchPerson.IconSpacing = 5;
            btnSearchPerson.IsLoading = false;
            btnSearchPerson.LeftIcon = null;
            btnSearchPerson.Location = new Point(282, 25);
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
            toolTip1.SetToolTip(btnSearchPerson, "Search for a person using National No.");
            // 
            // btnSelectPerson
            // 
            btnSelectPerson.BackColor = Color.Transparent;
            btnSelectPerson.BackgroundEndColor = SystemColors.Control;
            btnSelectPerson.BackgroundStartColor = SystemColors.Control;
            btnSelectPerson.BorderColor = Color.DarkGray;
            btnSelectPerson.BorderRadius = 8;
            btnSelectPerson.BorderSize = 1;
            btnSelectPerson.ButtonType = enButtonType.Secondary;
            btnSelectPerson.CenterIconWithText = false;
            btnSelectPerson.Cursor = Cursors.Hand;
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
            btnSelectPerson.IconSize = new Size(30, 30);
            btnSelectPerson.IconSpacing = 5;
            btnSelectPerson.IsLoading = false;
            btnSelectPerson.LeftIcon = null;
            btnSelectPerson.Location = new Point(721, 25);
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
            btnSelectPerson.TabIndex = 2;
            btnSelectPerson.TextColor = SystemColors.ControlText;
            btnSelectPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnSelectPerson, "Select Existing Person");
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.BackColor = Color.Transparent;
            btnAddNewPerson.BackgroundEndColor = SystemColors.Control;
            btnAddNewPerson.BackgroundStartColor = SystemColors.Control;
            btnAddNewPerson.BorderColor = Color.DarkGray;
            btnAddNewPerson.BorderRadius = 8;
            btnAddNewPerson.BorderSize = 1;
            btnAddNewPerson.ButtonType = enButtonType.Secondary;
            btnAddNewPerson.CenterIconWithText = false;
            btnAddNewPerson.Cursor = Cursors.Hand;
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
            btnAddNewPerson.IconSize = new Size(24, 24);
            btnAddNewPerson.IconSpacing = 5;
            btnAddNewPerson.IsLoading = false;
            btnAddNewPerson.LeftIcon = null;
            btnAddNewPerson.Location = new Point(674, 26);
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
            btnAddNewPerson.TabIndex = 3;
            btnAddNewPerson.TextColor = SystemColors.ControlText;
            btnAddNewPerson.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnAddNewPerson, "Add new Person");
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(16, 90);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(779, 260);
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
            btnNext.ButtonType = enButtonType.Secondary;
            btnNext.CenterIconWithText = false;
            btnNext.Cursor = Cursors.Hand;
            btnNext.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnNext.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnNext.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnNext.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnNext.HoverIconColor = Color.Navy;
            btnNext.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnNext.HoverTextColor = SystemColors.ControlText;
            btnNext.IconColor = Color.DimGray;
            btnNext.IconMargin = 10;
            btnNext.IconOffset = new Point(0, 0);
            btnNext.IconSize = new Size(16, 16);
            btnNext.IconSpacing = 10;
            btnNext.IsLoading = false;
            btnNext.LeftIcon = null;
            btnNext.Location = new Point(686, 355);
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
            btnNext.Size = new Size(110, 38);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.TextColor = SystemColors.ControlText;
            btnNext.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnNext, "Proceed to Driver Confirmation");
            // 
            // tpDriverConfirmation
            // 
            tpDriverConfirmation.BackColor = Color.White;
            tpDriverConfirmation.Controls.Add(lblConfirmTitle);
            tpDriverConfirmation.Controls.Add(lblPersonNameHeader);
            tpDriverConfirmation.Controls.Add(lblConfirmPersonName);
            tpDriverConfirmation.Controls.Add(lblPersonIdHeader);
            tpDriverConfirmation.Controls.Add(lblPersonIdValue);
            tpDriverConfirmation.Controls.Add(lblCreatedDateHeader);
            tpDriverConfirmation.Controls.Add(lblCreatedDateValue);
            tpDriverConfirmation.Controls.Add(lblCreatedByHeader);
            tpDriverConfirmation.Controls.Add(lblCreatedByValue);
            tpDriverConfirmation.Controls.Add(btnBack);
            tpDriverConfirmation.Location = new Point(4, 48);
            tpDriverConfirmation.Name = "tpDriverConfirmation";
            tpDriverConfirmation.Padding = new Padding(32);
            tpDriverConfirmation.Size = new Size(192, 48);
            tpDriverConfirmation.TabIndex = 1;
            tpDriverConfirmation.Text = "Driver Confirmation";
            // 
            // lblConfirmTitle
            // 
            lblConfirmTitle.AutoSize = true;
            lblConfirmTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblConfirmTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblConfirmTitle.Location = new Point(36, 32);
            lblConfirmTitle.Name = "lblConfirmTitle";
            lblConfirmTitle.Size = new Size(183, 21);
            lblConfirmTitle.TabIndex = 0;
            lblConfirmTitle.Text = "Confirm Driver Creation";
            // 
            // lblPersonNameHeader
            // 
            lblPersonNameHeader.AutoSize = true;
            lblPersonNameHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblPersonNameHeader.Location = new Point(36, 120);
            lblPersonNameHeader.Name = "lblPersonNameHeader";
            lblPersonNameHeader.Size = new Size(107, 17);
            lblPersonNameHeader.TabIndex = 3;
            lblPersonNameHeader.Text = "Selected Person:";
            // 
            // lblConfirmPersonName
            // 
            lblConfirmPersonName.AutoSize = true;
            lblConfirmPersonName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConfirmPersonName.ForeColor = Color.FromArgb(124, 58, 237);
            lblConfirmPersonName.Location = new Point(160, 118);
            lblConfirmPersonName.Name = "lblConfirmPersonName";
            lblConfirmPersonName.Size = new Size(79, 19);
            lblConfirmPersonName.TabIndex = 4;
            lblConfirmPersonName.Text = "[Unknown]";
            // 
            // lblPersonIdHeader
            // 
            lblPersonIdHeader.AutoSize = true;
            lblPersonIdHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblPersonIdHeader.Location = new Point(36, 80);
            lblPersonIdHeader.Name = "lblPersonIdHeader";
            lblPersonIdHeader.Size = new Size(70, 17);
            lblPersonIdHeader.TabIndex = 1;
            lblPersonIdHeader.Text = "Person ID:";
            // 
            // lblPersonIdValue
            // 
            lblPersonIdValue.AutoSize = true;
            lblPersonIdValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPersonIdValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblPersonIdValue.Location = new Point(160, 78);
            lblPersonIdValue.Name = "lblPersonIdValue";
            lblPersonIdValue.Size = new Size(35, 19);
            lblPersonIdValue.TabIndex = 2;
            lblPersonIdValue.Text = "N/A";
            // 
            // lblCreatedDateHeader
            // 
            lblCreatedDateHeader.AutoSize = true;
            lblCreatedDateHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblCreatedDateHeader.Location = new Point(36, 160);
            lblCreatedDateHeader.Name = "lblCreatedDateHeader";
            lblCreatedDateHeader.Size = new Size(94, 17);
            lblCreatedDateHeader.TabIndex = 5;
            lblCreatedDateHeader.Text = "Creation Date:";
            // 
            // lblCreatedDateValue
            // 
            lblCreatedDateValue.AutoSize = true;
            lblCreatedDateValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCreatedDateValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblCreatedDateValue.Location = new Point(160, 158);
            lblCreatedDateValue.Name = "lblCreatedDateValue";
            lblCreatedDateValue.Size = new Size(35, 19);
            lblCreatedDateValue.TabIndex = 6;
            lblCreatedDateValue.Text = "N/A";
            // 
            // lblCreatedByHeader
            // 
            lblCreatedByHeader.AutoSize = true;
            lblCreatedByHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblCreatedByHeader.Location = new Point(36, 200);
            lblCreatedByHeader.Name = "lblCreatedByHeader";
            lblCreatedByHeader.Size = new Size(77, 17);
            lblCreatedByHeader.TabIndex = 7;
            lblCreatedByHeader.Text = "Created By:";
            // 
            // lblCreatedByValue
            // 
            lblCreatedByValue.AutoSize = true;
            lblCreatedByValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCreatedByValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblCreatedByValue.Location = new Point(160, 198);
            lblCreatedByValue.Name = "lblCreatedByValue";
            lblCreatedByValue.Size = new Size(54, 19);
            lblCreatedByValue.TabIndex = 8;
            lblCreatedByValue.Text = "System";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.BackgroundEndColor = SystemColors.Control;
            btnBack.BackgroundStartColor = SystemColors.Control;
            btnBack.BorderColor = Color.DarkGray;
            btnBack.BorderRadius = 8;
            btnBack.BorderSize = 1;
            btnBack.ButtonType = enButtonType.Secondary;
            btnBack.CenterIconWithText = false;
            btnBack.Cursor = Cursors.Hand;
            btnBack.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnBack.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnBack.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnBack.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnBack.EnableHoverAnimation = false;
            btnBack.EnableIconTinting = false;
            btnBack.EnableRippleEffect = false;
            btnBack.EnableShadow = false;
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.GradientAngle = 90F;
            btnBack.HoverAnimationSpeed = 20;
            btnBack.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnBack.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnBack.HoverIconColor = Color.Navy;
            btnBack.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnBack.HoverTextColor = SystemColors.ControlText;
            btnBack.IconColor = Color.DimGray;
            btnBack.IconMargin = 10;
            btnBack.IconOffset = new Point(0, 0);
            btnBack.IconSize = new Size(16, 16);
            btnBack.IconSpacing = 10;
            btnBack.IsLoading = false;
            btnBack.LeftIcon = null;
            btnBack.Location = new Point(36, 355);
            btnBack.MiddleIcon = null;
            btnBack.Name = "btnBack";
            btnBack.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnBack.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnBack.RightIcon = null;
            btnBack.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnBack.RippleSpeed = 15;
            btnBack.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnBack.ShadowOffset = new Point(1, 1);
            btnBack.ShadowSize = 3;
            btnBack.ShiftOnPress = false;
            btnBack.Size = new Size(110, 38);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.TextColor = SystemColors.ControlText;
            btnBack.TextOffset = new Point(0, 0);
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundEndColor = SystemColors.Control;
            btnSave.BackgroundStartColor = SystemColors.Control;
            btnSave.BorderColor = Color.DarkGray;
            btnSave.BorderRadius = 8;
            btnSave.BorderSize = 1;
            btnSave.ButtonType = enButtonType.Primary;
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
            btnSave.Text = "Save Driver";
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
            btnCancel.ButtonType = enButtonType.Secondary;
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
            toolTip1.SetToolTip(btnCancel, "Cancel and Close the window");
            // 
            // frmSaveDriver
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
            Name = "frmSaveDriver";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += frmSaveDriver_Load;
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(tcWizard, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            tcWizard.ResumeLayout(false);
            tpPersonSelection.ResumeLayout(false);
            tpPersonSelection.PerformLayout();
            gbSearchFilter.ResumeLayout(false);
            tpDriverConfirmation.ResumeLayout(false);
            tpDriverConfirmation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolTip toolTip1;
    }
}