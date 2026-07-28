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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ctrlPeopleSearch1 = new DVLDPL.PeopleManagement.ctrlPeopleSearch();
            this.nDataGrid1 = new NControls.NDataGrid();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDataGrid1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1127, 24);
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
            // 
            // TNationalNo
            // 
            this.TNationalNo.Checked = true;
            this.TNationalNo.CheckOnClick = true;
            this.TNationalNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationalNo.Name = "TNationalNo";
            this.TNationalNo.Size = new System.Drawing.Size(140, 22);
            this.TNationalNo.Text = "National no.";
            // 
            // TFullName
            // 
            this.TFullName.Checked = true;
            this.TFullName.CheckOnClick = true;
            this.TFullName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TFullName.Name = "TFullName";
            this.TFullName.Size = new System.Drawing.Size(140, 22);
            this.TFullName.Text = "Full name";
            // 
            // TDateOfBirth
            // 
            this.TDateOfBirth.Checked = true;
            this.TDateOfBirth.CheckOnClick = true;
            this.TDateOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TDateOfBirth.Name = "TDateOfBirth";
            this.TDateOfBirth.Size = new System.Drawing.Size(140, 22);
            this.TDateOfBirth.Text = "Date of birth";
            // 
            // TNationality
            // 
            this.TNationality.Checked = true;
            this.TNationality.CheckOnClick = true;
            this.TNationality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TNationality.Name = "TNationality";
            this.TNationality.Size = new System.Drawing.Size(140, 22);
            this.TNationality.Text = "Nationality";
            // 
            // TPhone
            // 
            this.TPhone.Checked = true;
            this.TPhone.CheckOnClick = true;
            this.TPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TPhone.Name = "TPhone";
            this.TPhone.Size = new System.Drawing.Size(140, 22);
            this.TPhone.Text = "Phone";
            // 
            // TEmail
            // 
            this.TEmail.Checked = true;
            this.TEmail.CheckOnClick = true;
            this.TEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(140, 22);
            this.TEmail.Text = "Email";
            // 
            // TGender
            // 
            this.TGender.Checked = true;
            this.TGender.CheckOnClick = true;
            this.TGender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TGender.Name = "TGender";
            this.TGender.Size = new System.Drawing.Size(140, 22);
            this.TGender.Text = "Gender";
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
            this.ctrlPeopleSearch1.Size = new System.Drawing.Size(1127, 140);
            this.ctrlPeopleSearch1.TabIndex = 21;
            // 
            // nDataGrid1
            // 
            this.nDataGrid1.AllowUserToAddRows = false;
            this.nDataGrid1.AllowUserToDeleteRows = false;
            this.nDataGrid1.AllowUserToOrderColumns = true;
            this.nDataGrid1.AllowUserToResizeRows = false;
            this.nDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.nDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nDataGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.nDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.nDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nDataGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.nDataGrid1.EnableHeadersVisualStyles = false;
            this.nDataGrid1.Location = new System.Drawing.Point(249, 261);
            this.nDataGrid1.Name = "nDataGrid1";
            this.nDataGrid1.RowHeadersVisible = false;
            this.nDataGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.nDataGrid1.RowTemplate.Height = 40;
            this.nDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nDataGrid1.Size = new System.Drawing.Size(240, 150);
            this.nDataGrid1.TabIndex = 22;
            // 
            // frmPeopleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1127, 706);
            this.Controls.Add(this.nDataGrid1);
            this.Controls.Add(this.ctrlPeopleSearch1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(949, 348);
            this.Name = "frmPeopleManagement";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDataGrid1)).EndInit();
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
        private NControls.NDataGrid nDataGrid1;
    }
}