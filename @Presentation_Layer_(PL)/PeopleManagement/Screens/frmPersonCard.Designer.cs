namespace DVLDPL.PeopleManagement
{
    partial class frmPersonCard
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
            this.btnDeleteSelectedPerson = new System.Windows.Forms.PictureBox();
            this.btnUpdateSelectedPerson = new System.Windows.Forms.PictureBox();
            this.ctrlPersonCard1 = new DVLDPL.PeopleManagement.ctrlPersonCard();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteSelectedPerson
            // 
            this.btnDeleteSelectedPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteSelectedPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDeleteSelectedPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSelectedPerson.Image = global::DVLDPL.Properties.Resources.delete_user__1_1;
            this.btnDeleteSelectedPerson.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.btnDeleteSelectedPerson.Location = new System.Drawing.Point(554, 233);
            this.btnDeleteSelectedPerson.Name = "btnDeleteSelectedPerson";
            this.btnDeleteSelectedPerson.Size = new System.Drawing.Size(40, 38);
            this.btnDeleteSelectedPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteSelectedPerson.TabIndex = 30;
            this.btnDeleteSelectedPerson.TabStop = false;
            this.btnDeleteSelectedPerson.Click += new System.EventHandler(this.btnDeleteSelectedPerson_Click);
            // 
            // btnUpdateSelectedPerson
            // 
            this.btnUpdateSelectedPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdateSelectedPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnUpdateSelectedPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSelectedPerson.Image = global::DVLDPL.Properties.Resources.user_edit_21991;
            this.btnUpdateSelectedPerson.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.btnUpdateSelectedPerson.Location = new System.Drawing.Point(496, 233);
            this.btnUpdateSelectedPerson.Name = "btnUpdateSelectedPerson";
            this.btnUpdateSelectedPerson.Size = new System.Drawing.Size(40, 38);
            this.btnUpdateSelectedPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUpdateSelectedPerson.TabIndex = 29;
            this.btnUpdateSelectedPerson.TabStop = false;
            this.btnUpdateSelectedPerson.Click += new System.EventHandler(this.btnUpdateSelectedPerson_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 12);
            this.ctrlPersonCard1.MinimumSize = new System.Drawing.Size(573, 255);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(601, 255);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // frmPersonCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 279);
            this.Controls.Add(this.btnDeleteSelectedPerson);
            this.Controls.Add(this.btnUpdateSelectedPerson);
            this.Controls.Add(this.ctrlPersonCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(628, 322);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(588, 322);
            this.Name = "frmPersonCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Card";
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.PictureBox btnDeleteSelectedPerson;
        private System.Windows.Forms.PictureBox btnUpdateSelectedPerson;
    }
}