using System.Windows.Forms;

namespace DVLDPL
{
    public partial class frmUsersManagment : Form
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
        public void InitializeComponent()
        {
            this.ctrlUsersSearch1 = new DVLDPL.ctrlUsersSearch();
            this.ctrlListUsers1 = new DVLDPL.ctrlListUsers();
            this.SuspendLayout();
            // 
            // ctrlUsersSearch1
            // 
            this.ctrlUsersSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlUsersSearch1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUsersSearch1.MinimumSize = new System.Drawing.Size(893, 64);
            this.ctrlUsersSearch1.Name = "ctrlUsersSearch1";
            this.ctrlUsersSearch1.Size = new System.Drawing.Size(1299, 70);
            this.ctrlUsersSearch1.TabIndex = 1;
            // 
            // ctrlListUsers1
            // 
            this.ctrlListUsers1.DataTable = null;
            this.ctrlListUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListUsers1.Location = new System.Drawing.Point(0, 70);
            this.ctrlListUsers1.Name = "ctrlListUsers1";
            this.ctrlListUsers1.OnSelect = null;
            this.ctrlListUsers1.Size = new System.Drawing.Size(1299, 624);
            this.ctrlListUsers1.TabIndex = 2;
            // 
            // frmUsersManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 694);
            this.Controls.Add(this.ctrlListUsers1);
            this.Controls.Add(this.ctrlUsersSearch1);
            this.Name = "frmUsersManagment";
            this.Text = "frmListItems";
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlUsersSearch ctrlUsersSearch1;
        private ctrlListUsers ctrlListUsers1;
    }
}