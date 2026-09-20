using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    partial class frmDriverManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlTopBar;
        private ctrlDriversSearch ctrlDriversSearch1;
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
            ctrlNotFound1 = new DVLD.PL.Management.ctrlNotFound();
            ctrlManagementDataGrid1 = new DVLD.PL.Management.ctrlManagementDataGrid();
            pnlTopBar = new Panel();
            ctrlDriversSearch1 = new ctrlDriversSearch();
            ctrlManagementActions1 = new DVLD.PL.Management.ctrlManagementActions();
            ctrlPagination1 = new DVLD.PL.Management.ctrlPagination();
            pnlMain.SuspendLayout();
            pnlTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(1116, 38);
            headerControl.TitleText = "DVLD / Drivers Management";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(ctrlNotFound1);
            pnlMain.Controls.Add(pnlTopBar);
            pnlMain.Controls.Add(ctrlManagementDataGrid1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1116, 678);
            pnlMain.TabIndex = 1;
            // 
            // ctrlNotFound1
            // 
            ctrlNotFound1.BackColor = Color.White;
            ctrlNotFound1.Location = new Point(326, 247);
            ctrlNotFound1.Name = "ctrlNotFound1";
            ctrlNotFound1.Size = new Size(480, 240);
            ctrlNotFound1.TabIndex = 2;
            ctrlNotFound1.Visible = false;
            // 
            // ctrlManagementDataGrid1
            // 
            ctrlManagementDataGrid1.BackColor = Color.Transparent;
            ctrlManagementDataGrid1.Dock = DockStyle.Fill;
            ctrlManagementDataGrid1.Location = new Point(0, 0);
            ctrlManagementDataGrid1.Margin = new Padding(0);
            ctrlManagementDataGrid1.Name = "ctrlManagementDataGrid1";
            ctrlManagementDataGrid1.Size = new Size(1116, 678);
            ctrlManagementDataGrid1.TabIndex = 1;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.Transparent;
            pnlTopBar.Controls.Add(ctrlDriversSearch1);
            pnlTopBar.Controls.Add(ctrlManagementActions1);
            pnlTopBar.Controls.Add(ctrlPagination1);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1116, 136);
            pnlTopBar.TabIndex = 0;
            // 
            // ctrlDriversSearch1
            // 
            ctrlDriversSearch1.BackColor = Color.Transparent;
            ctrlDriversSearch1.Dock = DockStyle.Top;
            ctrlDriversSearch1.Location = new Point(0, 0);
            ctrlDriversSearch1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriversSearch1.MinimumSize = new Size(715, 86);
            ctrlDriversSearch1.Name = "ctrlDriversSearch1";
            ctrlDriversSearch1.Size = new Size(1116, 86);
            ctrlDriversSearch1.TabIndex = 0;
            // 
            // ctrlManagementActions1
            // 
            ctrlManagementActions1.BackColor = Color.Transparent;
            ctrlManagementActions1.Location = new Point(12, 90);
            ctrlManagementActions1.Name = "ctrlManagementActions1";
            ctrlManagementActions1.Size = new Size(170, 42);
            ctrlManagementActions1.TabIndex = 1;
            // 
            // ctrlPagination1
            // 
            ctrlPagination1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ctrlPagination1.BackColor = Color.White;
            ctrlPagination1.Location = new Point(764, 92);
            ctrlPagination1.MinimumSize = new Size(340, 38);
            ctrlPagination1.Name = "ctrlPagination1";
            ctrlPagination1.Size = new Size(340, 38);
            ctrlPagination1.TabIndex = 2;
            // 
            // frmDriverManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1120, 720);
            Controls.Add(pnlMain);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            Name = "frmDriverManagement";
            Text = "DVLD / Drivers Management";
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(pnlMain, 0);
            pnlMain.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}