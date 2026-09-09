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
            ctrlManagementDataGrid1 = new DVLD.PL.Management.ctrlManagementDataGrid();
            pnlTopBar = new Panel();
            pnlMain.SuspendLayout();
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
            pnlMain.Controls.Add(ctrlManagementDataGrid1);
            pnlMain.Controls.Add(pnlTopBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1116, 678);
            pnlMain.TabIndex = 1;
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
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1116, 136);
            pnlTopBar.TabIndex = 0;
            // 
            // frmDriverManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 720);
            Controls.Add(pnlMain);
            Name = "frmDriverManagement";
            Text = "DVLD / Drivers Management";
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(pnlMain, 0);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}