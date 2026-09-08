using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    partial class frmDeletePersonForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWarning;
        private ModernUI.Controls.NButton btnDelete;
        private ctrlPersonCard ctrlPersonCard1;
        private ModernUI.Controls.NButton btnCancel;

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
            lblWarning = new Label();
            btnDelete = new ModernUI.Controls.NButton();
            ctrlPersonCard1 = new ctrlPersonCard();
            btnCancel = new ModernUI.Controls.NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(826, 38);
            headerControl.TitleText = "DVLD / People Management / Delete Person";
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
            lblWarning.Location = new Point(25, 55);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(519, 20);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "Warning: Are you sure you want to permanently delete this person record?";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDelete.IconMargin = 6;
            btnDelete.IconOffset = new Point(0, 0);
            btnDelete.IconSize = new Size(18, 18);
            btnDelete.IconSpacing = 6;
            btnDelete.IsLoading = false;
            btnDelete.LeftIcon = Properties.Resources.bin;
            btnDelete.Location = new Point(515, 362);
            btnDelete.MiddleIcon = null;
            btnDelete.Name = "btnDelete";
            btnDelete.RightIcon = null;
            btnDelete.Size = new Size(148, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Record";
            btnDelete.TextOffset = new Point(0, 0);
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(25, 88);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(780, 260);
            ctrlPersonCard1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(670, 362);
            btnCancel.MiddleIcon = null;
            btnCancel.Name = "btnCancel";
            btnCancel.RightIcon = null;
            btnCancel.Size = new Size(135, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmDeletePersonForm
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 420);
            Controls.Add(ctrlPersonCard1);
            Controls.Add(lblWarning);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Name = "frmDeletePersonForm";
            Text = "DVLD / People Management / Delete Person";
            Load += frmDeletePersonForm_Load;
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(lblWarning, 0);
            Controls.SetChildIndex(ctrlPersonCard1, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}