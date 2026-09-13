namespace DVLD.PL.Common
{
    partial class frmCurrentUserSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.BackColor = Color.FromArgb(248, 250, 252);
            headerControl.Size = new Size(458, 38);
            headerControl.TitleText = "Title";
            // 
            // frmCurrentUserSettings
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 581);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCurrentUserSettings";
            Text = "Current User Settings";
            ResumeLayout(false);
        }

        #endregion
    }
}