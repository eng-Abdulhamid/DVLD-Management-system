using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class ctrlPeopleSearch : UserControl
    {
        private PersonService? _personService;
        private PersonService PersonServiceInstance => _personService ??= new PersonService();

        private readonly System.Windows.Forms.Timer? _searchTimer;
        private byte? _selectedGender = null;
        private bool _isInitializing = true;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageNumber { get; set; } = 1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageSize { get; set; } = 25;

        public event Action<string>? SearchTextChanged;
        public event EventHandler<OperationResults<PersonReadDTO>>? OnSearchResultsReceived;
        public event Action<int>? OnTotalCountReceived;

        public ctrlPeopleSearch()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode)
                return;

            _searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _searchTimer.Tick += async (s, e) =>
            {
                _searchTimer.Stop();
                await PerformSearchAsync();
            };

            InitializeControlsData();
            ApplyStyles();
            _isInitializing = false;

            this.Load += async (s, e) =>
            {
                if (UIUtility.IsDesignMode)
                    return;

                await PerformSearchAsync();
            };
        }

        private void ApplyStyles()
        {
            txtSearch.ApplyStandardStyle();
            cbSearchByLetter.ApplyStandardStyle();
            cbByGendor.ApplyStandardStyle();
            cbFilterBy.ApplyStandardStyle();
        }

        private void InitializeControlsData()
        {
            cbSearchByLetter.Items.AddRange(new object[]
            {
                "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            });
            cbSearchByLetter.SelectedIndex = 0;

            cbByGendor.Items.AddRange(new object[] { "Both", "Male", "Female" });
            cbByGendor.SelectedIndex = 0;

            cbFilterBy.Items.AddRange(new object[]
            {
                "Person ID", "National no.", "First name", "Second name",
                "Third name", "Last name", "Year of birth", "Nationality", "Phone", "Email"
            });
            cbFilterBy.SelectedIndex = 2;

            UpdatePlaceholder();
        }

        private void UpdatePlaceholder()
        {
            if (cbFilterBy.SelectedIndex >= 0)
            {
                txtSearch.PlaceholderText = $"Search by {cbFilterBy.Text.ToLower()}...";
            }
        }

        private string GetFilterColumnName()
        {
            return cbFilterBy.Text switch
            {
                "Person ID" => "PersonID",
                "National no." => "NationalNo",
                "First name" => "FirstName",
                "Second name" => "SecondName",
                "Third name" => "ThirdName",
                "Last name" => "LastName",
                "Year of birth" => "DateOfBirth",
                "Nationality" => "CountryName",
                "Phone" => "Phone",
                "Email" => "Email",
                _ => "FirstName"
            };
        }

        public async Task PerformSearchAsync()
        {
            if (UIUtility.IsDesignMode) return;

            string filterColumn = GetFilterColumnName();
            string searchValue = txtSearch.Text.Trim();
            string letter = cbSearchByLetter.Text == "All" ? string.Empty : cbSearchByLetter.Text;

            int totalCount = await PersonServiceInstance.GetSearchCountAsync(filterColumn, searchValue, letter, _selectedGender);
            OnTotalCountReceived?.Invoke(totalCount);

            OperationResults<PersonReadDTO> results = await PersonServiceInstance.SearchPeoplePagedAsync(
                filterColumn,
                searchValue,
                letter,
                _selectedGender,
                PageNumber,
                PageSize);

            if (results.IsSuccess && results.DataList != null)
            {
                UpdateSuggestions(results.DataList);
            }
            else
            {
                txtSearch.SuggestList = Array.Empty<string>();
            }

            OnSearchResultsReceived?.Invoke(this, results);
        }

        private void UpdateSuggestions(List<PersonReadDTO> people)
        {
            txtSearch.SuggestList = people
                .Take(8)
                .Select(p => p.FirstName)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .Distinct()
                .ToArray();
        }

        private async void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            PageNumber = 1;
            txtSearch.Text = string.Empty;
            UpdatePlaceholder();
            _searchTimer?.Stop();
            await PerformSearchAsync();
        }

        private async void cbSearchByLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            PageNumber = 1;
            if (cbSearchByLetter.Text != "All") txtSearch.Text = string.Empty;
            await PerformSearchAsync();
        }

        private async void cbByGendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            byte? newGender = cbByGendor.Text switch
            {
                "Male" => 0,
                "Female" => 1,
                _ => null
            };

            if (_selectedGender == newGender) return;

            _selectedGender = newGender;
            PageNumber = 1;
            await PerformSearchAsync();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            SearchTextChanged?.Invoke(txtSearch.Text);

            if (_isInitializing) return;

            PageNumber = 1;

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.SuggestList = Array.Empty<string>();
                _searchTimer?.Stop();
                _ = PerformSearchAsync();
                return;
            }

            if (cbSearchByLetter.SelectedIndex != 0)
            {
                cbSearchByLetter.SelectedIndex = 0;
            }

            _searchTimer?.Stop();
            _searchTimer?.Start();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _searchTimer?.Stop();
                PageNumber = 1;
                await PerformSearchAsync();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                _searchTimer?.Stop();
                txtSearch.Text = string.Empty;
            }
        }
    }
}