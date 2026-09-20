using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Management
{
    partial class ctrlNotFound
    {
        private System.ComponentModel.IContainer components = null;
        private NButton btnClearFilter;
        private Label lblEmptyDesc;
        private Label lblEmptyTitle;
        private Label lblEmptyIcon;

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
            btnClearFilter = new NButton();
            lblEmptyDesc = new Label();
            lblEmptyTitle = new Label();
            lblEmptyIcon = new Label();
            SuspendLayout();
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.Transparent;
            btnClearFilter.BackgroundEndColor = SystemColors.Control;
            btnClearFilter.BackgroundStartColor = SystemColors.Control;
            btnClearFilter.BorderColor = Color.DarkGray;
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.BorderSize = 1;
            btnClearFilter.ButtonType = enButtonType.Secondary;
            btnClearFilter.CenterIconWithText = false;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnClearFilter.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnClearFilter.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnClearFilter.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnClearFilter.EnableHoverAnimation = false;
            btnClearFilter.EnableIconTinting = false;
            btnClearFilter.EnableRippleEffect = false;
            btnClearFilter.EnableShadow = false;
            btnClearFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearFilter.ForeColor = SystemColors.ControlText;
            btnClearFilter.GradientAngle = 90F;
            btnClearFilter.HoverAnimationSpeed = 25;
            btnClearFilter.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnClearFilter.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnClearFilter.HoverIconColor = Color.White;
            btnClearFilter.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnClearFilter.HoverTextColor = SystemColors.ControlText;
            btnClearFilter.IconColor = Color.White;
            btnClearFilter.IconMargin = 10;
            btnClearFilter.IconOffset = new Point(0, 0);
            btnClearFilter.IconSize = new Size(16, 16);
            btnClearFilter.IconSpacing = 5;
            btnClearFilter.IsLoading = false;
            btnClearFilter.LeftIcon = null;
            btnClearFilter.Location = new Point(180, 180);
            btnClearFilter.MiddleIcon = null;
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnClearFilter.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnClearFilter.RightIcon = null;
            btnClearFilter.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnClearFilter.RippleSpeed = 15;
            btnClearFilter.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnClearFilter.ShadowOffset = new Point(1, 1);
            btnClearFilter.ShadowSize = 3;
            btnClearFilter.ShiftOnPress = false;
            btnClearFilter.Size = new Size(120, 36);
            btnClearFilter.TabIndex = 3;
            btnClearFilter.Text = "Clear Filters";
            btnClearFilter.TextColor = SystemColors.ControlText;
            btnClearFilter.TextOffset = new Point(0, 0);
            // 
            // lblEmptyDesc
            // 
            lblEmptyDesc.Font = new Font("Segoe UI", 9.5F);
            lblEmptyDesc.Location = new Point(20, 130);
            lblEmptyDesc.Name = "lblEmptyDesc";
            lblEmptyDesc.Size = new Size(440, 40);
            lblEmptyDesc.TabIndex = 2;
            lblEmptyDesc.Text = "We couldn't find anyone matching your search criteria. Try modifying your filters.";
            lblEmptyDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyTitle
            // 
            lblEmptyTitle.AutoSize = true;
            lblEmptyTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmptyTitle.Location = new Point(135, 100);
            lblEmptyTitle.Name = "lblEmptyTitle";
            lblEmptyTitle.Size = new Size(219, 21);
            lblEmptyTitle.TabIndex = 1;
            lblEmptyTitle.Text = "No Matching Records Found";
            lblEmptyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyIcon
            // 
            lblEmptyIcon.AutoSize = true;
            lblEmptyIcon.Font = new Font("Segoe UI Emoji", 40F);
            lblEmptyIcon.Location = new Point(195, 20);
            lblEmptyIcon.Name = "lblEmptyIcon";
            lblEmptyIcon.Size = new Size(104, 72);
            lblEmptyIcon.TabIndex = 0;
            lblEmptyIcon.Text = "🔍";
            lblEmptyIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ctrlNotFound
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnClearFilter);
            Controls.Add(lblEmptyDesc);
            Controls.Add(lblEmptyTitle);
            Controls.Add(lblEmptyIcon);
            Name = "ctrlNotFound";
            Size = new Size(480, 230);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}