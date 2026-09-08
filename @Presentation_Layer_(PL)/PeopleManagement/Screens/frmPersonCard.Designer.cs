using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    partial class frmPersonCard
    {
        private System.ComponentModel.IContainer components = null;
        private ctrlPersonCard ctrlPersonCard1;
        private ModernUI.Controls.NButton btnEdit;
        private ModernUI.Controls.NButton btnDelete;

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
            btnEdit = new ModernUI.Controls.NButton();
            btnDelete = new ModernUI.Controls.NButton();
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
            ctrlPersonCard1.Location = new Point(25, 55);
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
            btnEdit.CenterIconWithText = true;
            btnEdit.Cursor = Cursors.Hand;
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
            btnEdit.IconMargin = 6;
            btnEdit.IconOffset = new Point(0, 0);
            btnEdit.IconSize = new Size(26, 26);
            btnEdit.IconSpacing = 6;
            btnEdit.IsLoading = false;
            btnEdit.LeftIcon = null;
            btnEdit.Location = new Point(705, 55);
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
            btnEdit.Size = new Size(47, 38);
            btnEdit.TabIndex = 1;
            btnEdit.TextColor = SystemColors.ControlText;
            btnEdit.TextOffset = new Point(0, 0);
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
            btnDelete.IconMargin = 6;
            btnDelete.IconOffset = new Point(0, 0);
            btnDelete.IconSize = new Size(26, 26);
            btnDelete.IconSpacing = 6;
            btnDelete.IsLoading = false;
            btnDelete.LeftIcon = null;
            btnDelete.Location = new Point(758, 55);
            btnDelete.MiddleIcon = Properties.Resources.bin;
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
            btnDelete.Size = new Size(47, 38);
            btnDelete.TabIndex = 2;
            btnDelete.TextColor = SystemColors.ControlText;
            btnDelete.TextOffset = new Point(0, 0);
            // 
            // frmPersonCard
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 333);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(ctrlPersonCard1);
            MinimumSize = new Size(830, 333);
            Name = "frmPersonCard";
            Text = "DVLD / People Management / Person Details";
            Load += frmPersonCard_Load;
            Controls.SetChildIndex(ctrlPersonCard1, 0);
            Controls.SetChildIndex(btnEdit, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
    }
}