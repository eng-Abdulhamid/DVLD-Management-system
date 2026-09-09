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
        private NButton btnSettings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            pnlTopBar = new Panel();
            ctrlPeopleSearch1 = new ctrlPeopleSearch();
            ctrlManagementActions1 = new DVLD.PL.Management.ctrlManagementActions();
            ctrlPagination1 = new DVLD.PL.Management.ctrlPagination();
            btnSettings = new NButton();
            ctrlManagementDataGrid1 = new DVLD.PL.Management.ctrlManagementDataGrid();
            ctrlNotFound1 = new DVLD.PL.Management.ctrlNotFound();
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
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(ctrlPeopleSearch1);
            pnlTopBar.Controls.Add(ctrlManagementActions1);
            pnlTopBar.Controls.Add(btnSettings);
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
            ctrlPeopleSearch1.Name = "ctrlPeopleSearch1";
            ctrlPeopleSearch1.Size = new Size(1116, 86);
            ctrlPeopleSearch1.TabIndex = 0;
            // 
            // ctrlManagementActions1
            // 
            ctrlManagementActions1.BackColor = Color.Transparent;
            ctrlManagementActions1.Location = new Point(12, 90);
            ctrlManagementActions1.Name = "ctrlManagementActions1";
            ctrlManagementActions1.Size = new Size(175, 42);
            ctrlManagementActions1.TabIndex = 1;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BorderRadius = 8;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Location = new Point(190, 93);
            btnSettings.MiddleIcon = Properties.Resources.setting;
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(38, 36);
            btnSettings.TabIndex = 2;
            // 
            // ctrlPagination1
            // 
            ctrlPagination1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ctrlPagination1.BackColor = Color.Transparent;
            ctrlPagination1.Location = new Point(764, 92);
            ctrlPagination1.Name = "ctrlPagination1";
            ctrlPagination1.Size = new Size(340, 38);
            ctrlPagination1.TabIndex = 3;
            // 
            // ctrlManagementDataGrid1
            // 
            ctrlManagementDataGrid1.BackColor = Color.Transparent;
            ctrlManagementDataGrid1.Dock = DockStyle.Fill;
            ctrlManagementDataGrid1.Location = new Point(0, 136);
            ctrlManagementDataGrid1.Name = "ctrlManagementDataGrid1";
            ctrlManagementDataGrid1.Size = new Size(1116, 542);
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