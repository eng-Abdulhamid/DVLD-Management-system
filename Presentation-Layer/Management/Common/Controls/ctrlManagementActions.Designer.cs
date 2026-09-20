using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Management
{
    partial class ctrlManagementActions
    {
        private System.ComponentModel.IContainer components = null;
        private NButton btnAddNew;
        private NButton btnUpdate;
        private NButton btnDelete;
        private NButton btnRefresh;
        private ToolTip toolTip1;

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
            components = new System.ComponentModel.Container();
            btnAddNew = new NButton();
            btnUpdate = new NButton();
            btnDelete = new NButton();
            btnRefresh = new NButton();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.Transparent;
            btnAddNew.BackgroundEndColor = SystemColors.Control;
            btnAddNew.BackgroundStartColor = SystemColors.Control;
            btnAddNew.BorderColor = Color.DarkGray;
            btnAddNew.BorderRadius = 8;
            btnAddNew.BorderSize = 0;
            btnAddNew.ButtonType = enButtonType.Secondary;
            btnAddNew.CenterIconWithText = true;
            btnAddNew.Cursor = Cursors.Hand;
            btnAddNew.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnAddNew.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnAddNew.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnAddNew.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnAddNew.EnableHoverAnimation = false;
            btnAddNew.EnableIconTinting = false;
            btnAddNew.EnableRippleEffect = false;
            btnAddNew.EnableShadow = false;
            btnAddNew.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAddNew.ForeColor = SystemColors.ControlText;
            btnAddNew.GradientAngle = 90F;
            btnAddNew.HoverAnimationSpeed = 25;
            btnAddNew.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnAddNew.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnAddNew.HoverIconColor = Color.White;
            btnAddNew.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnAddNew.HoverTextColor = SystemColors.ControlText;
            btnAddNew.IconColor = Color.White;
            btnAddNew.IconMargin = 10;
            btnAddNew.IconOffset = new Point(0, 0);
            btnAddNew.IconSize = new Size(16, 16);
            btnAddNew.IconSpacing = 5;
            btnAddNew.IsLoading = false;
            btnAddNew.LeftIcon = null;
            btnAddNew.Location = new Point(0, 3);
            btnAddNew.MiddleIcon = Properties.Resources.add_person;
            btnAddNew.Name = "btnAddNew";
            btnAddNew.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnAddNew.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnAddNew.RightIcon = null;
            btnAddNew.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnAddNew.RippleSpeed = 15;
            btnAddNew.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnAddNew.ShadowOffset = new Point(1, 1);
            btnAddNew.ShadowSize = 3;
            btnAddNew.ShiftOnPress = false;
            btnAddNew.Size = new Size(38, 36);
            btnAddNew.TabIndex = 0;
            btnAddNew.TextColor = SystemColors.ControlText;
            btnAddNew.TextOffset = new Point(0, 0);
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.BackgroundEndColor = SystemColors.Control;
            btnUpdate.BackgroundStartColor = SystemColors.Control;
            btnUpdate.BorderColor = Color.DarkGray;
            btnUpdate.BorderRadius = 8;
            btnUpdate.BorderSize = 0;
            btnUpdate.ButtonType = enButtonType.Secondary;
            btnUpdate.CenterIconWithText = true;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnUpdate.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnUpdate.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnUpdate.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnUpdate.EnableHoverAnimation = false;
            btnUpdate.EnableIconTinting = false;
            btnUpdate.EnableRippleEffect = false;
            btnUpdate.EnableShadow = false;
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = SystemColors.ControlText;
            btnUpdate.GradientAngle = 90F;
            btnUpdate.HoverAnimationSpeed = 25;
            btnUpdate.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnUpdate.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnUpdate.HoverIconColor = Color.White;
            btnUpdate.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnUpdate.HoverTextColor = SystemColors.ControlText;
            btnUpdate.IconColor = Color.White;
            btnUpdate.IconMargin = 10;
            btnUpdate.IconOffset = new Point(0, 0);
            btnUpdate.IconSize = new Size(16, 16);
            btnUpdate.IconSpacing = 5;
            btnUpdate.IsLoading = false;
            btnUpdate.LeftIcon = null;
            btnUpdate.Location = new Point(44, 3);
            btnUpdate.MiddleIcon = Properties.Resources.edit_person;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnUpdate.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnUpdate.RightIcon = null;
            btnUpdate.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnUpdate.RippleSpeed = 15;
            btnUpdate.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnUpdate.ShadowOffset = new Point(1, 1);
            btnUpdate.ShadowSize = 3;
            btnUpdate.ShiftOnPress = false;
            btnUpdate.Size = new Size(38, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.TextColor = SystemColors.ControlText;
            btnUpdate.TextOffset = new Point(0, 0);
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BackgroundEndColor = SystemColors.Control;
            btnDelete.BackgroundStartColor = SystemColors.Control;
            btnDelete.BorderColor = Color.DarkGray;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.ButtonType = enButtonType.Secondary;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnDelete.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnDelete.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnDelete.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnDelete.EnableHoverAnimation = false;
            btnDelete.EnableIconTinting = false;
            btnDelete.EnableRippleEffect = false;
            btnDelete.EnableShadow = false;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = SystemColors.ControlText;
            btnDelete.GradientAngle = 90F;
            btnDelete.HoverAnimationSpeed = 25;
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
            btnDelete.LeftIcon = null;
            btnDelete.Location = new Point(88, 3);
            btnDelete.MiddleIcon = Properties.Resources.bin;
            btnDelete.Name = "btnDelete";
            btnDelete.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnDelete.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnDelete.RightIcon = null;
            btnDelete.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnDelete.RippleSpeed = 15;
            btnDelete.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnDelete.ShadowOffset = new Point(1, 1);
            btnDelete.ShadowSize = 3;
            btnDelete.ShiftOnPress = false;
            btnDelete.Size = new Size(38, 36);
            btnDelete.TabIndex = 2;
            btnDelete.TextColor = SystemColors.ControlText;
            btnDelete.TextOffset = new Point(0, 0);
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BackgroundEndColor = SystemColors.Control;
            btnRefresh.BackgroundStartColor = SystemColors.Control;
            btnRefresh.BorderColor = Color.DarkGray;
            btnRefresh.BorderRadius = 8;
            btnRefresh.BorderSize = 0;
            btnRefresh.ButtonType = enButtonType.Secondary;
            btnRefresh.CenterIconWithText = true;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnRefresh.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnRefresh.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnRefresh.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnRefresh.EnableHoverAnimation = false;
            btnRefresh.EnableIconTinting = false;
            btnRefresh.EnableRippleEffect = false;
            btnRefresh.EnableShadow = false;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = SystemColors.ControlText;
            btnRefresh.GradientAngle = 90F;
            btnRefresh.HoverAnimationSpeed = 25;
            btnRefresh.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnRefresh.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnRefresh.HoverIconColor = Color.White;
            btnRefresh.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnRefresh.HoverTextColor = SystemColors.ControlText;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconMargin = 10;
            btnRefresh.IconOffset = new Point(0, 0);
            btnRefresh.IconSize = new Size(16, 16);
            btnRefresh.IconSpacing = 5;
            btnRefresh.IsLoading = false;
            btnRefresh.LeftIcon = null;
            btnRefresh.Location = new Point(132, 3);
            btnRefresh.MiddleIcon = Properties.Resources.refresh;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnRefresh.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnRefresh.RightIcon = null;
            btnRefresh.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnRefresh.RippleSpeed = 15;
            btnRefresh.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnRefresh.ShadowOffset = new Point(1, 1);
            btnRefresh.ShadowSize = 3;
            btnRefresh.ShiftOnPress = false;
            btnRefresh.Size = new Size(38, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.TextColor = SystemColors.ControlText;
            btnRefresh.TextOffset = new Point(0, 0);
            // 
            // ctrlManagementActions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddNew);
            Name = "ctrlManagementActions";
            Size = new Size(170, 42);
            ResumeLayout(false);
        }
    }
}