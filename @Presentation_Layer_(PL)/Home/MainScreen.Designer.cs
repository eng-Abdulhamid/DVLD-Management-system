using DVLD.PL.Global;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL
{
    partial class frmMainScreen
    {
        private System.ComponentModel.IContainer components = null;

        // Container Panels
        private Panel pnlContainer;
        private Panel pnlContentArea;
        private MenuStrip menuStrip1;

        // Dashboard Visual Controls
        private Panel pnlDashboard;
        private Panel pnlGreeting;
        private Label lblGreetingTitle;
        private FlowLayoutPanel flowCards;

        // Card 1: People
        private Panel cardPeople;
        private Panel accentBarPeople;
        private Label lblPeopleIcon;
        private Label lblPeopleTitle;
        private Label lblPeopleDesc;
        private Label lblPeopleAction;

        // Card 2: Drivers
        private Panel cardDrivers;
        private Panel accentBarDrivers;
        private Label lblDriversIcon;
        private Label lblDriversTitle;
        private Label lblDriversDesc;
        private Label lblDriversAction;

        // Card 3: Users
        private Panel cardUsers;
        private Panel accentBarUsers;
        private Label lblUsersIcon;
        private Label lblUsersTitle;
        private Label lblUsersDesc;
        private Label lblUsersAction;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //AppSession.OnUserSessionChanged -= UpdateDashboardInfo;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlContentArea = new Panel();
            pnlDashboard = new Panel();
            flowCards = new FlowLayoutPanel();
            cardPeople = new Panel();
            lblPeopleAction = new Label();
            lblPeopleDesc = new Label();
            lblPeopleTitle = new Label();
            lblPeopleIcon = new Label();
            accentBarPeople = new Panel();
            cardDrivers = new Panel();
            lblDriversAction = new Label();
            lblDriversDesc = new Label();
            lblDriversTitle = new Label();
            lblDriversIcon = new Label();
            accentBarDrivers = new Panel();
            cardUsers = new Panel();
            lblUsersAction = new Label();
            lblUsersDesc = new Label();
            lblUsersTitle = new Label();
            lblUsersIcon = new Label();
            accentBarUsers = new Panel();
            pnlGreeting = new Panel();
            lblGreetingTitle = new Label();
            menuStrip1 = new MenuStrip();
            pnlContainer.SuspendLayout();
            pnlContentArea.SuspendLayout();
            pnlDashboard.SuspendLayout();
            flowCards.SuspendLayout();
            cardPeople.SuspendLayout();
            cardDrivers.SuspendLayout();
            cardUsers.SuspendLayout();
            pnlGreeting.SuspendLayout();
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
            pnlContainer.Padding = new Padding(2);
            pnlContainer.Size = new Size(1096, 646);
            pnlContainer.TabIndex = 1;
            // 
            // pnlContentArea
            // 
            pnlContentArea.BackColor = Color.White;
            pnlContentArea.Controls.Add(pnlDashboard);
            pnlContentArea.Controls.Add(menuStrip1);
            pnlContentArea.Dock = DockStyle.Fill;
            pnlContentArea.Location = new Point(2, 2);
            pnlContentArea.Name = "pnlContentArea";
            pnlContentArea.Padding = new Padding(28, 16, 28, 24);
            pnlContentArea.Size = new Size(1092, 642);
            pnlContentArea.TabIndex = 1;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(flowCards);
            pnlDashboard.Controls.Add(pnlGreeting);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(28, 40);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(0, 24, 0, 0);
            pnlDashboard.Size = new Size(1036, 578);
            pnlDashboard.TabIndex = 1;
            // 
            // flowCards
            // 
            flowCards.AutoScroll = true;
            flowCards.Controls.Add(cardPeople);
            flowCards.Controls.Add(cardDrivers);
            flowCards.Controls.Add(cardUsers);
            flowCards.Dock = DockStyle.Fill;
            flowCards.Location = new Point(0, 69);
            flowCards.Name = "flowCards";
            flowCards.Padding = new Padding(0, 16, 0, 0);
            flowCards.Size = new Size(1036, 509);
            flowCards.TabIndex = 1;
            // 
            // cardPeople
            // 
            cardPeople.BackColor = Color.FromArgb(248, 250, 252);
            cardPeople.Controls.Add(lblPeopleAction);
            cardPeople.Controls.Add(lblPeopleDesc);
            cardPeople.Controls.Add(lblPeopleTitle);
            cardPeople.Controls.Add(lblPeopleIcon);
            cardPeople.Controls.Add(accentBarPeople);
            cardPeople.Location = new Point(0, 16);
            cardPeople.Margin = new Padding(0, 0, 20, 20);
            cardPeople.Name = "cardPeople";
            cardPeople.Size = new Size(310, 140);
            cardPeople.TabIndex = 0;
            // 
            // lblPeopleAction
            // 
            lblPeopleAction.AutoSize = true;
            lblPeopleAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPeopleAction.ForeColor = Color.FromArgb(59, 130, 246);
            lblPeopleAction.Location = new Point(18, 108);
            lblPeopleAction.Name = "lblPeopleAction";
            lblPeopleAction.Size = new Size(123, 15);
            lblPeopleAction.TabIndex = 4;
            lblPeopleAction.Text = "Open Management →";
            // 
            // lblPeopleDesc
            // 
            lblPeopleDesc.Font = new Font("Segoe UI", 9F);
            lblPeopleDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblPeopleDesc.Location = new Point(18, 54);
            lblPeopleDesc.Name = "lblPeopleDesc";
            lblPeopleDesc.Size = new Size(276, 42);
            lblPeopleDesc.TabIndex = 3;
            lblPeopleDesc.Text = "Manage personal records, national IDs, and contact info.";
            // 
            // lblPeopleTitle
            // 
            lblPeopleTitle.AutoSize = true;
            lblPeopleTitle.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            lblPeopleTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblPeopleTitle.Location = new Point(62, 20);
            lblPeopleTitle.Name = "lblPeopleTitle";
            lblPeopleTitle.Size = new Size(161, 21);
            lblPeopleTitle.TabIndex = 2;
            lblPeopleTitle.Text = "People Management";
            // 
            // lblPeopleIcon
            // 
            lblPeopleIcon.AutoSize = true;
            lblPeopleIcon.Font = new Font("Segoe UI", 18F);
            lblPeopleIcon.Location = new Point(16, 14);
            lblPeopleIcon.Name = "lblPeopleIcon";
            lblPeopleIcon.Size = new Size(47, 32);
            lblPeopleIcon.TabIndex = 1;
            lblPeopleIcon.Text = "👥";
            // 
            // accentBarPeople
            // 
            accentBarPeople.BackColor = Color.FromArgb(59, 130, 246);
            accentBarPeople.Dock = DockStyle.Left;
            accentBarPeople.Location = new Point(0, 0);
            accentBarPeople.Name = "accentBarPeople";
            accentBarPeople.Size = new Size(4, 140);
            accentBarPeople.TabIndex = 0;
            // 
            // cardDrivers
            // 
            cardDrivers.BackColor = Color.FromArgb(248, 250, 252);
            cardDrivers.Controls.Add(lblDriversAction);
            cardDrivers.Controls.Add(lblDriversDesc);
            cardDrivers.Controls.Add(lblDriversTitle);
            cardDrivers.Controls.Add(lblDriversIcon);
            cardDrivers.Controls.Add(accentBarDrivers);
            cardDrivers.Location = new Point(330, 16);
            cardDrivers.Margin = new Padding(0, 0, 20, 20);
            cardDrivers.Name = "cardDrivers";
            cardDrivers.Size = new Size(310, 140);
            cardDrivers.TabIndex = 1;
            // 
            // lblDriversAction
            // 
            lblDriversAction.AutoSize = true;
            lblDriversAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDriversAction.ForeColor = Color.FromArgb(16, 185, 129);
            lblDriversAction.Location = new Point(18, 108);
            lblDriversAction.Name = "lblDriversAction";
            lblDriversAction.Size = new Size(123, 15);
            lblDriversAction.TabIndex = 4;
            lblDriversAction.Text = "Open Management →";
            // 
            // lblDriversDesc
            // 
            lblDriversDesc.Font = new Font("Segoe UI", 9F);
            lblDriversDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblDriversDesc.Location = new Point(18, 54);
            lblDriversDesc.Name = "lblDriversDesc";
            lblDriversDesc.Size = new Size(276, 42);
            lblDriversDesc.TabIndex = 3;
            lblDriversDesc.Text = "Manage registered drivers and view driving license histories.";
            // 
            // lblDriversTitle
            // 
            lblDriversTitle.AutoSize = true;
            lblDriversTitle.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            lblDriversTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblDriversTitle.Location = new Point(62, 20);
            lblDriversTitle.Name = "lblDriversTitle";
            lblDriversTitle.Size = new Size(162, 21);
            lblDriversTitle.TabIndex = 2;
            lblDriversTitle.Text = "Drivers Management";
            // 
            // lblDriversIcon
            // 
            lblDriversIcon.AutoSize = true;
            lblDriversIcon.Font = new Font("Segoe UI", 18F);
            lblDriversIcon.Location = new Point(16, 14);
            lblDriversIcon.Name = "lblDriversIcon";
            lblDriversIcon.Size = new Size(47, 32);
            lblDriversIcon.TabIndex = 1;
            lblDriversIcon.Text = "🚗";
            // 
            // accentBarDrivers
            // 
            accentBarDrivers.BackColor = Color.FromArgb(16, 185, 129);
            accentBarDrivers.Dock = DockStyle.Left;
            accentBarDrivers.Location = new Point(0, 0);
            accentBarDrivers.Name = "accentBarDrivers";
            accentBarDrivers.Size = new Size(4, 140);
            accentBarDrivers.TabIndex = 0;
            // 
            // cardUsers
            // 
            cardUsers.BackColor = Color.FromArgb(248, 250, 252);
            cardUsers.Controls.Add(lblUsersAction);
            cardUsers.Controls.Add(lblUsersDesc);
            cardUsers.Controls.Add(lblUsersTitle);
            cardUsers.Controls.Add(lblUsersIcon);
            cardUsers.Controls.Add(accentBarUsers);
            cardUsers.Location = new Point(660, 16);
            cardUsers.Margin = new Padding(0, 0, 20, 20);
            cardUsers.Name = "cardUsers";
            cardUsers.Size = new Size(310, 140);
            cardUsers.TabIndex = 2;
            // 
            // lblUsersAction
            // 
            lblUsersAction.AutoSize = true;
            lblUsersAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblUsersAction.ForeColor = Color.FromArgb(124, 58, 237);
            lblUsersAction.Location = new Point(18, 108);
            lblUsersAction.Name = "lblUsersAction";
            lblUsersAction.Size = new Size(123, 15);
            lblUsersAction.TabIndex = 4;
            lblUsersAction.Text = "Open Management →";
            // 
            // lblUsersDesc
            // 
            lblUsersDesc.Font = new Font("Segoe UI", 9F);
            lblUsersDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblUsersDesc.Location = new Point(18, 54);
            lblUsersDesc.Name = "lblUsersDesc";
            lblUsersDesc.Size = new Size(276, 42);
            lblUsersDesc.TabIndex = 3;
            lblUsersDesc.Text = "Control system access, user credentials, and active permissions.";
            // 
            // lblUsersTitle
            // 
            lblUsersTitle.AutoSize = true;
            lblUsersTitle.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            lblUsersTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblUsersTitle.Location = new Point(62, 20);
            lblUsersTitle.Name = "lblUsersTitle";
            lblUsersTitle.Size = new Size(151, 21);
            lblUsersTitle.TabIndex = 2;
            lblUsersTitle.Text = "Users Management";
            // 
            // lblUsersIcon
            // 
            lblUsersIcon.AutoSize = true;
            lblUsersIcon.Font = new Font("Segoe UI", 18F);
            lblUsersIcon.Location = new Point(16, 14);
            lblUsersIcon.Name = "lblUsersIcon";
            lblUsersIcon.Size = new Size(40, 32);
            lblUsersIcon.TabIndex = 1;
            lblUsersIcon.Text = "🛡️";
            // 
            // accentBarUsers
            // 
            accentBarUsers.BackColor = Color.FromArgb(124, 58, 237);
            accentBarUsers.Dock = DockStyle.Left;
            accentBarUsers.Location = new Point(0, 0);
            accentBarUsers.Name = "accentBarUsers";
            accentBarUsers.Size = new Size(4, 140);
            accentBarUsers.TabIndex = 0;
            // 
            // pnlGreeting
            // 
            pnlGreeting.Controls.Add(lblGreetingTitle);
            pnlGreeting.Dock = DockStyle.Top;
            pnlGreeting.Location = new Point(0, 24);
            pnlGreeting.Name = "pnlGreeting";
            pnlGreeting.Size = new Size(1036, 45);
            pnlGreeting.TabIndex = 0;
            // 
            // lblGreetingTitle
            // 
            lblGreetingTitle.AutoSize = true;
            lblGreetingTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreetingTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGreetingTitle.Location = new Point(0, 4);
            lblGreetingTitle.Name = "lblGreetingTitle";
            lblGreetingTitle.Size = new Size(402, 30);
            lblGreetingTitle.TabIndex = 0;
            lblGreetingTitle.Text = "Welcome to DVLD Management System";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Location = new Point(28, 16);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new Size(1036, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // frmMainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContainer);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 580);
            Name = "frmMainScreen";
            Text = "DVLD - Management System";
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContentArea.ResumeLayout(false);
            pnlContentArea.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            flowCards.ResumeLayout(false);
            cardPeople.ResumeLayout(false);
            cardPeople.PerformLayout();
            cardDrivers.ResumeLayout(false);
            cardDrivers.PerformLayout();
            cardUsers.ResumeLayout(false);
            cardUsers.PerformLayout();
            pnlGreeting.ResumeLayout(false);
            pnlGreeting.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}