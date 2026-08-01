using AbdUlhamid_CustomControls.CustomControls;
using Services;
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
    public partial class ctrlListItemsPagenation : UserControl
    {
        #region Properties
        protected int PageSize = 10;
        protected int SelectedPageSize = 10;
        protected int SelectedPage = 1;
        protected int CurrentPage { get; set; }
        public ToolStripItem[] ContextMenuStripItems 
        { 
            set
            {
                FillContextMenuStripWithItems(value);
            } 
        }
        public Action<DataGridViewRow> OnSelect { get; set; }
        public DataTable DataTable { get; set; }
        #endregion
        public ctrlListItemsPagenation()
        {
            InitializeComponent();
            btnNextPage.Enabled = false;
            btnPreviousPage.Enabled = false;
            btnApplyPageSize.Enabled = false;
            btnApplyPageSize.Enabled = false;
            btnApplyPage.Enabled = false;
            cbPageSize.Items.Add("10");
            cbPageSize.Items.Add("20");
            cbPageSize.Items.Add("30");
            cbPageSize.Items.Add("40");
            cbPageSize.Items.Add("50");
            cbPageSize.Items.Add("60");
            cbPageSize.Items.Add("70");
            cbPageSize.Items.Add("80");
            cbPageSize.Items.Add("90");
            cbPageSize.Items.Add("100");
            cbPageSize.Items.Add("150");
            cbPageSize.Items.Add("200");
            cbPageSize.Items.Add("300");
            cbPageSize.Items.Add("500");
            cbPageSize.Items.Add("700");
            cbPageSize.Items.Add("1000");
            if (cbPageSize.Items.Count > 0)
                cbPageSize.SelectedIndex = 0;
            //InitializeDataGridView();
        }
        
        private void SelectedIndexChanged_PageSize(object sender, EventArgs e)
        {
            if (int.TryParse(cbPageSize.Text, out int result))
            {
                if (PageSize != result)
                {
                    SelectedPageSize = result;
                    btnApplyPageSize.Enabled = true;
                }
                else
                {
                    btnApplyPageSize.Enabled = false;
                }
            }
        }
        private void SelectedIndexChanged_PageNumber(object sender, EventArgs e)
        {
            if (int.TryParse(cbPagesNumber.Text, out int result))
            {
                if (CurrentPage != result)
                {
                    SelectedPage = result;
                    btnApplyPage.Enabled = true;
                }
                else
                {
                    btnApplyPage.Enabled = false;
                }
            }
        }
        public virtual void FillColumnsToDataGrid(List<string> ColumnsNameList)
        {
            if (dgItemsList.Columns.Count > 0)
                dgItemsList.Columns.Clear();
            foreach (string clmn in ColumnsNameList)
            {
                dgItemsList.Columns.Add($"clmn{clmn}", clmn);
            }
            AdjustDataGridSize();
        }

        protected void FillPagesNumberInComboBox(int TotalPages)
        {
            if (cbPagesNumber.Items.Count > 0) 
                cbPagesNumber.Items.Clear();
            if (TotalPages < 0) return;
            for(int pages = 1; pages <= TotalPages; pages++)
            {
                cbPagesNumber.Items.Add(pages.ToString());
            }
            cbPagesNumber.SelectedIndex = CurrentPage - 1;
        }
        protected void InitializeDataGridView()
        {
            this.Resize += (s, e) => dgItemsList.AdjustHeightToContent(dgItemsList.Top, 50);
            btnPreviousPage.Enabled = false;
            this.dgItemsList.RowsAdded += (s, e) => dgItemsList.AdjustHeightToContent(dgItemsList.Top, 50);
            this.dgItemsList.RowsRemoved += (s, e) => dgItemsList.AdjustHeightToContent(dgItemsList.Top, 50);

            dgItemsList.DataBindingComplete += (s, e) =>
            {
                dgItemsList.AdjustColumnWidthsSmartly();
                dgItemsList.AdjustHeightToContent(dgItemsList.Top, 50);
            };
        }
        protected virtual void FillContextMenuStripWithItems(ToolStripItem[] ContextMenuStripItems)
        {
            if (ContextMenuStripItems == null) return;
            foreach (ToolStripItem item in ContextMenuStripItems)
            {
                cmpOperations.Items.Add(item);
            }
        }
          
        public void UpdatePaginationButtons(int TotalPages, int CurrentPage)
        {
            btnPreviousPage.Enabled = (CurrentPage > 1) && (TotalPages > 1);
            btnNextPage.Enabled = (CurrentPage < TotalPages) && (TotalPages > 1);
        }
        public void AdjustDataGridSize()
        {
            dgItemsList.AdjustColumnWidthsSmartly();
            dgItemsList.AdjustHeightToContent(dgItemsList.Top, 50);
        }
        
        private void dgItemsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Mode == enListMode.Select)
            //{
            //    OnSelect?.Invoke(dgItemsList.CurrentRow);
            //}
        }
        private bool _IsRow = false;
        private void dgItemsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var dgv = sender as DataGridView;
                var hit = dgv.HitTest(e.X, e.Y);

                _IsRow = (hit.Type == DataGridViewHitTestType.Cell);
            }
        }
        private void cmpOperations_Opening(object sender, CancelEventArgs e)
        {
            if (!_IsRow)
            {
                e.Cancel = true;
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            cbPagesNumber.SelectedIndex = CurrentPage -1;

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            cbPagesNumber.SelectedIndex = CurrentPage - 1;
        }

        private void btnApplyPageSize_Click(object sender, EventArgs e)
        {
        }

        private void btnApplyPageSize_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnPreviousPage_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnNextPage_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnApplyPage_Click(object sender, EventArgs e)
        {

        }
    }
}
