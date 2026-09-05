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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeopleManagement));
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
            this.TGendor = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvResults = new NControls.NDataGrid();
            this.cmsViewColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPersonID = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNationalNo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDateOfBirth = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNationality = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGendor = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlAddNewPersonBotton1 = new DVLDPL.PeopleManagement.ctrlAddNewPersonBotton();
            this.ctrlPeopleSearch1 = new DVLDPL.PeopleManagement.ctrlPeopleSearch();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnDeleteSelectedPerson = new System.Windows.Forms.PictureBox();
            this.btnUpdateSelectedPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.cmsViewColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1078, 25);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem1});
            this.viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
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
            this.TGendor});
            this.columnsToolStripMenuItem1.Name = "columnsToolStripMenuItem1";
            this.columnsToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.columnsToolStripMenuItem1.Text = "Columns";
            // 
            // TPersonID
            // 
            this.TPersonID.Checked = true;
            this.TPersonID.CheckOnClick = true;
            this.TPersonID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TPersonID.Name = "TPersonID";
            this.TPersonID.Size = new System.Drawing.Size(68, 22);
            this.TPersonID.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationalNo
            // 
            this.TNationalNo.Checked = true;
            this.TNationalNo.CheckOnClick = true;
            this.TNationalNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationalNo.Name = "TNationalNo";
            this.TNationalNo.Size = new System.Drawing.Size(68, 22);
            this.TNationalNo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TFullName
            // 
            this.TFullName.Checked = true;
            this.TFullName.CheckOnClick = true;
            this.TFullName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TFullName.Name = "TFullName";
            this.TFullName.Size = new System.Drawing.Size(68, 22);
            this.TFullName.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TDateOfBirth
            // 
            this.TDateOfBirth.Checked = true;
            this.TDateOfBirth.CheckOnClick = true;
            this.TDateOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TDateOfBirth.Name = "TDateOfBirth";
            this.TDateOfBirth.Size = new System.Drawing.Size(68, 22);
            this.TDateOfBirth.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationality
            // 
            this.TNationality.Checked = true;
            this.TNationality.CheckOnClick = true;
            this.TNationality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationality.Name = "TNationality";
            this.TNationality.Size = new System.Drawing.Size(68, 22);
            this.TNationality.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TPhone
            // 
            this.TPhone.Checked = true;
            this.TPhone.CheckOnClick = true;
            this.TPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TPhone.Name = "TPhone";
            this.TPhone.Size = new System.Drawing.Size(68, 22);
            this.TPhone.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TEmail
            // 
            this.TEmail.Checked = true;
            this.TEmail.CheckOnClick = true;
            this.TEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(68, 22);
            this.TEmail.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TGendor
            // 
            this.TGendor.Checked = true;
            this.TGendor.CheckOnClick = true;
            this.TGendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TGendor.Name = "TGendor";
            this.TGendor.Size = new System.Drawing.Size(68, 22);
            this.TGendor.CheckedChanged += new System.EventHandler(this.CheckedChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.ContextMenuStrip = this.cmsViewColumns;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.GridColor = System.Drawing.Color.White;
            this.dgvResults.Location = new System.Drawing.Point(0, 164);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "None";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.RowTemplate.Height = 40;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1078, 542);
            this.dgvResults.TabIndex = 22;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // cmsViewColumns
            // 
            this.cmsViewColumns.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsViewColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPersonID,
            this.cmsNationalNo,
            this.cmsFullName,
            this.cmsDateOfBirth,
            this.cmsNationality,
            this.cmsPhone,
            this.cmsEmail,
            this.cmsGendor});
            this.cmsViewColumns.Name = "cmsViewColumns";
            this.cmsViewColumns.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsViewColumns.Size = new System.Drawing.Size(192, 180);
            // 
            // cmsPersonID
            // 
            this.cmsPersonID.Checked = true;
            this.cmsPersonID.CheckOnClick = true;
            this.cmsPersonID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsPersonID.Name = "cmsPersonID";
            this.cmsPersonID.Size = new System.Drawing.Size(191, 22);
            this.cmsPersonID.Text = "toolStripMenuItem2";
            this.cmsPersonID.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsNationalNo
            // 
            this.cmsNationalNo.Checked = true;
            this.cmsNationalNo.CheckOnClick = true;
            this.cmsNationalNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsNationalNo.Name = "cmsNationalNo";
            this.cmsNationalNo.Size = new System.Drawing.Size(191, 22);
            this.cmsNationalNo.Text = "toolStripMenuItem2";
            this.cmsNationalNo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsFullName
            // 
            this.cmsFullName.Checked = true;
            this.cmsFullName.CheckOnClick = true;
            this.cmsFullName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsFullName.Name = "cmsFullName";
            this.cmsFullName.Size = new System.Drawing.Size(191, 22);
            this.cmsFullName.Text = "toolStripMenuItem2";
            this.cmsFullName.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsDateOfBirth
            // 
            this.cmsDateOfBirth.Checked = true;
            this.cmsDateOfBirth.CheckOnClick = true;
            this.cmsDateOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsDateOfBirth.Name = "cmsDateOfBirth";
            this.cmsDateOfBirth.Size = new System.Drawing.Size(191, 22);
            this.cmsDateOfBirth.Text = "toolStripMenuItem2";
            this.cmsDateOfBirth.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsNationality
            // 
            this.cmsNationality.Checked = true;
            this.cmsNationality.CheckOnClick = true;
            this.cmsNationality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsNationality.Name = "cmsNationality";
            this.cmsNationality.Size = new System.Drawing.Size(191, 22);
            this.cmsNationality.Text = "toolStripMenuItem2";
            this.cmsNationality.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsPhone
            // 
            this.cmsPhone.Checked = true;
            this.cmsPhone.CheckOnClick = true;
            this.cmsPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsPhone.Name = "cmsPhone";
            this.cmsPhone.Size = new System.Drawing.Size(191, 22);
            this.cmsPhone.Text = "toolStripMenuItem2";
            this.cmsPhone.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsEmail
            // 
            this.cmsEmail.Checked = true;
            this.cmsEmail.CheckOnClick = true;
            this.cmsEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsEmail.Name = "cmsEmail";
            this.cmsEmail.Size = new System.Drawing.Size(191, 22);
            this.cmsEmail.Text = "toolStripMenuItem2";
            this.cmsEmail.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmsGendor
            // 
            this.cmsGendor.Checked = true;
            this.cmsGendor.CheckOnClick = true;
            this.cmsGendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsGendor.Name = "cmsGendor";
            this.cmsGendor.Size = new System.Drawing.Size(191, 22);
            this.cmsGendor.Text = "toolStripMenuItem2";
            this.cmsGendor.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ctrlAddNewPersonBotton1
            // 
            this.ctrlAddNewPersonBotton1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlAddNewPersonBotton1.Location = new System.Drawing.Point(80, 102);
            this.ctrlAddNewPersonBotton1.Name = "ctrlAddNewPersonBotton1";
            this.ctrlAddNewPersonBotton1.Size = new System.Drawing.Size(40, 38);
            this.ctrlAddNewPersonBotton1.TabIndex = 26;
            // 
            // ctrlPeopleSearch1
            // 
            this.ctrlPeopleSearch1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPeopleSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPeopleSearch1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlPeopleSearch1.Location = new System.Drawing.Point(0, 25);
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
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::DVLDPL.Properties.Resources.refresh;
            this.btnRefresh.InitialImage = global::DVLDPL.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(22, 102);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 38);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmPeopleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 706);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnDeleteSelectedPerson);
            this.Controls.Add(this.btnUpdateSelectedPerson);
            this.Controls.Add(this.ctrlAddNewPersonBotton1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.ctrlPeopleSearch1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1094, 745);
            this.Name = "frmPeopleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.cmsViewColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelectedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSelectedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem1;
        private ctrlPeopleSearch ctrlPeopleSearch1;
        private NControls.NDataGrid dgvResults;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ctrlAddNewPersonBotton ctrlAddNewPersonBotton1;
        private System.Windows.Forms.PictureBox btnUpdateSelectedPerson;
        private System.Windows.Forms.PictureBox btnDeleteSelectedPerson;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.ContextMenuStrip cmsViewColumns;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsPersonID;
        private System.Windows.Forms.ToolStripMenuItem cmsNationalNo;
        private System.Windows.Forms.ToolStripMenuItem cmsFullName;
        private System.Windows.Forms.ToolStripMenuItem cmsDateOfBirth;
        private System.Windows.Forms.ToolStripMenuItem cmsNationality;
        private System.Windows.Forms.ToolStripMenuItem cmsPhone;
        private System.Windows.Forms.ToolStripMenuItem cmsEmail;
        private System.Windows.Forms.ToolStripMenuItem cmsGendor;
        private System.Windows.Forms.ToolStripMenuItem TPersonID;
        private System.Windows.Forms.ToolStripMenuItem TNationalNo;
        private System.Windows.Forms.ToolStripMenuItem TFullName;
        private System.Windows.Forms.ToolStripMenuItem TDateOfBirth;
        private System.Windows.Forms.ToolStripMenuItem TNationality;
        private System.Windows.Forms.ToolStripMenuItem TPhone;
        private System.Windows.Forms.ToolStripMenuItem TEmail;
        private System.Windows.Forms.ToolStripMenuItem TGendor;
    }
}