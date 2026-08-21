namespace DVLDPL
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUserManagement = new ModernUI.Controls.NButton();
            this.btnPeopleManagement = new ModernUI.Controls.NButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnUserManagement);
            this.panel1.Controls.Add(this.btnPeopleManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 496);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(279, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(552, 496);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnUserManagement.BackgroundEndColor = System.Drawing.Color.White;
            this.btnUserManagement.BackgroundStartColor = System.Drawing.Color.White;
            this.btnUserManagement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.btnUserManagement.BorderRadius = 6;
            this.btnUserManagement.BorderSize = 2;
            this.btnUserManagement.CenterIconWithText = false;
            this.btnUserManagement.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.EnableHoverAnimation = true;
            this.btnUserManagement.EnableIconTinting = true;
            this.btnUserManagement.EnableRippleEffect = true;
            this.btnUserManagement.EnableShadow = true;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUserManagement.GradientAngle = 200F;
            this.btnUserManagement.HoverAnimationSpeed = 30;
            this.btnUserManagement.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.btnUserManagement.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.btnUserManagement.HoverIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUserManagement.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.btnUserManagement.HoverTextColor = System.Drawing.Color.Black;
            this.btnUserManagement.IconColor = System.Drawing.Color.White;
            this.btnUserManagement.IconMargin = 10;
            this.btnUserManagement.IconOffset = new System.Drawing.Point(1, 2);
            this.btnUserManagement.IconSize = new System.Drawing.Size(45, 40);
            this.btnUserManagement.IconSpacing = 0;
            this.btnUserManagement.LeftIcon = global::DVLDPL.Properties.Resources.UsersManagement;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 61);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.PressedEndColor = System.Drawing.Color.White;
            this.btnUserManagement.PressedStartColor = System.Drawing.Color.White;
            this.btnUserManagement.RightIcon = null;
            this.btnUserManagement.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(138)))));
            this.btnUserManagement.RippleSpeed = 30;
            this.btnUserManagement.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.btnUserManagement.ShadowOffset = new System.Drawing.Point(0, 2);
            this.btnUserManagement.ShadowSize = 3;
            this.btnUserManagement.ShiftOnPress = true;
            this.btnUserManagement.Size = new System.Drawing.Size(279, 61);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "Manage Users";
            this.btnUserManagement.TextColor = System.Drawing.Color.Black;
            this.btnUserManagement.TextOffset = new System.Drawing.Point(0, 0);
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnPeopleManagement
            // 
            this.btnPeopleManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnPeopleManagement.BackgroundEndColor = System.Drawing.Color.White;
            this.btnPeopleManagement.BackgroundStartColor = System.Drawing.Color.White;
            this.btnPeopleManagement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.btnPeopleManagement.BorderRadius = 6;
            this.btnPeopleManagement.BorderSize = 2;
            this.btnPeopleManagement.CenterIconWithText = false;
            this.btnPeopleManagement.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPeopleManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPeopleManagement.EnableHoverAnimation = true;
            this.btnPeopleManagement.EnableIconTinting = true;
            this.btnPeopleManagement.EnableRippleEffect = true;
            this.btnPeopleManagement.EnableShadow = true;
            this.btnPeopleManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeopleManagement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPeopleManagement.GradientAngle = 200F;
            this.btnPeopleManagement.HoverAnimationSpeed = 30;
            this.btnPeopleManagement.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.btnPeopleManagement.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.btnPeopleManagement.HoverIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPeopleManagement.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.btnPeopleManagement.HoverTextColor = System.Drawing.Color.Black;
            this.btnPeopleManagement.IconColor = System.Drawing.Color.White;
            this.btnPeopleManagement.IconMargin = 10;
            this.btnPeopleManagement.IconOffset = new System.Drawing.Point(1, 2);
            this.btnPeopleManagement.IconSize = new System.Drawing.Size(45, 40);
            this.btnPeopleManagement.IconSpacing = 0;
            this.btnPeopleManagement.LeftIcon = global::DVLDPL.Properties.Resources.users_clients_group_167741;
            this.btnPeopleManagement.Location = new System.Drawing.Point(0, 0);
            this.btnPeopleManagement.Name = "btnPeopleManagement";
            this.btnPeopleManagement.PressedEndColor = System.Drawing.Color.White;
            this.btnPeopleManagement.PressedStartColor = System.Drawing.Color.White;
            this.btnPeopleManagement.RightIcon = null;
            this.btnPeopleManagement.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(138)))));
            this.btnPeopleManagement.RippleSpeed = 30;
            this.btnPeopleManagement.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.btnPeopleManagement.ShadowOffset = new System.Drawing.Point(0, 2);
            this.btnPeopleManagement.ShadowSize = 3;
            this.btnPeopleManagement.ShiftOnPress = true;
            this.btnPeopleManagement.Size = new System.Drawing.Size(279, 61);
            this.btnPeopleManagement.TabIndex = 4;
            this.btnPeopleManagement.Text = "Manage People";
            this.btnPeopleManagement.TextColor = System.Drawing.Color.Black;
            this.btnPeopleManagement.TextOffset = new System.Drawing.Point(0, 0);
            this.btnPeopleManagement.Click += new System.EventHandler(this.btnPeopleManagement_Click_1);
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 496);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ModernUI.Controls.NButton btnPeopleManagement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ModernUI.Controls.NButton btnUserManagement;
    }
}