namespace DVLD.PL.PeopleManagement
{
    partial class ctrlPeopleSearch
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new NControls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbByGendor = new System.Windows.Forms.ComboBox();
            this.cbSearchByLetter = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(508, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "By Gendor:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSearch.BorderRadius = 30;
            this.txtSearch.BorderSize = 1;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.EnableSuggest = true;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Figtree", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.IconOffsetLeft = 10;
            this.txtSearch.IconOffsetRight = 10;
            this.txtSearch.IconSpacing = 0;
            this.txtSearch.Location = new System.Drawing.Point(306, 3);
            this.txtSearch.MaxSuggestItems = 4;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(284, 46);
            this.txtSearch.SuggestIcon = global::DVLD.PL.Properties.Resources.delete_user__1_;
            this.txtSearch.SuggestList = new string[0];
            this.txtSearch.TabIndex = 35;
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Letters:";
            // 
            // cbByGendor
            // 
            this.cbByGendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbByGendor.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbByGendor.FormattingEnabled = true;
            this.cbByGendor.Location = new System.Drawing.Point(511, 73);
            this.cbByGendor.Name = "cbByGendor";
            this.cbByGendor.Size = new System.Drawing.Size(79, 24);
            this.cbByGendor.TabIndex = 40;
            this.cbByGendor.SelectedIndexChanged += new System.EventHandler(this.cbByGendor_SelectedIndexChanged);
            // 
            // cbSearchByLetter
            // 
            this.cbSearchByLetter.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchByLetter.FormattingEnabled = true;
            this.cbSearchByLetter.Location = new System.Drawing.Point(306, 73);
            this.cbSearchByLetter.Name = "cbSearchByLetter";
            this.cbSearchByLetter.Size = new System.Drawing.Size(63, 24);
            this.cbSearchByLetter.TabIndex = 36;
            this.cbSearchByLetter.SelectedIndexChanged += new System.EventHandler(this.cbSearchByLetter_SelectedIndexChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.Font = new System.Drawing.Font("Figtree", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(375, 73);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(124, 24);
            this.cbFilterBy.TabIndex = 38;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Figtree SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Filter by:";
            // 
            // ctrlPeopleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbByGendor);
            this.Controls.Add(this.cbSearchByLetter);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(923, 107);
            this.Name = "ctrlPeopleSearch";
            this.Size = new System.Drawing.Size(923, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private NControls.NTextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbByGendor;
        private System.Windows.Forms.ComboBox cbSearchByLetter;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
    }
}
