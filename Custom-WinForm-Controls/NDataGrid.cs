using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomizeControls
{
    public class NDataGrid : DataGridView
    {
        public NDataGrid()
        {
            DoubleBuffered = true;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = true;
            AllowUserToResizeRows = false;
            BackgroundColor = Color.White;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            EnableHeadersVisualStyles = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnHeadersHeight = 44;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DefaultCellStyle.BackColor = Color.White;
            DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 232, 255); // Violet Hover
            DefaultCellStyle.SelectionForeColor = Color.FromArgb(124, 58, 237);
            RowTemplate.Height = 40;

            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridColor = Color.FromArgb(241, 245, 249);
        }

        public void LoadDataFast(DataTable? dataTable)
        {
            if (dataTable == null) return;

            SuspendLayout();
            var prevMode = AutoSizeColumnsMode;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DataSource = dataTable;

            AutoSizeColumnsMode = prevMode;
            ResumeLayout(true);
        }

        public void FilterData(string columnName, string searchText)
        {
            DataTable? dt = null;

            if (DataSource is DataTable directTable)
            {
                dt = directTable;
            }
            else if (DataSource is BindingSource bindingSource && bindingSource.DataSource is DataTable boundTable)
            {
                dt = boundTable;
            }

            if (dt == null) return;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dt.DefaultView.RowFilter = string.Empty;
                return;
            }

            // تنظيف الحقل والمحارف الخاصة لمنع انهيار DataView RowFilter
            string safeColumn = columnName.Replace("]", @"\]");
            string safeText = EscapeLikeValue(searchText);

            try
            {
                dt.DefaultView.RowFilter = $"CONVERT([{safeColumn}], 'System.String') LIKE '%{safeText}%'";
            }
            catch
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private static string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c is '[' or ']' or '*' or '%')
                {
                    sb.Append('[').Append(c).Append(']');
                }
                else if (c == '\'')
                {
                    sb.Append("''");
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}