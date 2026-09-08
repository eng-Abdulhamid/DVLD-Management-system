using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL
{
    partial class frmMainScreen
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContainer;
        private Label lblAppName;
        private Label lblAppSubtitle;
        private ModernUI.Controls.NButton btnPeopleManagement;
        private Panel pnlContentArea;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlContentArea = new Panel();
            btnPeopleManagement = new ModernUI.Controls.NButton();
            lblAppSubtitle = new Label();
            lblAppName = new Label();
            pnlContainer.SuspendLayout();
            pnlContentArea.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(1096, 38);
            headerControl.TitleText = "DVLD - Management System";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 250, 252);
            pnlContainer.Controls.Add(pnlContentArea);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(2, 2);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1096, 646);
            pnlContainer.TabIndex = 1;
            // 
            // pnlContentArea
            // 
            pnlContentArea.BackColor = Color.White;
            pnlContentArea.Controls.Add(btnPeopleManagement);
            pnlContentArea.Dock = DockStyle.Fill;
            pnlContentArea.Location = new Point(0, 0);
            pnlContentArea.Name = "pnlContentArea";
            pnlContentArea.Padding = new Padding(36);
            pnlContentArea.Size = new Size(1096, 646);
            pnlContentArea.TabIndex = 1;
            // 
            // btnPeopleManagement
            // 
            btnPeopleManagement.BackColor = Color.Transparent;
            btnPeopleManagement.BackgroundEndColor = Color.FromArgb(30, 41, 59);
            btnPeopleManagement.BackgroundStartColor = Color.FromArgb(30, 41, 59);
            btnPeopleManagement.BorderColor = Color.FromArgb(51, 65, 85);
            btnPeopleManagement.BorderRadius = 8;
            btnPeopleManagement.BorderSize = 1;
            btnPeopleManagement.CenterIconWithText = false;
            btnPeopleManagement.Cursor = Cursors.Hand;
            btnPeopleManagement.EnableHoverAnimation = true;
            btnPeopleManagement.EnableIconTinting = false;
            btnPeopleManagement.EnableRippleEffect = true;
            btnPeopleManagement.EnableShadow = false;
            btnPeopleManagement.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnPeopleManagement.ForeColor = Color.White;
            btnPeopleManagement.GradientAngle = 90F;
            btnPeopleManagement.HoverAnimationSpeed = 20;
            btnPeopleManagement.HoverBorderColor = Color.FromArgb(124, 58, 237);
            btnPeopleManagement.HoverEndColor = Color.FromArgb(109, 40, 217);
            btnPeopleManagement.HoverIconColor = Color.White;
            btnPeopleManagement.HoverStartColor = Color.FromArgb(124, 58, 237);
            btnPeopleManagement.HoverTextColor = Color.White;
            btnPeopleManagement.IconColor = Color.White;
            btnPeopleManagement.IconMargin = 12;
            btnPeopleManagement.IconOffset = new Point(0, 0);
            btnPeopleManagement.IconSize = new Size(22, 22);
            btnPeopleManagement.IconSpacing = 10;
            btnPeopleManagement.IsLoading = false;
            btnPeopleManagement.LeftIcon = null;
            btnPeopleManagement.Location = new Point(3, 66);
            btnPeopleManagement.Name = "btnPeopleManagement";
            btnPeopleManagement.PressedEndColor = Color.FromArgb(91, 33, 182);
            btnPeopleManagement.PressedStartColor = Color.FromArgb(91, 33, 182);
            btnPeopleManagement.RightIcon = null;
            btnPeopleManagement.RippleColor = Color.FromArgb(60, 255, 255, 255);
            btnPeopleManagement.RippleSpeed = 20;
            btnPeopleManagement.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnPeopleManagement.ShadowOffset = new Point(1, 1);
            btnPeopleManagement.ShadowSize = 3;
            btnPeopleManagement.ShiftOnPress = false;
            btnPeopleManagement.Size = new Size(226, 46);
            btnPeopleManagement.TabIndex = 0;
            btnPeopleManagement.Text = "Manage People";
            btnPeopleManagement.TextColor = Color.White;
            btnPeopleManagement.TextOffset = new Point(0, 0);
            btnPeopleManagement.Click += btnPeopleManagement_Click;
            // 
            // lblAppSubtitle
            // 
            lblAppSubtitle.AutoSize = true;
            lblAppSubtitle.Font = new Font("Segoe UI", 8.25F);
            lblAppSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblAppSubtitle.Location = new Point(20, 49);
            lblAppSubtitle.Name = "lblAppSubtitle";
            lblAppSubtitle.Size = new Size(149, 13);
            lblAppSubtitle.TabIndex = 1;
            lblAppSubtitle.Text = "Licensing & Registry System";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(18, 22);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(130, 25);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "DVLD PORTAL";
            // 
            // frmMainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(950, 580);
            Name = "frmMainScreen";
            Text = "DVLD - Management System";
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContentArea.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}