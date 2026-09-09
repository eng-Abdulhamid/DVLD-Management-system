using DVLD.PL.Global;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    [DefaultEvent("OnFilterChanged")]
    public partial class ctrlUsersSearch : UserControl
    {
        private readonly System.Windows.Forms.Timer _searchTimer;
        private bool _isInitializing = true;

        [Category("Filter Events")]
        public event Action<string, string, bool?>? OnFilterChanged;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilterColumn => GetDbColumnName(cbFilterBy.Text);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchText => txtSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool? IsActiveStatus => cbIsActive.Text switch
        {
            "Active" => true,
            "Inactive" => false,
            _ => null
        };

        public ctrlUsersSearch()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            _searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _searchTimer.Tick += (s, e) =>
            {
                _searchTimer.Stop();
                TriggerFilterChanged();
            };

            InitializeControlsData();
            ApplyStyles();
            _isInitializing = false;
        }

        private void ApplyStyles()
        {
            txtSearch.ApplyStandardStyle();
            cbFilterBy.ApplyStandardStyle();
            cbIsActive.ApplyStandardStyle();
        }

        private void InitializeControlsData()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[]
            {
                "User ID", "Person ID", "Username"
            });
            cbFilterBy.SelectedIndex = 2; // Default: Username

            cbIsActive.Items.Clear();
            cbIsActive.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            cbIsActive.SelectedIndex = 0;

            UpdatePlaceholder();
            ConfigureInputConstraints(cbFilterBy.Text);
        }

        private void UpdatePlaceholder()
        {
            if (cbFilterBy.SelectedIndex >= 0)
            {
                txtSearch.PlaceholderText = $"Search by {cbFilterBy.Text.ToLower()}...";
            }
        }

        private string GetDbColumnName(string displayFilter)
        {
            return displayFilter switch
            {
                "User ID" => "UserID",
                "Person ID" => "PersonID",
                "Username" => "UserName",
                _ => "UserName"
            };
        }

        private void ConfigureInputConstraints(string selectedFilter)
        {
            bool isNumeric = selectedFilter == "User ID" || selectedFilter == "Person ID";

            txtSearch.AllowNumbers = true;
            txtSearch.AllowEnglishCharacters = !isNumeric;
            txtSearch.AllowArabicCharacters = false;
            txtSearch.AllowSpaces = false;
            txtSearch.AllowSymbols = false;
            txtSearch.MaxLength = isNumeric ? 10 : 20;
        }

        private void TriggerFilterChanged()
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;
            OnFilterChanged?.Invoke(FilterColumn, SearchText, IsActiveStatus);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            txtSearch.Text = string.Empty;
            UpdatePlaceholder();
            ConfigureInputConstraints(cbFilterBy.Text);
            _searchTimer.Stop();
            TriggerFilterChanged();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;
            TriggerFilterChanged();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _searchTimer.Stop();
                TriggerFilterChanged();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                _searchTimer.Stop();
                txtSearch.Text = string.Empty;
            }
        }

        public void FocusSearchBox()
        {
            if (txtSearch.Visible)
            {
                txtSearch.Focus();
            }
            else
            {
                cbFilterBy.Focus();
            }
        }

        public void ClearFilter()
        {
            cbFilterBy.SelectedIndex = 2;
            cbIsActive.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }

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
    }
}