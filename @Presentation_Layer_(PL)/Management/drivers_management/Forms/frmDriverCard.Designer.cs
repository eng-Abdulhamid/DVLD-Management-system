using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmDriverCard
    {
        private System.ComponentModel.IContainer components = null;
        private ctrlDriverCard ctrlDriverCard1;
        private NButton btnEditPerson;
        private NButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ctrlDriverCard1 = new ctrlDriverCard();
            btnEditPerson = new NButton();
            btnClose = new NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(820, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Driver Details";
            // 
            // ctrlDriverCard1
            // 
            ctrlDriverCard1.BackColor = Color.Transparent;
            ctrlDriverCard1.Location = new Point(20, 50);
            ctrlDriverCard1.Name = "ctrlDriverCard1";
            ctrlDriverCard1.Size = new Size(780, 350);
            ctrlDriverCard1.TabIndex = 0;
            // 
            // btnEditPerson
            // 
            btnEditPerson.BackColor = Color.Transparent;
            btnEditPerson.BackgroundEndColor = SystemColors.Control;
            btnEditPerson.BackgroundStartColor = SystemColors.Control;
            btnEditPerson.BorderColor = Color.DarkGray;
            btnEditPerson.BorderRadius = 8;
            btnEditPerson.BorderSize = 0;
            btnEditPerson.CenterIconWithText = false;
            btnEditPerson.Cursor = Cursors.Hand;
            btnEditPerson.EnableHoverAnimation = false;
            btnEditPerson.EnableIconTinting = false;
            btnEditPerson.EnableRippleEffect = false;
            btnEditPerson.EnableShadow = false;
            btnEditPerson.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEditPerson.ForeColor = SystemColors.ControlText;
            btnEditPerson.GradientAngle = 90F;
            btnEditPerson.HoverAnimationSpeed = 20;
            btnEditPerson.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnEditPerson.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnEditPerson.HoverIconColor = Color.White;
            btnEditPerson.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnEditPerson.HoverTextColor = SystemColors.ControlText;
            btnEditPerson.IconColor = Color.White;
            btnEditPerson.IconMargin = 10;
            btnEditPerson.IconOffset = new Point(0, 0);
            btnEditPerson.IconSize = new Size(16, 16);
            btnEditPerson.IconSpacing = 5;
            btnEditPerson.IsLoading = false;
            btnEditPerson.LeftIcon = null;
            btnEditPerson.Location = new Point(515, 410);
            btnEditPerson.MiddleIcon = null;
            btnEditPerson.Name = "btnEditPerson";
            btnEditPerson.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnEditPerson.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnEditPerson.RightIcon = null;
            btnEditPerson.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnEditPerson.RippleSpeed = 15;
            btnEditPerson.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnEditPerson.ShadowOffset = new Point(1, 1);
            btnEditPerson.ShadowSize = 3;
            btnEditPerson.ShiftOnPress = false;
            btnEditPerson.Size = new Size(148, 40);
            btnEditPerson.TabIndex = 1;
            btnEditPerson.Text = "Edit Person";
            btnEditPerson.TextColor = SystemColors.ControlText;
            btnEditPerson.TextOffset = new Point(0, 0);
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundEndColor = SystemColors.Control;
            btnClose.BackgroundStartColor = SystemColors.Control;
            btnClose.BorderColor = Color.DarkGray;
            btnClose.BorderRadius = 8;
            btnClose.BorderSize = 1;
            btnClose.CenterIconWithText = false;
            btnClose.Cursor = Cursors.Hand;
            btnClose.EnableHoverAnimation = false;
            btnClose.EnableIconTinting = false;
            btnClose.EnableRippleEffect = false;
            btnClose.EnableShadow = false;
            btnClose.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = SystemColors.ControlText;
            btnClose.GradientAngle = 90F;
            btnClose.HoverAnimationSpeed = 20;
            btnClose.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnClose.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnClose.HoverIconColor = Color.White;
            btnClose.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnClose.HoverTextColor = SystemColors.ControlText;
            btnClose.IconColor = Color.White;
            btnClose.IconMargin = 10;
            btnClose.IconOffset = new Point(0, 0);
            btnClose.IconSize = new Size(16, 16);
            btnClose.IconSpacing = 5;
            btnClose.IsLoading = false;
            btnClose.LeftIcon = null;
            btnClose.Location = new Point(670, 410);
            btnClose.MiddleIcon = null;
            btnClose.Name = "btnClose";
            btnClose.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnClose.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnClose.RightIcon = null;
            btnClose.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnClose.RippleSpeed = 15;
            btnClose.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnClose.ShadowOffset = new Point(1, 1);
            btnClose.ShadowSize = 3;
            btnClose.ShiftOnPress = false;
            btnClose.Size = new Size(130, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextColor = SystemColors.ControlText;
            btnClose.TextOffset = new Point(0, 0);
            // 
            // frmDriverCard
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 470);
            Controls.Add(btnClose);
            Controls.Add(btnEditPerson);
            Controls.Add(ctrlDriverCard1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDriverCard";
            Text = "DVLD / Drivers Management / Driver Details";
            Load += frmDriverCard_Load;
            Controls.SetChildIndex(ctrlDriverCard1, 0);
            Controls.SetChildIndex(btnEditPerson, 0);
            Controls.SetChildIndex(btnClose, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
    }
}