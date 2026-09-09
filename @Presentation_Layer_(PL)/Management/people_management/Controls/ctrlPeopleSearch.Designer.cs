using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    partial class ctrlPeopleSearch
    {
        private System.ComponentModel.IContainer components = null;
        private Label label2;
        private ComboBox cbFilterBy;
        private ComboBox cbSearchByLetter;
        private ComboBox cbByGendor;
        private Label label1;
        private NControls.NTextBox txtSearch;
        private Label label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label2 = new Label();
            cbFilterBy = new ComboBox();
            cbSearchByLetter = new ComboBox();
            cbByGendor = new ComboBox();
            label1 = new Label();
            txtSearch = new NControls.NTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(71, 85, 105);
            label2.Location = new Point(443, 23);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 39;
            label2.Text = "Filter by:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FlatStyle = FlatStyle.Flat;
            cbFilterBy.Font = new Font("Segoe UI", 9.75F);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new Point(447, 44);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(144, 25);
            cbFilterBy.TabIndex = 38;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // cbSearchByLetter
            // 
            cbSearchByLetter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSearchByLetter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchByLetter.FlatStyle = FlatStyle.Flat;
            cbSearchByLetter.Font = new Font("Segoe UI", 9.75F);
            cbSearchByLetter.FormattingEnabled = true;
            cbSearchByLetter.Location = new Point(366, 44);
            cbSearchByLetter.Margin = new Padding(4, 3, 4, 3);
            cbSearchByLetter.Name = "cbSearchByLetter";
            cbSearchByLetter.Size = new Size(73, 25);
            cbSearchByLetter.TabIndex = 36;
            cbSearchByLetter.SelectedIndexChanged += cbSearchByLetter_SelectedIndexChanged;
            // 
            // cbByGendor
            // 
            cbByGendor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbByGendor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbByGendor.FlatStyle = FlatStyle.Flat;
            cbByGendor.Font = new Font("Segoe UI", 9.75F);
            cbByGendor.FormattingEnabled = true;
            cbByGendor.Location = new Point(605, 44);
            cbByGendor.Margin = new Padding(4, 3, 4, 3);
            cbByGendor.Name = "cbByGendor";
            cbByGendor.Size = new Size(92, 25);
            cbByGendor.TabIndex = 40;
            cbByGendor.SelectedIndexChanged += cbByGendor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(71, 85, 105);
            label1.Location = new Point(360, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 37;
            label1.Text = "Letters:";
            // 
            // txtSearch
            // 
            txtSearch.AllowArabicCharacters = true;
            txtSearch.AllowEnglishCharacters = true;
            txtSearch.AllowNumbers = true;
            txtSearch.AllowSpaces = true;
            txtSearch.AllowSymbols = true;
            txtSearch.BackColor = Color.Transparent;
            txtSearch.BorderColor = Color.FromArgb(226, 232, 240);
            txtSearch.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtSearch.BorderRadius = 8;
            txtSearch.BorderSize = 1;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomAllowedCharacters = "";
            txtSearch.EnableIconTinting = true;
            txtSearch.EnableSuggest = true;
            txtSearch.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtSearch.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.HasError = false;
            txtSearch.HoverIconColor = Color.FromArgb(148, 163, 184);
            txtSearch.IconColor = Color.FromArgb(15, 23, 42);
            txtSearch.IconOffsetLeft = 10;
            txtSearch.IconOffsetRight = 10;
            txtSearch.IconSize = new Size(26, 26);
            txtSearch.IconSpacing = 10;
            txtSearch.LeftIcon = Properties.Resources.search;
            txtSearch.LeftIconClickable = false;
            txtSearch.Location = new Point(15, 25);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.MaxLength = 50;
            txtSearch.MaxSuggestItems = 6;
            txtSearch.MoveToNextControlOnEnter = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(9, 12, 9, 12);
            txtSearch.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "";
            txtSearch.RightIcon = null;
            txtSearch.RightIconClickable = false;
            txtSearch.ShowClearButton = true;
            txtSearch.Size = new Size(331, 44);
            txtSearch.SuggestIcon = null;
            txtSearch.TabIndex = 35;
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.ValidateEmail = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(71, 85, 105);
            label4.Location = new Point(602, 23);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 41;
            label4.Text = "By Gender:";
            // 
            // ctrlPeopleSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label4);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(cbByGendor);
            Controls.Add(cbSearchByLetter);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(715, 86);
            Name = "ctrlPeopleSearch";
            Size = new Size(715, 86);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}