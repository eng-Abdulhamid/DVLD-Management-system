namespace DVLD.PL.Management.user_management
{
    partial class frmUserCard
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
            ctrlUserCard1 = new DVLD.PL.UsersManagement.ctrlUserCard();
            ctrlUserManagementControls = new ctrlManagementActions();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.BackColor = Color.FromArgb(248, 250, 252);
            headerControl.Size = new Size(796, 38);
            headerControl.TitleText = "frmUserCard";
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.BackColor = Color.Transparent;
            ctrlUserCard1.Location = new Point(10, 46);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new Size(780, 345);
            ctrlUserCard1.TabIndex = 1;
            // 
            // ctrlUserManagementControls
            // 
            ctrlUserManagementControls.AddVisible = false;
            ctrlUserManagementControls.BackColor = Color.Transparent;
            ctrlUserManagementControls.DeleteEnabled = true;
            ctrlUserManagementControls.EditEnabled = true;
            ctrlUserManagementControls.Location = new Point(708, 46);
            ctrlUserManagementControls.Name = "ctrlUserManagementControls";
            ctrlUserManagementControls.RefreshVisible = false;
            ctrlUserManagementControls.Size = new Size(82, 42);
            ctrlUserManagementControls.TabIndex = 2;
            ctrlUserManagementControls.OnAddClick += ctrlUserManagementControls_OnAddClick;
            // 
            // frmUserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 405);
            Controls.Add(ctrlUserManagementControls);
            Controls.Add(ctrlUserCard1);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            Name = "frmUserCard";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "frmUserCard";
            Controls.SetChildIndex(headerControl, 0);
            Controls.SetChildIndex(ctrlUserCard1, 0);
            Controls.SetChildIndex(ctrlUserManagementControls, 0);
            ResumeLayout(false);
        }

        #endregion

        private UsersManagement.ctrlUserCard ctrlUserCard1;
        private ctrlManagementActions ctrlUserManagementControls;
    }
}