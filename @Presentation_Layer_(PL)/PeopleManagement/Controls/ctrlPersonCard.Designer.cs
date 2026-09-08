using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    partial class ctrlPersonCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            tlpDetails = new TableLayoutPanel();
            lblTitleID = new Label();
            lblPersonID = new Label();
            lblTitleNationalNo = new Label();
            lblNationalNo = new Label();
            lblTitleGender = new Label();
            lblGender = new Label();
            lblTitleDOB = new Label();
            lblDateOfBirth = new Label();
            lblTitlePhone = new Label();
            lblPhone = new Label();
            lblTitleEmail = new Label();
            lblEmail = new Label();
            lblTitleCountry = new Label();
            lblCountry = new Label();
            lblTitleAddress = new Label();
            lblAddress = new Label();
            lblFullName = new Label();
            pbPersonImage = new PictureBox();
            pnlMain.SuspendLayout();
            tlpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(tlpDetails);
            pnlMain.Controls.Add(lblFullName);
            pnlMain.Controls.Add(pbPersonImage);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(780, 260);
            pnlMain.TabIndex = 0;
            // 
            // tlpDetails
            // 
            tlpDetails.ColumnCount = 4;
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetails.Controls.Add(lblTitleID, 0, 0);
            tlpDetails.Controls.Add(lblPersonID, 1, 0);
            tlpDetails.Controls.Add(lblTitleNationalNo, 2, 0);
            tlpDetails.Controls.Add(lblNationalNo, 3, 0);
            tlpDetails.Controls.Add(lblTitleGender, 0, 1);
            tlpDetails.Controls.Add(lblGender, 1, 1);
            tlpDetails.Controls.Add(lblTitleDOB, 2, 1);
            tlpDetails.Controls.Add(lblDateOfBirth, 3, 1);
            tlpDetails.Controls.Add(lblTitlePhone, 0, 2);
            tlpDetails.Controls.Add(lblPhone, 1, 2);
            tlpDetails.Controls.Add(lblTitleEmail, 2, 2);
            tlpDetails.Controls.Add(lblEmail, 3, 2);
            tlpDetails.Controls.Add(lblTitleCountry, 0, 3);
            tlpDetails.Controls.Add(lblCountry, 1, 3);
            tlpDetails.Controls.Add(lblTitleAddress, 2, 3);
            tlpDetails.Controls.Add(lblAddress, 3, 3);
            tlpDetails.Location = new Point(204, 70);
            tlpDetails.Name = "tlpDetails";
            tlpDetails.RowCount = 4;
            tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpDetails.Size = new Size(550, 160);
            tlpDetails.TabIndex = 2;
            // 
            // lblTitleID
            // 
            lblTitleID.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleID.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleID.Location = new Point(3, 0);
            lblTitleID.Name = "lblTitleID";
            lblTitleID.Size = new Size(100, 23);
            lblTitleID.TabIndex = 0;
            lblTitleID.Text = "Person ID:";
            // 
            // lblPersonID
            // 
            lblPersonID.Font = new Font("Segoe UI", 10.5F);
            lblPersonID.ForeColor = Color.FromArgb(31, 41, 55);
            lblPersonID.Location = new Point(113, 0);
            lblPersonID.Name = "lblPersonID";
            lblPersonID.Size = new Size(100, 23);
            lblPersonID.TabIndex = 1;
            lblPersonID.Text = "[????]";
            // 
            // lblTitleNationalNo
            // 
            lblTitleNationalNo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleNationalNo.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleNationalNo.Location = new Point(278, 0);
            lblTitleNationalNo.Name = "lblTitleNationalNo";
            lblTitleNationalNo.Size = new Size(100, 23);
            lblTitleNationalNo.TabIndex = 2;
            lblTitleNationalNo.Text = "National No:";
            // 
            // lblNationalNo
            // 
            lblNationalNo.Font = new Font("Segoe UI", 10.5F);
            lblNationalNo.ForeColor = Color.FromArgb(31, 41, 55);
            lblNationalNo.Location = new Point(388, 0);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(100, 23);
            lblNationalNo.TabIndex = 3;
            lblNationalNo.Text = "[????]";
            // 
            // lblTitleGender
            // 
            lblTitleGender.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleGender.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleGender.Location = new Point(3, 40);
            lblTitleGender.Name = "lblTitleGender";
            lblTitleGender.Size = new Size(100, 23);
            lblTitleGender.TabIndex = 4;
            lblTitleGender.Text = "Gender:";
            // 
            // lblGender
            // 
            lblGender.Font = new Font("Segoe UI", 10.5F);
            lblGender.ForeColor = Color.FromArgb(31, 41, 55);
            lblGender.Location = new Point(113, 40);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 23);
            lblGender.TabIndex = 5;
            lblGender.Text = "[????]";
            // 
            // lblTitleDOB
            // 
            lblTitleDOB.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleDOB.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleDOB.Location = new Point(278, 40);
            lblTitleDOB.Name = "lblTitleDOB";
            lblTitleDOB.Size = new Size(100, 23);
            lblTitleDOB.TabIndex = 6;
            lblTitleDOB.Text = "Date Of Birth:";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.Font = new Font("Segoe UI", 10.5F);
            lblDateOfBirth.ForeColor = Color.FromArgb(31, 41, 55);
            lblDateOfBirth.Location = new Point(388, 40);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(100, 23);
            lblDateOfBirth.TabIndex = 7;
            lblDateOfBirth.Text = "[????]";
            // 
            // lblTitlePhone
            // 
            lblTitlePhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitlePhone.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitlePhone.Location = new Point(3, 80);
            lblTitlePhone.Name = "lblTitlePhone";
            lblTitlePhone.Size = new Size(100, 23);
            lblTitlePhone.TabIndex = 8;
            lblTitlePhone.Text = "Phone:";
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 10.5F);
            lblPhone.ForeColor = Color.FromArgb(31, 41, 55);
            lblPhone.Location = new Point(113, 80);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "[????]";
            // 
            // lblTitleEmail
            // 
            lblTitleEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleEmail.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleEmail.Location = new Point(278, 80);
            lblTitleEmail.Name = "lblTitleEmail";
            lblTitleEmail.Size = new Size(100, 23);
            lblTitleEmail.TabIndex = 10;
            lblTitleEmail.Text = "Email:";
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10.5F);
            lblEmail.ForeColor = Color.FromArgb(31, 41, 55);
            lblEmail.Location = new Point(388, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "[????]";
            // 
            // lblTitleCountry
            // 
            lblTitleCountry.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleCountry.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleCountry.Location = new Point(3, 120);
            lblTitleCountry.Name = "lblTitleCountry";
            lblTitleCountry.Size = new Size(100, 23);
            lblTitleCountry.TabIndex = 12;
            lblTitleCountry.Text = "Country:";
            // 
            // lblCountry
            // 
            lblCountry.Font = new Font("Segoe UI", 10.5F);
            lblCountry.ForeColor = Color.FromArgb(31, 41, 55);
            lblCountry.Location = new Point(113, 120);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(100, 23);
            lblCountry.TabIndex = 13;
            lblCountry.Text = "[????]";
            // 
            // lblTitleAddress
            // 
            lblTitleAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitleAddress.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitleAddress.Location = new Point(278, 120);
            lblTitleAddress.Name = "lblTitleAddress";
            lblTitleAddress.Size = new Size(100, 23);
            lblTitleAddress.TabIndex = 14;
            lblTitleAddress.Text = "Address:";
            // 
            // lblAddress
            // 
            lblAddress.Font = new Font("Segoe UI", 10.5F);
            lblAddress.ForeColor = Color.FromArgb(31, 41, 55);
            lblAddress.Location = new Point(388, 120);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 15;
            lblAddress.Text = "[????]";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(17, 24, 39);
            lblFullName.Location = new Point(200, 20);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(213, 30);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "No Person Selected";
            // 
            // pbPersonImage
            // 
            pbPersonImage.BackColor = Color.FromArgb(250, 250, 252);
            pbPersonImage.Image = Properties.Resources.User;
            pbPersonImage.Location = new Point(20, 30);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(160, 180);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 0;
            pbPersonImage.TabStop = false;
            // 
            // ctrlPersonCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlMain);
            Name = "ctrlPersonCard";
            Size = new Size(780, 260);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            tlpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;

        private System.Windows.Forms.Label lblTitleID;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblTitleNationalNo;
        private System.Windows.Forms.Label lblNationalNo;

        private System.Windows.Forms.Label lblTitleGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblTitleDOB;
        private System.Windows.Forms.Label lblDateOfBirth;

        private System.Windows.Forms.Label lblTitlePhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblTitleEmail;
        private System.Windows.Forms.Label lblEmail;

        private System.Windows.Forms.Label lblTitleCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblTitleAddress;
        private System.Windows.Forms.Label lblAddress;
    }
}