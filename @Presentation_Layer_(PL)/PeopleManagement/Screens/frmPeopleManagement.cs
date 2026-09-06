using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagement : Form
    {
        private class ColumnDefinition
        {
            public string Key { get; set; }
            public string HeaderText { get; set; }
            public string DataPropertyName { get; set; }
            public int Width { get; set; }
            public ToolStripMenuItem ToolStripItem { get; set; }
            public ToolStripMenuItem ContextMenuItem { get; set; }
            public Func<PersonReadDTO, object> ValueSelector { get; set; }
        }

        private List<ColumnDefinition> _columnDefinitions;

        public frmPeopleManagement()
        {
            InitializeComponent();

            _columnDefinitions = new List<ColumnDefinition>
            {
                new ColumnDefinition
                {
                    Key = "PersonID",
                    HeaderText = "Person ID",
                    DataPropertyName = "PersonID",
                    Width = 80,
                    ToolStripItem = TPersonID,
                    ContextMenuItem = cmsPersonID,
                    ValueSelector = person => person.PersonID
                },

                new ColumnDefinition
                {
                    Key = "NationalNo",
                    HeaderText = "National No.",
                    DataPropertyName = "NationalNo",
                    Width = 120,
                    ToolStripItem = TNationalNo,
                    ContextMenuItem = cmsNationalNo,
                    ValueSelector = person => person.NationalNo
                },

                new ColumnDefinition
                {
                    Key = "FullName",
                    HeaderText = "Full Name",
                    DataPropertyName = "FullName",
                    Width = 200,
                    ToolStripItem = TFullName,
                    ContextMenuItem = cmsFullName,
                    ValueSelector = person => person.FullName
                },

                new ColumnDefinition
                {
                    Key = "DateOfBirth",
                    HeaderText = "Date of Birth",
                    DataPropertyName = "DateOfBirth",
                    Width = 100,
                    ToolStripItem = TDateOfBirth,
                    ContextMenuItem = cmsDateOfBirth,
                    ValueSelector = person => person.DateOfBirth.ToString("yyyy-MM-dd")
                },

                new ColumnDefinition
                {
                    Key = "Nationality",
                    HeaderText = "Nationality",
                    DataPropertyName = "Nationality",
                    Width = 120,
                    ToolStripItem = TNationality,
                    ContextMenuItem = cmsNationality,
                    ValueSelector = person => person.CountryName
                },

                new ColumnDefinition
                {
                    Key = "Phone",
                    HeaderText = "Phone",
                    DataPropertyName = "Phone",
                    Width = 120,
                    ToolStripItem = TPhone,
                    ContextMenuItem = cmsPhone,
                    ValueSelector = person => person.Phone
                },

                new ColumnDefinition
                {
                    Key = "Email",
                    HeaderText = "Email",
                    DataPropertyName = "Email",
                    Width = 200,
                    ToolStripItem = TEmail,
                    ContextMenuItem = cmsEmail,
                    ValueSelector = person => person.Email
                },

                new ColumnDefinition
                {
                    Key = "Gendor",
                    HeaderText = "Gendor",
                    DataPropertyName = "Gendor",
                    Width = 100,
                    ToolStripItem = TGendor,
                    ContextMenuItem = cmsGendor,
                    ValueSelector = person => person.Gendor
                }
            };

            InitializeFunctions();
        }

        private void InitializeFunctions()
        {
            InitializeDataGridColumns();
            ctrlPeopleSearch1.eventSearchResults += AddPeopleListInDataGrid;
            ctrlAddNewPersonBotton1.PersonSaved += PersonSaveEventHandler;
            timer.Tick += Timer_Tick;
        }

        private void InitializeDataGridColumns()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Clear();

            foreach (ColumnDefinition column in _columnDefinitions)
            {
                if (column.ToolStripItem.Checked)
                {
                    dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = column.Key,
                        HeaderText = column.HeaderText,
                        DataPropertyName = column.DataPropertyName,
                        Width = column.Width
                    });
                }
                column.ToolStripItem.Text = column.HeaderText;
                column.ToolStripItem.Tag = column.Key;
                column.ToolStripItem.Enabled = true;

                column.ContextMenuItem.Text = column.HeaderText;
                column.ContextMenuItem.Tag = column.Key;
                column.ContextMenuItem.Enabled = true;

            }
        }
        private void AddPeopleListInDataGrid(object sender, OperationResults<PersonReadDTO> lstPerson)
        {
            dgvResults.Rows.Clear();

            if (lstPerson == null || !lstPerson.IsSuccess)
                return;

            foreach (PersonReadDTO person in lstPerson.DataList)
            {
                AddPersonToDataGrid(person);
            }
        }

        private void AddPersonToDataGrid(PersonReadDTO person)
        {
            var cells = new List<object>();

            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                ColumnDefinition column = _columnDefinitions.Find(c => c.Key == col.Name);

                if (column != null)
                {
                    cells.Add(column.ValueSelector(person));
                }
            }

            dgvResults.Rows.Add(cells.ToArray());
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem senderObject = sender as ToolStripMenuItem;

            if (senderObject == null)
                return;

            string columnKey = senderObject.Tag?.ToString();

            if (string.IsNullOrEmpty(columnKey))
                return;

            if (dgvResults.Columns.Contains(columnKey))
            {
                dgvResults.Columns[columnKey].Visible = senderObject.Checked;

                foreach (ColumnDefinition column in _columnDefinitions)
                {
                    if (column.Key == columnKey)
                    {
                        column.ToolStripItem.Checked = senderObject.Checked;
                        column.ContextMenuItem.Checked = senderObject.Checked;
                        break;
                    }
                }
            }
        }

        Timer timer = new Timer();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshPeopleList();
            btnRefresh.Enabled = false;
            timer.Start();
            timer.Interval = 3000;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            timer.Stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshPeopleList();
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvResults.SelectedCells.Count > 0)
            {
                int personID = GetSelectedPersonIDFromDataGrid();

                using (frmPersonCard PersonCardForm = new frmPersonCard(personID))
                {
                    PersonCardForm.PersonDeleted += PersonDeletedSuccessfullyEventHundler;
                    PersonCardForm.PersonUpdated += PersonSaveEventHandler;
                    PersonCardForm.ShowDialog();
                }
            }
        }

        private void PersonSaveEventHandler(int personId)
        {
            RefreshPeopleList();
        }

        private void RefreshPeopleList()
        {
            ctrlPeopleSearch1.PerformSearch();
        }

        private void btnDeleteSelectedPerson_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedCells.Count > 0)
            {
                int personID = GetSelectedPersonIDFromDataGrid();

                if (personID > 0)
                {
                    using (frmDeletePersonForm DeletePersonForm = new frmDeletePersonForm(personID))
                    {
                        DeletePersonForm.DeletedSuccessfully += PersonDeletedSuccessfullyEventHundler;
                        DeletePersonForm.ShowDialog();
                    }
                }
            }
            else
            {
                Shared.ShowNotificaiton("Please select a person to delete.", "Delete Person", IconType.Info);
            }
        }

        private void PersonDeletedSuccessfullyEventHundler()
        {
            RefreshPeopleList();
        }

        private void btnUpdateSelectedPerson_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedCells.Count > 0)
            {
                int personID = GetSelectedPersonIDFromDataGrid();

                if (personID > 0)
                {
                    using (frmSavePerson frm = new frmSavePerson(personID))
                    {
                        frm.PersonSaved += PersonSaveEventHandler;
                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                Shared.ShowNotificaiton("Please select a person to edit.", "Edit Person", IconType.Info);
            }
        }

        private int GetSelectedPersonIDFromDataGrid()
        {
            object cellValue = dgvResults.SelectedRows[0].Cells["PersonID"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int personID))
            {
                return personID;
            }

            return -1;
        }

    }
}