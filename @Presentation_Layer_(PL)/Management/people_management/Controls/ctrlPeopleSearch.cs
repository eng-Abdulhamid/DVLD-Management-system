using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using System.ComponentModel;
using System.Runtime.InteropServices.ObjectiveC;
namespace DVLD.PL.PeopleManagement
{
    public partial class ctrlPeopleSearch : UserControl
    {
        #region Fields & Properties
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
        #endregion
        #region Events
        public event Action<string>? SearchTextChanged;
        public event EventHandler<OperationResults<PersonReadDTO>>? OnSearchResultsReceived;
        public event Action<int>? OnTotalCountReceived;
        #endregion
        #region Constructor & Initialization
        public ctrlPeopleSearch()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            _searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _searchTimer.Tick += async (s, e) =>
            {
                _searchTimer.Stop();
                await PerformSearchAsync();
            };

            InitializeControlsData();
            ApplyStyles();
            _isInitializing = false;

            this.Load += PeopleSearch_Load;
        }
        private void InitializeControlsData()
        {
            cbSearchByLetter.Items.AddRange(EnglishLetters());
            cbSearchByLetter.SelectedIndex = 0;

            cbByGendor.Items.AddRange(GendorTypes());
            cbByGendor.SelectedIndex = 0;

            cbFilterBy.Items.AddRange(PersonColumns());
            cbFilterBy.SelectedIndex = 2;

            UpdatePlaceholder();
        }
        private object[] EnglishLetters()
        {
            return new object[]
            {
                "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };
        }
        private object[] GendorTypes()
        {
            return new object[] { "Both", "Male", "Female" };
        }
        private object[] PersonColumns()
        {
            return new object[]
            {
                "Person ID", "National no.", "First name", "Second name",
                "Third name", "Last name", "Year of birth", "Nationality", "Phone", "Email"
            };
        }
        private void ApplyStyles()
        {
            txtSearch.ApplyStandardStyle();
            cbSearchByLetter.ApplyStandardStyle();
            cbByGendor.ApplyStandardStyle();
            cbFilterBy.ApplyStandardStyle();
        }
        private async void PeopleSearch_Load(object? sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;
            UpdatePlaceholder();
        }
        #endregion
        #region Search Logic
        public async Task PerformSearchAsync()
        {
            if (UIUtility.IsDesignMode) return;

            var searchParams = GetCurrentSearchParameters();

            await UpdateTotalRecordsCountAsync(searchParams);
            await FetchAndBroadcastSearchResultsAsync(searchParams);
        }
        private (string FilterColumn, string SearchValue, string Letter, byte? Gender) GetCurrentSearchParameters()
        {
            string filterColumn = GetFilterColumnName();
            string searchValue = txtSearch.Text.Trim();
            string letter = cbSearchByLetter.Text == "All" ? string.Empty : cbSearchByLetter.Text;

            return (filterColumn, searchValue, letter, _selectedGender);
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
        private async Task UpdateTotalRecordsCountAsync((string Column, string Value, string Letter, byte? Gender) p)
        {
            int totalCount = 
                await PersonServiceInstance.GetSearchCountAsync(p.Column, p.Value, p.Letter, p.Gender);
            OnTotalCountReceived?.Invoke(totalCount);
        }
        private async Task FetchAndBroadcastSearchResultsAsync((string Column, string Value, string Letter, byte? Gender) p)
        {
            var results = await PersonServiceInstance.SearchPeoplePagedAsync(
                p.Column, p.Value, p.Letter, p.Gender, PageNumber, PageSize);

            HandleSuggestionsUpdate(results);
            OnSearchResultsReceived?.Invoke(this, results);
        }
        private void HandleSuggestionsUpdate(OperationResults<PersonReadDTO> results)
        {
            if (results.IsSuccess && results.DataList != null)
            {
                UpdateSuggestionsList(results.DataList);
            }
            else
            {
                txtSearch.SuggestList = Array.Empty<string>();
            }
        }
        private void UpdateSuggestionsList(List<PersonReadDTO> people)
        {
            txtSearch.SuggestList = people
                .Take(8)
                .Select(p => p.FirstName)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .Distinct()
                .ToArray();
        }
        #endregion
        #region Event Handlers
        private async void cbSearchByLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            bool shouldClearText = cbSearchByLetter.Text != "All";
            await ResetPaginationAndSearchAsync(clearSearchText: shouldClearText);
        }
        private async void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || UIUtility.IsDesignMode) return;

            UpdatePlaceholder();
            await ResetPaginationAndSearchAsync(clearSearchText: true);
        }
        private void UpdatePlaceholder()
        {
            if (cbFilterBy.SelectedIndex >= 0)
            {
                txtSearch.PlaceholderText = $"Search by {cbFilterBy.Text.ToLower()}...";
            }
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
            await ResetPaginationAndSearchAsync(clearSearchText: false);
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
                _isInitializing = true;
                cbSearchByLetter.SelectedIndex = 0;
                _isInitializing = false;
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
                await ResetPaginationAndSearchAsync(clearSearchText: false);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                await ResetPaginationAndSearchAsync(clearSearchText: true);
            }
        }
        private async Task ResetPaginationAndSearchAsync(bool clearSearchText = false)
        {
            PageNumber = 1;

            if (clearSearchText)
                txtSearch.Text = string.Empty;

            _searchTimer?.Stop();
            await PerformSearchAsync();
        }

        #endregion
    }
}