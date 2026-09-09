using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.PL.Global.UITheme;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagement : frmBase
    {
        public enum enMode
        {
            ManagePeople = 0,
            SelectPerson = 1
        }

        private readonly enMode _mode;
        private readonly PersonService _personService = new PersonService();
        private readonly List<DataGridColumnDefinition> _columnDefinitions;

        public event Action<int>? OnPersonSelected;
        public int SelectedPersonID { get; private set; } = -1;

        public frmPeopleManagement(enMode mode = enMode.ManagePeople)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            _mode = mode;

            _columnDefinitions = new List<DataGridColumnDefinition>
            {
                new DataGridColumnDefinition { Key = "PersonID", HeaderText = "ID", DataPropertyName = "PersonID", Width = 70 },
                new DataGridColumnDefinition { Key = "NationalNo", HeaderText = "National No", DataPropertyName = "NationalNo", Width = 110 },
                new DataGridColumnDefinition { Key = "FullName", HeaderText = "Full Name", DataPropertyName = "FullName", Width = 230 },
                new DataGridColumnDefinition { Key = "DateOfBirth", HeaderText = "Birth Date", DataPropertyName = "DateOfBirth", Width = 100 },
                new DataGridColumnDefinition { Key = "Gender", HeaderText = "Gender", DataPropertyName = "Gender", Width = 80 },
                new DataGridColumnDefinition { Key = "Nationality", HeaderText = "Nationality", DataPropertyName = "CountryName", Width = 130 },
                new DataGridColumnDefinition { Key = "Phone", HeaderText = "Phone", DataPropertyName = "Phone", Width = 120 },
                new DataGridColumnDefinition { Key = "Email", HeaderText = "Email", DataPropertyName = "Email", Width = 180 }
            };

            ctrlManagementDataGrid1.InitializeColumns(_columnDefinitions);
            ConfigureModeSettings();
            InitializeRowContextMenu();
            RegisterEvents();

            CenterOverlays();
        }

        private void ConfigureModeSettings()
        {
            if (_mode == enMode.SelectPerson)
            {
                this.Text = "DVLD / Select Person";
                headerControl.TitleText = "DVLD / Select Person";

                ctrlManagementActions1.AddVisible = true;
                ctrlManagementActions1.RefreshVisible = true;
                ctrlManagementActions1.EditVisible = false;
                ctrlManagementActions1.DeleteVisible = false;

                btnSelect.Visible = true;
                btnSelect.Location = new Point(ctrlManagementActions1.Right + 10, 92);

                UpdateSelectButtonState(false);
            }
            else
            {
                this.Text = "DVLD / People Management";
                headerControl.TitleText = "DVLD / People Management";

                ctrlManagementActions1.AddVisible = true;
                ctrlManagementActions1.RefreshVisible = true;
                ctrlManagementActions1.EditVisible = true;
                ctrlManagementActions1.DeleteVisible = true;

                btnSelect.Visible = false;
            }
        }

        private void UpdateSelectButtonState(bool hasSelection)
        {
            if (_mode != enMode.SelectPerson) return;

            btnSelect.Enabled = hasSelection;

            if (hasSelection)
            {
                btnSelect.ApplyPrimaryStyle();
            }
            else
            {
                btnSelect.ApplyDisabledStyle();
            }

            btnSelect.Update();
        }

        private void CenterOverlays()
        {
            if (ctrlNotFound1 == null || pnlMain == null) return;
            ctrlNotFound1.Location = new Point(
                Math.Max(0, (pnlMain.Width - ctrlNotFound1.Width) / 2),
                Math.Max(0, (pnlMain.Height - ctrlNotFound1.Height) / 2 + 30)
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterOverlays();
        }

        private void RegisterEvents()
        {
            ctrlPeopleSearch1.OnSearchResultsReceived += PopulateDataGrid;
            ctrlPeopleSearch1.OnTotalCountReceived += (total) =>
            {
                ctrlPagination1.TotalRecords = total;
                ctrlPagination1.UpdateUI();
            };

            ctrlPagination1.OnPageChanged += async (s, e) =>
            {
                ctrlPeopleSearch1.PageNumber = ctrlPagination1.CurrentPage;
                await ctrlPeopleSearch1.PerformSearchAsync();
            };

            ctrlPagination1.OnPageSizeChanged += async (s, e) =>
            {
                ctrlPeopleSearch1.PageSize = ctrlPagination1.PageSize;
                ctrlPeopleSearch1.PageNumber = 1;
                await ctrlPeopleSearch1.PerformSearchAsync();
            };

            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewPersonDialog();
            ctrlManagementActions1.OnEditClick += (s, e) => OpenUpdateSelectedPersonDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedPersonDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await HandleManualRefreshAsync();

            btnSelect.Click += (s, e) => SelectCurrentPerson();

            ctrlManagementDataGrid1.SelectionChanged += (s, e) =>
            {
                bool hasSelection = ctrlManagementDataGrid1.HasSelection;
                ctrlManagementActions1.UpdateButtonsState(hasSelection);
                UpdateSelectButtonState(hasSelection);
            };

            ctrlManagementDataGrid1.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;

                if (_mode == enMode.SelectPerson)
                {
                    SelectCurrentPerson();
                }
                else
                {
                    OpenViewPersonCardDialog();
                }
            };

            ctrlNotFound1.OnClearFilterClick += async (s, e) =>
            {
                var txtSearch = ctrlPeopleSearch1.Controls.Find("txtSearch", true);
                if (txtSearch.Length > 0 && txtSearch[0] is NControls.NTextBox txt)
                {
                    txt.Text = string.Empty;
                }
                await ctrlPeopleSearch1.PerformSearchAsync();
            };

        }

        private void InitializeRowContextMenu()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

            if (_mode == enMode.SelectPerson)
            {
                var selectItem = new ToolStripMenuItem("Select Person", Properties.Resources.hasFounded, (s, e) => SelectCurrentPerson())
                {
                    ShortcutKeyDisplayString = "Enter"
                };
                menu.Items.Add(selectItem);
                menu.Items.Add(new ToolStripSeparator());

                menu.Items.Add(new ToolStripMenuItem("Show Details", Properties.Resources.details, (s, e) => OpenViewPersonCardDialog()));
                menu.Items.Add(new ToolStripSeparator());

                var addItem = new ToolStripMenuItem("Add New Person", Properties.Resources.add_person, (s, e) => OpenAddNewPersonDialog())
                {
                    ShortcutKeys = Keys.Control | Keys.N
                };
                menu.Items.Add(addItem);

                var refreshItem = new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await HandleManualRefreshAsync())
                {
                    ShortcutKeys = Keys.F5
                };
                menu.Items.Add(refreshItem);
            }
            else
            {
                menu.Items.Add(new ToolStripMenuItem("Show Details", Properties.Resources.details, (s, e) => OpenViewPersonCardDialog()));
                menu.Items.Add(new ToolStripSeparator());

                var editItem = new ToolStripMenuItem("Edit Person", Properties.Resources.edit_person, (s, e) => OpenUpdateSelectedPersonDialog())
                {
                    ShortcutKeys = Keys.Control | Keys.E
                };
                menu.Items.Add(editItem);

                var deleteItem = new ToolStripMenuItem("Delete Person", Properties.Resources.bin, (s, e) => OpenDeleteSelectedPersonDialog())
                {
                    ShortcutKeys = Keys.Delete
                };
                menu.Items.Add(deleteItem);

                menu.Items.Add(new ToolStripSeparator());

                var addItem = new ToolStripMenuItem("Add New Person", Properties.Resources.add_person, (s, e) => OpenAddNewPersonDialog())
                {
                    ShortcutKeys = Keys.Control | Keys.N
                };
                menu.Items.Add(addItem);

                var refreshItem = new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await HandleManualRefreshAsync())
                {
                    ShortcutKeys = Keys.F5
                };
                menu.Items.Add(refreshItem);
            }
        }

        private void SelectCurrentPerson()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int id))
            {
                SelectedPersonID = id;
                OnPersonSelected?.Invoke(id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void PopulateDataGrid(object? sender, OperationResults<PersonReadDTO> results)
        {
            ctrlManagementDataGrid1.ClearRows();

            if (!results.IsSuccess || results.DataList == null || results.DataList.Count == 0)
            {
                ctrlNotFound1.Visible = true;
                ctrlNotFound1.BringToFront();
                ctrlManagementActions1.UpdateButtonsState(false);
                UpdateSelectButtonState(false);
                return;
            }

            ctrlNotFound1.Visible = false;

            foreach (PersonReadDTO person in results.DataList)
            {
                var row = new object[]
                {
                    person.PersonID,
                    person.NationalNo,
                    person.FullName,
                    person.DateOfBirth.ToString("dd MMM yyyy"),
                    person.Gendor.ToString(),
                    person.CountryName,
                    person.Phone,
                    string.IsNullOrWhiteSpace(person.Email) ? "-" : person.Email
                };
                ctrlManagementDataGrid1.AddRow(row);
            }

            ctrlManagementDataGrid1.ClearSelection();
            ctrlManagementActions1.UpdateButtonsState(false);
            UpdateSelectButtonState(false);
        }

        private async Task HandleManualRefreshAsync()
        {
            await ctrlPeopleSearch1.PerformSearchAsync();
            UITheme.ShowSuccessToast("People records reloaded successfully.");
        }

        private void OpenAddNewPersonDialog()
        {
            using frmSavePerson frm = new frmSavePerson();
            frm.PersonSaved += async (id) => await ctrlPeopleSearch1.PerformSearchAsync();
            frm.ShowDialog();
        }

        private void OpenUpdateSelectedPersonDialog()
        {
            if (_mode == enMode.SelectPerson) return;

            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int id))
            {
                using frmSavePerson frm = new frmSavePerson(id);
                frm.PersonSaved += async (savedId) => await ctrlPeopleSearch1.PerformSearchAsync();
                frm.ShowDialog();
            }
        }

        private void OpenDeleteSelectedPersonDialog()
        {
            if (_mode == enMode.SelectPerson) return;

            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int id))
            {
                using frmDeletePersonForm frm = new frmDeletePersonForm(id);
                frm.DeletedSuccessfully += async () => await ctrlPeopleSearch1.PerformSearchAsync();
                frm.ShowDialog();
            }
        }

        private void OpenViewPersonCardDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int id))
            {
                using frmPersonCard frm = new frmPersonCard(id);
                frm.PersonDeleted += async () => await ctrlPeopleSearch1.PerformSearchAsync();
                frm.PersonUpdated += async (savedId) => await ctrlPeopleSearch1.PerformSearchAsync();
                frm.ShowDialog();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_mode == enMode.SelectPerson)
            {
                if (keyData == Keys.Enter && ctrlManagementDataGrid1.HasSelection)
                {
                    SelectCurrentPerson();
                    return true;
                }
            }
            else
            {
                if (keyData == (Keys.Control | Keys.E)) { OpenUpdateSelectedPersonDialog(); return true; }
                if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D)) { OpenDeleteSelectedPersonDialog(); return true; }
            }

            if (keyData == (Keys.Control | Keys.N)) { OpenAddNewPersonDialog(); return true; }
            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R)) { _ = HandleManualRefreshAsync(); return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}