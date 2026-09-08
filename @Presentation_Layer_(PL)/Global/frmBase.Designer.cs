namespace DVLD.PL.Global
{
    partial class frmBase
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
            this.headerControl = new DVLD.PL.Global.ctrlFormHeader();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.AllowClose = true;
            this.headerControl.AllowMaximize = true;
            this.headerControl.AllowMinimize = true;
            this.headerControl.BackColor = System.Drawing.Color.White;
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl.Location = new System.Drawing.Point(2, 2);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(796, 38);
            this.headerControl.TabIndex = 0;
            this.headerControl.TitleText = "Window Title";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.headerControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBase";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        protected DVLD.PL.Global.ctrlFormHeader headerControl;
    }
}