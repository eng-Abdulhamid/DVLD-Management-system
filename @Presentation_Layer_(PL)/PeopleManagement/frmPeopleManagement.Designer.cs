using DTOs;
using DVLD_BusinessLogicLayer;

namespace DVLDPL.PeopleManagement
{
    partial class frmPeopleManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TPersonID = new System.Windows.Forms.ToolStripMenuItem();
            this.TNationalNo = new System.Windows.Forms.ToolStripMenuItem();
            this.TFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.TDateOfBirth = new System.Windows.Forms.ToolStripMenuItem();
            this.TNationality = new System.Windows.Forms.ToolStripMenuItem();
            this.TPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.TEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.TGender = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvResults = new NControls.NDataGrid();
            this.ctrlAddNewPersonBotton1 = new DVLDPL.PeopleManagement.ctrlAddNewPersonBotton();
            this.ctrlPeopleSearch1 = new DVLDPL.PeopleManagement.ctrlPeopleSearch();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnDeleteSelectedPerson = new System.Windows.Forms.PictureBox();
            this.btnUpdateSelectedPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1078, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // columnsToolStripMenuItem1
            // 
            this.columnsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TPersonID,
            this.TNationalNo,
            this.TFullName,
            this.TDateOfBirth,
            this.TNationality,
            this.TPhone,
            this.TEmail,
            this.TGender});
            this.columnsToolStripMenuItem1.Name = "columnsToolStripMenuItem1";
            this.columnsToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.columnsToolStripMenuItem1.Text = "Columns";
            // 
            // TPersonID
            // 
            this.TPersonID.Checked = true;
            this.TPersonID.CheckOnClick = true;
            this.TPersonID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TPersonID.Name = "TPersonID";
            this.TPersonID.Size = new System.Drawing.Size(140, 22);
            this.TPersonID.Text = "Person ID";
            this.TPersonID.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationalNo
            // 
            this.TNationalNo.Checked = true;
            this.TNationalNo.CheckOnClick = true;
            this.TNationalNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationalNo.Name = "TNationalNo";
            this.TNationalNo.Size = new System.Drawing.Size(140, 22);
            this.TNationalNo.Text = "National no.";
            this.TNationalNo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TFullName
            // 
            this.TFullName.Checked = true;
            this.TFullName.CheckOnClick = true;
            this.TFullName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TFullName.Name = "TFullName";
            this.TFullName.Size = new System.Drawing.Size(140, 22);
            this.TFullName.Text = "Full name";
            this.TFullName.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TDateOfBirth
            // 
            this.TDateOfBirth.Checked = true;
            this.TDateOfBirth.CheckOnClick = true;
            this.TDateOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TDateOfBirth.Name = "TDateOfBirth";
            this.TDateOfBirth.Size = new System.Drawing.Size(140, 22);
            this.TDateOfBirth.Text = "Date of birth";
            this.TDateOfBirth.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationality
            // 
            this.TNationality.Checked = true;
            this.TNationality.CheckOnClick = true;
            this.TNationality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationality.Name = "TNationality";
            this.TNationality.Size = new System.Drawing.Size(140, 22);
            this.TNationality.Text = "Nationality";
            this.TNationality.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TPhone
            // 
            this.TPhone.Checked = true;
            this.TPhone.CheckOnClick = true;
            this.TPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TPhone.Name = "TPhone";
            this.TPhone.Size = new System.Drawing.Size(140, 22);
            this.TPhone.Text = "Phone";
            this.TPhone.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TEmail
            // 
            this.TEmail.Checked = true;
            this.TEmail.CheckOnClick = true;
            this.TEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(140, 22);
            this.TEmail.Text = "Email";
            this.TEmail.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TGender
            // 
            this.TGender.Checked = true;
            this.TGender.CheckOnClick = true;
            this.TGender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TGender.Name = "TGender";
            this.TGender.Size = new System.Drawing.Size(140, 22);
            this.TGender.Text = "Gender";
            this.TGender.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.GridColor = System.Drawing.Color.White;
            this.dgvResults.Location = new System.Drawing.Point(0, 164);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.NullValue = "None";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvResults.RowTemplate.Height = 40;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1078, 542);
            this.dgvResults.TabIndex = 22;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // ctrlAddNewPersonBotton1
            // 
            this.ctrlAddNewPersonBotton1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlAddNewPersonBotton1.Location = new System.Drawing.Point(80, 102);
            this.ctrlAddNewPersonBotton1.Name = "ctrlAddNewPersonBotton1";
            this.ctrlAddNewPersonBotton1.Size = new System.Drawing.Size(40, 38);
            this.ctrlAddNewPersonBotton1.TabIndex = 26;
            this.ctrlAddNewPersonBotton1.Load += new System.EventHandler(this.ctrlAddNewPersonBotton1_Load);
            // 
            // ctrlPeopleSearch1
            // 
            this.ctrlPeopleSearch1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPeopleSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPeopleSearch1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlPeopleSearch1.Location = new System.Drawing.Point(0, 24);
            this.ctrlPeopleSearch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlPeopleSearch1.MinimumSize = new System.Drawing.Size(1077, 140);
            this.ctrlPeopleSearch1.Name = "ctrlPeopleSearch1";
            this.ctrlPeopleSearch1.Size = new System.Drawing.Size(1078, 140);
            this.ctrlPeopleSearch1.TabIndex = 21;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::DVLDPL.Properties.Resources.Settings;
            this.btnSettings.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.btnSettings.Location = new System.Drawing.Point(1038, 24);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 38);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSettings.TabIndex = 29;
            this.btnSettings.TabStop = false;
            // 
            // btnDeleteSelectedPerson
            // 
            this.btnDeleteSelectedPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteSelectedPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDeleteSelectedPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSelectedPerson.Image = global::DVLDPL.Properties.Resources.delete_user__1_1;
            this.btnDeleteSelectedPerson.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.btnDeleteSelectedPerson.Location = new System.Drawing.Point(196, 102);
            this.btnDeleteSelectedPerson.Name = "btnDeleteSelectedPerson";
            this.btnDeleteSelectedPerson.Size = new System.Drawing.Size(40, 38);
            this.btnDeleteSelectedPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteSelectedPerson.TabIndex = 28;
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
            this.btnUpdateSelectedPerson.Location = new System.Drawing.Point(138, 102);
            this.btnUpdateSelectedPerson.Name = "btnUpdateSelectedPerson";
            this.btnUpdateSelectedPerson.Size = new System.Drawing.Size(40, 38);
            this.btnUpdateSelectedPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUpdateSelectedPerson.TabIndex = 27;
            this.btnUpdateSelectedPerson.TabStop = false;
            this.btnUpdateSelectedPerson.Click += new System.EventHandler(this.btnUpdateSelectedPerson_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::DVLDPL.Properties.Resources.icons8_search_500;
            this.pictureBox3.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.pictureBox3.Location = new System.Drawing.Point(699, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DVLDPL.Properties.Resources.refresh;
            this.pictureBox1.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.pictureBox1.Location = new System.Drawing.Point(22, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmPeopleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1078, 706);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnDeleteSelectedPerson);
            this.Controls.Add(this.btnUpdateSelectedPerson);
            this.Controls.Add(this.ctrlAddNewPersonBotton1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.ctrlPeopleSearch1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(1094, 745);
            this.Name = "frmPeopleManagement";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People Management";
            this.Load += new System.EventHandler(this.frmPeopleManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TPersonID;
        private System.Windows.Forms.ToolStripMenuItem TNationalNo;
        private System.Windows.Forms.ToolStripMenuItem TFullName;
        private System.Windows.Forms.ToolStripMenuItem TDateOfBirth;
        private System.Windows.Forms.ToolStripMenuItem TNationality;
        private System.Windows.Forms.ToolStripMenuItem TPhone;
        private System.Windows.Forms.ToolStripMenuItem TEmail;
        private System.Windows.Forms.ToolStripMenuItem TGender;
        private ctrlPeopleSearch ctrlPeopleSearch1;
        private NControls.NDataGrid dgvResults;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ctrlAddNewPersonBotton ctrlAddNewPersonBotton1;
        private System.Windows.Forms.PictureBox btnUpdateSelectedPerson;
        private System.Windows.Forms.PictureBox btnDeleteSelectedPerson;
        private System.Windows.Forms.PictureBox btnSettings;
    }
}