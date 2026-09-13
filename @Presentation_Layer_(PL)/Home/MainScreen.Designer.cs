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
            menuStrip1 = new MenuStrip();
            peopleManagementToolStripMenuItem = new ToolStripMenuItem();
            btnPeopleManagement = new ToolStripMenuItem();
            btnUsersManagement = new ToolStripMenuItem();
            btnDriversManagement = new ToolStripMenuItem();
            lblAppSubtitle = new Label();
            lblAppName = new Label();
            pnlContainer.SuspendLayout();
            pnlContentArea.SuspendLayout();
            menuStrip1.SuspendLayout();
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
            pnlContentArea.Controls.Add(menuStrip1);
            pnlContentArea.Dock = DockStyle.Fill;
            pnlContentArea.Location = new Point(0, 0);
            pnlContentArea.Name = "pnlContentArea";
            pnlContentArea.Padding = new Padding(36);
            pnlContentArea.Size = new Size(1096, 646);
            pnlContentArea.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { peopleManagementToolStripMenuItem });
            menuStrip1.Location = new Point(36, 36);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // peopleManagementToolStripMenuItem
            // 
            peopleManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnPeopleManagement, btnUsersManagement, btnDriversManagement });
            peopleManagementToolStripMenuItem.Name = "peopleManagementToolStripMenuItem";
            peopleManagementToolStripMenuItem.Size = new Size(169, 36);
            peopleManagementToolStripMenuItem.Text = "Management";
            // 
            // btnPeopleManagement
            // 
            btnPeopleManagement.Font = new Font("Segoe UI", 14.25F);
            btnPeopleManagement.Name = "btnPeopleManagement";
            btnPeopleManagement.Size = new Size(260, 30);
            btnPeopleManagement.Text = "People Management";
            btnPeopleManagement.Click += btnPeopleManagement_Click;
            // 
            // btnUsersManagement
            // 
            btnUsersManagement.Font = new Font("Segoe UI", 14.25F);
            btnUsersManagement.Name = "btnUsersManagement";
            btnUsersManagement.Size = new Size(260, 30);
            btnUsersManagement.Text = "Users Mangement";
            btnUsersManagement.Click += btnUsersManagement_Click;
            // 
            // btnDriversManagement
            // 
            btnDriversManagement.Font = new Font("Segoe UI", 14.25F);
            btnDriversManagement.Name = "btnDriversManagement";
            btnDriversManagement.Size = new Size(260, 30);
            btnDriversManagement.Text = "Drivers Mangement";
            btnDriversManagement.Click += btnDriversManagement_Click;
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
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 580);
            Name = "frmMainScreen";
            Text = "DVLD - Management System";
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContentArea.ResumeLayout(false);
            pnlContentArea.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem peopleManagementToolStripMenuItem;
        private ToolStripMenuItem btnPeopleManagement;
        private ToolStripMenuItem btnUsersManagement;
        private ToolStripMenuItem btnDriversManagement;
    }
}