using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.PeopleManagement
{
    partial class frmPersonCard
    {
        private System.ComponentModel.IContainer components = null;
        private ctrlPersonCard ctrlPersonCard1;
        private NButton btnEdit;

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
            ctrlPersonCard1 = new ctrlPersonCard();
            btnEdit = new NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(826, 38);
            headerControl.TitleText = "DVLD / People Management / Person Details";
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(22, 54);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(780, 260);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.BackgroundEndColor = SystemColors.Control;
            btnEdit.BackgroundStartColor = SystemColors.Control;
            btnEdit.BorderColor = Color.DarkGray;
            btnEdit.BorderRadius = 8;
            btnEdit.BorderSize = 0;
            btnEdit.ButtonType = enButtonType.Primary;
            btnEdit.CenterIconWithText = true;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnEdit.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnEdit.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnEdit.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnEdit.EnableHoverAnimation = false;
            btnEdit.EnableIconTinting = false;
            btnEdit.EnableRippleEffect = false;
            btnEdit.EnableShadow = false;
            btnEdit.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = SystemColors.ControlText;
            btnEdit.GradientAngle = 90F;
            btnEdit.HoverAnimationSpeed = 20;
            btnEdit.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnEdit.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnEdit.HoverIconColor = Color.White;
            btnEdit.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnEdit.HoverTextColor = SystemColors.ControlText;
            btnEdit.IconColor = Color.White;
            btnEdit.IconMargin = 10;
            btnEdit.IconOffset = new Point(0, 0);
            btnEdit.IconSize = new Size(20, 20);
            btnEdit.IconSpacing = 5;
            btnEdit.IsLoading = false;
            btnEdit.LeftIcon = null;
            btnEdit.Location = new Point(760, 54);
            btnEdit.MiddleIcon = Properties.Resources.edit_person;
            btnEdit.Name = "btnEdit";
            btnEdit.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnEdit.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnEdit.RightIcon = null;
            btnEdit.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnEdit.RippleSpeed = 15;
            btnEdit.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnEdit.ShadowOffset = new Point(1, 1);
            btnEdit.ShadowSize = 3;
            btnEdit.ShiftOnPress = false;
            btnEdit.Size = new Size(42, 38);
            btnEdit.TabIndex = 1;
            btnEdit.TextColor = SystemColors.ControlText;
            btnEdit.TextOffset = new Point(0, 0);
            // 
            // frmPersonCard
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 335);
            Controls.Add(btnEdit);
            Controls.Add(ctrlPersonCard1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(830, 335);
            Name = "frmPersonCard";
            Text = "DVLD / People Management / Person Details";
            Load += frmPersonCard_Load;
            Controls.SetChildIndex(ctrlPersonCard1, 0);
            Controls.SetChildIndex(btnEdit, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
    }
}