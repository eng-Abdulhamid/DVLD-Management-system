using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    partial class ctrlDriversSearch
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblLetters;
        private ComboBox cbSearchByLetter;
        private Label lblFilterBy;
        private ComboBox cbFilterBy;
        private NControls.NTextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _searchTimer?.Stop();
                _searchTimer?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLetters = new Label();
            cbSearchByLetter = new ComboBox();
            lblFilterBy = new Label();
            cbFilterBy = new ComboBox();
            txtSearch = new NControls.NTextBox();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.AllowArabicCharacters = true;
            txtSearch.AllowEnglishCharacters = true;
            txtSearch.AllowNumbers = true;
            txtSearch.AllowSpaces = true;
            txtSearch.AllowSymbols = false;
            txtSearch.BackColor = Color.Transparent;
            txtSearch.BorderColor = Color.FromArgb(226, 232, 240);
            txtSearch.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtSearch.BorderRadius = 8;
            txtSearch.BorderSize = 1;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomAllowedCharacters = "";
            txtSearch.EnableIconTinting = true;
            txtSearch.EnableSuggest = false;
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
            txtSearch.MoveToNextControlOnEnter = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(9, 12, 9, 12);
            txtSearch.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "";
            txtSearch.RightIcon = null;
            txtSearch.RightIconClickable = false;
            txtSearch.ShowClearButton = true;
            txtSearch.Size = new Size(331, 44);
            txtSearch.TabIndex = 0;
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.ValidateEmail = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblLetters
            // 
            lblLetters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLetters.AutoSize = true;
            lblLetters.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLetters.ForeColor = Color.FromArgb(71, 85, 105);
            lblLetters.Location = new Point(450, 23);
            lblLetters.Margin = new Padding(4, 0, 4, 0);
            lblLetters.Name = "lblLetters";
            lblLetters.Size = new Size(54, 19);
            lblLetters.TabIndex = 1;
            lblLetters.Text = "Letters:";
            // 
            // cbSearchByLetter
            // 
            cbSearchByLetter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSearchByLetter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchByLetter.FlatStyle = FlatStyle.Flat;
            cbSearchByLetter.Font = new Font("Segoe UI", 9.75F);
            cbSearchByLetter.FormattingEnabled = true;
            cbSearchByLetter.Location = new Point(454, 44);
            cbSearchByLetter.Margin = new Padding(4, 3, 4, 3);
            cbSearchByLetter.Name = "cbSearchByLetter";
            cbSearchByLetter.Size = new Size(78, 25);
            cbSearchByLetter.TabIndex = 2;
            cbSearchByLetter.SelectedIndexChanged += cbSearchByLetter_SelectedIndexChanged;
            // 
            // lblFilterBy
            // 
            lblFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilterBy.AutoSize = true;
            lblFilterBy.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFilterBy.ForeColor = Color.FromArgb(71, 85, 105);
            lblFilterBy.Location = new Point(545, 23);
            lblFilterBy.Margin = new Padding(4, 0, 4, 0);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(63, 19);
            lblFilterBy.TabIndex = 3;
            lblFilterBy.Text = "Filter by:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FlatStyle = FlatStyle.Flat;
            cbFilterBy.Font = new Font("Segoe UI", 9.75F);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new Point(549, 44);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(150, 25);
            cbFilterBy.TabIndex = 4;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // ctrlDriversSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cbFilterBy);
            Controls.Add(lblFilterBy);
            Controls.Add(cbSearchByLetter);
            Controls.Add(lblLetters);
            Controls.Add(txtSearch);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(715, 86);
            Name = "ctrlDriversSearch";
            Size = new Size(715, 86);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}