using DVLD.PL.Global;
using DVLD.PL.Theme;
using DVLD.PL.UsersManagement;
namespace DVLD.PL.Management.user_management
{
    public partial class frmUserCard : BaseForm
    {
        private readonly int _userID;
        public event Action? OnEditedSuccessfully;
        public event Action? OnDeletedSuccessfully;
        public frmUserCard(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
            SetContextTitle("User Card");
            ctrlUserCard1?.LoadUserInfoAsync(_userID);
            ctrlUserManagementControls.OnDeleteClick += CtrlManagementActions1_OnDeleteClick;
            ctrlUserManagementControls.OnEditClick += CtrlManagementActions1_OnEditClick;
            ctrlUserManagementControls.EditEnabled = true;
            ctrlUserManagementControls.DeleteEnabled = true;
            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;
            this.Load += frmUserCard_Load;
            ApplyTheme();
        }
        private async void frmUserCard_Load(object? sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_userID <= 0)
            {
                NotificationTheme.ShowErrorToast("Invalid user ID.");
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
                    OnDeletedSuccessfully?.Invoke();
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
                    ctrlUserCard1?.LoadUserInfoAsync(UserId);
                    OnEditedSuccessfully?.Invoke();
                };
                editForm.ShowDialog();
            }
        }

        private void ctrlUserManagementControls_OnAddClick(object sender, EventArgs e)
        {

        }
    }
}
