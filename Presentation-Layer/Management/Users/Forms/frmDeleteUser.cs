using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Theme;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    public partial class frmDeleteUser : BaseForm
    {
        private readonly int _userId;
        private readonly UserService _userService;
        private ToolTip? _toolTips;

        public event Action? DeletedSuccessfully;

        public frmDeleteUser(int userId)
        {
            InitializeComponent();
            SetContextTitle("Delete User");
            _userId = userId;
            _userService = new UserService();

            SetupToolTips();
            RegisterEvents();
            base.ApplyTheme();
        }
        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 300,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnDelete, "Permanently delete this user");
            _toolTips.SetToolTip(btnCancel, "Cancel and close window");
        }

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnDelete.Click += async (s, e) => await PerformDeleteAsync();
        }

        private async void frmDeleteUser_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_userId <= 0)
            {
                NotificationTheme.ShowErrorToast("Invalid user ID.");
                this.Close();
                return;
            }

            await ctrlUserCard1.LoadUserInfoAsync(_userId);
        }
        private void UpdateDeleteButtonEnabled(bool Enabled)
        {
            btnDelete.IsLoading = !Enabled;
            btnDelete.Enabled = Enabled;
            btnCancel.Enabled = Enabled;
        }
        private async Task PerformDeleteAsync()
        {
            UpdateDeleteButtonEnabled(false);
            
            if (_userId == AppSession.CurrentUserID) {
                NotificationTheme.ShowWarningToast("You cannot delete login user. Please login with another account to delete this one.", "Deleting faild");
                return;
            };

            var result = await _userService.DeleteAsync(_userId);

            if (result.IsSuccess)
            {
                NotificationTheme.ShowSuccessToast("User deleted successfully.");
                DeletedSuccessfully?.Invoke();
                this.Close();
            }
            else
            {
                NotificationTheme.ShowErrorToast(result.Message);
            }
            UpdateDeleteButtonEnabled(true);

        }
    }
}