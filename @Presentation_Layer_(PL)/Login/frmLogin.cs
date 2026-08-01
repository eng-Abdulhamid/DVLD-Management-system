using DVLDPL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls;
using Services;
using DVLD_BusinessLogicLayer;
using DTOs;

namespace DVLDPL
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Enabled = false;

            txtUsername.textBox.Focus();
            txtUsername.textBox.TabIndex = 0;
            txtPassword.textBox.TabIndex = 1;
            btnLogin.TabIndex = 1;
            btnCancel.TabIndex = 3;
        }
        IUserServices services = new UserServices();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.textBox.TextChanged += UsernameTextChanged;
            lblPasswordWarning.Visible = false;
            lblUsernameWarning.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _CheckPassword(UserReadDTO User)
        {
            return User.Password == txtPassword.Text;
        }
        private bool _CheckCanLogin(UserReadDTO User)
        {
            bool CanLogin = true;
            if (!_CheckPassword(User))
            {
                CanLogin = false;
                Notification.Show("Incorrect password", IconType.Error, 1);
            }
            else if (!User.IsActive)
            {
                CanLogin = false;
                Notification.Show("User is inactive", IconType.Error, 1);
            }
            btnLogin.Enabled = CanLogin;
            return CanLogin;

        }
        private bool _CheckCanAcceptUsername(string Username)
        {
            foreach(char c in Username)
            {
                if (!(char.IsLetter(c) || char.IsDigit(c) || c == '_'))
                {
                    return false;
                }
            }
            return true;
        }
        private void UsernameTextChanged(object sender, EventArgs e)
        {
            bool CanAccept = false;
            if (CanAccept = (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text)))
            {
                lblUsernameWarning.Text = "Username cannot be empty.";
            }
            else if (CanAccept = (txtUsername.Text.Length <= 3))
            {
                lblUsernameWarning.Text = "Username must be more than 3 characters.";
            }
            else if ((CanAccept = !_CheckCanAcceptUsername(txtUsername.Text)))
            {
                lblUsernameWarning.Text = "Username must be contain only letter, numbers or underscore '_'";
            }
            CanAccept = !CanAccept;
            btnLogin.Enabled = CanAccept;
            lblUsernameWarning.Visible = !CanAccept;
        }
        private void _Login()
        {
            OperationResult<UserReadDTO> User = services.FindUserByUsername(txtUsername.Text);
            if (User.IsSuccess)
            {
                if (_CheckCanLogin(User.Data))
                {
                    frmDashboard frm = new frmDashboard(); 
                    Global.CurrentUser = User.Data;
                    frm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                Notification.Show("This username does not exist. Please enter another one", IconType.Error, 1);

            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            bool CheckPass = true;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblPasswordWarning.Text = "The password should not be empty.";
                CheckPass = false;
            }
            else if (txtPassword.Text.Length <= 3)
            {
                lblPasswordWarning.Text = "Password be more than 3 characters.";
                CheckPass = false;
            }
            lblPasswordWarning.Visible = !CheckPass;
            btnLogin.Enabled = CheckPass;
        }
    }
}
