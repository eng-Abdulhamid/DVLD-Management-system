using DTOs;
using DVLD_BusinessLogicLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace DVLDPL.PeopleManagement
{
    public partial class frmPeopleManagement : Form
    {
        public frmPeopleManagement()
        {
            InitializeComponent();
            InitializeToolStripMenuItems();
            ctrlPeopleSearch1.eventSearchResults += AddListPersonRowToDataGrid;
            ctrlAddNewPersonBotton1.PersonSaved += PersonSaveEventHandler;
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
        private void AddListPersonRowToDataGrid(object sender, OperationResults<PersonReadDTO> lstPerson)
        {
            dgvResults.Rows.Clear();
            if (lstPerson == null) return;
            if (lstPerson.IsSuccess)
            {
                if (lstPerson.DataList.Count > 0)
                {
                    dgvResults.Rows.Clear();
                    if (lstPerson != null && lstPerson.DataList.Count > 0)
                    {
                        foreach (PersonReadDTO person in lstPerson.DataList)
                        {
                            AddNewPersonRowToDataGrid(person);
                        }
                    }
                }
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
                        cells.Add(person.CountryName);
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
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshPeopleList();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshPeopleList();
        }

        private void ctrlAddNewPersonBotton1_Load(object sender, EventArgs e)
        {

        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int personID = GetSelectedPersonIDFromDataGrid();
            frmPersonCard PersonCardForm = new frmPersonCard(personID);

            PersonCardForm.PersonDeleted += PersonDeletedSuccessfullyEventHundler;
            PersonCardForm.PersonUpdated += PersonSaveEventHandler;
            PersonCardForm.ShowDialog();

        }
        private void PersonSaveEventHandler(int personId)
        {
            RefreshPeopleList();
        }
        private void RefreshPeopleList()
        {
            ctrlPeopleSearch1.PerformSearch();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        
        private void btnDeleteSelectedPerson_Click(object sender, EventArgs e)
        {
            int personID = GetSelectedPersonIDFromDataGrid();
            if (personID > 0)
            {
                frmDeletePersonForm DeletePersonForm = new frmDeletePersonForm(personID);
                DeletePersonForm.DeletedSuccessfully += PersonDeletedSuccessfullyEventHundler;
                DeletePersonForm.ShowDialog();
            }

        }
        private void PersonDeletedSuccessfullyEventHundler()
        {
            RefreshPeopleList();
        }

        private void btnUpdateSelectedPerson_Click(object sender, EventArgs e)
        {
            int personID = GetSelectedPersonIDFromDataGrid();
            if (personID > 0)
            {
                frmSavePerson frm = new frmSavePerson(personID);

                frm.PersonSaved += PersonSaveEventHandler;

                frm.ShowDialog();
            }
        }
        private int GetSelectedPersonIDFromDataGrid()
        {
            object cellValue = dgvResults.SelectedRows[0].Cells["Person ID"].Value;
            if (cellValue != null && int.TryParse(cellValue.ToString(), out int personID))
            {
                return personID;
            }
            return -1;

        }
    }
}
