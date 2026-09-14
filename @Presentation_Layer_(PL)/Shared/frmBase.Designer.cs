using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    partial class frmBase
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AppSession.OnUserSessionChanged -= HandleUserSessionChanged;
                UITheme.OnThemeChanged -= HandleThemeChanged; 
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            headerControl = new ctrlFormHeader();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.BackColor = Color.White;
            headerControl.Location = new Point(2, 2);
            headerControl.Name = "headerControl";
            headerControl.Size = new Size(335, 38);
            headerControl.TabIndex = 0;
            headerControl.TitleText = "Window Title";
            // 
            // frmBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(339, 339);
            Controls.Add(headerControl);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(339, 339);
            Name = "frmBase";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        protected DVLD.PL.Global.ctrlFormHeader headerControl;
    }
}