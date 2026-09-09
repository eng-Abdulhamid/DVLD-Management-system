using DVLD.BLL.Services;
using DVLD.PL.Global;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    public partial class frmDeleteUser : frmBase
    {
        private readonly int _userId;
        private readonly UserService _userService;
        private ToolTip? _toolTips;

        public event Action? DeletedSuccessfully;

        public frmDeleteUser(int userId)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            _userId = userId;
            _userService = new UserService();

            ApplyStyles();
            SetupToolTips();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnDelete.ApplyDangerStyle();
            btnCancel.ApplySecondaryStyle();
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 300,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnDelete, "Permanently delete this user record");
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
                UITheme.ShowErrorToast("Invalid user ID.");
                this.Close();
                return;
            }

            await ctrlUserCard1.LoadUserInfoAsync(_userId);
        }

        private async Task PerformDeleteAsync()
        {
            btnDelete.IsLoading = true;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;

            try
            {
                var result = await _userService.DeleteAsync(_userId);

                if (result.IsSuccess)
                {
                    UITheme.ShowSuccessToast("User deleted successfully.");
                    DeletedSuccessfully?.Invoke();
                    this.Close();
                }
                else
                {
                    UITheme.ShowErrorToast(result.Message);
                }
            }
            finally
            {
                btnDelete.IsLoading = false;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
    }
}