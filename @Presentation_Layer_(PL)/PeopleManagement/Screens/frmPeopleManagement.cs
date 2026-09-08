using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagement : frmBase
    {
        private class ColumnDefinition
        {
            public string Key { get; set; } = string.Empty;
            public string HeaderText { get; set; } = string.Empty;
            public string DataPropertyName { get; set; } = string.Empty;
            public int Width { get; set; }
            public ToolStripMenuItem? ToolStripItem { get; set; }
            public Func<PersonReadDTO, object>? ValueSelector { get; set; }
        }

        private readonly List<ColumnDefinition> _columnDefinitions;
        private ToolTip? _toolTips;
        private int _totalRecords = 0;
        private bool _isPageSizeChanging = false;
        private readonly PersonService _personService = new PersonService();

        public frmPeopleManagement()
        {
            InitializeComponent();

            this.ApplyStandardFormTheme();

            _columnDefinitions = new List<ColumnDefinition>
            {
                new ColumnDefinition { Key = "PersonID", HeaderText = "ID", DataPropertyName = "PersonID", Width = 70, ValueSelector = p => p.PersonID },
                new ColumnDefinition { Key = "NationalNo", HeaderText = "National No", DataPropertyName = "NationalNo", Width = 110, ValueSelector = p => p.NationalNo },
                new ColumnDefinition { Key = "FullName", HeaderText = "Full Name", DataPropertyName = "FullName", Width = 230, ValueSelector = p => p.FullName },
                new ColumnDefinition { Key = "DateOfBirth", HeaderText = "Birth Date", DataPropertyName = "DateOfBirth", Width = 100, ValueSelector = p => p.DateOfBirth.ToString("dd MMM yyyy") },
                new ColumnDefinition { Key = "Gender", HeaderText = "Gender", DataPropertyName = "Gender", Width = 80, ValueSelector = p => p.Gendor.ToString() },
                new ColumnDefinition { Key = "Nationality", HeaderText = "Nationality", DataPropertyName = "CountryName", Width = 130, ValueSelector = p => p.CountryName },
                new ColumnDefinition { Key = "Phone", HeaderText = "Phone", DataPropertyName = "Phone", Width = 120, ValueSelector = p => p.Phone },
                new ColumnDefinition { Key = "Email", HeaderText = "Email", DataPropertyName = "Email", Width = 180, ValueSelector = p => string.IsNullOrWhiteSpace(p.Email) ? "-" : p.Email }
            };

            EnableDoubleBuffering(dgvResults);
            InitializeDataGridColumns();
            InitializeRowContextMenu();
            RegisterEvents();
            ApplyStyles();
            SetupToolTips();

            _isPageSizeChanging = true;
            cmbPageSize.SelectedIndex = 1;
            ctrlPeopleSearch1.PageSize = 25;
            _isPageSizeChanging = false;

            CenterOverlays();

            if (UIUtility.IsDesignMode) return;
            UpdateActionButtonsState();
        }

        private void ApplyStyles()
        {
            btnAddNewPerson.ApplySecondaryStyle();
            btnRefresh.ApplySecondaryStyle();
            btnSettings.ApplySecondaryStyle();
            btnUpdate.ApplySecondaryStyle();
            btnDelete.ApplySecondaryStyle();

            btnPrevPage.ApplySecondaryStyle();
            btnNextPage.ApplySecondaryStyle();
            btnClearFilter.ApplySecondaryStyle();

            cmbPageSize.ApplyStandardStyle();
            dgvResults.ApplyModernStyle();
        }

        private void CenterOverlays()
        {
            if (pnlMain == null || pnlEmptyState == null || pnlLoadingOverlay == null)
                return;

            pnlEmptyState.Location = new Point(
                Math.Max(0, (pnlMain.Width - pnlEmptyState.Width) / 2),
                Math.Max(0, (pnlMain.Height - pnlEmptyState.Height) / 2 + 30)
            );

            pnlLoadingOverlay.Location = new Point(
                Math.Max(0, (pnlMain.Width - pnlLoadingOverlay.Width) / 2),
                Math.Max(0, (pnlMain.Height - pnlLoadingOverlay.Height) / 2 + 30)
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterOverlays();
        }

        private void EnableDoubleBuffering(DataGridView dgv)
        {
            PropertyInfo? pi = dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 250,
                ReshowDelay = 100,
                AutoPopDelay = 5000,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnAddNewPerson, "Add new person (Ctrl + N)");
            _toolTips.SetToolTip(btnRefresh, "Refresh list (F5 / Ctrl + R)");
            _toolTips.SetToolTip(btnSettings, "Column preferences");
            _toolTips.SetToolTip(btnPrevPage, "Previous page");
            _toolTips.SetToolTip(btnNextPage, "Next page");
            _toolTips.SetToolTip(cmbPageSize, "Rows per page");

            UpdateToolTipsForActionButtons();
        }

        private void UpdateToolTipsForActionButtons()
        {
            if (_toolTips == null) return;

            bool hasSelection = dgvResults.SelectedRows.Count > 0;
            _toolTips.SetToolTip(btnUpdate, hasSelection ? "Edit selected person (Ctrl + E)" : "Select a record to edit");
            _toolTips.SetToolTip(btnDelete, hasSelection ? "Delete selected person (Delete / Ctrl + D)" : "Select a record to delete");
        }

        private void RegisterEvents()
        {
            ctrlPeopleSearch1.OnSearchResultsReceived += PopulateDataGrid;
            ctrlPeopleSearch1.OnTotalCountReceived += UpdateTotalCount;

            dgvResults.SelectionChanged += (s, e) => UpdateActionButtonsState();
            dgvResults.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) OpenViewPersonCardDialog(); };
            dgvResults.MouseDown += DgvResults_MouseDown;

            btnAddNewPerson.Click += (s, e) => OpenAddNewPersonDialog();
            btnUpdate.Click += (s, e) => OpenUpdateSelectedPersonDialog();
            btnDelete.Click += (s, e) => OpenDeleteSelectedPersonDialog();
            btnRefresh.Click += async (s, e) => await HandleManualRefreshAsync();
            btnSettings.Click += (s, e) => OpenSettingsDialog();

            btnClearFilter.Click += async (s, e) =>
            {
                var txtSearchBox = ctrlPeopleSearch1.Controls.Find("txtSearch", true);
                if (txtSearchBox.Length > 0 && txtSearchBox[0] is NControls.NTextBox txt)
                {
                    txt.Text = string.Empty;
                }
                await ExecuteSearchWithOverlayAsync();
            };

            btnNextPage.Click += async (s, e) =>
            {
                int totalPages = (int)Math.Ceiling((double)_totalRecords / ctrlPeopleSearch1.PageSize);
                if (ctrlPeopleSearch1.PageNumber < totalPages)
                {
                    ctrlPeopleSearch1.PageNumber++;
                    await ExecuteSearchWithOverlayAsync();
                }
            };

            btnPrevPage.Click += async (s, e) =>
            {
                if (ctrlPeopleSearch1.PageNumber > 1)
                {
                    ctrlPeopleSearch1.PageNumber--;
                    await ExecuteSearchWithOverlayAsync();
                }
            };

            cmbPageSize.SelectedIndexChanged += async (s, e) =>
            {
                if (_isPageSizeChanging) return;

                if (int.TryParse(cmbPageSize.Text, out int size))
                {
                    ctrlPeopleSearch1.PageSize = Math.Min(size, 100);
                    ctrlPeopleSearch1.PageNumber = 1;
                    await ExecuteSearchWithOverlayAsync();
                }
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                OpenAddNewPersonDialog();
                return true;
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                OpenUpdateSelectedPersonDialog();
                return true;
            }

            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.D))
            {
                OpenDeleteSelectedPersonDialog();
                return true;
            }

            if (keyData == Keys.F5 || keyData == (Keys.Control | Keys.R))
            {
                _ = HandleManualRefreshAsync();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                var searchBox = ctrlPeopleSearch1.Controls.Find("txtSearch", true);
                if (searchBox.Length > 0)
                {
                    searchBox[0].Focus();
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async Task ExecuteSearchWithOverlayAsync()
        {
            ShowLoadingOverlay(true);
            try
            {
                await ctrlPeopleSearch1.PerformSearchAsync();
            }
            finally
            {
                ShowLoadingOverlay(false);
            }
        }

        private void ShowLoadingOverlay(bool show)
        {
            if (pnlLoadingOverlay == null || pnlEmptyState == null) return;

            pnlLoadingOverlay.Visible = show;
            if (show)
            {
                pnlLoadingOverlay.BringToFront();
                pnlEmptyState.Visible = false;
            }
        }

        private async Task HandleManualRefreshAsync()
        {
            ShowLoadingOverlay(true);
            try
            {
                await ctrlPeopleSearch1.PerformSearchAsync();
                UITheme.ShowSuccessToast("People records reloaded successfully.");
            }
            finally
            {
                ShowLoadingOverlay(false);
            }
        }

        private void InitializeDataGridColumns()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Clear();
            cmsColumns.Items.Clear();

            foreach (var col in _columnDefinitions)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = col.Key,
                    HeaderText = col.HeaderText,
                    DataPropertyName = col.DataPropertyName,
                    Width = col.Width
                });

                ToolStripMenuItem item = new ToolStripMenuItem(col.HeaderText)
                {
                    Checked = true,
                    CheckOnClick = true,
                    Tag = col.Key
                };

                item.CheckedChanged += (s, e) =>
                {
                    if (s is ToolStripMenuItem menuItem && menuItem.Tag != null)
                    {
                        string key = menuItem.Tag.ToString()!;
                        if (dgvResults.Columns.Contains(key))
                        {
                            dgvResults.Columns[key].Visible = menuItem.Checked;
                        }
                    }
                };

                col.ToolStripItem = item;
                cmsColumns.Items.Add(item);
            }
        }

        private void InitializeRowContextMenu()
        {
            cmsRowActions.Items.Clear();
            cmsRowActions.RenderMode = ToolStripRenderMode.System;

            var itemDetails = new ToolStripMenuItem("Show Details", Properties.Resources.details, (s, e) => OpenViewPersonCardDialog())
            {
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold)
            };

            var itemEdit = new ToolStripMenuItem("Edit Person", Properties.Resources.edit_person, (s, e) => OpenUpdateSelectedPersonDialog());
            var itemDelete = new ToolStripMenuItem("Delete Person", Properties.Resources.bin, (s, e) => OpenDeleteSelectedPersonDialog());
            var itemAdd = new ToolStripMenuItem("Add New Person", Properties.Resources.add_person, (s, e) => OpenAddNewPersonDialog());
            var itemRefresh = new ToolStripMenuItem("Refresh", Properties.Resources.refresh, async (s, e) => await HandleManualRefreshAsync());

            cmsRowActions.Items.Add(itemDetails);
            cmsRowActions.Items.Add(new ToolStripSeparator());
            cmsRowActions.Items.Add(itemEdit);
            cmsRowActions.Items.Add(itemDelete);
            cmsRowActions.Items.Add(new ToolStripSeparator());
            cmsRowActions.Items.Add(itemAdd);
            cmsRowActions.Items.Add(itemRefresh);
        }

        private void DgvResults_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dgvResults.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.ColumnHeader)
                {
                    cmsColumns.Show(dgvResults, e.Location);
                }
                else if (hitTest.Type == DataGridViewHitTestType.Cell && hitTest.RowIndex >= 0)
                {
                    dgvResults.ClearSelection();
                    dgvResults.Rows[hitTest.RowIndex].Selected = true;
                    cmsRowActions.Show(dgvResults, e.Location);
                }
            }
        }

        private void UpdateActionButtonsState()
        {
            bool hasSelection = dgvResults.SelectedRows.Count > 0;

            btnUpdate.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            if (hasSelection)
            {
                btnUpdate.ApplySecondaryStyle();
                btnDelete.ApplySecondaryStyle();
            }
            else
            {
                Color disabledBg = Color.FromArgb(241, 245, 249);
                Color disabledText = Color.FromArgb(203, 213, 225);

                btnUpdate.BackgroundStartColor = disabledBg;
                btnUpdate.BackgroundEndColor = disabledBg;
                btnUpdate.TextColor = disabledText;
                btnUpdate.BorderColor = disabledText;

                btnDelete.BackgroundStartColor = disabledBg;
                btnDelete.BackgroundEndColor = disabledBg;
                btnDelete.TextColor = disabledText;
                btnDelete.BorderColor = disabledText;
            }

            UpdateToolTipsForActionButtons();
        }

        private void UpdateTotalCount(int totalCount)
        {
            _totalRecords = totalCount;
            UpdatePaginationUI();
        }

        private void UpdatePaginationUI()
        {
            int pageSize = ctrlPeopleSearch1.PageSize;
            int currentPage = ctrlPeopleSearch1.PageNumber;
            int totalPages = (int)Math.Ceiling((double)_totalRecords / pageSize);

            if (_totalRecords == 0)
            {
                lblPaginationInfo.Text = "0-0 of 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
                return;
            }

            int startRecord = ((currentPage - 1) * pageSize) + 1;
            int endRecord = Math.Min(currentPage * pageSize, _totalRecords);

            lblPaginationInfo.Text = $"{startRecord}-{endRecord} of {_totalRecords}";

            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }

        private void PopulateDataGrid(object? sender, OperationResults<PersonReadDTO> results)
        {
            dgvResults.Rows.Clear();

            if (!results.IsSuccess || results.DataList == null || results.DataList.Count == 0)
            {
                pnlEmptyState.Visible = true;
                pnlEmptyState.BringToFront();
                UpdateActionButtonsState();
                UpdatePaginationUI();
                return;
            }

            pnlEmptyState.Visible = false;

            foreach (PersonReadDTO person in results.DataList)
            {
                var cells = new List<object>();
                foreach (DataGridViewColumn col in dgvResults.Columns)
                {
                    var definition = _columnDefinitions.Find(c => c.Key == col.Name);
                    if (definition?.ValueSelector != null) cells.Add(definition.ValueSelector(person));
                }
                dgvResults.Rows.Add(cells.ToArray());
            }

            dgvResults.ClearSelection();
            UpdateActionButtonsState();
            UpdatePaginationUI();
        }

        private int GetSelectedPersonId()
        {
            if (dgvResults.SelectedRows.Count == 0) return -1;
            object val = dgvResults.SelectedRows[0].Cells["PersonID"].Value;
            return (val != null && int.TryParse(val.ToString(), out int id)) ? id : -1;
        }

        private void OpenAddNewPersonDialog()
        {
            using frmSavePerson frm = new frmSavePerson();
            frm.PersonSaved += async (id) =>
            {
                UITheme.ShowSuccessToast("New person registered successfully.");
                await ExecuteSearchWithOverlayAsync();
            };
            frm.ShowDialog();
        }

        private void OpenUpdateSelectedPersonDialog()
        {
            int personId = GetSelectedPersonId();
            if (personId <= 0) return;

            using frmSavePerson frm = new frmSavePerson(personId);
            frm.PersonSaved += async (id) =>
            {
                UITheme.ShowSuccessToast("Person profile updated.");
                await UpdateLocalRowAsync(id);
            };
            frm.ShowDialog();
        }

        private async Task UpdateLocalRowAsync(int personId)
        {
            OperationResult<PersonReadDTO> result = await _personService.GetByIdAsync(personId);
            if (!result.IsSuccess || result.Data == null || dgvResults.SelectedRows.Count == 0) return;

            var selectedRow = dgvResults.SelectedRows[0];
            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                var definition = _columnDefinitions.Find(c => c.Key == col.Name);
                if (definition?.ValueSelector != null)
                {
                    selectedRow.Cells[col.Name].Value = definition.ValueSelector(result.Data);
                }
            }
        }

        private void OpenDeleteSelectedPersonDialog()
        {
            int personId = GetSelectedPersonId();
            if (personId <= 0) return;

            using frmDeletePersonForm frm = new frmDeletePersonForm(personId);
            frm.DeletedSuccessfully += () =>
            {
                if (dgvResults.SelectedRows.Count > 0)
                {
                    dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
                    _totalRecords = Math.Max(0, _totalRecords - 1);
                    UpdatePaginationUI();
                    UpdateActionButtonsState();

                    if (dgvResults.Rows.Count == 0 && ctrlPeopleSearch1.PageNumber > 1)
                    {
                        ctrlPeopleSearch1.PageNumber--;
                        _ = ExecuteSearchWithOverlayAsync();
                    }
                    else if (dgvResults.Rows.Count == 0)
                    {
                        pnlEmptyState.Visible = true;
                        pnlEmptyState.BringToFront();
                    }
                }
            };
            frm.ShowDialog();
        }

        private void OpenViewPersonCardDialog()
        {
            int personId = GetSelectedPersonId();
            if (personId <= 0) return;

            using frmPersonCard frm = new frmPersonCard(personId);
            frm.PersonDeleted += () =>
            {
                if (dgvResults.SelectedRows.Count > 0)
                {
                    dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
                    _totalRecords = Math.Max(0, _totalRecords - 1);
                    UpdatePaginationUI();
                }
            };
            frm.PersonUpdated += async (id) => await UpdateLocalRowAsync(id);
            frm.ShowDialog();
        }

        private void OpenSettingsDialog()
        {
            using frmPeopleManagementSettings frm = new frmPeopleManagementSettings();
            frm.ShowDialog();
        }
    }
}