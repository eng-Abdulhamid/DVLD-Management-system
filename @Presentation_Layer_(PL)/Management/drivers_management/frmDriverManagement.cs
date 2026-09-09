using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using DVLD.PL.PeopleManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.DriversManagement
{
    public partial class frmDriverManagement : frmBase
    {
        private readonly DriverService _driverService = new DriverService();
        private List<DriverReadDTO> _allDrivers = new List<DriverReadDTO>();
        private List<DriverReadDTO> _filteredDrivers = new List<DriverReadDTO>();
        private readonly List<DataGridColumnDefinition> _columnDefinitions;

        public frmDriverManagement()
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            // Setup DataGrid columns matching DriverReadDTO schema
            _columnDefinitions = new List<DataGridColumnDefinition>
            {
                new DataGridColumnDefinition { Key = "DriverID", HeaderText = "Driver ID", DataPropertyName = "DriverID", Width = 110 },
                new DataGridColumnDefinition { Key = "PersonID", HeaderText = "Person ID", DataPropertyName = "PersonID", Width = 110 },
                new DataGridColumnDefinition { Key = "CreatedByUserID", HeaderText = "Created By User ID", DataPropertyName = "CreatedByUserID", Width = 160 },
                new DataGridColumnDefinition { Key = "CreatedDate", HeaderText = "Created Date", DataPropertyName = "CreatedDate", Width = 180 }
            };

            ctrlManagementDataGrid1.InitializeColumns(_columnDefinitions);
            InitializeRowContextMenu();
            RegisterEvents();
            CenterOverlays();
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
            this.Load += async (s, e) => await LoadDriversDataAsync();

            // Drivers search control filter event
            ctrlDriversSearch1.OnFilterChanged += (col, text, letter) => ApplyFilter(col, text, letter);

            // Pagination events
            ctrlPagination1.OnPageChanged += (s, e) => DisplayCurrentPage();
            ctrlPagination1.OnPageSizeChanged += (s, e) =>
            {
                ctrlPagination1.CurrentPage = 1;
                DisplayCurrentPage();
            };

            // Toolbar action events
            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewDriverDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedDriverDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await LoadDriversDataAsync();

            // Grid selection state synchronization
            ctrlManagementDataGrid1.SelectionChanged += (s, e) =>
            {
                ctrlManagementActions1.UpdateButtonsState(ctrlManagementDataGrid1.HasSelection);
            };

            ctrlManagementDataGrid1.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) OpenViewPersonCardDialog();
            };

            ctrlNotFound1.OnClearFilterClick += (s, e) =>
            {
                ctrlDriversSearch1.ClearFilter();
            };
        }

        private void InitializeRowContextMenu()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

            menu.Items.Add(new ToolStripMenuItem("Show Person Info", Properties.Resources.User, (s, e) => OpenViewPersonCardDialog()));
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem("Add New Driver", Properties.Resources.add_person, (s, e) => OpenAddNewDriverDialog()) { ShortcutKeys = Keys.Control | Keys.N });
            menu.Items.Add(new ToolStripMenuItem("Delete Driver", Properties.Resources.bin, (s, e) => OpenDeleteSelectedDriverDialog()) { ShortcutKeys = Keys.Delete });
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await LoadDriversDataAsync()) { ShortcutKeys = Keys.F5 });
        }

        private async Task LoadDriversDataAsync()
        {
            var result = await _driverService.GetAllAsync();
            if (result.IsSuccess && result.DataList != null)
            {
                _allDrivers = result.DataList;
                ApplyFilter(ctrlDriversSearch1.FilterColumn, ctrlDriversSearch1.SearchText, ctrlDriversSearch1.Letter);
                UITheme.ShowSuccessToast("Drivers list updated successfully.");
            }
            else
            {
                _allDrivers.Clear();
                ApplyFilter(string.Empty, string.Empty, string.Empty);
            }
        }

        private void ApplyFilter(string filterColumn, string searchText, string letter)
        {
            IEnumerable<DriverReadDTO> query = _allDrivers;

            // Apply text-based search on matched column
            if (!string.IsNullOrWhiteSpace(filterColumn) && !string.IsNullOrWhiteSpace(searchText))
            {
                string search = searchText.ToLower();
                query = filterColumn switch
                {
                    "DriverID" => query.Where(d => d.DriverID.ToString().Contains(search)),
                    "PersonID" => query.Where(d => d.PersonID.ToString().Contains(search)),
                    _ => query
                };
            }

            _filteredDrivers = query.ToList();

            // Update pagination metrics
            ctrlPagination1.TotalRecords = _filteredDrivers.Count;
            ctrlPagination1.CurrentPage = 1;
            ctrlPagination1.UpdateUI();

            DisplayCurrentPage();
        }

        private void DisplayCurrentPage()
        {
            ctrlManagementDataGrid1.ClearRows();

            if (_filteredDrivers.Count == 0)
            {
                ctrlNotFound1.Visible = true;
                ctrlNotFound1.BringToFront();
                ctrlManagementActions1.UpdateButtonsState(false);
                return;
            }

            ctrlNotFound1.Visible = false;

            int skip = (ctrlPagination1.CurrentPage - 1) * ctrlPagination1.PageSize;
            var pageData = _filteredDrivers.Skip(skip).Take(ctrlPagination1.PageSize);

            foreach (var driver in pageData)
            {
                ctrlManagementDataGrid1.AddRow(
                    driver.DriverID,
                    driver.PersonID,
                    driver.CreatedByUserID,
                    driver.CreatedDate.ToString("dd MMM yyyy")
                );
            }

            ctrlManagementDataGrid1.ClearSelection();
            ctrlManagementActions1.UpdateButtonsState(false);
        }

        private void OpenAddNewDriverDialog()
        {
            using frmSaveDriver frm = new frmSaveDriver();
            frm.DriverSaved += async (id) => await LoadDriversDataAsync();
            frm.ShowDialog();
        }

        private void OpenDeleteSelectedDriverDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("DriverID", out int id))
            {
                using frmDeleteDriver frm = new frmDeleteDriver(id);
                frm.DeletedSuccessfully += async () => await LoadDriversDataAsync();
                frm.ShowDialog();
            }
        }

        private void OpenViewPersonCardDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int personId))
            {
                using frmPersonCard frm = new frmPersonCard(personId);
                frm.ShowDialog();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N)) { OpenAddNewDriverDialog(); return true; }
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D)) { OpenDeleteSelectedDriverDialog(); return true; }
            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R)) { _ = LoadDriversDataAsync(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}