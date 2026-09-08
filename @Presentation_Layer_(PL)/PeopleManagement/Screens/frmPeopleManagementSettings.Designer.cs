namespace DVLD.PL.PeopleManagement
{
    partial class frmPeopleManagementSettings
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
            chkAutoSearch = new NControls.NCheckBox();
            chkConfirmDelete = new NControls.NCheckBox();
            btnSave = new ModernUI.Controls.NButton();
            btnCancel = new ModernUI.Controls.NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(450, 31);
            headerControl.TitleText = "DVLD/Home/People Management/Settings";
            // 
            // chkAutoSearch
            // 
            chkAutoSearch.AnimationSpeed = 25;
            chkAutoSearch.AutoCheck = true;
            chkAutoSearch.BackColor = Color.Transparent;
            chkAutoSearch.BorderRadius = 4;
            chkAutoSearch.BorderSize = 1;
            chkAutoSearch.BoxBackColor = Color.White;
            chkAutoSearch.BoxBorderColor = Color.FromArgb(200, 205, 212);
            chkAutoSearch.BoxSize = 18;
            chkAutoSearch.CheckAlign = NControls.NCheckAlign.Left;
            chkAutoSearch.Checked = true;
            chkAutoSearch.CheckedColor = Color.FromArgb(0, 120, 215);
            chkAutoSearch.CheckMarkColor = Color.White;
            chkAutoSearch.CheckState = CheckState.Checked;
            chkAutoSearch.CheckThickness = 2F;
            chkAutoSearch.DisabledColor = Color.FromArgb(220, 224, 230);
            chkAutoSearch.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkAutoSearch.EnableAnimation = true;
            chkAutoSearch.EnableRipple = false;
            chkAutoSearch.Font = new Font("Segoe UI", 9.5F);
            chkAutoSearch.ForeColor = Color.FromArgb(30, 41, 59);
            chkAutoSearch.HoverBorderColor = Color.FromArgb(0, 120, 215);
            chkAutoSearch.Location = new Point(83, 81);
            chkAutoSearch.Name = "chkAutoSearch";
            chkAutoSearch.RippleColor = Color.FromArgb(40, 0, 120, 215);
            chkAutoSearch.Size = new Size(290, 24);
            chkAutoSearch.Style = NControls.NCheckBoxStyle.Rounded;
            chkAutoSearch.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkAutoSearch.SwitchThumbColor = Color.White;
            chkAutoSearch.SwitchWidth = 38;
            chkAutoSearch.TabIndex = 1;
            chkAutoSearch.Text = "Enable search as you type";
            chkAutoSearch.TextSpacing = 8;
            chkAutoSearch.ThreeState = false;
            // 
            // chkConfirmDelete
            // 
            chkConfirmDelete.AnimationSpeed = 25;
            chkConfirmDelete.AutoCheck = true;
            chkConfirmDelete.BackColor = Color.Transparent;
            chkConfirmDelete.BorderRadius = 4;
            chkConfirmDelete.BorderSize = 1;
            chkConfirmDelete.BoxBackColor = Color.White;
            chkConfirmDelete.BoxBorderColor = Color.FromArgb(200, 205, 212);
            chkConfirmDelete.BoxSize = 18;
            chkConfirmDelete.CheckAlign = NControls.NCheckAlign.Left;
            chkConfirmDelete.Checked = true;
            chkConfirmDelete.CheckedColor = Color.FromArgb(0, 120, 215);
            chkConfirmDelete.CheckMarkColor = Color.White;
            chkConfirmDelete.CheckState = CheckState.Checked;
            chkConfirmDelete.CheckThickness = 2F;
            chkConfirmDelete.DisabledColor = Color.FromArgb(220, 224, 230);
            chkConfirmDelete.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkConfirmDelete.EnableAnimation = true;
            chkConfirmDelete.EnableRipple = false;
            chkConfirmDelete.Font = new Font("Segoe UI", 9.5F);
            chkConfirmDelete.ForeColor = Color.FromArgb(30, 41, 59);
            chkConfirmDelete.HoverBorderColor = Color.FromArgb(0, 120, 215);
            chkConfirmDelete.Location = new Point(83, 126);
            chkConfirmDelete.Name = "chkConfirmDelete";
            chkConfirmDelete.RippleColor = Color.FromArgb(40, 0, 120, 215);
            chkConfirmDelete.Size = new Size(290, 24);
            chkConfirmDelete.Style = NControls.NCheckBoxStyle.Rounded;
            chkConfirmDelete.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkConfirmDelete.SwitchThumbColor = Color.White;
            chkConfirmDelete.SwitchWidth = 38;
            chkConfirmDelete.TabIndex = 2;
            chkConfirmDelete.Text = "Confirm before deleting records";
            chkConfirmDelete.TextSpacing = 8;
            chkConfirmDelete.ThreeState = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundEndColor = SystemColors.Control;
            btnSave.BackgroundStartColor = SystemColors.Control;
            btnSave.BorderColor = Color.DarkGray;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 1;
            btnSave.CenterIconWithText = false;
            btnSave.EnableHoverAnimation = false;
            btnSave.EnableIconTinting = false;
            btnSave.EnableRippleEffect = false;
            btnSave.EnableShadow = false;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = SystemColors.ControlText;
            btnSave.GradientAngle = 90F;
            btnSave.HoverAnimationSpeed = 20;
            btnSave.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSave.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverIconColor = Color.White;
            btnSave.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverTextColor = SystemColors.ControlText;
            btnSave.IconColor = Color.White;
            btnSave.IconMargin = 10;
            btnSave.IconOffset = new Point(0, 0);
            btnSave.IconSize = new Size(16, 16);
            btnSave.IconSpacing = 5;
            btnSave.IsLoading = false;
            btnSave.LeftIcon = null;
            btnSave.Location = new Point(120, 195);
            btnSave.Name = "btnSave";
            btnSave.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSave.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSave.RightIcon = null;
            btnSave.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSave.RippleSpeed = 15;
            btnSave.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSave.ShadowOffset = new Point(1, 1);
            btnSave.ShadowSize = 3;
            btnSave.ShiftOnPress = false;
            btnSave.Size = new Size(105, 38);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.TextColor = SystemColors.ControlText;
            btnSave.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.EnableHoverAnimation = false;
            btnCancel.EnableIconTinting = false;
            btnCancel.EnableRippleEffect = false;
            btnCancel.EnableShadow = false;
            btnCancel.Font = new Font("Segoe UI", 9F);
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
            btnCancel.Location = new Point(235, 195);
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
            btnCancel.Size = new Size(95, 38);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmPeopleManagementSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(454, 255);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkConfirmDelete);
            Controls.Add(chkAutoSearch);
            Name = "frmPeopleManagementSettings";
            Text = "Preferences";
            Controls.SetChildIndex(chkAutoSearch, 0);
            Controls.SetChildIndex(chkConfirmDelete, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
        private NControls.NCheckBox chkAutoSearch;
        private NControls.NCheckBox chkConfirmDelete;
        private ModernUI.Controls.NButton btnSave;
        private ModernUI.Controls.NButton btnCancel;
    }
}