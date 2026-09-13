using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.DriversManagement
{
    partial class frmDriverCard
    {
        private System.ComponentModel.IContainer components = null;
        private ctrlDriverCard ctrlDriverCard1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ctrlDriverCard1 = new ctrlDriverCard();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(816, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Driver Details";
            // 
            // ctrlDriverCard1
            // 
            ctrlDriverCard1.BackColor = Color.Transparent;
            ctrlDriverCard1.Location = new Point(20, 50);
            ctrlDriverCard1.Name = "ctrlDriverCard1";
            ctrlDriverCard1.Size = new Size(780, 350);
            ctrlDriverCard1.TabIndex = 0;
            // 
            // frmDriverCard
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 416);
            Controls.Add(ctrlDriverCard1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDriverCard";
            Text = "DVLD / Drivers Management / Driver Details";
            Load += frmDriverCard_Load;
            Controls.SetChildIndex(ctrlDriverCard1, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
    }
}