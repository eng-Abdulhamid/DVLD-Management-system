using DVLD.PL.Global;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    [DefaultEvent("OnFilterChanged")]
    public partial class ctrlDriversSearch : UserControl
    {
        private readonly System.Windows.Forms.Timer _searchTimer;
        private bool _isInitializing = true;

        [Category("Filter Events")]
        public event Action<string, string, string>? OnFilterChanged;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilterColumn => GetDbColumnName(cbFilterBy.Text);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchText => txtSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Letter => cbSearchByLetter.Text == "All" ? string.Empty : cbSearchByLetter.Text;

        public ctrlDriversSearch()
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
            cbSearchByLetter.ApplyStandardStyle();
        }

        private void InitializeControlsData()
        {
            cbSearchByLetter.Items.Clear();
            cbSearchByLetter.Items.AddRange(new object[]
            {
                "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            });
            cbSearchByLetter.SelectedIndex = 0;

            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[]
            {
                "Driver ID", "Person ID", "National No.", "Full Name"
            });
            cbFilterBy.SelectedIndex = 3; // Default: Full Name

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
                "Driver ID" => "DriverID",
                "Person ID" => "PersonID",
                "National No." => "NationalNo",
                "Full Name" => "FullName",
                _ => "FullName"
            };
        }

        private void ConfigureInputConstraints(string selectedFilter)
        {
            bool isNumeric = selectedFilter == "Driver ID" || selectedFilter == "Person ID";

            txtSearch.AllowNumbers = true;
            txtSearch.AllowEnglishCharacters = !isNumeric;
            txtSearch.AllowArabicCharacters = selectedFilter == "Full Name";
            txtSearch.AllowSpaces = selectedFilter == "Full Name";
            txtSearch.AllowSymbols = false;
            txtSearch.MaxLength = isNumeric ? 10 : 50;
        }

        private void TriggerFilterChanged()
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;
            OnFilterChanged?.Invoke(FilterColumn, SearchText, Letter);
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

        private void cbSearchByLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            if (cbSearchByLetter.Text != "All")
            {
                txtSearch.Text = string.Empty;
            }
            TriggerFilterChanged();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            if (cbSearchByLetter.SelectedIndex != 0 && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                cbSearchByLetter.SelectedIndex = 0;
            }

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

        public void ClearFilter()
        {
            cbFilterBy.SelectedIndex = 3;
            cbSearchByLetter.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }
    }
}