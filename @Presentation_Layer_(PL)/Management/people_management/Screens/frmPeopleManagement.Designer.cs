using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.PeopleManagement
{
    partial class frmPeopleManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlTopBar;
        private ctrlPeopleSearch ctrlPeopleSearch1;
        private DVLD.PL.Management.ctrlManagementDataGrid ctrlManagementDataGrid1;
        private DVLD.PL.Management.ctrlManagementActions ctrlManagementActions1;
        private DVLD.PL.Management.ctrlPagination ctrlPagination1;
        private DVLD.PL.Management.ctrlNotFound ctrlNotFound1;
        private NButton btnSelect;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            ctrlNotFound1 = new DVLD.PL.Management.ctrlNotFound();
            ctrlManagementDataGrid1 = new DVLD.PL.Management.ctrlManagementDataGrid();
            pnlTopBar = new Panel();
            ctrlPeopleSearch1 = new ctrlPeopleSearch();
            ctrlManagementActions1 = new DVLD.PL.Management.ctrlManagementActions();
            btnSelect = new NButton();
            ctrlPagination1 = new DVLD.PL.Management.ctrlPagination();
            pnlMain.SuspendLayout();
            pnlTopBar.SuspendLayout();
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
            pnlMain.Controls.Add(ctrlNotFound1);
            pnlMain.Controls.Add(ctrlManagementDataGrid1);
            pnlMain.Controls.Add(pnlTopBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1116, 678);
            pnlMain.TabIndex = 1;
            // 
            // ctrlNotFound1
            // 
            ctrlNotFound1.BackColor = Color.Transparent;
            ctrlNotFound1.Location = new Point(318, 220);
            ctrlNotFound1.Name = "ctrlNotFound1";
            ctrlNotFound1.Size = new Size(480, 240);
            ctrlNotFound1.TabIndex = 2;
            ctrlNotFound1.Visible = false;
            // 
            // ctrlManagementDataGrid1
            // 
            ctrlManagementDataGrid1.BackColor = Color.Transparent;
            ctrlManagementDataGrid1.Dock = DockStyle.Fill;
            ctrlManagementDataGrid1.Location = new Point(0, 136);
            ctrlManagementDataGrid1.Margin = new Padding(0);
            ctrlManagementDataGrid1.Name = "ctrlManagementDataGrid1";
            ctrlManagementDataGrid1.Size = new Size(1116, 542);
            ctrlManagementDataGrid1.TabIndex = 1;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(ctrlPeopleSearch1);
            pnlTopBar.Controls.Add(ctrlManagementActions1);
            pnlTopBar.Controls.Add(btnSelect);
            pnlTopBar.Controls.Add(ctrlPagination1);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1116, 136);
            pnlTopBar.TabIndex = 0;
            // 
            // ctrlPeopleSearch1
            // 
            ctrlPeopleSearch1.BackColor = Color.Transparent;
            ctrlPeopleSearch1.Dock = DockStyle.Top;
            ctrlPeopleSearch1.Location = new Point(0, 0);
            ctrlPeopleSearch1.Margin = new Padding(4, 3, 4, 3);
            ctrlPeopleSearch1.MinimumSize = new Size(715, 86);
            ctrlPeopleSearch1.Name = "ctrlPeopleSearch1";
            ctrlPeopleSearch1.Size = new Size(1116, 86);
            ctrlPeopleSearch1.TabIndex = 0;
            // 
            // ctrlManagementActions1
            // 
            ctrlManagementActions1.BackColor = Color.Transparent;
            ctrlManagementActions1.DeleteEnabled = true;
            ctrlManagementActions1.EditEnabled = true;
            ctrlManagementActions1.Location = new Point(12, 90);
            ctrlManagementActions1.Name = "ctrlManagementActions1";
            ctrlManagementActions1.Size = new Size(170, 42);
            ctrlManagementActions1.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.Transparent;
            btnSelect.BackgroundEndColor = SystemColors.Control;
            btnSelect.BackgroundStartColor = SystemColors.Control;
            btnSelect.BorderColor = Color.DarkGray;
            btnSelect.BorderRadius = 8;
            btnSelect.BorderSize = 1;
            btnSelect.CenterIconWithText = false;
            btnSelect.Cursor = Cursors.Hand;
            btnSelect.EnableHoverAnimation = false;
            btnSelect.EnableIconTinting = false;
            btnSelect.EnableRippleEffect = false;
            btnSelect.EnableShadow = false;
            btnSelect.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSelect.ForeColor = SystemColors.ControlText;
            btnSelect.GradientAngle = 90F;
            btnSelect.HoverAnimationSpeed = 20;
            btnSelect.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSelect.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSelect.HoverIconColor = Color.White;
            btnSelect.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSelect.HoverTextColor = SystemColors.ControlText;
            btnSelect.IconColor = Color.White;
            btnSelect.IconMargin = 10;
            btnSelect.IconOffset = new Point(0, 0);
            btnSelect.IconSize = new Size(16, 16);
            btnSelect.IconSpacing = 5;
            btnSelect.IsLoading = false;
            btnSelect.LeftIcon = null;
            btnSelect.Location = new Point(190, 92);
            btnSelect.MiddleIcon = null;
            btnSelect.Name = "btnSelect";
            btnSelect.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSelect.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSelect.RightIcon = null;
            btnSelect.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSelect.RippleSpeed = 15;
            btnSelect.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSelect.ShadowOffset = new Point(1, 1);
            btnSelect.ShadowSize = 3;
            btnSelect.ShiftOnPress = false;
            btnSelect.Size = new Size(100, 38);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select";
            btnSelect.TextColor = SystemColors.ControlText;
            btnSelect.TextOffset = new Point(0, 0);
            btnSelect.Visible = false;
            // 
            // ctrlPagination1
            // 
            ctrlPagination1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ctrlPagination1.BackColor = Color.Transparent;
            ctrlPagination1.Location = new Point(764, 92);
            ctrlPagination1.MinimumSize = new Size(340, 38);
            ctrlPagination1.Name = "ctrlPagination1";
            ctrlPagination1.Size = new Size(340, 38);
            ctrlPagination1.TabIndex = 4;
            // 
            // frmPeopleManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 720);
            Controls.Add(pnlMain);
            Name = "frmPeopleManagement";
            Text = "DVLD / People Management";
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(pnlMain, 0);
            pnlMain.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}