namespace DVLD.PL.PeopleManagement
{
    partial class ctrlAddNewPersonBotton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbAdNewPerson = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdNewPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAdNewPerson
            // 
            this.pbAdNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAdNewPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAdNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdNewPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAdNewPerson.Image = global::DVLD.PL.Properties.Resources.business_application_addmale_useradd_insert_add_user_client_2312__2_;
            this.pbAdNewPerson.Location = new System.Drawing.Point(0, 0);
            this.pbAdNewPerson.Name = "pbAdNewPerson";
            this.pbAdNewPerson.Size = new System.Drawing.Size(73, 63);
            this.pbAdNewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAdNewPerson.TabIndex = 25;
            this.pbAdNewPerson.TabStop = false;
            this.pbAdNewPerson.Click += new System.EventHandler(this.pbAdNewPerson_Click);
            // 
            // ctrlAddNewPersonBotton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbAdNewPerson);
            this.Name = "ctrlAddNewPersonBotton";
            this.Size = new System.Drawing.Size(73, 63);
            ((System.ComponentModel.ISupportInitialize)(this.pbAdNewPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAdNewPerson;
    }
}
