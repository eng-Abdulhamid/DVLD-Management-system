using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using DVLD.PL.UsersManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagement : BaseForm
    {
        public enum enMode
        {
            ManagePeople = 0,
            SelectPerson = 1
        }
        public event Action<int>? OnPersonSelected;
        private readonly enMode _mode;
        public int SelectedPersonID { get; private set; } = -1;
        public frmPeopleManagement(enMode mode = enMode.ManagePeople)
        {
            InitializeComponent();
            _mode = mode;
            SetContextTitle("People Management");

            InitializeDataGridColumns();
            ConfigureModeSettings();
            InitializeRowContextMenu();
            RegisterEvents();
            CenterOverlays();
            
            base.ApplyTheme();
            this.Icon = Resources.people;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterOverlays();
        }
        private void InitializeDataGridColumns()
        {
            var columnDefinitions = new List<DataGridColumnDefinition>
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

            ctrlManagementDataGrid1.InitializeColumns(columnDefinitions);
        }

        private void ConfigureModeSettings()
        {
            bool isSelectionMode = _mode == enMode.SelectPerson;

            ctrlManagementActions1.AddVisible = true;
            ctrlManagementActions1.RefreshVisible = true;
            ctrlManagementActions1.EditVisible = !isSelectionMode;
            ctrlManagementActions1.DeleteVisible = !isSelectionMode;

            btnSelect.Visible = isSelectionMode;
            if (isSelectionMode)
            {
                btnSelect.Location = new Point(ctrlManagementActions1.Right + 10, ctrlManagementActions1.Top);
                UpdateSelectButtonState(false);
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
        #region Context Menu Configuration

        private void InitializeRowContextMenu()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

            if (_mode == enMode.SelectPerson)
            {
                BuildSelectModeContextMenu(menu);
            }
            else
            {
                BuildManageModeContextMenu(menu);
            }
        }

        private void BuildSelectModeContextMenu(ContextMenuStrip menu)
        {
            var selectItem = new ToolStripMenuItem("Select Person", Properties.Resources.hasFounded, (s, e) => SelectCurrentPerson())
            {
                ShortcutKeyDisplayString = "Enter"
            };
            menu.Items.Add(selectItem);
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem("Show Details", Properties.Resources.details, (s, e) => OpenViewPersonCardDialog()));
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(CreateAddPersonMenuItem());
            menu.Items.Add(CreateRefreshMenuItem());
        }

        private void BuildManageModeContextMenu(ContextMenuStrip menu)
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

            menu.Items.Add(CreateAddPersonMenuItem());
            menu.Items.Add(CreateRefreshMenuItem());
        }

        private ToolStripMenuItem CreateAddPersonMenuItem()
        {
            return new ToolStripMenuItem("Add New Person", Properties.Resources.add_person, (s, e) => OpenAddNewPersonDialog())
            {
                ShortcutKeys = Keys.Control | Keys.N
            };
        }

        private ToolStripMenuItem CreateRefreshMenuItem()
        {
            return new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await HandleManualRefreshAsync())
            {
                ShortcutKeys = Keys.F5
            };
        }

        #endregion

        private void RegisterEvents()
        {
            SubscribeSearchAndPaginationEvents();
            SubscribeManagementActionEvents();
            SubscribeGridEvents();
            this.Load += FrmPeopleManagement_Load;
        }

        

        private void SubscribeSearchAndPaginationEvents()
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

            ctrlNotFound1.OnClearFilterClick += async (s, e) => await HandleClearSearchFilterAsync();
        }
        private void SubscribeManagementActionEvents()
        {
            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewPersonDialog();
            ctrlManagementActions1.OnEditClick += (s, e) => OpenUpdateSelectedPersonDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedPersonDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await HandleManualRefreshAsync();

            btnSelect.Click += (s, e) => SelectCurrentPerson();
        }
        private void SubscribeGridEvents()
        {
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
        }
        private async void FrmPeopleManagement_Load(object? sender, EventArgs e)
        {
            await HandleManualRefreshAsync();
        }
        #region Grid Data Population

        private void PopulateDataGrid(object? sender, OperationResults<PersonReadDTO> results)
        {
            ctrlManagementDataGrid1.ClearRows();

            if (!results.IsSuccess || results.DataList == null || results.DataList.Count == 0)
            {
                DisplayNoDataState();
                return;
            }

            DisplayDataState(results.DataList);
        }

        private void DisplayNoDataState()
        {
            ctrlNotFound1.Visible = true;
            ctrlNotFound1.BringToFront();
            ctrlManagementActions1.UpdateButtonsState(false);
            UpdateSelectButtonState(false);
        }

        private void DisplayDataState(List<PersonReadDTO> people)
        {
            ctrlNotFound1.Visible = false;

            foreach (var person in people)
            {
                ctrlManagementDataGrid1.AddRow(CreatePersonGridRow(person));
            }

            ctrlManagementDataGrid1.ClearSelection();
            ctrlManagementActions1.UpdateButtonsState(false);
            UpdateSelectButtonState(false);
        }

        private static object[] CreatePersonGridRow(PersonReadDTO person)
        {
            return new object[]
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
        }

        #endregion

        #region Action Handlers & Dialogs

        private void SelectCurrentPerson()
        {
            if (TryGetSelectedPersonId(out int id))
            {
                SelectedPersonID = id;
                OnPersonSelected?.Invoke(id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async Task OpenAddNewPersonDialog()
        {
            using var frm = new frmSavePerson();
            frm.PersonSaved += async (id) => await HandleManualRefreshAsync();
            await frm.ShowDialogAsync();
        }

        private async Task  OpenUpdateSelectedPersonDialog()
        {
            if (_mode == enMode.SelectPerson) return;

            if (TryGetSelectedPersonId(out int id))
            {
                using var frm = new frmSavePerson(id);
                frm.PersonSaved += async (savedId) => await HandleManualRefreshAsync();
                await frm.ShowDialogAsync();
            }
        }

        private async Task OpenDeleteSelectedPersonDialog()
        {
            if (_mode == enMode.SelectPerson) return;

            if (TryGetSelectedPersonId(out int id))
            {
                using var frm = new frmDeletePersonForm(id);
                frm.DeletedSuccessfully += async () => await HandleManualRefreshAsync();
                await frm.ShowDialogAsync();
            }
        }

        private async Task OpenViewPersonCardDialog()
        {
            if (TryGetSelectedPersonId(out int id))
            {
                using var frm = new frmPersonCard(id);
                frm.PersonDeleted += async () => await HandleManualRefreshAsync();
                frm.PersonUpdated += async (savedId) => await HandleManualRefreshAsync();
                await frm.ShowDialogAsync();
            }
        }

        private bool TryGetSelectedPersonId(out int personId)
        {
            return ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out personId);
        }

        private async Task HandleManualRefreshAsync()
        {
            await ctrlPeopleSearch1.PerformSearchAsync();
        }

        private async Task HandleClearSearchFilterAsync()
        {
            var txtSearchControls = ctrlPeopleSearch1.Controls.Find("txtSearch", true);
            if (txtSearchControls.Length > 0 && txtSearchControls[0] is CustomizeControls.NTextBox txt)
            {
                txt.Text = string.Empty;
            }

            await ctrlPeopleSearch1.PerformSearchAsync();
        }

        #endregion

        #region Keyboard Shortcuts

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

        #endregion
    }
}