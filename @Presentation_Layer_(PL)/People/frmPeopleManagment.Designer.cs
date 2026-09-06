using System.Windows.Forms;

namespace DVLD.PL
{
    public partial class frmPeopleManagment : Form
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
            this.ctrlListPeople1 = new DVLD.PL.ctrlListPeople();
            this.ctrlPeopleSearch1 = new DVLD.PL.ctrlPeopleSearch();
            this.SuspendLayout();
            // 
            // ctrlListPeople1
            // 
            this.ctrlListPeople1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListPeople1.Location = new System.Drawing.Point(0, 64);
            this.ctrlListPeople1.Name = "ctrlListPeople1";
            this.ctrlListPeople1.OnSelect = null;
            this.ctrlListPeople1.Size = new System.Drawing.Size(1299, 630);
            this.ctrlListPeople1.TabIndex = 3;
            this.ctrlListPeople1.Load += new System.EventHandler(this.ctrlListPeople1_Load);
            // 
            // ctrlPeopleSearch1
            // 
            this.ctrlPeopleSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPeopleSearch1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPeopleSearch1.MinimumSize = new System.Drawing.Size(866, 64);
            this.ctrlPeopleSearch1.Name = "ctrlPeopleSearch1";
            this.ctrlPeopleSearch1.Size = new System.Drawing.Size(1299, 64);
            this.ctrlPeopleSearch1.TabIndex = 2;
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 694);
            this.Controls.Add(this.ctrlListPeople1);
            this.Controls.Add(this.ctrlPeopleSearch1);
            this.Name = "frmListPeople";
            this.Text = "frmListItems";
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlPeopleSearch ctrlPeopleSearch1;
        private ctrlListPeople ctrlListPeople1;
    }
}