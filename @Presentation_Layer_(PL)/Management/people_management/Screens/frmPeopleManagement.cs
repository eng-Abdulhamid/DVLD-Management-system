using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using static DVLD.PL.Global.UITheme;
namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagement : frmBase
    {
        private readonly PersonService _personService = new PersonService();
        private readonly List<DataGridColumnDefinition> _columnDefinitions;

        public frmPeopleManagement()
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

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
            InitializeRowContextMenu();
            RegisterEvents();
            ApplyStyles();

            CenterOverlays();
        }

        private void ApplyStyles()
        {
            btnSettings.ApplySecondaryStyle();
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
            // Search Control Events
            ctrlPeopleSearch1.OnSearchResultsReceived += PopulateDataGrid;
            ctrlPeopleSearch1.OnTotalCountReceived += (total) =>
            {
                ctrlPagination1.TotalRecords = total;
                ctrlPagination1.UpdateUI();
            };

            // Pagination Events
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

            // Grid Actions
            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewPersonDialog();
            ctrlManagementActions1.OnEditClick += (s, e) => OpenUpdateSelectedPersonDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedPersonDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await HandleManualRefreshAsync();

            // Grid Selection & Row Events
            ctrlManagementDataGrid1.SelectionChanged += (s, e) =>
            {
                ctrlManagementActions1.UpdateButtonsState(ctrlManagementDataGrid1.HasSelection);
            };

            ctrlManagementDataGrid1.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) OpenViewPersonCardDialog();
            };

            // Empty State Handling
            ctrlNotFound1.OnClearFilterClick += async (s, e) =>
            {
                var txtSearch = ctrlPeopleSearch1.Controls.Find("txtSearch", true);
                if (txtSearch.Length > 0 && txtSearch[0] is NControls.NTextBox txt)
                {
                    txt.Text = string.Empty;
                }
                await ctrlPeopleSearch1.PerformSearchAsync();
            };

            btnSettings.Click += (s, e) =>
            {
                using frmPeopleManagementSettings frm = new frmPeopleManagementSettings();
                frm.ShowDialog();
            };
        }

        private void InitializeRowContextMenu()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

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

        private void PopulateDataGrid(object? sender, OperationResults<PersonReadDTO> results)
        {
            ctrlManagementDataGrid1.ClearRows();

            if (!results.IsSuccess || results.DataList == null || results.DataList.Count == 0)
            {
                ctrlNotFound1.Visible = true;
                ctrlNotFound1.BringToFront();
                ctrlManagementActions1.UpdateButtonsState(false);
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
            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int id))
            {
                using frmSavePerson frm = new frmSavePerson(id);
                frm.PersonSaved += async (savedId) => await ctrlPeopleSearch1.PerformSearchAsync();
                frm.ShowDialog();
            }
        }

        private void OpenDeleteSelectedPersonDialog()
        {
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
            if (keyData == (Keys.Control | Keys.N)) { OpenAddNewPersonDialog(); return true; }
            if (keyData == (Keys.Control | Keys.E)) { OpenUpdateSelectedPersonDialog(); return true; }
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D)) { OpenDeleteSelectedPersonDialog(); return true; }
            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R)) { _ = HandleManualRefreshAsync(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}