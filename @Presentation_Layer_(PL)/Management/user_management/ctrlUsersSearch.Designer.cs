using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    partial class ctrlUsersSearch
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFilterBy;
        private ComboBox cbFilterBy;
        private Label lblStatus;
        private ComboBox cbIsActive;
        private NControls.NTextBox txtSearch;

        private void InitializeComponent()
        {
            lblFilterBy = new Label();
            cbFilterBy = new ComboBox();
            lblStatus = new Label();
            cbIsActive = new ComboBox();
            txtSearch = new NControls.NTextBox();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.AllowArabicCharacters = false;
            txtSearch.AllowEnglishCharacters = true;
            txtSearch.AllowNumbers = true;
            txtSearch.AllowSpaces = false;
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
            txtSearch.IconSize = new Size(24, 24);
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
            txtSearch.PlaceholderText = "Search by username...";
            txtSearch.RightIcon = null;
            txtSearch.RightIconClickable = false;
            txtSearch.ShowClearButton = true;
            txtSearch.Size = new Size(330, 44);
            txtSearch.TabIndex = 0;
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.ValidateEmail = false;
            txtSearch.Visible = true;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblFilterBy
            // 
            lblFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilterBy.AutoSize = true;
            lblFilterBy.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFilterBy.ForeColor = Color.FromArgb(71, 85, 105);
            lblFilterBy.Location = new Point(410, 23);
            lblFilterBy.Margin = new Padding(4, 0, 4, 0);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(63, 19);
            lblFilterBy.TabIndex = 1;
            lblFilterBy.Text = "Filter by:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FlatStyle = FlatStyle.Flat;
            cbFilterBy.Font = new Font("Segoe UI", 9.75F);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new Point(414, 44);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(150, 25);
            cbFilterBy.TabIndex = 2;
            cbFilterBy.Visible = true;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.Location = new Point(585, 23);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // cbIsActive
            // 
            cbIsActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbIsActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsActive.FlatStyle = FlatStyle.Flat;
            cbIsActive.Font = new Font("Segoe UI", 9.75F);
            cbIsActive.FormattingEnabled = true;
            cbIsActive.Location = new Point(589, 44);
            cbIsActive.Margin = new Padding(4, 3, 4, 3);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(110, 25);
            cbIsActive.TabIndex = 4;
            cbIsActive.Visible = true;
            cbIsActive.SelectedIndexChanged += cbIsActive_SelectedIndexChanged;
            // 
            // ctrlUsersSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cbIsActive);
            Controls.Add(lblStatus);
            Controls.Add(cbFilterBy);
            Controls.Add(lblFilterBy);
            Controls.Add(txtSearch);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(715, 86);
            Name = "ctrlUsersSearch";
            Size = new Size(715, 86);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}