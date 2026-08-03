using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    public class ModernDataGridView : DataGridView
    {
        public ModernDataGridView()
        {
            InitializeStyle();
            ApplyModernTheme();
        }

        private void InitializeStyle()
        {
            // Enable double buffering and optimize for smooth rendering to prevent flickering
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            // Accessing the internal DoubleBuffered property via reflection as a secondary guard
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, this, new object[] { true });
        }

        private void ApplyModernTheme()
        {
            // Basic configuration
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = true;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            StandardTab = true;

            // Hide scrollbars as requested
            ScrollBars = ScrollBars.None;

            // Header style
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 118, 232);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            ColumnHeadersHeight = 45;
            EnableHeadersVisualStyles = false;

            // Cell style
            DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            DefaultCellStyle.ForeColor = Color.FromArgb(34, 47, 62);
            DefaultCellStyle.BackColor = Color.White;
            DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            DefaultCellStyle.SelectionForeColor = Color.FromArgb(34, 47, 62);
            DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alternating row colors
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);

            RowTemplate.Height = 40;
            GridColor = Color.FromArgb(235, 239, 242);
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            BackgroundColor = Color.White;
            BorderStyle = BorderStyle.None;

            // Fill the grid area
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Prevent the background from being erased separately to avoid white flashes
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing here to prevent flickering during rapid updates
        }

        /// <summary>
        /// Adds an action button with a fixed width, while others fill the space
        /// </summary>
        public void AddActionButtonColumn(string name, string text, Color buttonColor)
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = name;
            btnColumn.HeaderText = "Action";
            btnColumn.Text = text;
            btnColumn.UseColumnTextForButtonValue = true;
            btnColumn.FlatStyle = FlatStyle.Flat;

            // Fixed width for buttons to look consistent
            btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnColumn.Width = 80;

            btnColumn.DefaultCellStyle.BackColor = buttonColor;
            btnColumn.DefaultCellStyle.ForeColor = Color.White;
            btnColumn.DefaultCellStyle.SelectionBackColor = buttonColor;
            btnColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            Columns.Add(btnColumn);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    ClearSelection();
                    Rows[hit.RowIndex].Selected = true;
                    CurrentCell = Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    if (this.ContextMenuStrip != null)
                    {
                        this.ContextMenuStrip.Show(this, e.Location);
                    }
                }
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Adjusts column weights so that columns with more content get more space within the "Fill" mode
        /// </summary>
        public void AdjustColumnWidthsSmartly()
        {
            if (Columns.Count == 0) return;

            // Temporarily use AllCells to calculate required width
            foreach (DataGridViewColumn col in Columns)
            {
                if (col is DataGridViewButtonColumn) continue;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Capture the calculated widths
            Dictionary<int, int> preferredWidths = new Dictionary<int, int>();
            float totalPreferred = 0;

            foreach (DataGridViewColumn col in Columns)
            {
                if (col.Visible)
                {
                    preferredWidths[col.Index] = col.Width;
                    totalPreferred += col.Width;
                }
            }

            // Switch back to Fill and set FillWeight based on content ratio
            foreach (DataGridViewColumn col in Columns)
            {
                if (col is DataGridViewButtonColumn)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    continue;
                }

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (totalPreferred > 0)
                {
                    float weight = (preferredWidths[col.Index] / totalPreferred) * 100;
                    col.FillWeight = Math.Max(1, weight);
                }
            }
        }

        public void AdjustHeightToContent(int topOffset = 0, int bottomPadding = 50)
        {
            try
            {
                if (Rows.Count == 0) return;

                int headerHeight = ColumnHeadersVisible ? ColumnHeadersHeight : 0;
                int rowsHeight = 0;

                foreach (DataGridViewRow row in Rows)
                {
                    rowsHeight += row.Height;
                }

                int totalDesiredHeight = headerHeight + rowsHeight + 2;
                Height = Math.Max(100, totalDesiredHeight);
            }
            catch
            {
                // Ignore layout errors
            }
        }
    }
}