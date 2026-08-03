using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using NControls;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL.PeopleManagement
{
    public partial class ctrlPeopleSearch : UserControl
    {
        public ctrlPeopleSearch()
        {
            InitializeComponent();
            personServices = new PersonServices();
            InitializeDesign();
            InitializeTools();
            eventSearchResults.Invoke(this, GetSearchResults());
        }
        public event EventHandler<OperationResults<PersonReadDTO>> eventSearchResults = delegate { };
        private string letter = "";
        private string lastSearchResult = "";
        private PersonServices personServices;
        private enGender selectedGender = enGender.Unknown;
        private void InitializeDesign()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Padding = new Padding(0);

            ApplyModernStyling();
        }
        private void ApplyModernStyling()
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.FromArgb(45, 45, 45);
                    comboBox.Font = new Font("Segoe UI", 10F);
                    comboBox.Margin = new Padding(8);
                }
                else if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(60, 60, 60);
                    label.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            }
        }
        private void InitializeSearchBox()
        {
            txtSearch.AddIcon(
                image: Properties.Resources.icons8_search_500,
                position: IconPosition.Left,
                width: 20,
                height: 20,
                isClickable: false
            );

            txtSearch.BorderRadius = 18;
            txtSearch.BorderSize = 1;
            txtSearch.BorderColor = Color.FromArgb(220, 220, 220);
            txtSearch.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.FromArgb(45, 45, 45);
            txtSearch.PlaceholderText = "Search by first name...";
            txtSearch.PlaceholderColor = Color.FromArgb(150, 150, 150);
            txtSearch.Margin = new Padding(15, 15, 15, 10);
        }
        private void InitializeSearchByLetterComboBox()
        {
            cbSearchByLetter.Items.AddRange(new object[]
            {
                "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            });
            cbSearchByLetter.SelectedIndex = 0;
            cbSearchByLetter.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void InitializeSearchByGenderComboBox()
        {
            cbByGender.Items.AddRange(new object[] { "Both", "Male", "Female" });
            cbByGender.SelectedIndex = 0;
            cbByGender.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void InitializeFilterByComboBox()
        {
            cbFilterBy.Items.AddRange(new object[]
            {
                "Person ID", "National no.", "First name", "Second name",
                "Third name", "Last name", "Year of birth", "Nationality", "Phone", "Email"
            });
            cbFilterBy.SelectedIndex = 2;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            UpdateSearchPlaceholder("Search by first name...");
        }
        private void InitializeTools()
        {
            InitializeSearchBox();
            InitializeSearchByLetterComboBox();
            InitializeSearchByGenderComboBox();
            InitializeFilterByComboBox();
        }
        private void UpdateSearchPlaceholder(string newText)
        {
            txtSearch.PlaceholderText = newText;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            UpdateSearchPlaceholder($"Search by {cbFilterBy.Text.ToLower()}...");
            eventSearchResults.Invoke(this, GetSearchResults());
        }
        private void cbSearchByLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            letter = cbSearchByLetter.Text == "All" ? "" : cbSearchByLetter.Text;
            if (letter != "")
            {
                txtSearch.Text = string.Empty;
            }
            eventSearchResults.Invoke(this, GetSearchResults());
        }
        private enGender GetSelectedGender()
        {
            string gender = cbByGender.Text;
            if (gender == "Male")
            {
                return enGender.Male;

            }
            else if (gender == "Female")
            {
                return enGender.Female;
            }
            else
            {
                return enGender.Unknown;
            }

        }
        private void cbByGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedGender != GetSelectedGender())
            {
                selectedGender = GetSelectedGender();
                eventSearchResults.Invoke(this, GetSearchResults());
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = string.Empty;
                e.SuppressKeyPress = true;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.SuggestList = new string[0];
                eventSearchResults.Invoke(this, GetSearchResults());
            }
            else
            {
                cbSearchByLetter.SelectedIndex = 0; // Reset to "All" when typing
                if (txtSearch.Text != lastSearchResult)
                {
                    OperationResults<PersonReadDTO> results = GetSearchResults();
                    if (results.IsSuccess && results.DataList?.Count > 0)
                    {
                        UpdateSearchSuggestions(results.DataList);
                    }
                    else
                    {
                        txtSearch.SuggestList = new string[0];
                    }
                }
            }
        }
        private PersonServices.enFields SelectCurrentFilter()
        {
            return cbFilterBy.Text switch
            {
                "Person ID" => PersonServices.enFields.PersonID,
                "National no." => PersonServices.enFields.NationalNo,
                "First name" => PersonServices.enFields.FirstName,
                "Second name" => PersonServices.enFields.SecondName,
                "Third name" => PersonServices.enFields.ThirdName,
                "Last name" => PersonServices.enFields.LastName,
                "Year of birth" => PersonServices.enFields.DateOfBirth,
                "Nationality" => PersonServices.enFields.NationalityCountryID,
                "Phone" => PersonServices.enFields.Phone,
                "Email" => PersonServices.enFields.Email,
                "Gender" => PersonServices.enFields.Gender,
                _ => PersonServices.enFields.None
            };
        }
        private void UpdateSearchSuggestions(List<PersonReadDTO> people)
        {
            var suggestions = people
                .Take(8)
                .Select(p => $"{p.FirstName}")
                .ToArray();
            txtSearch.SuggestList = suggestions;
        }
        private OperationResults<PersonReadDTO> GetSearchResults()
        {
            string searchText = txtSearch.Text.Trim();
            enSearchType searchType = enSearchType.None;
            if (string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(letter))
            {
                searchText = letter;
                searchType = enSearchType.StartWith;
            }
            else
            {
                searchType = enSearchType.Contain;
            }
            SearchCriteria<PersonServices.enFields> searchBy = new SearchCriteria<PersonServices.enFields>
            {
                GenderFilter = GetSelectedGender(),
                FilterBy = SelectCurrentFilter(),
                SearchString = searchText,
                SearchType = searchType
            };
            return personServices.GetPeople(searchBy);
        }
        public void PerformSearch()
        {
            try
            {
                OperationResults<PersonReadDTO> results = GetSearchResults();

                if (results.IsSuccess && results.DataList?.Count > 0)
                {
                    lastSearchResult = txtSearch.Text;
                    eventSearchResults.Invoke(this, GetSearchResults());
                }
                else
                {
                    txtSearch.SuggestList = new string[0];
                    eventSearchResults.Invoke(this, null); // Nothing
                    Notification.Show($"No people found matching the search criteria.", IconType.Info, 3);

                }
            }
            catch (Exception ex)
            {
                Notification.Show($"Search error: {ex.Message}", IconType.Error, 3);
            }
        }


    }
}
