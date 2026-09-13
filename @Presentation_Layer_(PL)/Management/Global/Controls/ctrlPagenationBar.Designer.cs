using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.Management
{
    partial class ctrlPagination
    {
        private System.ComponentModel.IContainer components = null;
        private NButton btnPrevPage;
        private NButton btnNextPage;
        private Label lblRowsPerPage;
        private ComboBox cmbPageSize;
        private Label lblPaginationInfo;

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
            btnPrevPage = new NButton();
            btnNextPage = new NButton();
            lblRowsPerPage = new Label();
            cmbPageSize = new ComboBox();
            lblPaginationInfo = new Label();
            SuspendLayout();
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevPage.BackColor = Color.Transparent;
            btnPrevPage.BackgroundEndColor = SystemColors.Control;
            btnPrevPage.BackgroundStartColor = SystemColors.Control;
            btnPrevPage.BorderColor = Color.DarkGray;
            btnPrevPage.BorderRadius = 8;
            btnPrevPage.BorderSize = 1;
            btnPrevPage.CenterIconWithText = true;
            btnPrevPage.Cursor = Cursors.Hand;
            btnPrevPage.EnableHoverAnimation = false;
            btnPrevPage.EnableIconTinting = false;
            btnPrevPage.EnableRippleEffect = false;
            btnPrevPage.EnableShadow = false;
            btnPrevPage.Font = new Font("Segoe UI", 9F);
            btnPrevPage.ForeColor = SystemColors.ControlText;
            btnPrevPage.GradientAngle = 90F;
            btnPrevPage.HoverAnimationSpeed = 20;
            btnPrevPage.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnPrevPage.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnPrevPage.HoverIconColor = Color.White;
            btnPrevPage.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnPrevPage.HoverTextColor = SystemColors.ControlText;
            btnPrevPage.IconColor = Color.White;
            btnPrevPage.IconMargin = 10;
            btnPrevPage.IconOffset = new Point(0, 0);
            btnPrevPage.IconSize = new Size(16, 16);
            btnPrevPage.IconSpacing = 5;
            btnPrevPage.IsLoading = false;
            btnPrevPage.LeftIcon = null;
            btnPrevPage.Location = new Point(255, 3);
            btnPrevPage.MiddleIcon = Properties.Resources.back;
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnPrevPage.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnPrevPage.RightIcon = null;
            btnPrevPage.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnPrevPage.RippleSpeed = 15;
            btnPrevPage.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnPrevPage.ShadowOffset = new Point(1, 1);
            btnPrevPage.ShadowSize = 3;
            btnPrevPage.ShiftOnPress = false;
            btnPrevPage.Size = new Size(38, 32);
            btnPrevPage.TabIndex = 3;
            btnPrevPage.TextColor = SystemColors.ControlText;
            btnPrevPage.TextOffset = new Point(0, 0);
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextPage.BackColor = Color.Transparent;
            btnNextPage.BackgroundEndColor = SystemColors.Control;
            btnNextPage.BackgroundStartColor = SystemColors.Control;
            btnNextPage.BorderColor = Color.DarkGray;
            btnNextPage.BorderRadius = 8;
            btnNextPage.BorderSize = 1;
            btnNextPage.CenterIconWithText = true;
            btnNextPage.Cursor = Cursors.Hand;
            btnNextPage.EnableHoverAnimation = false;
            btnNextPage.EnableIconTinting = false;
            btnNextPage.EnableRippleEffect = false;
            btnNextPage.EnableShadow = false;
            btnNextPage.Font = new Font("Segoe UI", 9F);
            btnNextPage.ForeColor = SystemColors.ControlText;
            btnNextPage.GradientAngle = 90F;
            btnNextPage.HoverAnimationSpeed = 20;
            btnNextPage.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnNextPage.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnNextPage.HoverIconColor = Color.White;
            btnNextPage.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnNextPage.HoverTextColor = SystemColors.ControlText;
            btnNextPage.IconColor = Color.White;
            btnNextPage.IconMargin = 10;
            btnNextPage.IconOffset = new Point(0, 0);
            btnNextPage.IconSize = new Size(16, 16);
            btnNextPage.IconSpacing = 5;
            btnNextPage.IsLoading = false;
            btnNextPage.LeftIcon = null;
            btnNextPage.Location = new Point(298, 3);
            btnNextPage.MiddleIcon = Properties.Resources.forward;
            btnNextPage.Name = "btnNextPage";
            btnNextPage.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnNextPage.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnNextPage.RightIcon = null;
            btnNextPage.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnNextPage.RippleSpeed = 15;
            btnNextPage.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnNextPage.ShadowOffset = new Point(1, 1);
            btnNextPage.ShadowSize = 3;
            btnNextPage.ShiftOnPress = false;
            btnNextPage.Size = new Size(38, 32);
            btnNextPage.TabIndex = 4;
            btnNextPage.TextColor = SystemColors.ControlText;
            btnNextPage.TextOffset = new Point(0, 0);
            // 
            // lblRowsPerPage
            // 
            lblRowsPerPage.AutoSize = true;
            lblRowsPerPage.Font = new Font("Segoe UI", 9.5F);
            lblRowsPerPage.ForeColor = Color.FromArgb(100, 116, 139);
            lblRowsPerPage.Location = new Point(0, 10);
            lblRowsPerPage.Name = "lblRowsPerPage";
            lblRowsPerPage.Size = new Size(74, 17);
            lblRowsPerPage.TabIndex = 0;
            lblRowsPerPage.Text = "Show rows:";
            // 
            // cmbPageSize
            // 
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.FlatStyle = FlatStyle.Flat;
            cmbPageSize.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            cmbPageSize.ForeColor = Color.FromArgb(15, 23, 42);
            cmbPageSize.Location = new Point(78, 6);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(60, 25);
            cmbPageSize.TabIndex = 1;
            // 
            // lblPaginationInfo
            // 
            lblPaginationInfo.AutoSize = true;
            lblPaginationInfo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPaginationInfo.ForeColor = Color.FromArgb(71, 85, 105);
            lblPaginationInfo.Location = new Point(148, 10);
            lblPaginationInfo.Name = "lblPaginationInfo";
            lblPaginationInfo.Size = new Size(54, 17);
            lblPaginationInfo.TabIndex = 2;
            lblPaginationInfo.Text = "0-0 of 0";
            // 
            // ctrlPagination
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnNextPage);
            Controls.Add(btnPrevPage);
            Controls.Add(lblPaginationInfo);
            Controls.Add(cmbPageSize);
            Controls.Add(lblRowsPerPage);
            MinimumSize = new Size(340, 38);
            Name = "ctrlPagination";
            Size = new Size(340, 38);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}