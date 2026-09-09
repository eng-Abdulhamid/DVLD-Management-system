using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    partial class ctrlUsersSearch
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFilterBy;
        private ComboBox cbFilterBy;
        private NControls.NTextBox txtSearch;
        private ComboBox cbIsActive;

        private void InitializeComponent()
        {
            lblFilterBy = new Label();
            cbFilterBy = new ComboBox();
            txtSearch = new NControls.NTextBox();
            cbIsActive = new ComboBox();
            SuspendLayout();
            // 
            // lblFilterBy
            // 
            lblFilterBy.AutoSize = true;
            lblFilterBy.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFilterBy.ForeColor = Color.FromArgb(71, 85, 105);
            lblFilterBy.Location = new Point(8, 14);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(63, 19);
            lblFilterBy.TabIndex = 3;
            lblFilterBy.Text = "Filter by:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new Font("Segoe UI", 9.75F);
            cbFilterBy.Location = new Point(78, 11);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(150, 25);
            cbFilterBy.TabIndex = 0;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.AllowArabicCharacters = true;
            txtSearch.AllowEnglishCharacters = true;
            txtSearch.AllowNumbers = true;
            txtSearch.AllowSpaces = true;
            txtSearch.AllowSymbols = true;
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.Transparent;
            txtSearch.BorderColor = Color.FromArgb(220, 220, 220);
            txtSearch.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtSearch.BorderRadius = 24;
            txtSearch.BorderSize = 1;
            txtSearch.CustomAllowedCharacters = "";
            txtSearch.EnableIconTinting = false;
            txtSearch.EnableSuggest = false;
            txtSearch.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtSearch.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.HasError = false;
            txtSearch.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtSearch.IconColor = Color.FromArgb(148, 163, 184);
            txtSearch.IconOffsetLeft = 10;
            txtSearch.IconOffsetRight = 10;
            txtSearch.IconSize = new Size(20, 20);
            txtSearch.IconSpacing = 8;
            txtSearch.LeftIcon = null;
            txtSearch.LeftIconClickable = false;
            txtSearch.Location = new Point(385, 3);
            txtSearch.MaxLength = 32767;
            txtSearch.MaxSuggestItems = 8;
            txtSearch.MoveToNextControlOnEnter = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(8, 12, 8, 12);
            txtSearch.PlaceholderColor = Color.DarkGray;
            txtSearch.PlaceholderText = "Search...";
            txtSearch.RightIcon = null;
            txtSearch.RightIconClickable = false;
            txtSearch.ShowClearButton = false;
            txtSearch.Size = new Size(270, 38);
            txtSearch.SuggestIcon = null;
            txtSearch.TabIndex = 1;
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.ValidateEmail = false;
            txtSearch.Visible = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cbIsActive
            // 
            cbIsActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsActive.Font = new Font("Segoe UI", 9.75F);
            cbIsActive.Location = new Point(236, 11);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(120, 25);
            cbIsActive.TabIndex = 2;
            cbIsActive.Visible = false;
            cbIsActive.SelectedIndexChanged += cbIsActive_SelectedIndexChanged;
            // 
            // ctrlUsersSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cbIsActive);
            Controls.Add(txtSearch);
            Controls.Add(cbFilterBy);
            Controls.Add(lblFilterBy);
            Name = "ctrlUsersSearch";
            Size = new Size(693, 48);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}