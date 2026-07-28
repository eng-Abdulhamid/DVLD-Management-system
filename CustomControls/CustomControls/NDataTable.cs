using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
    public class NDataGrid : DataGridView
    {
        public NDataGrid()
        {
            this.DoubleBuffered = true;

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeRows = false;
            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.RowHeadersVisible = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.ColumnHeadersHeight = 45;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.RowTemplate.Height = 40;

            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LoadDataFast(DataTable dataTable)
        {
            if (dataTable == null) return;

            this.SuspendLayout();
            var previousSizeMode = this.AutoSizeColumnsMode;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            this.DataSource = dataTable;

            this.AutoSizeColumnsMode = previousSizeMode;
            this.ResumeLayout(true);
        }

        public void FilterData(string columnName, string searchText)
        {
            DataTable dt = null;

            if (this.DataSource is DataTable directTable)
            {
                dt = directTable;
            }
            else if (this.DataSource is BindingSource bindingSource && bindingSource.DataSource is DataTable boundTable)
            {
                dt = boundTable;
            }

            if (dt != null)
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"[{columnName}] LIKE '%{searchText}%'";
                }
            }
        }
    }
}