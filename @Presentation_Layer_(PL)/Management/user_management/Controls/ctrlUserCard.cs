using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    public partial class ctrlUserCard : UserControl
    {
        private int _userId = -1;
        private UserService? _userService;

        private UserService UserServiceInstance => _userService ??= new UserService();

        public int UserID => _userId;
        public UserReadDTO? SelectedUserInfo { get; private set; }

        public ctrlUserCard()
        {
            InitializeComponent();
            ResetCard();
        }
        public async Task LoadUserInfoAsync(int userId)
        {
            if (UIUtility.IsDesignMode) return;

            _userId = userId;

            if (userId <= 0)
            {
                ResetCard();
                return;
            }

            var result = await UserServiceInstance.GetByIdAsync(userId);

            if (result.IsSuccess && result.Data != null)
            {
                await LoadUserInfoAsync(result.Data);
            }
            else
            {
                ResetCard();
            }
        }

        public async Task LoadUserInfoAsync(UserReadDTO user)
        {
            if (UIUtility.IsDesignMode) return;

            if (user == null)
            {
                ResetCard();
                return;
            }

            _userId = user.UserID;
            SelectedUserInfo = user;

            // Load encapsulated person details
            await ctrlPersonCard1.LoadPersonInfoAsync(SelectedUserInfo.PersonID);

            PopulateUserDetails();
        }

        private void PopulateUserDetails()
        {
            if (SelectedUserInfo == null) return;

            lblUserID.Text = SelectedUserInfo.UserID.ToString();
            lblUserName.Text = SelectedUserInfo.UserName;
            lblIsActive.Text = SelectedUserInfo.IsActive ? "Yes" : "No";
            lblIsActive.ForeColor = SelectedUserInfo.IsActive ? UITheme.Success : UITheme.Danger;
        }

        public void ResetCard()
        {
            _userId = -1;
            SelectedUserInfo = null;

            ctrlPersonCard1.ResetCard();

            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblIsActive.ForeColor = Color.FromArgb(31, 41, 55);
        }
    }
}