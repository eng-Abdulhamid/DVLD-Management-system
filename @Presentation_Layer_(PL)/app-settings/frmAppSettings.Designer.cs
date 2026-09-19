namespace DVLD.PL.Home
{
    partial class frmAppSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabctrlSettings = new TabControl();
            tabTheme = new TabPage();
            tabControl1 = new TabControl();
            tabBtn = new TabPage();
            tabControl2 = new TabControl();
            tabPrimaryButton = new TabPage();
            btnPrimary = new CustomizeControls.NButton();
            label1 = new Label();
            tabSecondaryButton = new TabPage();
            btnSecondary = new CustomizeControls.NButton();
            label2 = new Label();
            tabDisabledButton = new TabPage();
            btnDanger = new CustomizeControls.NButton();
            label3 = new Label();
            tabDangerButton = new TabPage();
            btnDisabled = new CustomizeControls.NButton();
            label4 = new Label();
            tabPage1 = new TabPage();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            tabctrlSettings.SuspendLayout();
            tabTheme.SuspendLayout();
            tabControl1.SuspendLayout();
            tabBtn.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPrimaryButton.SuspendLayout();
            tabSecondaryButton.SuspendLayout();
            tabDisabledButton.SuspendLayout();
            tabDangerButton.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.BackColor = Color.FromArgb(248, 250, 252);
            headerControl.Size = new Size(849, 32);
            headerControl.TitleText = "frmAppSettings";
            // 
            // tabctrlSettings
            // 
            tabctrlSettings.Controls.Add(tabTheme);
            tabctrlSettings.Dock = DockStyle.Fill;
            tabctrlSettings.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabctrlSettings.Location = new Point(2, 2);
            tabctrlSettings.Name = "tabctrlSettings";
            tabctrlSettings.SelectedIndex = 0;
            tabctrlSettings.Size = new Size(849, 533);
            tabctrlSettings.TabIndex = 1;
            // 
            // tabTheme
            // 
            tabTheme.Controls.Add(tabControl1);
            tabTheme.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabTheme.Location = new Point(4, 26);
            tabTheme.Name = "tabTheme";
            tabTheme.Padding = new Padding(3);
            tabTheme.Size = new Size(841, 503);
            tabTheme.TabIndex = 0;
            tabTheme.Text = "Theme";
            tabTheme.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabBtn);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(835, 497);
            tabControl1.TabIndex = 0;
            // 
            // tabBtn
            // 
            tabBtn.Controls.Add(tabControl2);
            tabBtn.Location = new Point(4, 26);
            tabBtn.Name = "tabBtn";
            tabBtn.Padding = new Padding(3);
            tabBtn.Size = new Size(827, 467);
            tabBtn.TabIndex = 0;
            tabBtn.Text = "Buttons";
            tabBtn.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPrimaryButton);
            tabControl2.Controls.Add(tabSecondaryButton);
            tabControl2.Controls.Add(tabDisabledButton);
            tabControl2.Controls.Add(tabDangerButton);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(821, 461);
            tabControl2.TabIndex = 8;
            // 
            // tabPrimaryButton
            // 
            tabPrimaryButton.Controls.Add(label5);
            tabPrimaryButton.Controls.Add(btnPrimary);
            tabPrimaryButton.Controls.Add(label1);
            tabPrimaryButton.Location = new Point(4, 26);
            tabPrimaryButton.Name = "tabPrimaryButton";
            tabPrimaryButton.Padding = new Padding(3);
            tabPrimaryButton.Size = new Size(813, 431);
            tabPrimaryButton.TabIndex = 0;
            tabPrimaryButton.Text = "Primary Button";
            tabPrimaryButton.UseVisualStyleBackColor = true;
            // 
            // btnPrimary
            // 
            btnPrimary.Anchor = AnchorStyles.Top;
            btnPrimary.BackColor = Color.Transparent;
            btnPrimary.BackgroundEndColor = SystemColors.Control;
            btnPrimary.BackgroundStartColor = SystemColors.Control;
            btnPrimary.BorderColor = Color.DarkGray;
            btnPrimary.BorderRadius = 0;
            btnPrimary.BorderSize = 1;
            btnPrimary.CenterIconWithText = false;
            btnPrimary.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnPrimary.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnPrimary.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnPrimary.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnPrimary.EnableHoverAnimation = false;
            btnPrimary.EnableIconTinting = false;
            btnPrimary.EnableRippleEffect = false;
            btnPrimary.EnableShadow = false;
            btnPrimary.Font = new Font("Segoe UI", 9.5F);
            btnPrimary.ForeColor = SystemColors.ControlText;
            btnPrimary.GradientAngle = 90F;
            btnPrimary.HoverAnimationSpeed = 25;
            btnPrimary.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnPrimary.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnPrimary.HoverIconColor = Color.White;
            btnPrimary.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnPrimary.HoverTextColor = SystemColors.ControlText;
            btnPrimary.IconColor = Color.White;
            btnPrimary.IconMargin = 10;
            btnPrimary.IconOffset = new Point(0, 0);
            btnPrimary.IconSize = new Size(16, 16);
            btnPrimary.IconSpacing = 5;
            btnPrimary.IsLoading = false;
            btnPrimary.LeftIcon = null;
            btnPrimary.Location = new Point(279, 37);
            btnPrimary.MiddleIcon = null;
            btnPrimary.Name = "btnPrimary";
            btnPrimary.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnPrimary.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnPrimary.RightIcon = null;
            btnPrimary.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnPrimary.RippleSpeed = 15;
            btnPrimary.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnPrimary.ShadowOffset = new Point(1, 1);
            btnPrimary.ShadowSize = 3;
            btnPrimary.ShiftOnPress = false;
            btnPrimary.Size = new Size(193, 54);
            btnPrimary.TabIndex = 0;
            btnPrimary.Text = "Primary";
            btnPrimary.TextColor = SystemColors.ControlText;
            btnPrimary.TextOffset = new Point(0, 0);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(110, 11);
            label1.Name = "label1";
            label1.Size = new Size(598, 17);
            label1.TabIndex = 1;
            label1.Text = "Primary button uses for important and positive actions such as Save, Add, Next, Submit, and Confirm.";
            // 
            // tabSecondaryButton
            // 
            tabSecondaryButton.Controls.Add(label6);
            tabSecondaryButton.Controls.Add(btnSecondary);
            tabSecondaryButton.Controls.Add(label2);
            tabSecondaryButton.Location = new Point(4, 26);
            tabSecondaryButton.Name = "tabSecondaryButton";
            tabSecondaryButton.Padding = new Padding(3);
            tabSecondaryButton.Size = new Size(813, 431);
            tabSecondaryButton.TabIndex = 1;
            tabSecondaryButton.Text = "Secondary Button";
            tabSecondaryButton.UseVisualStyleBackColor = true;
            // 
            // btnSecondary
            // 
            btnSecondary.Anchor = AnchorStyles.Top;
            btnSecondary.BackColor = Color.Transparent;
            btnSecondary.BackgroundEndColor = SystemColors.Control;
            btnSecondary.BackgroundStartColor = SystemColors.Control;
            btnSecondary.BorderColor = Color.DarkGray;
            btnSecondary.BorderRadius = 0;
            btnSecondary.BorderSize = 1;
            btnSecondary.CenterIconWithText = false;
            btnSecondary.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnSecondary.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnSecondary.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnSecondary.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnSecondary.EnableHoverAnimation = false;
            btnSecondary.EnableIconTinting = false;
            btnSecondary.EnableRippleEffect = false;
            btnSecondary.EnableShadow = false;
            btnSecondary.Font = new Font("Segoe UI", 9.5F);
            btnSecondary.ForeColor = SystemColors.ControlText;
            btnSecondary.GradientAngle = 90F;
            btnSecondary.HoverAnimationSpeed = 25;
            btnSecondary.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSecondary.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSecondary.HoverIconColor = Color.White;
            btnSecondary.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSecondary.HoverTextColor = SystemColors.ControlText;
            btnSecondary.IconColor = Color.White;
            btnSecondary.IconMargin = 10;
            btnSecondary.IconOffset = new Point(0, 0);
            btnSecondary.IconSize = new Size(16, 16);
            btnSecondary.IconSpacing = 5;
            btnSecondary.IsLoading = false;
            btnSecondary.LeftIcon = null;
            btnSecondary.Location = new Point(279, 37);
            btnSecondary.MiddleIcon = null;
            btnSecondary.Name = "btnSecondary";
            btnSecondary.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSecondary.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSecondary.RightIcon = null;
            btnSecondary.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnSecondary.RippleSpeed = 15;
            btnSecondary.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnSecondary.ShadowOffset = new Point(1, 1);
            btnSecondary.ShadowSize = 3;
            btnSecondary.ShiftOnPress = false;
            btnSecondary.Size = new Size(193, 54);
            btnSecondary.TabIndex = 2;
            btnSecondary.Text = "Secondary";
            btnSecondary.TextColor = SystemColors.ControlText;
            btnSecondary.TextOffset = new Point(0, 0);
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(54, 11);
            label2.Name = "label2";
            label2.Size = new Size(717, 17);
            label2.TabIndex = 3;
            label2.Text = "Secondary button uses for regular or optional actions that are not the main action, such as Cancel, Back, View, or Refresh.";
            // 
            // tabDisabledButton
            // 
            tabDisabledButton.Controls.Add(label7);
            tabDisabledButton.Controls.Add(btnDanger);
            tabDisabledButton.Controls.Add(label3);
            tabDisabledButton.Location = new Point(4, 26);
            tabDisabledButton.Name = "tabDisabledButton";
            tabDisabledButton.Size = new Size(813, 431);
            tabDisabledButton.TabIndex = 2;
            tabDisabledButton.Text = "Disabled Button";
            tabDisabledButton.UseVisualStyleBackColor = true;
            // 
            // btnDanger
            // 
            btnDanger.Anchor = AnchorStyles.Top;
            btnDanger.BackColor = Color.Transparent;
            btnDanger.BackgroundEndColor = SystemColors.Control;
            btnDanger.BackgroundStartColor = SystemColors.Control;
            btnDanger.BorderColor = Color.DarkGray;
            btnDanger.BorderRadius = 0;
            btnDanger.BorderSize = 1;
            btnDanger.CenterIconWithText = false;
            btnDanger.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnDanger.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnDanger.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnDanger.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnDanger.EnableHoverAnimation = false;
            btnDanger.EnableIconTinting = false;
            btnDanger.EnableRippleEffect = false;
            btnDanger.EnableShadow = false;
            btnDanger.Font = new Font("Segoe UI", 9.5F);
            btnDanger.ForeColor = SystemColors.ControlText;
            btnDanger.GradientAngle = 90F;
            btnDanger.HoverAnimationSpeed = 25;
            btnDanger.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnDanger.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnDanger.HoverIconColor = Color.White;
            btnDanger.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnDanger.HoverTextColor = SystemColors.ControlText;
            btnDanger.IconColor = Color.White;
            btnDanger.IconMargin = 10;
            btnDanger.IconOffset = new Point(0, 0);
            btnDanger.IconSize = new Size(16, 16);
            btnDanger.IconSpacing = 5;
            btnDanger.IsLoading = false;
            btnDanger.LeftIcon = null;
            btnDanger.Location = new Point(279, 37);
            btnDanger.MiddleIcon = null;
            btnDanger.Name = "btnDanger";
            btnDanger.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnDanger.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnDanger.RightIcon = null;
            btnDanger.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnDanger.RippleSpeed = 15;
            btnDanger.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnDanger.ShadowOffset = new Point(1, 1);
            btnDanger.ShadowSize = 3;
            btnDanger.ShiftOnPress = false;
            btnDanger.Size = new Size(193, 54);
            btnDanger.TabIndex = 4;
            btnDanger.Text = "Danger";
            btnDanger.TextColor = SystemColors.ControlText;
            btnDanger.TextOffset = new Point(0, 0);
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(96, 11);
            label3.Name = "label3";
            label3.Size = new Size(641, 17);
            label3.TabIndex = 5;
            label3.Text = "Danger button uses for sensitive or potentially destructive actions such as Delete, Remove, Disable, or Reset.";
            // 
            // tabDangerButton
            // 
            tabDangerButton.Controls.Add(label8);
            tabDangerButton.Controls.Add(btnDisabled);
            tabDangerButton.Controls.Add(label4);
            tabDangerButton.Location = new Point(4, 26);
            tabDangerButton.Name = "tabDangerButton";
            tabDangerButton.Size = new Size(813, 431);
            tabDangerButton.TabIndex = 3;
            tabDangerButton.Text = "Danger Button";
            tabDangerButton.UseVisualStyleBackColor = true;
            // 
            // btnDisabled
            // 
            btnDisabled.Anchor = AnchorStyles.Top;
            btnDisabled.BackColor = Color.Transparent;
            btnDisabled.BackgroundEndColor = SystemColors.Control;
            btnDisabled.BackgroundStartColor = SystemColors.Control;
            btnDisabled.BorderColor = Color.DarkGray;
            btnDisabled.BorderRadius = 0;
            btnDisabled.BorderSize = 1;
            btnDisabled.CenterIconWithText = false;
            btnDisabled.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnDisabled.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnDisabled.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnDisabled.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnDisabled.EnableHoverAnimation = false;
            btnDisabled.EnableIconTinting = false;
            btnDisabled.EnableRippleEffect = false;
            btnDisabled.EnableShadow = false;
            btnDisabled.Font = new Font("Segoe UI", 9.5F);
            btnDisabled.ForeColor = SystemColors.ControlText;
            btnDisabled.GradientAngle = 90F;
            btnDisabled.HoverAnimationSpeed = 25;
            btnDisabled.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnDisabled.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnDisabled.HoverIconColor = Color.White;
            btnDisabled.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnDisabled.HoverTextColor = SystemColors.ControlText;
            btnDisabled.IconColor = Color.White;
            btnDisabled.IconMargin = 10;
            btnDisabled.IconOffset = new Point(0, 0);
            btnDisabled.IconSize = new Size(16, 16);
            btnDisabled.IconSpacing = 5;
            btnDisabled.IsLoading = false;
            btnDisabled.LeftIcon = null;
            btnDisabled.Location = new Point(279, 37);
            btnDisabled.MiddleIcon = null;
            btnDisabled.Name = "btnDisabled";
            btnDisabled.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnDisabled.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnDisabled.RightIcon = null;
            btnDisabled.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnDisabled.RippleSpeed = 15;
            btnDisabled.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnDisabled.ShadowOffset = new Point(1, 1);
            btnDisabled.ShadowSize = 3;
            btnDisabled.ShiftOnPress = false;
            btnDisabled.Size = new Size(193, 54);
            btnDisabled.TabIndex = 6;
            btnDisabled.Text = "Disabled";
            btnDisabled.TextColor = SystemColors.ControlText;
            btnDisabled.TextOffset = new Point(0, 0);
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(35, 11);
            label4.Name = "label4";
            label4.Size = new Size(744, 17);
            label4.TabIndex = 7;
            label4.Text = "This state when an action is currently unavailable or cannot be performed because the required conditions have not been met.";
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(827, 467);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Notifications";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(279, 94);
            label5.Name = "label5";
            label5.Size = new Size(193, 15);
            label5.TabIndex = 2;
            label5.Text = "You will see changes on this button";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(279, 94);
            label6.Name = "label6";
            label6.Size = new Size(193, 15);
            label6.TabIndex = 4;
            label6.Text = "You will see changes on this button";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(279, 94);
            label7.Name = "label7";
            label7.Size = new Size(193, 15);
            label7.TabIndex = 6;
            label7.Text = "You will see changes on this button";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(279, 94);
            label8.Name = "label8";
            label8.Size = new Size(193, 15);
            label8.TabIndex = 8;
            label8.Text = "You will see changes on this button";
            // 
            // frmAppSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 537);
            Controls.Add(tabctrlSettings);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MinimumSize = new Size(853, 537);
            Name = "frmAppSettings";
            Text = "frmAppSettings";
            Controls.SetChildIndex(tabctrlSettings, 0);
            Controls.SetChildIndex(headerControl, 0);
            tabctrlSettings.ResumeLayout(false);
            tabTheme.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabBtn.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPrimaryButton.ResumeLayout(false);
            tabPrimaryButton.PerformLayout();
            tabSecondaryButton.ResumeLayout(false);
            tabSecondaryButton.PerformLayout();
            tabDisabledButton.ResumeLayout(false);
            tabDisabledButton.PerformLayout();
            tabDangerButton.ResumeLayout(false);
            tabDangerButton.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabctrlSettings;
        private TabPage tabTheme;
        private TabControl tabControl1;
        private TabPage tabBtn;
        private CustomizeControls.NButton btnPrimary;
        private TabPage tabPage1;
        private Label label3;
        private CustomizeControls.NButton btnDanger;
        private Label label2;
        private CustomizeControls.NButton btnSecondary;
        private Label label1;
        private Label label4;
        private CustomizeControls.NButton btnDisabled;
        private TabControl tabControl2;
        private TabPage tabPrimaryButton;
        private TabPage tabSecondaryButton;
        private TabPage tabDisabledButton;
        private TabPage tabDangerButton;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}