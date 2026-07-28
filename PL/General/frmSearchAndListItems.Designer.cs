namespace DVLDPL
{
    partial class frmSearchAndListItems
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
            this.ctrlSearchItems1 = new DVLDPL.ctrlSearchItems();
            this.ctrlListPeople1 = new DVLDPL.People.ctrlListPeople();
            this.SuspendLayout();
            // 
            // ctrlSearchItems1
            // 
            this.ctrlSearchItems1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlSearchItems1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSearchItems1.MinimumSize = new System.Drawing.Size(918, 63);
            this.ctrlSearchItems1.Name = "ctrlSearchItems1";
            this.ctrlSearchItems1.Size = new System.Drawing.Size(1118, 63);
            this.ctrlSearchItems1.TabIndex = 0;
            // 
            // ctrlListPeople1
            // 
            this.ctrlListPeople1.DataTable = null;
            this.ctrlListPeople1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListPeople1.Location = new System.Drawing.Point(0, 63);
            this.ctrlListPeople1.Name = "ctrlListPeople1";
            this.ctrlListPeople1.OnSelect = null;
            this.ctrlListPeople1.Size = new System.Drawing.Size(1118, 549);
            this.ctrlListPeople1.TabIndex = 1;
            // 
            // frmSearchAndListItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 612);
            this.Controls.Add(this.ctrlListPeople1);
            this.Controls.Add(this.ctrlSearchItems1);
            this.Name = "frmSearchAndListItems";
            this.Text = "frmSearchAndListItems";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSearchItems ctrlSearchItems1;
        private People.ctrlListPeople ctrlListPeople1;
    }
}