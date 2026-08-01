namespace DVLDPL.SearchDynamic
{
    partial class frmSearchPeople
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSearchByLetter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.cbByGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new NControls.NTextBox();
            this.dgvResults = new NControls.NDataGrid();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.columnsToolStripMenuItem.Text = "Columns";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip1.TabIndex = 18;
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
            this.columnsToolStripMenuItem1.Click += new System.EventHandler(this.columnsToolStripMenuItem1_Click);
            // 
            // TPersonID
            // 
            this.TPersonID.CheckOnClick = true;
            this.TPersonID.Name = "TPersonID";
            this.TPersonID.Size = new System.Drawing.Size(140, 22);
            this.TPersonID.Text = "Person ID";
            this.TPersonID.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationalNo
            // 
            this.TNationalNo.CheckOnClick = true;
            this.TNationalNo.Name = "TNationalNo";
            this.TNationalNo.Size = new System.Drawing.Size(140, 22);
            this.TNationalNo.Text = "National no.";
            this.TNationalNo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TFullName
            // 
            this.TFullName.CheckOnClick = true;
            this.TFullName.Name = "TFullName";
            this.TFullName.Size = new System.Drawing.Size(140, 22);
            this.TFullName.Text = "Full name";
            this.TFullName.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TDateOfBirth
            // 
            this.TDateOfBirth.CheckOnClick = true;
            this.TDateOfBirth.Name = "TDateOfBirth";
            this.TDateOfBirth.Size = new System.Drawing.Size(140, 22);
            this.TDateOfBirth.Text = "Date of birth";
            this.TDateOfBirth.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TNationality
            // 
            this.TNationality.CheckOnClick = true;
            this.TNationality.Name = "TNationality";
            this.TNationality.Size = new System.Drawing.Size(140, 22);
            this.TNationality.Text = "Nationality";
            this.TNationality.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TPhone
            // 
            this.TPhone.CheckOnClick = true;
            this.TPhone.Name = "TPhone";
            this.TPhone.Size = new System.Drawing.Size(140, 22);
            this.TPhone.Text = "Phone";
            this.TPhone.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // TEmail
            // 
            this.TEmail.CheckOnClick = true;
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 562);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Letters:";
            // 
            // cbSearchByLetter
            // 
            this.cbSearchByLetter.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchByLetter.FormattingEnabled = true;
            this.cbSearchByLetter.Location = new System.Drawing.Point(370, 73);
            this.cbSearchByLetter.Name = "cbSearchByLetter";
            this.cbSearchByLetter.Size = new System.Drawing.Size(63, 24);
            this.cbSearchByLetter.TabIndex = 1;
            this.cbSearchByLetter.SelectedIndexChanged += new System.EventHandler(this.cbSearchByLetter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter by:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(446, 73);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // cbByGender
            // 
            this.cbByGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbByGender.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbByGender.FormattingEnabled = true;
            this.cbByGender.Location = new System.Drawing.Point(580, 73);
            this.cbByGender.Name = "cbByGender";
            this.cbByGender.Size = new System.Drawing.Size(141, 24);
            this.cbByGender.TabIndex = 7;
            this.cbByGender.SelectedIndexChanged += new System.EventHandler(this.cbByGender_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "By Gender:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cbByGender);
            this.panel1.Controls.Add(this.cbFilterBy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbSearchByLetter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 107);
            this.panel1.TabIndex = 19;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.White;
            this.txtSearch.BorderFocusColor = System.Drawing.Color.White;
            this.txtSearch.BorderRadius = 30;
            this.txtSearch.BorderSize = 1;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.EnableSuggest = true;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Figtree", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.IconOffsetLeft = 10;
            this.txtSearch.IconOffsetRight = 10;
            this.txtSearch.IconSpacing = 0;
            this.txtSearch.Location = new System.Drawing.Point(368, 3);
            this.txtSearch.MaxSuggestItems = 4;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(353, 46);
            this.txtSearch.SuggestIcon = global::DVLDPL.Properties.Resources.delete_user__1_;
            this.txtSearch.SuggestList = new string[0];
            this.txtSearch.TabIndex = 0;
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.AllowUserToResizeRows = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvResults.Location = new System.Drawing.Point(0, 131);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResults.RowTemplate.Height = 40;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1111, 431);
            this.dgvResults.TabIndex = 9;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // frmSearchPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 562);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(949, 348);
            this.Name = "frmSearchPeople";
            this.Text = "frmSearch";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSearchByLetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ComboBox cbByGender;
        private NControls.NTextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private NControls.NDataGrid dgvResults;
    }
}