using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmDriverCard
    {
        private System.ComponentModel.IContainer components = null;
        private ctrlDriverCard ctrlDriverCard1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ctrlDriverCard1 = new ctrlDriverCard();
            ctrlManagementActions1 = new DVLD.PL.Management.ctrlManagementActions();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.BackColor = Color.FromArgb(248, 250, 252);
            headerControl.Size = new Size(816, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Driver Details";
            // 
            // ctrlDriverCard1
            // 
            ctrlDriverCard1.BackColor = Color.Transparent;
            ctrlDriverCard1.Location = new Point(20, 46);
            ctrlDriverCard1.Name = "ctrlDriverCard1";
            ctrlDriverCard1.Size = new Size(780, 329);
            ctrlDriverCard1.TabIndex = 0;
            // 
            // ctrlManagementActions1
            // 
            ctrlManagementActions1.AddVisible = false;
            ctrlManagementActions1.BackColor = Color.Transparent;
            ctrlManagementActions1.DeleteEnabled = true;
            ctrlManagementActions1.DeleteVisible = false;
            ctrlManagementActions1.EditEnabled = true;
            ctrlManagementActions1.Location = new Point(762, 46);
            ctrlManagementActions1.Name = "ctrlManagementActions1";
            ctrlManagementActions1.RefreshVisible = false;
            ctrlManagementActions1.Size = new Size(38, 42);
            ctrlManagementActions1.TabIndex = 5;
            ctrlManagementActions1.OnAddClick += ctrlManagementActions1_OnAddClick;
            // 
            // frmDriverCard
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 392);
            Controls.Add(ctrlManagementActions1);
            Controls.Add(ctrlDriverCard1);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDriverCard";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "DVLD / Drivers Management / Driver Details";
            Load += frmDriverCard_Load;
            Controls.SetChildIndex(ctrlDriverCard1, 0);
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(ctrlManagementActions1, 0);
            ResumeLayout(false);
        }

        private Management.ctrlManagementActions ctrlManagementActions1;
    }
}