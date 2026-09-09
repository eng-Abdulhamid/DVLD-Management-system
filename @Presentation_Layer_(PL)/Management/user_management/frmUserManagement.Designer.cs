using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    partial class frmUserManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlTopBar;
        private ctrlUsersSearch ctrlUsersSearch1;
        private DVLD.PL.Management.ctrlManagementDataGrid ctrlManagementDataGrid1;
        private DVLD.PL.Management.ctrlManagementActions ctrlManagementActions1;
        private DVLD.PL.Management.ctrlPagination ctrlPagination1;
        private DVLD.PL.Management.ctrlNotFound ctrlNotFound1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            pnlTopBar = new Panel();
            ctrlUsersSearch1 = new ctrlUsersSearch();
            ctrlManagementActions1 = new DVLD.PL.Management.ctrlManagementActions();
            ctrlPagination1 = new DVLD.PL.Management.ctrlPagination();
            ctrlManagementDataGrid1 = new DVLD.PL.Management.ctrlManagementDataGrid();
            ctrlNotFound1 = new DVLD.PL.Management.ctrlNotFound();
            pnlMain.SuspendLayout();
            pnlTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(1116, 38);
            headerControl.TitleText = "DVLD / Users Management";
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
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(ctrlUsersSearch1);
            pnlTopBar.Controls.Add(ctrlManagementActions1);
            pnlTopBar.Controls.Add(ctrlPagination1);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1116, 108);
            pnlTopBar.TabIndex = 0;
            // 
            // ctrlUsersSearch1
            // 
            ctrlUsersSearch1.BackColor = Color.Transparent;
            ctrlUsersSearch1.Dock = DockStyle.Top;
            ctrlUsersSearch1.Location = new Point(0, 0);
            ctrlUsersSearch1.MinimumSize = new Size(715, 54);
            ctrlUsersSearch1.Name = "ctrlUsersSearch1";
            ctrlUsersSearch1.Size = new Size(1116, 54);
            ctrlUsersSearch1.TabIndex = 0;
            // 
            // ctrlManagementActions1
            // 
            ctrlManagementActions1.BackColor = Color.Transparent;
            ctrlManagementActions1.Location = new Point(12, 58);
            ctrlManagementActions1.Name = "ctrlManagementActions1";
            ctrlManagementActions1.Size = new Size(175, 42);
            ctrlManagementActions1.TabIndex = 1;
            // 
            // ctrlPagination1
            // 
            ctrlPagination1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ctrlPagination1.BackColor = Color.Transparent;
            ctrlPagination1.Location = new Point(764, 60);
            ctrlPagination1.Name = "ctrlPagination1";
            ctrlPagination1.Size = new Size(340, 38);
            ctrlPagination1.TabIndex = 2;
            // 
            // ctrlManagementDataGrid1
            // 
            ctrlManagementDataGrid1.BackColor = Color.Transparent;
            ctrlManagementDataGrid1.Dock = DockStyle.Fill;
            ctrlManagementDataGrid1.Location = new Point(0, 108);
            ctrlManagementDataGrid1.Name = "ctrlManagementDataGrid1";
            ctrlManagementDataGrid1.Size = new Size(1116, 570);
            ctrlManagementDataGrid1.TabIndex = 1;
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
            // frmUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 720);
            Controls.Add(pnlMain);
            Name = "frmUserManagement";
            Text = "DVLD / Users Management";
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(pnlMain, 0);
            pnlMain.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}