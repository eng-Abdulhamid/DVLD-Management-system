using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    partial class frmPeopleManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlTopBar;
        private Panel panel1;
        private ctrlPeopleSearch ctrlPeopleSearch1;
        private ModernUI.Controls.NButton btnAddNewPerson;
        private ModernUI.Controls.NButton btnUpdate;
        private ModernUI.Controls.NButton btnDelete;
        private ModernUI.Controls.NButton btnRefresh;
        private ModernUI.Controls.NButton btnSettings;
        private Panel pnlPagination;
        private Label lblRowsPerPage;
        private ComboBox cmbPageSize;
        private Label lblPaginationInfo;
        private ModernUI.Controls.NButton btnPrevPage;
        private ModernUI.Controls.NButton btnNextPage;
        private NControls.NDataGrid dgvResults;
        private ContextMenuStrip cmsColumns;

        private Panel pnlEmptyState;
        private Label lblEmptyIcon;
        private Label lblEmptyTitle;
        private Label lblEmptyDesc;
        private ModernUI.Controls.NButton btnClearFilter;
        private Panel pnlLoadingOverlay;
        private ModernUI.Controls.NButton btnLoadingSpinner;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMain = new Panel();
            pnlLoadingOverlay = new Panel();
            btnLoadingSpinner = new ModernUI.Controls.NButton();
            pnlEmptyState = new Panel();
            btnClearFilter = new ModernUI.Controls.NButton();
            lblEmptyDesc = new Label();
            lblEmptyTitle = new Label();
            lblEmptyIcon = new Label();
            dgvResults = new NControls.NDataGrid();
            pnlTopBar = new Panel();
            pnlPagination = new Panel();
            btnPrevPage = new ModernUI.Controls.NButton();
            btnNextPage = new ModernUI.Controls.NButton();
            lblRowsPerPage = new Label();
            cmbPageSize = new ComboBox();
            lblPaginationInfo = new Label();
            panel1 = new Panel();
            btnAddNewPerson = new ModernUI.Controls.NButton();
            btnUpdate = new ModernUI.Controls.NButton();
            btnDelete = new ModernUI.Controls.NButton();
            btnRefresh = new ModernUI.Controls.NButton();
            btnSettings = new ModernUI.Controls.NButton();
            ctrlPeopleSearch1 = new ctrlPeopleSearch();
            cmsColumns = new ContextMenuStrip(components);
            cmsRowActions = new ContextMenuStrip(components);
            pnlMain.SuspendLayout();
            pnlLoadingOverlay.SuspendLayout();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            pnlTopBar.SuspendLayout();
            pnlPagination.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(1116, 38);
            headerControl.TitleText = "DVLD / People Management";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(pnlLoadingOverlay);
            pnlMain.Controls.Add(pnlEmptyState);
            pnlMain.Controls.Add(dgvResults);
            pnlMain.Controls.Add(pnlTopBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1116, 716);
            pnlMain.TabIndex = 0;
            // 
            // pnlLoadingOverlay
            // 
            pnlLoadingOverlay.BackColor = Color.Transparent;
            pnlLoadingOverlay.Controls.Add(btnLoadingSpinner);
            pnlLoadingOverlay.Location = new Point(528, 340);
            pnlLoadingOverlay.Name = "pnlLoadingOverlay";
            pnlLoadingOverlay.Size = new Size(60, 60);
            pnlLoadingOverlay.TabIndex = 3;
            pnlLoadingOverlay.Visible = false;
            // 
            // btnLoadingSpinner
            // 
            btnLoadingSpinner.BackColor = Color.Transparent;
            btnLoadingSpinner.BackgroundEndColor = Color.White;
            btnLoadingSpinner.BackgroundStartColor = Color.White;
            btnLoadingSpinner.BorderColor = Color.FromArgb(226, 232, 240);
            btnLoadingSpinner.BorderRadius = 30;
            btnLoadingSpinner.BorderSize = 1;
            btnLoadingSpinner.CenterIconWithText = false;
            btnLoadingSpinner.Dock = DockStyle.Fill;
            btnLoadingSpinner.EnableHoverAnimation = false;
            btnLoadingSpinner.EnableIconTinting = false;
            btnLoadingSpinner.EnableRippleEffect = false;
            btnLoadingSpinner.EnableShadow = true;
            btnLoadingSpinner.Font = new Font("Segoe UI", 9F);
            btnLoadingSpinner.ForeColor = Color.FromArgb(124, 58, 237);
            btnLoadingSpinner.GradientAngle = 90F;
            btnLoadingSpinner.HoverAnimationSpeed = 20;
            btnLoadingSpinner.HoverBorderColor = Color.FromArgb(226, 232, 240);
            btnLoadingSpinner.HoverEndColor = Color.White;
            btnLoadingSpinner.HoverIconColor = Color.White;
            btnLoadingSpinner.HoverStartColor = Color.White;
            btnLoadingSpinner.HoverTextColor = Color.FromArgb(124, 58, 237);
            btnLoadingSpinner.IconColor = Color.White;
            btnLoadingSpinner.IconMargin = 10;
            btnLoadingSpinner.IconOffset = new Point(0, 0);
            btnLoadingSpinner.IconSize = new Size(16, 16);
            btnLoadingSpinner.IconSpacing = 5;
            btnLoadingSpinner.IsLoading = true;
            btnLoadingSpinner.LeftIcon = null;
            btnLoadingSpinner.Location = new Point(0, 0);
            btnLoadingSpinner.MiddleIcon = null;
            btnLoadingSpinner.Name = "btnLoadingSpinner";
            btnLoadingSpinner.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnLoadingSpinner.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnLoadingSpinner.RightIcon = null;
            btnLoadingSpinner.RippleColor = Color.Transparent;
            btnLoadingSpinner.RippleSpeed = 15;
            btnLoadingSpinner.ShadowColor = Color.FromArgb(40, 15, 23, 42);
            btnLoadingSpinner.ShadowOffset = new Point(0, 3);
            btnLoadingSpinner.ShadowSize = 5;
            btnLoadingSpinner.ShiftOnPress = false;
            btnLoadingSpinner.Size = new Size(60, 60);
            btnLoadingSpinner.TabIndex = 0;
            btnLoadingSpinner.TextColor = Color.FromArgb(124, 58, 237);
            btnLoadingSpinner.TextOffset = new Point(0, 0);
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.BackColor = Color.White;
            pnlEmptyState.Controls.Add(btnClearFilter);
            pnlEmptyState.Controls.Add(lblEmptyDesc);
            pnlEmptyState.Controls.Add(lblEmptyTitle);
            pnlEmptyState.Controls.Add(lblEmptyIcon);
            pnlEmptyState.Location = new Point(320, 230);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(480, 220);
            pnlEmptyState.TabIndex = 4;
            pnlEmptyState.Visible = false;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.Transparent;
            btnClearFilter.BackgroundEndColor = SystemColors.Control;
            btnClearFilter.BackgroundStartColor = SystemColors.Control;
            btnClearFilter.BorderColor = Color.DarkGray;
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.BorderSize = 1;
            btnClearFilter.CenterIconWithText = false;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.EnableHoverAnimation = false;
            btnClearFilter.EnableIconTinting = false;
            btnClearFilter.EnableRippleEffect = false;
            btnClearFilter.EnableShadow = false;
            btnClearFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearFilter.ForeColor = SystemColors.ControlText;
            btnClearFilter.GradientAngle = 90F;
            btnClearFilter.HoverAnimationSpeed = 20;
            btnClearFilter.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnClearFilter.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnClearFilter.HoverIconColor = Color.White;
            btnClearFilter.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnClearFilter.HoverTextColor = SystemColors.ControlText;
            btnClearFilter.IconColor = Color.White;
            btnClearFilter.IconMargin = 10;
            btnClearFilter.IconOffset = new Point(0, 0);
            btnClearFilter.IconSize = new Size(16, 16);
            btnClearFilter.IconSpacing = 5;
            btnClearFilter.IsLoading = false;
            btnClearFilter.LeftIcon = null;
            btnClearFilter.Location = new Point(180, 160);
            btnClearFilter.MiddleIcon = null;
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnClearFilter.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnClearFilter.RightIcon = null;
            btnClearFilter.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnClearFilter.RippleSpeed = 15;
            btnClearFilter.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnClearFilter.ShadowOffset = new Point(1, 1);
            btnClearFilter.ShadowSize = 3;
            btnClearFilter.ShiftOnPress = false;
            btnClearFilter.Size = new Size(120, 36);
            btnClearFilter.TabIndex = 3;
            btnClearFilter.Text = "Clear Filters";
            btnClearFilter.TextColor = SystemColors.ControlText;
            btnClearFilter.TextOffset = new Point(0, 0);
            // 
            // lblEmptyDesc
            // 
            lblEmptyDesc.Font = new Font("Segoe UI", 9.5F);
            lblEmptyDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyDesc.Location = new Point(20, 112);
            lblEmptyDesc.Name = "lblEmptyDesc";
            lblEmptyDesc.Size = new Size(440, 40);
            lblEmptyDesc.TabIndex = 2;
            lblEmptyDesc.Text = "We couldn't find anyone matching your search criteria. Try modifying your filters.";
            lblEmptyDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyTitle
            // 
            lblEmptyTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmptyTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblEmptyTitle.Location = new Point(20, 85);
            lblEmptyTitle.Name = "lblEmptyTitle";
            lblEmptyTitle.Size = new Size(440, 24);
            lblEmptyTitle.TabIndex = 1;
            lblEmptyTitle.Text = "No Matching Records Found";
            lblEmptyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyIcon
            // 
            lblEmptyIcon.Font = new Font("Segoe UI", 36F);
            lblEmptyIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblEmptyIcon.Location = new Point(190, 15);
            lblEmptyIcon.Name = "lblEmptyIcon";
            lblEmptyIcon.Size = new Size(100, 65);
            lblEmptyIcon.TabIndex = 0;
            lblEmptyIcon.Text = "🔍";
            lblEmptyIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AllowUserToOrderColumns = true;
            dgvResults.AllowUserToResizeRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.ColumnHeadersHeight = 45;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.GridColor = Color.FromArgb(226, 232, 240);
            dgvResults.Location = new Point(0, 130);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(1116, 586);
            dgvResults.TabIndex = 2;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(pnlPagination);
            pnlTopBar.Controls.Add(panel1);
            pnlTopBar.Controls.Add(ctrlPeopleSearch1);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Padding = new Padding(12, 6, 12, 6);
            pnlTopBar.Size = new Size(1116, 130);
            pnlTopBar.TabIndex = 0;
            // 
            // pnlPagination
            // 
            pnlPagination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPagination.BackColor = Color.Transparent;
            pnlPagination.Controls.Add(btnPrevPage);
            pnlPagination.Controls.Add(btnNextPage);
            pnlPagination.Controls.Add(lblRowsPerPage);
            pnlPagination.Controls.Add(cmbPageSize);
            pnlPagination.Controls.Add(lblPaginationInfo);
            pnlPagination.Location = new Point(749, 88);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(354, 36);
            pnlPagination.TabIndex = 5;
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.Transparent;
            btnPrevPage.BackgroundEndColor = SystemColors.Control;
            btnPrevPage.BackgroundStartColor = SystemColors.Control;
            btnPrevPage.BorderColor = Color.DarkGray;
            btnPrevPage.BorderRadius = 8;
            btnPrevPage.BorderSize = 1;
            btnPrevPage.CenterIconWithText = true;
            btnPrevPage.Cursor = Cursors.Hand;
            btnPrevPage.EnableHoverAnimation = false;
            btnPrevPage.EnableIconTinting = false;
            btnPrevPage.EnableRippleEffect = false;
            btnPrevPage.EnableShadow = false;
            btnPrevPage.Font = new Font("Segoe UI", 9F);
            btnPrevPage.ForeColor = SystemColors.ControlText;
            btnPrevPage.GradientAngle = 90F;
            btnPrevPage.HoverAnimationSpeed = 20;
            btnPrevPage.HoverBorderColor = Color.WhiteSmoke;
            btnPrevPage.HoverEndColor = Color.WhiteSmoke;
            btnPrevPage.HoverIconColor = Color.DarkGray;
            btnPrevPage.HoverStartColor = Color.WhiteSmoke;
            btnPrevPage.HoverTextColor = SystemColors.ControlText;
            btnPrevPage.IconColor = Color.Black;
            btnPrevPage.IconMargin = 0;
            btnPrevPage.IconOffset = new Point(0, 0);
            btnPrevPage.IconSize = new Size(16, 16);
            btnPrevPage.IconSpacing = 5;
            btnPrevPage.IsLoading = false;
            btnPrevPage.LeftIcon = null;
            btnPrevPage.Location = new Point(269, 3);
            btnPrevPage.MiddleIcon = Properties.Resources.back;
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.PressedEndColor = Color.WhiteSmoke;
            btnPrevPage.PressedStartColor = Color.WhiteSmoke;
            btnPrevPage.RightIcon = null;
            btnPrevPage.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnPrevPage.RippleSpeed = 15;
            btnPrevPage.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnPrevPage.ShadowOffset = new Point(1, 1);
            btnPrevPage.ShadowSize = 3;
            btnPrevPage.ShiftOnPress = false;
            btnPrevPage.Size = new Size(38, 30);
            btnPrevPage.TabIndex = 6;
            btnPrevPage.TextColor = SystemColors.ControlText;
            btnPrevPage.TextOffset = new Point(0, 0);
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.Transparent;
            btnNextPage.BackgroundEndColor = SystemColors.Control;
            btnNextPage.BackgroundStartColor = SystemColors.Control;
            btnNextPage.BorderColor = Color.DarkGray;
            btnNextPage.BorderRadius = 8;
            btnNextPage.BorderSize = 1;
            btnNextPage.CenterIconWithText = true;
            btnNextPage.Cursor = Cursors.Hand;
            btnNextPage.EnableHoverAnimation = false;
            btnNextPage.EnableIconTinting = false;
            btnNextPage.EnableRippleEffect = false;
            btnNextPage.EnableShadow = false;
            btnNextPage.Font = new Font("Segoe UI", 9F);
            btnNextPage.ForeColor = SystemColors.ControlText;
            btnNextPage.GradientAngle = 90F;
            btnNextPage.HoverAnimationSpeed = 20;
            btnNextPage.HoverBorderColor = Color.WhiteSmoke;
            btnNextPage.HoverEndColor = Color.WhiteSmoke;
            btnNextPage.HoverIconColor = Color.DarkGray;
            btnNextPage.HoverStartColor = Color.WhiteSmoke;
            btnNextPage.HoverTextColor = SystemColors.ControlText;
            btnNextPage.IconColor = Color.Black;
            btnNextPage.IconMargin = 0;
            btnNextPage.IconOffset = new Point(0, 0);
            btnNextPage.IconSize = new Size(16, 16);
            btnNextPage.IconSpacing = 5;
            btnNextPage.IsLoading = false;
            btnNextPage.LeftIcon = null;
            btnNextPage.Location = new Point(313, 3);
            btnNextPage.MiddleIcon = Properties.Resources.forward;
            btnNextPage.Name = "btnNextPage";
            btnNextPage.PressedEndColor = Color.WhiteSmoke;
            btnNextPage.PressedStartColor = Color.WhiteSmoke;
            btnNextPage.RightIcon = null;
            btnNextPage.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnNextPage.RippleSpeed = 15;
            btnNextPage.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnNextPage.ShadowOffset = new Point(1, 1);
            btnNextPage.ShadowSize = 3;
            btnNextPage.ShiftOnPress = false;
            btnNextPage.Size = new Size(38, 30);
            btnNextPage.TabIndex = 5;
            btnNextPage.TextColor = SystemColors.ControlText;
            btnNextPage.TextOffset = new Point(0, 0);
            // 
            // lblRowsPerPage
            // 
            lblRowsPerPage.AutoSize = true;
            lblRowsPerPage.Font = new Font("Segoe UI", 9F);
            lblRowsPerPage.ForeColor = Color.FromArgb(100, 116, 139);
            lblRowsPerPage.Location = new Point(6, 10);
            lblRowsPerPage.Name = "lblRowsPerPage";
            lblRowsPerPage.Size = new Size(67, 15);
            lblRowsPerPage.TabIndex = 0;
            lblRowsPerPage.Text = "Show rows:";
            // 
            // cmbPageSize
            // 
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.FlatStyle = FlatStyle.Flat;
            cmbPageSize.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cmbPageSize.ForeColor = Color.FromArgb(15, 23, 42);
            cmbPageSize.Items.AddRange(new object[] { "10", "25", "50", "100" });
            cmbPageSize.Location = new Point(78, 6);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(58, 23);
            cmbPageSize.TabIndex = 1;
            // 
            // lblPaginationInfo
            // 
            lblPaginationInfo.AutoSize = true;
            lblPaginationInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPaginationInfo.ForeColor = Color.FromArgb(71, 85, 105);
            lblPaginationInfo.Location = new Point(148, 10);
            lblPaginationInfo.Name = "lblPaginationInfo";
            lblPaginationInfo.Size = new Size(50, 15);
            lblPaginationInfo.TabIndex = 2;
            lblPaginationInfo.Text = "0-0 of 0";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddNewPerson);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnSettings);
            panel1.Location = new Point(12, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 36);
            panel1.TabIndex = 6;
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.BackColor = Color.Transparent;
            btnAddNewPerson.BackgroundEndColor = SystemColors.Control;
            btnAddNewPerson.BackgroundStartColor = SystemColors.Control;
            btnAddNewPerson.BorderColor = Color.DarkGray;
            btnAddNewPerson.BorderRadius = 8;
            btnAddNewPerson.BorderSize = 0;
            btnAddNewPerson.CenterIconWithText = true;
            btnAddNewPerson.Cursor = Cursors.Hand;
            btnAddNewPerson.EnableHoverAnimation = false;
            btnAddNewPerson.EnableIconTinting = false;
            btnAddNewPerson.EnableRippleEffect = false;
            btnAddNewPerson.EnableShadow = false;
            btnAddNewPerson.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
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
            btnAddNewPerson.Location = new Point(2, 1);
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
            btnAddNewPerson.Size = new Size(38, 36);
            btnAddNewPerson.TabIndex = 0;
            btnAddNewPerson.TextColor = SystemColors.ControlText;
            btnAddNewPerson.TextOffset = new Point(0, 0);
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.BackgroundEndColor = SystemColors.Control;
            btnUpdate.BackgroundStartColor = SystemColors.Control;
            btnUpdate.BorderColor = Color.DarkGray;
            btnUpdate.BorderRadius = 8;
            btnUpdate.BorderSize = 0;
            btnUpdate.CenterIconWithText = true;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.EnableHoverAnimation = false;
            btnUpdate.EnableIconTinting = false;
            btnUpdate.EnableRippleEffect = false;
            btnUpdate.EnableShadow = false;
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = SystemColors.ControlText;
            btnUpdate.GradientAngle = 90F;
            btnUpdate.HoverAnimationSpeed = 20;
            btnUpdate.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnUpdate.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnUpdate.HoverIconColor = Color.White;
            btnUpdate.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnUpdate.HoverTextColor = SystemColors.ControlText;
            btnUpdate.IconColor = Color.White;
            btnUpdate.IconMargin = 10;
            btnUpdate.IconOffset = new Point(0, 0);
            btnUpdate.IconSize = new Size(20, 20);
            btnUpdate.IconSpacing = 5;
            btnUpdate.IsLoading = false;
            btnUpdate.LeftIcon = null;
            btnUpdate.Location = new Point(49, 1);
            btnUpdate.MiddleIcon = Properties.Resources.edit_person;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnUpdate.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnUpdate.RightIcon = null;
            btnUpdate.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnUpdate.RippleSpeed = 15;
            btnUpdate.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnUpdate.ShadowOffset = new Point(1, 1);
            btnUpdate.ShadowSize = 3;
            btnUpdate.ShiftOnPress = false;
            btnUpdate.Size = new Size(38, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.TextColor = SystemColors.ControlText;
            btnUpdate.TextOffset = new Point(0, 0);
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BackgroundEndColor = SystemColors.Control;
            btnDelete.BackgroundStartColor = SystemColors.Control;
            btnDelete.BorderColor = Color.DarkGray;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.EnableHoverAnimation = false;
            btnDelete.EnableIconTinting = false;
            btnDelete.EnableRippleEffect = false;
            btnDelete.EnableShadow = false;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = SystemColors.ControlText;
            btnDelete.GradientAngle = 90F;
            btnDelete.HoverAnimationSpeed = 20;
            btnDelete.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnDelete.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnDelete.HoverIconColor = Color.White;
            btnDelete.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnDelete.HoverTextColor = SystemColors.ControlText;
            btnDelete.IconColor = Color.White;
            btnDelete.IconMargin = 10;
            btnDelete.IconOffset = new Point(0, 0);
            btnDelete.IconSize = new Size(20, 20);
            btnDelete.IconSpacing = 5;
            btnDelete.IsLoading = false;
            btnDelete.LeftIcon = null;
            btnDelete.Location = new Point(96, 1);
            btnDelete.MiddleIcon = Properties.Resources.bin;
            btnDelete.Name = "btnDelete";
            btnDelete.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnDelete.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnDelete.RightIcon = null;
            btnDelete.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnDelete.RippleSpeed = 15;
            btnDelete.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnDelete.ShadowOffset = new Point(1, 1);
            btnDelete.ShadowSize = 3;
            btnDelete.ShiftOnPress = false;
            btnDelete.Size = new Size(38, 36);
            btnDelete.TabIndex = 2;
            btnDelete.TextColor = SystemColors.ControlText;
            btnDelete.TextOffset = new Point(0, 0);
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BackgroundEndColor = SystemColors.Control;
            btnRefresh.BackgroundStartColor = SystemColors.Control;
            btnRefresh.BorderColor = Color.DarkGray;
            btnRefresh.BorderRadius = 8;
            btnRefresh.BorderSize = 0;
            btnRefresh.CenterIconWithText = true;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.EnableHoverAnimation = false;
            btnRefresh.EnableIconTinting = false;
            btnRefresh.EnableRippleEffect = false;
            btnRefresh.EnableShadow = false;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = SystemColors.ControlText;
            btnRefresh.GradientAngle = 90F;
            btnRefresh.HoverAnimationSpeed = 20;
            btnRefresh.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnRefresh.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnRefresh.HoverIconColor = Color.White;
            btnRefresh.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnRefresh.HoverTextColor = SystemColors.ControlText;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconMargin = 10;
            btnRefresh.IconOffset = new Point(0, 0);
            btnRefresh.IconSize = new Size(20, 20);
            btnRefresh.IconSpacing = 5;
            btnRefresh.IsLoading = false;
            btnRefresh.LeftIcon = null;
            btnRefresh.Location = new Point(143, 1);
            btnRefresh.MiddleIcon = Properties.Resources.refresh;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnRefresh.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnRefresh.RightIcon = null;
            btnRefresh.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnRefresh.RippleSpeed = 15;
            btnRefresh.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnRefresh.ShadowOffset = new Point(1, 1);
            btnRefresh.ShadowSize = 3;
            btnRefresh.ShiftOnPress = false;
            btnRefresh.Size = new Size(38, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.TextColor = SystemColors.ControlText;
            btnRefresh.TextOffset = new Point(0, 0);
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundEndColor = SystemColors.Control;
            btnSettings.BackgroundStartColor = SystemColors.Control;
            btnSettings.BorderColor = Color.DarkGray;
            btnSettings.BorderRadius = 8;
            btnSettings.BorderSize = 0;
            btnSettings.CenterIconWithText = true;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.EnableHoverAnimation = false;
            btnSettings.EnableIconTinting = false;
            btnSettings.EnableRippleEffect = false;
            btnSettings.EnableShadow = false;
            btnSettings.Font = new Font("Segoe UI", 9F);
            btnSettings.ForeColor = SystemColors.ControlText;
            btnSettings.GradientAngle = 90F;
            btnSettings.HoverAnimationSpeed = 20;
            btnSettings.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSettings.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSettings.HoverIconColor = Color.White;
            btnSettings.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSettings.HoverTextColor = SystemColors.ControlText;
            btnSettings.IconColor = Color.White;
            btnSettings.IconMargin = 10;
            btnSettings.IconOffset = new Point(0, 0);
            btnSettings.IconSize = new Size(20, 20);
            btnSettings.IconSpacing = 5;
            btnSettings.IsLoading = false;
            btnSettings.LeftIcon = null;
            btnSettings.Location = new Point(190, 1);
            btnSettings.MiddleIcon = Properties.Resources.setting;
            btnSettings.Name = "btnSettings";
            btnSettings.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSettings.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSettings.RightIcon = null;
            btnSettings.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSettings.RippleSpeed = 15;
            btnSettings.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSettings.ShadowOffset = new Point(1, 1);
            btnSettings.ShadowSize = 3;
            btnSettings.ShiftOnPress = false;
            btnSettings.Size = new Size(38, 36);
            btnSettings.TabIndex = 4;
            btnSettings.TextColor = SystemColors.ControlText;
            btnSettings.TextOffset = new Point(0, 0);
            // 
            // ctrlPeopleSearch1
            // 
            ctrlPeopleSearch1.BackColor = Color.Transparent;
            ctrlPeopleSearch1.Dock = DockStyle.Fill;
            ctrlPeopleSearch1.Location = new Point(12, 6);
            ctrlPeopleSearch1.Margin = new Padding(4, 3, 4, 3);
            ctrlPeopleSearch1.MinimumSize = new Size(920, 100);
            ctrlPeopleSearch1.Name = "ctrlPeopleSearch1";
            ctrlPeopleSearch1.Size = new Size(1092, 118);
            ctrlPeopleSearch1.TabIndex = 0;
            // 
            // cmsColumns
            // 
            cmsColumns.Name = "cmsColumns";
            cmsColumns.Size = new Size(61, 4);
            // 
            // cmsRowActions
            // 
            cmsRowActions.Name = "cmsRowActions";
            cmsRowActions.Size = new Size(61, 4);
            // 
            // frmPeopleManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(1120, 720);
            Controls.Add(pnlMain);
            KeyPreview = true;
            MinimumSize = new Size(960, 600);
            Name = "frmPeopleManagement";
            Text = "DVLD / People Management";
            Controls.SetChildIndex(pnlMain, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlMain.ResumeLayout(false);
            pnlLoadingOverlay.ResumeLayout(false);
            pnlEmptyState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            pnlTopBar.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ContextMenuStrip cmsRowActions;
    }
}