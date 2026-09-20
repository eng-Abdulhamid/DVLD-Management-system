namespace DVLD.PL
{
    partial class ctrlButtonSettingsLayout
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDescription = new Label();
            label5 = new Label();
            btn = new CustomizeControls.NButton();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.Location = new Point(0, 11);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(1079, 30);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(443, 114);
            label5.Name = "label5";
            label5.Size = new Size(193, 15);
            label5.TabIndex = 4;
            label5.Text = "You will see changes on this button";
            // 
            // btn
            // 
            btn.Anchor = AnchorStyles.Top;
            btn.BackColor = Color.Transparent;
            btn.BackgroundEndColor = SystemColors.Control;
            btn.BackgroundStartColor = SystemColors.Control;
            btn.BorderColor = Color.DarkGray;
            btn.BorderRadius = 0;
            btn.BorderSize = 1;
            btn.CenterIconWithText = false;
            btn.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btn.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btn.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btn.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btn.EnableHoverAnimation = false;
            btn.EnableIconTinting = false;
            btn.EnableRippleEffect = false;
            btn.EnableShadow = false;
            btn.Font = new Font("Segoe UI", 9.5F);
            btn.ForeColor = SystemColors.ControlText;
            btn.GradientAngle = 90F;
            btn.HoverAnimationSpeed = 25;
            btn.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btn.HoverEndColor = Color.FromArgb(229, 241, 251);
            btn.HoverIconColor = Color.White;
            btn.HoverStartColor = Color.FromArgb(229, 241, 251);
            btn.HoverTextColor = SystemColors.ControlText;
            btn.IconColor = Color.White;
            btn.IconMargin = 10;
            btn.IconOffset = new Point(0, 0);
            btn.IconSize = new Size(16, 16);
            btn.IconSpacing = 5;
            btn.IsLoading = false;
            btn.LeftIcon = null;
            btn.Location = new Point(442, 50);
            btn.MiddleIcon = null;
            btn.Name = "btn";
            btn.PressedEndColor = Color.FromArgb(204, 228, 247);
            btn.PressedStartColor = Color.FromArgb(204, 228, 247);
            btn.RightIcon = null;
            btn.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btn.RippleSpeed = 15;
            btn.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btn.ShadowOffset = new Point(1, 1);
            btn.ShadowSize = 3;
            btn.ShiftOnPress = false;
            btn.Size = new Size(193, 54);
            btn.TabIndex = 3;
            btn.Text = "Button";
            btn.TextColor = SystemColors.ControlText;
            btn.TextOffset = new Point(0, 0);
            // 
            // ctrlButtonSettingsLayout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btn);
            Controls.Add(lblDescription);
            Name = "ctrlButtonSettingsLayout";
            Size = new Size(1079, 485);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescription;
        private Label label5;
        private CustomizeControls.NButton btn;
    }
}