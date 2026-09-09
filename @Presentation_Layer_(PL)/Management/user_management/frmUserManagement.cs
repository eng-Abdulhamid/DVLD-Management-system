using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Management;
using DVLD.PL.Management.user_management;
using DVLD.PL.PeopleManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    public partial class frmUserManagement : frmBase
    {
        private readonly UserService _userService = new UserService();
        private List<UserReadDTO> _allUsers = new List<UserReadDTO>();
        private List<UserReadDTO> _filteredUsers = new List<UserReadDTO>();
        private readonly List<DataGridColumnDefinition> _columnDefinitions;

        public frmUserManagement()
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            // Setup DataGrid columns matching UserReadDTO schema
            _columnDefinitions = new List<DataGridColumnDefinition>
            {
                new DataGridColumnDefinition { Key = "UserID", HeaderText = "User ID", DataPropertyName = "UserID", Width = 120 },
                new DataGridColumnDefinition { Key = "PersonID", HeaderText = "Person ID", DataPropertyName = "PersonID", Width = 120 },
                new DataGridColumnDefinition { Key = "UserName", HeaderText = "Username", DataPropertyName = "UserName", Width = 220 },
                new DataGridColumnDefinition { Key = "IsActive", HeaderText = "Is Active", DataPropertyName = "IsActive", Width = 120 }
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
            this.Load += async (s, e) => await LoadUsersDataAsync();

            // Search control filter event
            ctrlUsersSearch1.OnFilterChanged += (col, text, isActive) => ApplyFilter(col, text, isActive);

            // Pagination events
            ctrlPagination1.OnPageChanged += (s, e) => DisplayCurrentPage();
            ctrlPagination1.OnPageSizeChanged += (s, e) =>
            {
                ctrlPagination1.CurrentPage = 1;
                DisplayCurrentPage();
            };

            // Actions toolbar events
            ctrlManagementActions1.OnAddClick += (s, e) => OpenAddNewUserDialog();
            ctrlManagementActions1.OnEditClick += (s, e) => OpenUpdateSelectedUserDialog();
            ctrlManagementActions1.OnDeleteClick += (s, e) => OpenDeleteSelectedUserDialog();
            ctrlManagementActions1.OnRefreshClick += async (s, e) => await LoadUsersDataAsync();

            // Grid selection state synchronization
            ctrlManagementDataGrid1.SelectionChanged += (s, e) =>
            {
                ctrlManagementActions1.UpdateButtonsState(ctrlManagementDataGrid1.HasSelection);
            };

            ctrlManagementDataGrid1.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) OpenViewUserCardDialog();
            };

            ctrlNotFound1.OnClearFilterClick += (s, e) =>
            {
                ctrlUsersSearch1.ClearFilter();
            };
        }

        private void InitializeRowContextMenu()
        {
            var menu = ctrlManagementDataGrid1.RowActionsContextMenu;
            menu.Items.Clear();

            menu.Items.Add(new ToolStripMenuItem("Show Details", Properties.Resources.details, (s, e) => OpenViewUserCardDialog()));
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem("Add New User", Properties.Resources.add_person, (s, e) => OpenAddNewUserDialog()) { ShortcutKeys = Keys.Control | Keys.N });
            menu.Items.Add(new ToolStripMenuItem("Edit User", Properties.Resources.edit_person, (s, e) => OpenUpdateSelectedUserDialog()) { ShortcutKeys = Keys.Control | Keys.E });
            menu.Items.Add(new ToolStripMenuItem("Delete User", Properties.Resources.bin, (s, e) => OpenDeleteSelectedUserDialog()) { ShortcutKeys = Keys.Delete });
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add(new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await LoadUsersDataAsync()) { ShortcutKeys = Keys.F5 });
        }

        private async Task LoadUsersDataAsync()
        {
            var result = await _userService.GetAllAsync();
            if (result.IsSuccess && result.DataList != null)
            {
                _allUsers = result.DataList;
                ApplyFilter(ctrlUsersSearch1.FilterColumn, ctrlUsersSearch1.SearchText, ctrlUsersSearch1.IsActiveStatus);
                UITheme.ShowSuccessToast("Users list updated successfully.");
            }
            else
            {
                _allUsers.Clear();
                ApplyFilter(string.Empty, string.Empty, null);
            }
        }

        private void ApplyFilter(string filterColumn, string searchText, bool? isActive)
        {
            IEnumerable<UserReadDTO> query = _allUsers;

            // Apply active status filter
            if (isActive.HasValue)
            {
                query = query.Where(u => u.IsActive == isActive.Value);
            }

            // Apply text-based search on matched column
            if (!string.IsNullOrWhiteSpace(filterColumn) && !string.IsNullOrWhiteSpace(searchText))
            {
                string search = searchText.ToLower();
                query = filterColumn switch
                {
                    "UserID" => query.Where(u => u.UserID.ToString().Contains(search)),
                    "PersonID" => query.Where(u => u.PersonID.ToString().Contains(search)),
                    "UserName" => query.Where(u => u.UserName.ToLower().Contains(search)),
                    _ => query
                };
            }

            _filteredUsers = query.ToList();

            // Update pagination metrics
            ctrlPagination1.TotalRecords = _filteredUsers.Count;
            ctrlPagination1.CurrentPage = 1;
            ctrlPagination1.UpdateUI();

            DisplayCurrentPage();
        }

        private void DisplayCurrentPage()
        {
            ctrlManagementDataGrid1.ClearRows();

            if (_filteredUsers.Count == 0)
            {
                ctrlNotFound1.Visible = true;
                ctrlNotFound1.BringToFront();
                ctrlManagementActions1.UpdateButtonsState(false);
                return;
            }

            ctrlNotFound1.Visible = false;

            int skip = (ctrlPagination1.CurrentPage - 1) * ctrlPagination1.PageSize;
            var pageData = _filteredUsers.Skip(skip).Take(ctrlPagination1.PageSize);

            foreach (var user in pageData)
            {
                ctrlManagementDataGrid1.AddRow(
                    user.UserID,
                    user.PersonID,
                    user.UserName,
                    user.IsActive ? "Yes" : "No"
                );
            }

            ctrlManagementDataGrid1.ClearSelection();
            ctrlManagementActions1.UpdateButtonsState(false);
        }

        private void OpenAddNewUserDialog()
        {
            using frmSaveUser frm = new frmSaveUser(-1, "User Management");
            frm.UserSaved += async (id) => await LoadUsersDataAsync();
            frm.ShowDialog();
        }

        private void OpenUpdateSelectedUserDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("UserID", out int id))
            {
                using frmSaveUser frm = new frmSaveUser(id, "User Management");
                frm.UserSaved += async (savedId) => await LoadUsersDataAsync();
                frm.ShowDialog();
            }
        }

        private void OpenDeleteSelectedUserDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("UserID", out int id))
            {
                using frmDeleteUser frm = new frmDeleteUser(id, "User Management");
                frm.DeletedSuccessfully += async () => await LoadUsersDataAsync();
                frm.ShowDialog();
            }
        }

        private void OpenViewUserCardDialog()
        {
            if (ctrlManagementDataGrid1.TryGetSelectedInt("UserID", out int value))
            {
                using (frmUserCard frm = new(UserID: value, "User Management"))
                {
                    frm.ShowDialog();
                } 
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N)) { OpenAddNewUserDialog(); return true; }
            if (keyData == (Keys.Control | Keys.E)) { OpenUpdateSelectedUserDialog(); return true; }
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D)) { OpenDeleteSelectedUserDialog(); return true; }
            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R)) { _ = LoadUsersDataAsync(); return true; }
            if (keyData == (Keys.Control | Keys.F)) { ctrlUsersSearch1.FocusSearchBox(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}