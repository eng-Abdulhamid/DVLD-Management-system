using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL
{
    public partial class ctrlCustomDataGridView : DataGridView
    {
        public ctrlCustomDataGridView()
        {
            InitializeComponent();
            ConfigureDataGridViewResponsive();

            this.Resize += (s, e) => AdjustDataGridViewHeightToRows();

            // Update height when rows change
            this.dgPeople.RowsAdded += (s, e) => AdjustDataGridViewHeightToRows();
            this.dgPeople.RowsRemoved += (s, e) => AdjustDataGridViewHeightToRows();

        }
        public void RefreshLayout()
        {
            AdjustColumnWidthsSmartly();
            AdjustDataGridViewHeightToRows();
        }
        #region Responsive DataGridView Helpers
        private void ConfigureDataGridViewResponsive()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgPeople, new object[] { true });

            dgPeople.BackgroundColor = SystemColors.Control;
            dgPeople.BorderStyle = BorderStyle.None;
            dgPeople.RowHeadersVisible = false;
            dgPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPeople.AllowUserToResizeRows = false;

            dgPeople.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgPeople.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgPeople.DataBindingComplete += (s, e) => RecalculateLayout();
            this.Resize += (s, e) => RecalculateLayout();
        }

        private void RecalculateLayout()
        {
            dgPeople.SuspendLayout();
            this.SuspendLayout();

            try
            {
                AdjustColumnWidthsSmartly();
                AdjustDataGridViewHeightToRows();
            }
            finally
            {
                dgPeople.ResumeLayout();
                this.ResumeLayout();
            }
        }

        private void AdjustColumnWidthsSmartly()
        {
            if (dgPeople.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgPeople.Columns)
            {
                col.MinimumWidth = 50;
            }

            int totalWidth = dgPeople.ClientSize.Width - dgPeople.RowHeadersWidth;

            dgPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            var colWeights = new Dictionary<int, float>();
            float totalContentWidth = 0;

            foreach (DataGridViewColumn col in dgPeople.Columns)
            {
                if (!col.Visible) continue;

                float w = col.Width;
                colWeights[col.Index] = w;
                totalContentWidth += w;
            }

            dgPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var kvp in colWeights)
            {
                var col = dgPeople.Columns[kvp.Key];
                float weight = totalContentWidth > 0 ? (kvp.Value / totalContentWidth) * 100f : 1f;

                if (weight < 1) weight = 1;

                col.FillWeight = weight;
            }
        }

        private void AdjustDataGridViewHeightToRows()
        {
            try
            {
                if (dgPeople.Rows.Count == 0) return;

                int headerHeight = dgPeople.ColumnHeadersVisible ? dgPeople.ColumnHeadersHeight : 0;
                int rowsHeight = 0;

                foreach (DataGridViewRow row in dgPeople.Rows)
                {
                    rowsHeight += row.Height;
                }

                int totalDesiredHeight = headerHeight + rowsHeight + 2;

                int topOffset = dgPeople.Top;
                int availableHeight = this.ClientSize.Height - topOffset - 50;

                if (totalDesiredHeight < availableHeight)
                {
                    dgPeople.Height = Math.Max(100, totalDesiredHeight);
                    dgPeople.ScrollBars = ScrollBars.Horizontal;
                }
                else
                {
                    dgPeople.Height = Math.Max(100, availableHeight);
                    dgPeople.ScrollBars = ScrollBars.Vertical | ScrollBars.Horizontal;
                }
            }
            catch
            {
                // ignore errors during layout
            }
        }

        #endregion

    }
}
