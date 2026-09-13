using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    partial class ctrlDriverCard
    {
        private System.ComponentModel.IContainer components = null;
        private DVLD.PL.PeopleManagement.ctrlPersonCard ctrlPersonCard1;
        private GroupBox gbDriverInfo;
        private Label lblTitleDriverID;
        private Label lblDriverID;
        private Label lblTitleCreatedByUserID;
        private Label lblCreatedByUserID;
        private Label lblTitleCreatedDate;
        private Label lblCreatedDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            gbDriverInfo = new GroupBox();
            lblTitleDriverID = new Label();
            lblDriverID = new Label();
            lblTitleCreatedByUserID = new Label();
            lblCreatedByUserID = new Label();
            lblTitleCreatedDate = new Label();
            lblCreatedDate = new Label();
            gbDriverInfo.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Dock = DockStyle.Top;
            ctrlPersonCard1.Location = new Point(0, 0);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(780, 260);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // gbDriverInfo
            // 
            gbDriverInfo.BackColor = Color.White;
            gbDriverInfo.Controls.Add(lblTitleDriverID);
            gbDriverInfo.Controls.Add(lblDriverID);
            gbDriverInfo.Controls.Add(lblTitleCreatedByUserID);
            gbDriverInfo.Controls.Add(lblCreatedByUserID);
            gbDriverInfo.Controls.Add(lblTitleCreatedDate);
            gbDriverInfo.Controls.Add(lblCreatedDate);
            gbDriverInfo.Dock = DockStyle.Bottom;
            gbDriverInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbDriverInfo.ForeColor = Color.FromArgb(71, 85, 105);
            gbDriverInfo.Location = new Point(0, 265);
            gbDriverInfo.Name = "gbDriverInfo";
            gbDriverInfo.Size = new Size(780, 80);
            gbDriverInfo.TabIndex = 1;
            gbDriverInfo.TabStop = false;
            gbDriverInfo.Text = "Driver Information";
            // 
            // lblTitleDriverID
            // 
            lblTitleDriverID.AutoSize = true;
            lblTitleDriverID.Location = new Point(25, 35);
            lblTitleDriverID.Name = "lblTitleDriverID";
            lblTitleDriverID.Size = new Size(68, 19);
            lblTitleDriverID.TabIndex = 0;
            lblTitleDriverID.Text = "Driver ID:";
            // 
            // lblDriverID
            // 
            lblDriverID.AutoSize = true;
            lblDriverID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDriverID.ForeColor = Color.FromArgb(31, 41, 55);
            lblDriverID.Location = new Point(95, 35);
            lblDriverID.Name = "lblDriverID";
            lblDriverID.Size = new Size(49, 19);
            lblDriverID.TabIndex = 1;
            lblDriverID.Text = "[????]";
            // 
            // lblTitleCreatedByUserID
            // 
            lblTitleCreatedByUserID.AutoSize = true;
            lblTitleCreatedByUserID.Location = new Point(220, 35);
            lblTitleCreatedByUserID.Name = "lblTitleCreatedByUserID";
            lblTitleCreatedByUserID.Size = new Size(80, 19);
            lblTitleCreatedByUserID.TabIndex = 2;
            lblTitleCreatedByUserID.Text = "Created By:";
            // 
            // lblCreatedByUserID
            // 
            lblCreatedByUserID.AutoSize = true;
            lblCreatedByUserID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCreatedByUserID.ForeColor = Color.FromArgb(31, 41, 55);
            lblCreatedByUserID.Location = new Point(305, 35);
            lblCreatedByUserID.Name = "lblCreatedByUserID";
            lblCreatedByUserID.Size = new Size(49, 19);
            lblCreatedByUserID.TabIndex = 3;
            lblCreatedByUserID.Text = "[????]";
            // 
            // lblTitleCreatedDate
            // 
            lblTitleCreatedDate.AutoSize = true;
            lblTitleCreatedDate.Location = new Point(470, 35);
            lblTitleCreatedDate.Name = "lblTitleCreatedDate";
            lblTitleCreatedDate.Size = new Size(94, 19);
            lblTitleCreatedDate.TabIndex = 4;
            lblTitleCreatedDate.Text = "Created Date:";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCreatedDate.ForeColor = Color.FromArgb(31, 41, 55);
            lblCreatedDate.Location = new Point(570, 35);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(49, 19);
            lblCreatedDate.TabIndex = 5;
            lblCreatedDate.Text = "[????]";
            // 
            // ctrlDriverCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(gbDriverInfo);
            Controls.Add(ctrlPersonCard1);
            Name = "ctrlDriverCard";
            Size = new Size(780, 345);
            gbDriverInfo.ResumeLayout(false);
            gbDriverInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}