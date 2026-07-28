using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL
{
    public abstract class absMangement<ReadDTO> where ReadDTO : class
    {
        protected abstract ToolStripItem[] _GetToolStripItemsInArray();
        public abstract void OpenItemsListDialogInListMode();
        public abstract void OpenItemsListDialogInSelectMode(Action<DataGridViewRow> onSelected);
        public abstract void OpenItemsListInListMode();
        public abstract void OpenItemsListInSelectMode(Action<DataGridViewRow> onSelected);
        protected abstract object[] _MapReadDTOToObjectArray(ReadDTO person);
        protected abstract DataTable _MapListOfReadDTOToDataTable(List<ReadDTO> Items);
        protected abstract void _OnUpdateSuccessfully(int ID);
        protected abstract void _OnAddSuccessfully(int ID);
        protected abstract void _OnAddNewClicked();
        protected abstract void _OnDeleteSuccessfully(int ID);
    }
}
