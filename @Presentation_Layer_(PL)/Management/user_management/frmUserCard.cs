using CustomControls;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using DVLD.PL.UsersManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DVLD.PL.Global.UIUtility;
namespace DVLD.PL.Management.user_management
{
    public partial class frmUserCard : frmBase
    {
        private readonly int _userID;
        public frmUserCard(int UserID)
        {
            InitializeComponent();
            _userID = UserID;

            ctrlUserCard1?.LoadUserInfoAsync(_userID);
            ctrlUserManagementControls.OnDeleteClick += CtrlManagementActions1_OnDeleteClick;
            ctrlUserManagementControls.OnEditClick += CtrlManagementActions1_OnEditClick;
            ctrlUserManagementControls.EditEnabled = true;
            ctrlUserManagementControls.DeleteEnabled = true;
            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;
            this.Load += frmUserCard_Load;
        }
        private async void frmUserCard_Load(object? sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_userID <= 0)
            {
                UITheme.ShowErrorToast("Invalid user ID.");
                this.Close();
                return;
            }

            await ctrlUserCard1.LoadUserInfoAsync(_userID);
        }
        private void CtrlManagementActions1_OnDeleteClick(object? sender, EventArgs e)
        {
            using (var deleteForm = new frmDeleteUser(_userID))
            {
                deleteForm.DeletedSuccessfully += () =>
                {
                    UITheme.ShowSuccessToast("User deleted successfully.", "Deleted Successfully");
                    this.Close();
                };
                deleteForm.ShowDialog();
            }
        }
        private void CtrlManagementActions1_OnEditClick(object? sender, EventArgs e)
        {
            using (var editForm = new frmSaveUser(_userID))
            {
                editForm.UserSaved += (int UserId) =>
                {
                    UITheme.ShowSuccessToast("User updated successfully.", "Updated Successfully");
                    ctrlUserCard1?.LoadUserInfoAsync(UserId);
                };
                editForm.ShowDialog();
            }
        }   
    }
}
