using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmDeleteDriver
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWarning;
        private ctrlDriverCard ctrlDriverCard1;
        private NButton btnDelete;
        private NButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWarning = new Label();
            ctrlDriverCard1 = new ctrlDriverCard();
            btnDelete = new NButton();
            btnCancel = new NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(826, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Delete Driver";
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
            lblWarning.Location = new Point(25, 55);
            lblWarning.Size = new Size(519, 20);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "Warning: Are you sure you want to permanently delete this driver record?";
            // 
            // ctrlDriverCard1
            // 
            ctrlDriverCard1.BackColor = Color.Transparent;
            ctrlDriverCard1.Location = new Point(25, 88);
            ctrlDriverCard1.Name = "ctrlDriverCard1";
            ctrlDriverCard1.Size = new Size(780, 350);
            ctrlDriverCard1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDelete.IsLoading = false;
            btnDelete.LeftIcon = Properties.Resources.bin;
            btnDelete.Location = new Point(515, 450);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Record";
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
            btnCancel.Location = new Point(670, 450);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            // 
            // frmDeleteDriver
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 510);
            Controls.Add(ctrlDriverCard1);
            Controls.Add(lblWarning);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Name = "frmDeleteDriver";
            Text = "DVLD / Drivers Management / Delete Driver";
            Load += frmDeleteDriver_Load;
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(lblWarning, 0);
            Controls.SetChildIndex(ctrlDriverCard1, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}