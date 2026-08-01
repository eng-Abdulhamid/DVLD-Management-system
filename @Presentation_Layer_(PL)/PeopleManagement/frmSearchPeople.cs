using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using NControls;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLDPL.SearchDynamic
{
    public partial class frmSearchPeople : Form
    {
        public frmSearchPeople()
        {
            InitializeComponent();
            InitializeToolStripMenuItems();
            personServices = new PersonServices();
            InitializeDesign();
            InitializeTools();
            AddListPersonRowToDataGrid(GetSearchResults().DataList);
        }
        private string letter = "";
        private string lastSearchResult = "";
        private PersonServices personServices;
        private enGender selectedGender = enGender.Both;
        
        private void InitializeToolStripMenuItems()
        {
            TPersonID.Checked = true;
            TNationalNo.Checked = true;
            TFullName.Checked = true;
            TDateOfBirth.Checked = true;
            TNationality.Checked = true;
            TPhone.Checked = true;
            TEmail.Checked = true;
            TGender.Checked = true;
            InitializeDataGridColumns();
        }

        private void InitializeDataGridColumns()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Clear();
            if (TPersonID.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Person ID",
                    HeaderText = "Person ID",
                    DataPropertyName = "PersonID",
                    Width = 80
                });
            }
            if (TNationalNo.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "National No.",
                    HeaderText = "National No.",
                    DataPropertyName = "NationalNo",
                    Width = 120
                });
            }

            if (TFullName.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Full Name",
                    HeaderText = "Full Name",
                    DataPropertyName = "FullName",
                    Width = 200
                });
            }
            if (TDateOfBirth.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Date of Birth",
                    HeaderText = "Date of Birth",
                    DataPropertyName = "DateOfBirth",
                    Width = 100
                });
            }
            if (TNationality.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nationality",
                    HeaderText = "Nationality",
                    DataPropertyName = "Nationality",
                    Width = 120
                });
            }
            if (TPhone.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    HeaderText = "Phone",
                    DataPropertyName = "Phone",
                    Width = 120
                });
            }
            if (TEmail.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Email",
                    HeaderText = "Email",
                    DataPropertyName = "Email",
                    Width = 200
                });
            }
            if (TGender.Checked)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Gender",
                    HeaderText = "Gender",
                    DataPropertyName = "Gender",
                    Width = 100
                });
            }
        }
        private void AddNewPersonRowToDataGrid(PersonReadDTO person)
        {
            var cells = new List<object>();
            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                switch (col.Name)
                {
                    case "Person ID":
                        cells.Add(person.PersonID);
                        break;
                    case "National No.":
                        cells.Add(person.NationalNo);
                        break;
                    case "Full Name":
                        cells.Add($"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}".Trim());
                        break;
                    case "Date of Birth":
                        cells.Add(person.DateOfBirth.ToString("yyyy-MM-dd"));
                        break;
                    case "Nationality":
                        cells.Add("Not Specified");
                        break;
                    case "Phone":
                        cells.Add(person.Phone);
                        break;
                    case "Email":
                        cells.Add(person.Email);
                        break;
                    case "Gender":
                        cells.Add(person.Gender);
                        break; 
                    default:
                        cells.Add(null);
                        break;
                }
            }
            dgvResults.Rows.Add(cells.ToArray());
        }
        private void AddListPersonRowToDataGrid(List<PersonReadDTO> lstPerson)
        {
            dgvResults.Rows.Clear();
            if (lstPerson != null && lstPerson.Count > 0)
            {
                foreach (PersonReadDTO person in lstPerson)
                {
                    AddNewPersonRowToDataGrid(person);
                }
            }
        }

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
        }

        private void cbSearchByLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            letter = cbSearchByLetter.Text == "All" ? "" : cbSearchByLetter.Text;
            if (letter != "")
            {
                txtSearch.Text = string.Empty;
            }
            AddListPersonRowToDataGrid(GetSearchResults().DataList);
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
                return enGender.Both;
            }

        }
        private void cbByGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedGender != GetSelectedGender())
            {
                selectedGender = GetSelectedGender();
                AddListPersonRowToDataGrid(GetSearchResults().DataList);
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
                AddListPersonRowToDataGrid(GetSearchResults().DataList);
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
            if (string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(letter))
            {
                searchText = letter;
            }
            SearchCriteria<PersonServices.enFields> searchBy = new SearchCriteria<PersonServices.enFields>
            {
                GenderFilter = GetSelectedGender(),
                FilterBy = SelectCurrentFilter(),
                SearchString = searchText,
                SearchType = enSearchType.Contain
            };
            return personServices.GetPeople(searchBy);
        }
        private void PerformSearch()
        {
            try
            {
                OperationResults<PersonReadDTO> results = GetSearchResults();

                if (results.IsSuccess && results.DataList?.Count > 0)
                {
                    lastSearchResult = txtSearch.Text;
                    AddListPersonRowToDataGrid(results.DataList);
                }
                else
                {
                    txtSearch.SuggestList = new string[0];
                    dgvResults.Rows.Clear();
                    Notification.Show($"No people found matching the search criteria.", IconType.Info, 3);

                }
            }
            catch (Exception ex)
            {
                Notification.Show($"Search error: {ex.Message}", IconType.Error, 3);
            }
        }

        private void columnsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem senderObject = sender as ToolStripMenuItem;

            string columnKey = (senderObject.Text ?? string.Empty).Trim();
            if (dgvResults.Columns.Contains(columnKey))
            {

                if (senderObject.Checked)
                {
                    dgvResults.Columns[columnKey].Visible = true;   
                }
                else
                {
                    dgvResults.Columns[columnKey].Visible = false;
                }
            }
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


