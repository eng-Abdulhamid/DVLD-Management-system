using DVLD.PL.Global;
using DVLD.PL.Theme;
using System.ComponentModel;
using System.Reflection;
namespace DVLD.PL.Management
{
    public partial class ctrlManagementDataGrid : UserControl
    {
        #region Properties and the Constructor
        private readonly List<DataGridColumnDefinition> _columnDefinitions = new();
        private bool _suppressSelectionEvents { get; set; }
        public event DataGridViewCellEventHandler? CellDoubleClick;
        public event EventHandler? SelectionChanged;
        public event MouseEventHandler? GridMouseDown;
        public event CancelEventHandler? ColumnsContextMenuOpening;
        public event CancelEventHandler? RowActionsContextMenuOpening;
        #region Expression-bodied members
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView Grid => dgvResults;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContextMenuStrip ColumnsContextMenu => cmsColumns;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContextMenuStrip RowActionsContextMenu => cmsRowActions;

        [Browsable(false)]
        public bool HasSelection =>
            dgvResults.Rows.Count > 0 &&
            dgvResults.CurrentCell != null &&
            dgvResults.SelectedRows.Count > 0 &&
            dgvResults.SelectedRows[0].Index >= 0 &&
            dgvResults.SelectedRows[0].Index < dgvResults.Rows.Count;

        [Browsable(false)]
        public int SelectedRowIndex => HasSelection ? dgvResults.SelectedRows[0].Index : -1;
        #endregion
        public ctrlManagementDataGrid()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            ConfigureGrid();
            ConfigureContextMenus();
            RegisterEvents();
        }
        private void ConfigureGrid()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AllowUserToResizeRows = false;
            dgvResults.MultiSelect = false;
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.RowHeadersVisible = false;
            dgvResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.EnableHeadersVisualStyles = false;

            EnableDoubleBuffering(dgvResults);

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                dgvResults.ApplyDataGridStyle();
            }
        }
        private void ConfigureContextMenus()
        {
            cmsColumns.AutoClose = true;
            cmsRowActions.AutoClose = true;

            cmsColumns.ShowImageMargin = true;
            cmsRowActions.ShowImageMargin = true;
            cmsColumns.Font = new Font("Segoe UI", 9.5F);
            cmsRowActions.Font = new Font("Segoe UI", 9.5F);
        }
        #region Event Registration
        private void RegisterEvents()
        {
            dgvResults.MouseDown += DataGrid_MouseDown;

            dgvResults.CellDoubleClick += (s, e) => CellDoubleClick?.Invoke(s, e);

            dgvResults.SelectionChanged += dgvResults_SelectionChanged;
        }
        #region DataGrid MouseDown Event Handling
        private void DataGrid_MouseDown(object? sender, MouseEventArgs e)
        {
            GridMouseDown?.Invoke(sender, e);

            if (e.Button != MouseButtons.Right)
                return;

            var hitTest = dgvResults.HitTest(e.X, e.Y);

            switch (hitTest.Type)
            {
                case DataGridViewHitTestType.ColumnHeader:
                    HandleColumnHeaderRightClick(e);
                    break;

                case DataGridViewHitTestType.Cell:
                    HandleCellRightClick(hitTest.RowIndex, e);
                    break;
            }
        }
        private void HandleColumnHeaderRightClick(MouseEventArgs e)
        {
            var cancelArgs = new CancelEventArgs();

            ColumnsContextMenuOpening?.Invoke(cmsColumns, cancelArgs);

            if (!cancelArgs.Cancel)
                cmsColumns.Show(dgvResults, e.Location);
        }
        private void HandleCellRightClick(int rowIndex, MouseEventArgs e)
        {
            if (rowIndex < 0)
                return;

            SelectRow(rowIndex);

            if (!HasSelection)
                return;

            var cancelArgs = new CancelEventArgs();

            RowActionsContextMenuOpening?.Invoke(cmsRowActions, cancelArgs);

            if (!cancelArgs.Cancel)
                cmsRowActions.Show(dgvResults, e.Location);
        }
        #endregion
        private void dgvResults_SelectionChanged(object? sender, EventArgs e)
        {
            if (_suppressSelectionEvents) return;
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #endregion
        #region Column Management
        public void InitializeColumns(IEnumerable<DataGridColumnDefinition> columns)
        {
            ArgumentNullException.ThrowIfNull(columns, nameof(columns));

            _columnDefinitions.Clear();
            _columnDefinitions.AddRange(columns);

            _suppressSelectionEvents = true;

            dgvResults.SuspendLayout();
            cmsColumns.SuspendLayout();

            dgvResults.Columns.Clear();
            cmsColumns.Items.Clear();

            foreach (DataGridColumnDefinition definition in _columnDefinitions)
            {
                AddDataGridColumn(definition);
                AddColumnMenuItem(definition);
            }

            cmsColumns.ResumeLayout();
            dgvResults.ResumeLayout();

            _suppressSelectionEvents = false;
        }
        private void AddDataGridColumn(DataGridColumnDefinition definition)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                Name = definition.Key,
                HeaderText = definition.HeaderText,
                DataPropertyName = definition.DataPropertyName,
                Width = definition.Width,
                ReadOnly = true
            };

            dgvResults.Columns.Add(column);
        }
        private void AddColumnMenuItem(DataGridColumnDefinition definition)
        {
            ToolStripMenuItem menuItem = CreateColumnMenuItem(definition);

            definition.ToolStripItem = menuItem;

            cmsColumns.Items.Add(menuItem);
        }
        private ToolStripMenuItem CreateColumnMenuItem(DataGridColumnDefinition definition)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(definition.HeaderText)
            {
                Checked = true,
                CheckOnClick = true,
                Tag = definition.Key
            };

            menuItem.CheckedChanged += ColumnMenuItem_CheckedChanged;

            return menuItem;
        }
        private void ColumnMenuItem_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
                return;

            if (menuItem.Tag is not string key)
                return;

            if (!dgvResults.Columns.Contains(key))
                return;

            dgvResults.Columns[key].Visible = menuItem.Checked;
        }
        #endregion
        #region Management Features
        public void SelectRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvResults.Rows.Count) return;

            _suppressSelectionEvents = true;
            dgvResults.ClearSelection();
            dgvResults.Rows[rowIndex].Selected = true;

            if (dgvResults.Columns.Count > 0)
                dgvResults.CurrentCell = dgvResults.Rows[rowIndex].Cells[0];
            _suppressSelectionEvents = false;
            

            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        public void ClearSelection()
        {
            _suppressSelectionEvents = true;

            dgvResults.CurrentCell = null;
            dgvResults.ClearSelection();
            
            _suppressSelectionEvents = false;
            

            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        public void ClearRows()
        {
            _suppressSelectionEvents = true;

            dgvResults.Rows.Clear();
            dgvResults.CurrentCell = null;
            
            _suppressSelectionEvents = false;
            
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        public int AddRow(params object[] values)
        {
            _suppressSelectionEvents = true;
            int newRowIndex = -1;

            newRowIndex = dgvResults.Rows.Add(values);
            _suppressSelectionEvents = false;

            return newRowIndex;
        }
        public void RemoveSelectedRow()
        {
            if (!HasSelection) return;

            _suppressSelectionEvents = true;
            dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
            dgvResults.CurrentCell = null;
            dgvResults.ClearSelection();
                
            _suppressSelectionEvents = false;
           

            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        public bool TryGetSelectedInt(string columnName, out int value)
        {
            value = -1;
            if (!HasSelection || !dgvResults.Columns.Contains(columnName)) return false;

            object? cellValue = dgvResults.SelectedRows[0].Cells[columnName].Value;
            return cellValue != null && int.TryParse(cellValue.ToString(), out value);
        }
        private static void EnableDoubleBuffering(DataGridView dataGridView)
        {
            PropertyInfo? property = dataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property?.SetValue(dataGridView, true, null);
        }
        #endregion
    }
}