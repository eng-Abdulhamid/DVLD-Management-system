using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    partial class ctrlUserCard
    {
        private System.ComponentModel.IContainer components = null;
        private DVLD.PL.PeopleManagement.ctrlPersonCard ctrlPersonCard1;
        private GroupBox gbLoginInfo;
        private Label lblTitleUserID;
        private Label lblUserID;
        private Label lblTitleUserName;
        private Label lblUserName;
        private Label lblTitleIsActive;
        private Label lblIsActive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            gbLoginInfo = new GroupBox();
            lblTitleUserID = new Label();
            lblUserID = new Label();
            lblTitleUserName = new Label();
            lblUserName = new Label();
            lblTitleIsActive = new Label();
            lblIsActive = new Label();
            gbLoginInfo.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.Transparent;
            ctrlPersonCard1.Dock = DockStyle.Top;
            ctrlPersonCard1.Location = new Point(0, 0);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(780, 260);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // gbLoginInfo
            // 
            gbLoginInfo.BackColor = Color.Transparent;
            gbLoginInfo.Controls.Add(lblTitleUserID);
            gbLoginInfo.Controls.Add(lblUserID);
            gbLoginInfo.Controls.Add(lblTitleUserName);
            gbLoginInfo.Controls.Add(lblUserName);
            gbLoginInfo.Controls.Add(lblTitleIsActive);
            gbLoginInfo.Controls.Add(lblIsActive);
            gbLoginInfo.Dock = DockStyle.Bottom;
            gbLoginInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbLoginInfo.ForeColor = Color.FromArgb(71, 85, 105);
            gbLoginInfo.Location = new Point(0, 265);
            gbLoginInfo.Name = "gbLoginInfo";
            gbLoginInfo.Size = new Size(780, 80);
            gbLoginInfo.TabIndex = 1;
            gbLoginInfo.TabStop = false;
            gbLoginInfo.Text = "Login Information";
            // 
            // lblTitleUserID
            // 
            lblTitleUserID.AutoSize = true;
            lblTitleUserID.BackColor = Color.Transparent;
            lblTitleUserID.Location = new Point(25, 35);
            lblTitleUserID.Name = "lblTitleUserID";
            lblTitleUserID.Size = new Size(58, 19);
            lblTitleUserID.TabIndex = 0;
            lblTitleUserID.Text = "User ID:";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.BackColor = Color.Transparent;
            lblUserID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblUserID.ForeColor = Color.FromArgb(31, 41, 55);
            lblUserID.Location = new Point(95, 35);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(43, 19);
            lblUserID.TabIndex = 1;
            lblUserID.Text = "[????]";
            // 
            // lblTitleUserName
            // 
            lblTitleUserName.AutoSize = true;
            lblTitleUserName.BackColor = Color.Transparent;
            lblTitleUserName.Location = new Point(245, 35);
            lblTitleUserName.Name = "lblTitleUserName";
            lblTitleUserName.Size = new Size(74, 19);
            lblTitleUserName.TabIndex = 2;
            lblTitleUserName.Text = "Username:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(31, 41, 55);
            lblUserName.Location = new Point(330, 35);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(43, 19);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "[????]";
            // 
            // lblTitleIsActive
            // 
            lblTitleIsActive.AutoSize = true;
            lblTitleIsActive.BackColor = Color.Transparent;
            lblTitleIsActive.Location = new Point(510, 35);
            lblTitleIsActive.Name = "lblTitleIsActive";
            lblTitleIsActive.Size = new Size(65, 19);
            lblTitleIsActive.TabIndex = 4;
            lblTitleIsActive.Text = "Is Active:";
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.BackColor = Color.Transparent;
            lblIsActive.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblIsActive.ForeColor = Color.FromArgb(31, 41, 55);
            lblIsActive.Location = new Point(585, 35);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(43, 19);
            lblIsActive.TabIndex = 5;
            lblIsActive.Text = "[????]";
            // 
            // ctrlUserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(gbLoginInfo);
            Controls.Add(ctrlPersonCard1);
            Name = "ctrlUserCard";
            Size = new Size(780, 345);
            gbLoginInfo.ResumeLayout(false);
            gbLoginInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}