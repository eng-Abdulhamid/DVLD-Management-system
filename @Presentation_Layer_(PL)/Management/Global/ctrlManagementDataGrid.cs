using DVLD.PL.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DVLD.PL.Management
{
    public partial class ctrlManagementDataGrid : UserControl
    {
        private readonly List<DataGridColumnDefinition> _columnDefinitions = new();

        public event DataGridViewCellEventHandler? CellDoubleClick;
        public event EventHandler? SelectionChanged;
        public event MouseEventHandler? GridMouseDown;
        public event CancelEventHandler? ColumnsContextMenuOpening;
        public event CancelEventHandler? RowActionsContextMenuOpening;

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
                dgvResults.ApplyModernStyle();
            }
        }

        private void ConfigureContextMenus()
        {
            cmsColumns.AutoClose = true;
            cmsRowActions.AutoClose = true;

            // إضافة مسافات وخيارات قياسية لتحسين مظهر القائمة الافتراضية
            cmsColumns.ShowImageMargin = true;
            cmsRowActions.ShowImageMargin = true;
            cmsColumns.Font = new Font("Segoe UI", 9.5F);
            cmsRowActions.Font = new Font("Segoe UI", 9.5F);
        }

        private void RegisterEvents()
        {
            dgvResults.MouseDown += (s, e) =>
            {
                GridMouseDown?.Invoke(s, e);
                if (e.Button != MouseButtons.Right) return;

                var hitTest = dgvResults.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.ColumnHeader)
                {
                    CancelEventArgs cancelArgs = new CancelEventArgs();
                    ColumnsContextMenuOpening?.Invoke(cmsColumns, cancelArgs);
                    if (!cancelArgs.Cancel)
                        cmsColumns.Show(dgvResults, e.Location);
                }
                else if (hitTest.Type == DataGridViewHitTestType.Cell && hitTest.RowIndex >= 0)
                {
                    SelectRow(hitTest.RowIndex);
                    if (HasSelection)
                    {
                        CancelEventArgs cancelArgs = new CancelEventArgs();
                        RowActionsContextMenuOpening?.Invoke(cmsRowActions, cancelArgs);
                        if (!cancelArgs.Cancel)
                            cmsRowActions.Show(dgvResults, e.Location);
                    }
                }
            };

            dgvResults.CellDoubleClick += (s, e) => CellDoubleClick?.Invoke(s, e);
            dgvResults.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);
        }

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
        public bool HasSelection => dgvResults.SelectedRows.Count > 0;

        [Browsable(false)]
        public int SelectedRowIndex => dgvResults.SelectedRows.Count > 0 ? dgvResults.SelectedRows[0].Index : -1;

        public void InitializeColumns(IEnumerable<DataGridColumnDefinition> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));

            _columnDefinitions.Clear();
            _columnDefinitions.AddRange(columns);

            dgvResults.Columns.Clear();
            cmsColumns.Items.Clear();

            foreach (DataGridColumnDefinition def in _columnDefinitions)
            {
                dgvResults.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = def.Key,
                    HeaderText = def.HeaderText,
                    DataPropertyName = def.DataPropertyName,
                    Width = def.Width,
                    ReadOnly = true
                });

                ToolStripMenuItem menuItem = new ToolStripMenuItem(def.HeaderText)
                {
                    Checked = true,
                    CheckOnClick = true,
                    Tag = def.Key
                };

                menuItem.CheckedChanged += (s, e) =>
                {
                    if (s is ToolStripMenuItem item && item.Tag is string key && dgvResults.Columns.Contains(key))
                        dgvResults.Columns[key].Visible = item.Checked;
                };

                def.ToolStripItem = menuItem;
                cmsColumns.Items.Add(menuItem);
            }
        }

        public void SelectRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvResults.Rows.Count) return;

            dgvResults.ClearSelection();
            dgvResults.Rows[rowIndex].Selected = true;

            if (dgvResults.Columns.Count > 0)
                dgvResults.CurrentCell = dgvResults.Rows[rowIndex].Cells[0];
        }

        public void ClearSelection() => dgvResults.ClearSelection();
        public void ClearRows() => dgvResults.Rows.Clear();
        public int AddRow(params object[] values) => dgvResults.Rows.Add(values);

        public void RemoveSelectedRow()
        {
            if (HasSelection) dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
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
    }
}