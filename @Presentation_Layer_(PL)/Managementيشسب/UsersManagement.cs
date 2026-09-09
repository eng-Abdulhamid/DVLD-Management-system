using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLD.PL.Properties;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users;

namespace DVLD.PL
{
    public class UsersManagement : absMangement<UserReadDTO>
    {
        //frmListItems<UserReadDTO, UserAddDTO, UserUpdateDTO, UserServices.enFields> _UsersListForm; 
        
        public UsersManagement()
        {
            _InitializeItemsListForm(enListMode.List);
        }
        #region Map Methods
        protected override object[] _MapReadDTOToObjectArray(UserReadDTO User)
        {
            return new object[]
            {
                (object)User.UserID,
                (object)User.PersonID,
                (object)User.UserName,
                (object)(User.IsActive ? "Active" : "Not Active")
            };

        }
        protected override DataTable _MapListOfReadDTOToDataTable(List<UserReadDTO> Users)
        {
            DataTable dt = new DataTable();
            List<string> ColumnsName = new List<string>()
            {
                "UserID",
                "PersonID",
                "UserName",
                "IsActive"
            };
            foreach (string str in ColumnsName)
            {
                dt.Columns.Add(str);
            }
            foreach (UserReadDTO User in Users)
            {
                dt.Rows.Add(_MapReadDTOToObjectArray(User));
            }
            return dt;
        }
        #endregion
        #region Open Users List
        public override void OpenItemsListDialogInListMode()
        {
            //_UsersListForm.ShowDialog();
        }
        public override void OpenItemsListInListMode()
        {
            //_UsersListForm.Show();
        }
        public override void OpenItemsListDialogInSelectMode(Action<DataGridViewRow> OnSelected)
        {
            _InitializeItemsListForm(enListMode.Select);
            //_UsersListForm.OnSelect += OnSelected;
            //_UsersListForm.ShowDialog();
        }
        public override void OpenItemsListInSelectMode(Action<DataGridViewRow> OnSelected)
        {
            _InitializeItemsListForm(enListMode.Select);
            _UsersListForm.OnSelect += OnSelected;
            _UsersListForm.Show();
        }
        #endregion
        #region Initialize Methods
        protected override void _InitializeItemsListForm(enListMode Mode)
        {
            //_UsersListForm =
            //    new frmListItems<UserReadDTO, UserAddDTO, UserUpdateDTO, UserServices.enFields>
            //    (FormTitle: "Users management",
            //    FormIcon: null,
            //    Mode,
            //    Services: new UserServices(),
            //    _MapListOfReadDTOToDataTable,
            //    20,
            //    _GetToolStripItemsInArray(), OnAddNewClicked);
        }
        #endregion
        #region Users Management     
        #region Add new
        private void OnAddNewClicked()
        {
            frmSaveUser frmSaveUser = new frmSaveUser();
            frmSaveUser.onSavedSuccessfully += _OnAddSuccessfully;
            frmSaveUser.ShowDialog();
        }
        #endregion
        #region Update
        private void EditUserInformation_ToolStripClickEvent(object sender, EventArgs e)
        {
            int UserID = _GetUserIDByTollStripSender(sender);
            if (UserID != -1)
            {
                frmSaveUser frmSaveUser = new frmSaveUser(UserID);
                frmSaveUser.onSavedSuccessfully += _OnUpdateSuccessfully;
                frmSaveUser.ShowDialog();
            }

        }
        private ToolStripItem _EditUserToolStripItem()
        {
            ToolStripItem item = new ToolStripMenuItem("Edit User", Resources.write_icon_176713, EditUserInformation_ToolStripClickEvent);
            item.AutoSize = true;
            item.MouseEnter += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.ToolTipText = "Edit selected user information";
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            item.MouseLeave += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            return item;
        }

        #endregion
        #region Delete
        private void _DeleteUserInformation_ToolStripClickEvent(object sender, EventArgs e)
        {
            int UserID = _GetUserIDByTollStripSender(sender);
            if (UserID != -1)
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    IUserServices UserServices = new UserServices();
                    if (UserServices.DeleteByUserID(UserID))
                    {
                        Notification.Show("User deleted successfully!", type: IconType.Success, 1);
                        _OnDeleteSuccessfully(UserID);
                    }
                    else
                    {
                        Notification.Show("User can't delete!", type: IconType.Error, 1);
                    }
                }
            }
        }
        private ToolStripItem _DeleteUserToolStripItem()
        {
            ToolStripItem n = new ToolStripMenuItem("Delete User", Resources.delete_user__1_, _DeleteUserInformation_ToolStripClickEvent);
            n.AutoSize = true;
            n.MouseEnter += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.ToolTipText = "Delete selected user.";
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            n.MouseLeave += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            return n;
        }

        #endregion
        #region Helper
        private int _GetUserIDByTollStripSender(object sender)
        {
            if (sender is ToolStripItem item &&
                item.Owner is ContextMenuStrip cms &&
                cms.SourceControl is DataGridView dgv)
            {
                if (int.TryParse(dgv.CurrentRow.Cells[0].Value?.ToString(), out int result))
                {
                    return result;
                }
            }
            return -1;
        }
        protected override ToolStripItem[] _GetToolStripItemsInArray()
        {
            ToolStripItem[] items = new ToolStripItem[2];
            items[0] = _EditUserToolStripItem();
            items[1] = _DeleteUserToolStripItem();
            return items;
        }
        #endregion
        protected override void _OnUpdateSuccessfully(int ID)
        {
            IUserServices UserServices = new UserServices();
            OperationResult<UserReadDTO> result = UserServices.FindByUserID(ID);
            if (result.IsSuccess)
            {
                _UsersListForm.UpdateRowInfoByFirstCellTo(ID, _MapReadDTOToObjectArray(result.Data));
            }
        }
        protected override void _OnAddSuccessfully(int ID)
        {
            IUserServices UserServices = new UserServices();
            OperationResult<UserReadDTO> result = UserServices.FindByUserID(ID);
            if (result.IsSuccess)
            {
                _UsersListForm.AddNewRowInfoToDataGrid(_MapReadDTOToObjectArray(result.Data));
            }
        }
        protected override void _OnAddNewClicked()
        {
            frmSaveUser AddUser = new frmSaveUser(-1);
            AddUser.onSavedSuccessfully += _OnAddSuccessfully;
            AddUser.Show();
        }
        protected override void _OnDeleteSuccessfully(int ID)
        {
            IUserServices UserServices = new UserServices();
            OperationResult<UserReadDTO> result = UserServices.FindByUserID(ID);
            if (result.IsSuccess)
            {
                _UsersListForm.DeleteRowFromDataGridFirstCellIs(ID);
            }
        }
        #endregion

    }
}
