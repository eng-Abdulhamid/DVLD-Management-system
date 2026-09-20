using DVLD.PL.Global;
using DVLD.PL.Management;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL
{
    partial class frmMainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Container Panels
        private Panel pnlContainer;
        private Panel pnlContentArea;
        private MenuStrip menuStrip1;

        // Dashboard
        private Panel pnlDashboard;
        private Panel pnlGreeting;
        private Label lblGreetingTitle;
        private FlowLayoutPanel flowCards;

        // Reusable Action Cards
        private ctrlActionCard cardPeople;
        private ctrlActionCard cardDrivers;
        private ctrlActionCard cardUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
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
            cardPeople = new ctrlActionCard();
            cardDrivers = new ctrlActionCard();
            cardUsers = new ctrlActionCard();
            pnlGreeting = new Panel();
            lblGreetingTitle = new Label();
            menuStrip1 = new MenuStrip();
            pnlContainer.SuspendLayout();
            pnlContentArea.SuspendLayout();
            pnlDashboard.SuspendLayout();
            flowCards.SuspendLayout();
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
            flowCards.Size = new Size(1036, 509);
            flowCards.TabIndex = 1;
            // 
            // cardPeople
            // 
            cardPeople.Accent = enActionCardAccent.Info;
            cardPeople.BackColor = Color.White;
            cardPeople.DescriptionText = "Manage People in the System";
            cardPeople.Icon = null;
            cardPeople.IconColor = Color.Silver;
            cardPeople.IconHoverColor = SystemColors.ActiveCaptionText;
            cardPeople.IconImage = null;
            cardPeople.IconText = "👥";
            cardPeople.Location = new Point(0, 0);
            cardPeople.Margin = new Padding(0, 0, 14, 14);
            cardPeople.MinimumSize = new Size(200, 70);
            cardPeople.Name = "cardPeople";
            cardPeople.Size = new Size(270, 86);
            cardPeople.TabIndex = 0;
            cardPeople.TitleText = "People Management";
            // 
            // cardDrivers
            // 
            cardDrivers.Accent = enActionCardAccent.Success;
            cardDrivers.BackColor = Color.White;
            cardDrivers.DescriptionText = "Manage Drivers in the System";
            cardDrivers.Icon = null;
            cardDrivers.IconColor = Color.Silver;
            cardDrivers.IconHoverColor = SystemColors.ActiveCaptionText;
            cardDrivers.IconImage = null;
            cardDrivers.IconText = "🚗";
            cardDrivers.Location = new Point(284, 0);
            cardDrivers.Margin = new Padding(0, 0, 14, 14);
            cardDrivers.MinimumSize = new Size(200, 70);
            cardDrivers.Name = "cardDrivers";
            cardDrivers.Size = new Size(270, 86);
            cardDrivers.TabIndex = 1;
            cardDrivers.TitleText = "Drivers Management";
            // 
            // cardUsers
            // 
            cardUsers.BackColor = Color.White;
            cardUsers.DescriptionText = "Manage Users in the System.";
            cardUsers.Icon = null;
            cardUsers.IconColor = Color.Silver;
            cardUsers.IconHoverColor = SystemColors.ActiveCaptionText;
            cardUsers.IconImage = null;
            cardUsers.IconText = "🛡";
            cardUsers.Location = new Point(568, 0);
            cardUsers.Margin = new Padding(0, 0, 14, 14);
            cardUsers.MinimumSize = new Size(200, 70);
            cardUsers.Name = "cardUsers";
            cardUsers.Size = new Size(270, 86);
            cardUsers.TabIndex = 2;
            cardUsers.TitleText = "Users Management";
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
            lblGreetingTitle.Location = new Point(28, 4);
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
            // frmMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContainer);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(100, 100);
            Name = "frmMainForm";
            Text = "DVLD - Management System";
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContentArea.ResumeLayout(false);
            pnlContentArea.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            flowCards.ResumeLayout(false);
            pnlGreeting.ResumeLayout(false);
            pnlGreeting.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}