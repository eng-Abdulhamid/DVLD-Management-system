using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using DVLD.PL.PeopleManagement;
namespace DVLD.PL.DriversManagement
{
    public partial class frmDriverManagement : frmBase
    {
        #region Properties and the Constructor
        private readonly DriverService _driverService = new DriverService();
        private List<DriverReadDTO> _allDrivers = new List<DriverReadDTO>();
        private List<DriverReadDTO> _filteredDrivers = new List<DriverReadDTO>();
        private readonly List<DataGridColumnDefinition> _columnDefinitions;

        public frmDriverManagement()
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();
            SetContextTitle("Drivers Management");

            _columnDefinitions = new List<DataGridColumnDefinition>
            {
                new DataGridColumnDefinition 
                { 
                    Key = "DriverID", 
                    HeaderText = "Driver ID", 
                    DataPropertyName = "DriverID", 
                    Width = 110 
                },
                new DataGridColumnDefinition 
                { 
                    Key = "PersonID", 
                    HeaderText = "Person ID", 
                    DataPropertyName = "PersonID", 
                    Width = 110 
                },
                new DataGridColumnDefinition 
                { 
                    Key = "CreatedByUserID", 
                    HeaderText = "Created By User ID", 
                    DataPropertyName = "CreatedByUserID", 
                    Width = 160 
                },
                new DataGridColumnDefinition 
                { 
                    Key = "CreatedDate", 
                    HeaderText = "Created Date", 
                    DataPropertyName = "CreatedDate", 
                    Width = 180 
                }
            };

            ctrlManagementDataGrid1.InitializeColumns(_columnDefinitions);
            InitializeRowContextMenuInDataGrid();
            RegisterEvents();
            CenterOverlays();
        }
        private void InitializeRowContextMenuInDataGrid()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

            menu.Items.Add(
                new ToolStripMenuItem
                (
                    "Show Driver Info", 
                    Properties.Resources.User, (s, e) => OpenViewDriverCardDialog())
                );

            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem(
                    "Add New Driver",
                    Properties.Resources.add_person, (s, e) => OpenAddNewDriverDialog()) 
            {
                ShortcutKeys = Keys.Control | Keys.N 
            });

            menu.Items.Add(new ToolStripMenuItem(
                    "Edit Person Info",
                    Properties.Resources.edit_person, (s, e) => OpenEditPersonDialog())
            {
                ShortcutKeys = Keys.Control | Keys.E
            });

            menu.Items.Add(new ToolStripMenuItem(
                    "Delete Driver",
                    Properties.Resources.bin, (s, e) => OpenDeleteSelectedDriverDialog())
            {
                ShortcutKeys = Keys.Delete
            });

            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem(
                    "Refresh", 
                    Properties.Resources.refresh, async (s, e) => await LoadDriversDataAsync())
            {
                ShortcutKeys = Keys.F5
            });
        }
        #region Register Events
        private void RegisterEvents()
        {
            this.Load += async (s, e) => await LoadDriversDataAsync();

            ctrlDriversSearch1.OnFilterChanged += (col, text, letter) => ApplyFilter(col, text, letter);

            ctrlPagination1.OnPageChanged += (s, e) => DisplayCurrentPage();
            ctrlPagination1.OnPageSizeChanged += (s, e) =>
            {
                ctrlPagination1.CurrentPage = 1;
                DisplayCurrentPage();
            };

            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewDriverDialog();
            ctrlManagementActions1.OnEditClick += (s, e) => OpenEditPersonDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedDriverDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await LoadDriversDataAsync();

            ctrlManagementDataGrid1.SelectionChanged += (s, e) =>
            {
                ctrlManagementActions1.UpdateButtonsState(ctrlManagementDataGrid1.HasSelection);
            };

            ctrlManagementDataGrid1.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) OpenViewDriverCardDialog();
            };

            ctrlNotFound1.OnClearFilterClick += (s, e) =>
            {
                ctrlDriversSearch1.ClearFilter();
            };
        }
        private async Task LoadDriversDataAsync()
        {
            var result = await _driverService.GetAllAsync();
            if (result.IsSuccess && result.DataList != null)
            {
                _allDrivers = result.DataList;
                ApplyFilter(ctrlDriversSearch1.FilterColumn, ctrlDriversSearch1.SearchText, ctrlDriversSearch1.Letter);
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

            if (!string.IsNullOrEmpty(letter))
            {
                // Reflection ensures safety if 'FullName' is missing from standard DTOs
                query = query.Where(d => d.GetType().GetProperty("FullName")?.GetValue(d)?.ToString()?.StartsWith(letter, StringComparison.OrdinalIgnoreCase) == true);
            }

            if (!string.IsNullOrWhiteSpace(filterColumn) && !string.IsNullOrWhiteSpace(searchText))
            {
                string search = searchText.ToLower();
                query = filterColumn switch
                {
                    "DriverID" => query.Where(d => d.DriverID.ToString().Contains(search)),
                    "PersonID" => query.Where(d => d.PersonID.ToString().Contains(search)),
                    "NationalNo" => query.Where(d => d.GetType().GetProperty("NationalNo")?.GetValue(d)?.ToString()?.ToLower().Contains(search) == true),
                    "FullName" => query.Where(d => d.GetType().GetProperty("FullName")?.GetValue(d)?.ToString()?.ToLower().Contains(search) == true),
                    _ => query
                };
            }

            _filteredDrivers = query.ToList();

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
        #endregion
        private void CenterOverlays()
        {
            if (ctrlNotFound1 == null || pnlMain == null) return;
            ctrlNotFound1.Location = new Point(
                Math.Max(0, (pnlMain.Width - ctrlNotFound1.Width) / 2),
                Math.Max(0, (pnlMain.Height - ctrlNotFound1.Height) / 2 + 30)
            );
        }
        #endregion
        #region Operation forms
        private void OpenAddNewDriverDialog()
        {
            using frmSaveDriver frm = new frmSaveDriver();
            frm.DriverSaved += async (id) => await LoadDriversDataAsync();
            frm.ShowDialog(this);
        }
        private void OpenEditPersonDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("PersonID", out int personId))
            {
                using frmSavePerson frm = new frmSavePerson(personId);
                frm.PersonSaved += async (id) => await LoadDriversDataAsync();
                frm.ShowDialog(this);
            }
        }
        private void OpenDeleteSelectedDriverDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("DriverID", out int driverId))
            {
                using frmDeleteDriver frm = new frmDeleteDriver(driverId);
                frm.DeletedSuccessfully += async () => await LoadDriversDataAsync();
                frm.ShowDialog(this);
            }
        }
        private void OpenViewDriverCardDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("DriverID", out int driverId))
            {
                using frmDriverCard frm = new frmDriverCard(driverId);
                frm.ShowDialog(this);
            }
        }
        #endregion
        #region Override functions
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N)) { OpenAddNewDriverDialog(); return true; }
            if (keyData == (Keys.Control | Keys.E)) { OpenEditPersonDialog(); return true; }
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D)) { OpenDeleteSelectedDriverDialog(); return true; }
            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R)) { _ = LoadDriversDataAsync(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterOverlays();
        }
        #endregion
    }
}