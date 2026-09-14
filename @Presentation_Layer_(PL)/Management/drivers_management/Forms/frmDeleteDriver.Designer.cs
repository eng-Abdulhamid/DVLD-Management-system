using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmDeleteDriver
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWarning;
        private ctrlDriverCard ctrlDriverCard1;
        private NButton btnDelete;
        private NButton btnCancel;
        private ToolTip toolTip1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblWarning = new Label();
            ctrlDriverCard1 = new ctrlDriverCard();
            btnDelete = new NButton();
            btnCancel = new NButton();
            toolTip1 = new ToolTip(components);
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
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(519, 20);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "⚠ Warning: Are you sure you want to permanently delete this driver record?";
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
            btnDelete.BackgroundEndColor = SystemColors.Control;
            btnDelete.BackgroundStartColor = SystemColors.Control;
            btnDelete.BorderColor = Color.DarkGray;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.EnableHoverAnimation = false;
            btnDelete.EnableIconTinting = false;
            btnDelete.EnableRippleEffect = false;
            btnDelete.EnableShadow = false;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.ControlText;
            btnDelete.GradientAngle = 90F;
            btnDelete.HoverAnimationSpeed = 20;
            btnDelete.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnDelete.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnDelete.HoverIconColor = Color.White;
            btnDelete.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnDelete.HoverTextColor = SystemColors.ControlText;
            btnDelete.IconColor = Color.White;
            btnDelete.IconMargin = 10;
            btnDelete.IconOffset = new Point(0, 0);
            btnDelete.IconSize = new Size(16, 16);
            btnDelete.IconSpacing = 5;
            btnDelete.IsLoading = false;
            btnDelete.LeftIcon = Properties.Resources.bin;
            btnDelete.Location = new Point(515, 450);
            btnDelete.MiddleIcon = null;
            btnDelete.Name = "btnDelete";
            btnDelete.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnDelete.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnDelete.RightIcon = null;
            btnDelete.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnDelete.RippleSpeed = 15;
            btnDelete.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnDelete.ShadowOffset = new Point(1, 1);
            btnDelete.ShadowSize = 3;
            btnDelete.ShiftOnPress = false;
            btnDelete.Size = new Size(148, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Record";
            btnDelete.TextColor = SystemColors.ControlText;
            btnDelete.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.EnableHoverAnimation = false;
            btnCancel.EnableIconTinting = false;
            btnCancel.EnableRippleEffect = false;
            btnCancel.EnableShadow = false;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ControlText;
            btnCancel.GradientAngle = 90F;
            btnCancel.HoverAnimationSpeed = 20;
            btnCancel.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnCancel.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverIconColor = Color.White;
            btnCancel.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverTextColor = SystemColors.ControlText;
            btnCancel.IconColor = Color.White;
            btnCancel.IconMargin = 10;
            btnCancel.IconOffset = new Point(0, 0);
            btnCancel.IconSize = new Size(16, 16);
            btnCancel.IconSpacing = 5;
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(670, 450);
            btnCancel.MiddleIcon = null;
            btnCancel.Name = "btnCancel";
            btnCancel.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnCancel.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnCancel.RightIcon = null;
            btnCancel.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnCancel.RippleSpeed = 15;
            btnCancel.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnCancel.ShadowOffset = new Point(1, 1);
            btnCancel.ShadowSize = 3;
            btnCancel.ShiftOnPress = false;
            btnCancel.Size = new Size(135, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
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