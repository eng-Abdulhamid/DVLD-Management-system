using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLD.PL;
using DVLD.PL.Properties;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace Users
{
    public partial class frmSaveUser : Form
    {
        private string _imagePath { get; set; } = string.Empty;
        private enMode _Mode { get; set; }
        private int _UserID { get; set; } = -1;
        private int _PersonID { get; set; } = -1;
        public Action<int> onSavedSuccessfully { get; set; }
        private IUserServices _UserServcies { get; set; } = new UserServices();
        private enMode Mode
        {
            get => _Mode;
            set
            {
                _Mode = value;
                switch (_Mode)
                {
                    case enMode.AddNew:
                    {
                        this.Text = "Add New User";
                        this.lblTitle.Text = "Add New User";
                        pbTitle.Image = Resources.user_add_21995;
                        break;
                    }
                    case enMode.Edit:
                    {
                        this.Text = "Edit User";
                        this.lblTitle.Text = "Edit User";
                        pbTitle.Image = Resources.user_edit_21991;
                        break;
                    }
            }
        }
        }
        public enum enMode { AddNew = 1, Edit = 2 }
        private void _FillUserInfoToControls(UserReadDTO User)
        {
            txtPassword.Text = User.Password;
            txtUsername.Text = User.UserName;
            txtPersonID.Text = User.UserID.ToString();
            cbIsAcive.SelectedIndex = User.IsActive ? 0 : 1;
            _PersonID = User.PersonID;
        }
        public frmSaveUser(int UserID = -1)
        {
            InitializeComponent();
            InitializeForm();
            
            if ((_UserID = UserID) == -1)
            {
                this.Mode = enMode.AddNew;
                lblUserIDValue.Text = "N/A";
            }
            else
            {
                this.Mode = enMode.Edit;
                lblUserIDValue.Text = UserID.ToString();
                OperationResult<UserReadDTO> result = _UserServcies.FindByUserID(UserID);
                if (result.IsSuccess)
                {
                    _FillUserInfoToControls(result.Data);
                }
            }

        }
        #region Methods
        private void InitializeForm()
        { 
            // Buttons
            btnCancel.Click += (s, e) => this.Close();

            // Hide warning label initially
            lblWarning.Visible = false;
            txtPassword.textBox.TextChanged += ValidateField;
            txtPersonID.textBox.TextChanged += ValidateField;
            txtUsername.textBox.TextChanged += ValidateField;

        }

        private void ValidateField(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    txt.BackColor = Color.FromArgb(255, 240, 245);
                    errorProvider.SetError(txt, "This field is required");
                }
                else
                {
                    txt.BackColor = Color.White;
                    errorProvider.SetError(txt, "");
                }
            }
        }

        private string _GetOnlyIntFromString(string str)
        {
            string intOnly = "";
            for(int i = 0;i<str.Length;i++)
            {
                if (char.IsDigit(str[i]) || ((str[i] == '+') && (i == 0)))
                {
                    intOnly += str[i];
                }
            }
            return intOnly;
        }
        private bool _ValidateUsernameTextBox()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.BackColor = Color.FromArgb(255, 240, 245);
                errorProvider.SetError(txtUsername, "First Name should't be empty!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtUsername, "");
                return true;
            }
        }
        private bool _ValidatePasswordTextBox()
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.BackColor = Color.FromArgb(255, 240, 245);
                errorProvider.SetError(txtPassword, "Second Name should't be empty!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtPassword, "");
                return true;
            }
        }
        private bool _ValidateUserIDTextBox()
        {
            if (string.IsNullOrEmpty(txtPersonID.Text))
            {
                txtPersonID.BackColor = Color.FromArgb(255, 240, 245);
                errorProvider.SetError(txtPersonID, "Last Name should't be empty!");
                return false;

            }
            else
            {
                errorProvider.SetError(txtPersonID, "");
                return true;
            }
        }
        private bool ValidateAllFields()
        {
            if (!_ValidateUsernameTextBox() || !_ValidatePasswordTextBox() || !_ValidateUserIDTextBox())
            {
                return false;
            }
            return true;
        }

        #endregion
        private bool _AddNewUser()
        {
            txtPersonID.Text = _GetOnlyIntFromString(txtPersonID.Text);
            UserAddDTO NewUser = new UserAddDTO()
            {
                PersonID = Convert.ToInt32(txtPersonID.Text),
                IsActive = (cbIsAcive.SelectedIndex == 0),
                Password = txtPassword.Text,
                UserName = txtUsername.Text,
            };
            UserServices UServices = new UserServices();
            int UserID = UServices.AddNew(NewUser);
            if (UserID > 0)
            {
                lblUserIDValue.Text = UserID.ToString();
                this.Mode = enMode.Edit;
                onSavedSuccessfully?.Invoke(UserID);
                Notification.Show("User Added Successfully", IconType.Success, 2);
                _UserID = UserID;
                return true;
            }
            return false;
        }
        private bool _EditUser()
        {
            UserUpdateDTO UpdatedUserDetails = new UserUpdateDTO();
            lblUserIDValue.Text = _GetOnlyIntFromString(lblUserIDValue.Text);
            UpdatedUserDetails.UserID = Convert.ToInt32(lblUserIDValue.Text);
            if (!string.IsNullOrEmpty(lblUserIDValue.Text))
            {

                if (!string.IsNullOrEmpty(txtPersonID.Text))
                {
                    txtPersonID.Text = _GetOnlyIntFromString(txtPersonID.Text);
                    UpdatedUserDetails.PersonID = Convert.ToInt32(txtPersonID.Text);
                    UpdatedUserDetails.UserName = txtUsername.Text;
                    UpdatedUserDetails.Password = txtPassword.Text;
                    UpdatedUserDetails.IsActive = (cbIsAcive.SelectedIndex == 0);
                    _UserServcies.UpdateByUserID(UpdatedUserDetails);
                    _UserID = UpdatedUserDetails.UserID;
                    onSavedSuccessfully?.Invoke(UpdatedUserDetails.UserID);
                    Notification.Show("User Updated Successfully", IconType.Success, 2);
                    return true;
                }
                else
                {
                    Notification.Show("This User is not Exist in the System.", type: IconType.Error, 1);
                    return false;
                }
            }
            return false;
        }
        private bool _SaveUser()
        {
            bool IsSave = false;
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        IsSave = _AddNewUser();
                        break;
                    }
                case enMode.Edit:
                    {
                        IsSave = _EditUser();
                        break;
                    }
            }
            return IsSave;
        }

        private void frmSaveUser_Load(object sender, EventArgs e)
        {

        }

        private void setImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void Save()
        {
            if (!ValidateAllFields())
            {
                lblWarning.Text = "⚠ Please fill all required fields correctly";
                lblWarning.Visible = true;
                return;
            }

            _SaveUser();
            lblWarning.Visible = false;
        }
        private void btnSaveDontBackHome_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnSaveBackToHome_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void lblSelectAnotherPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSavePerson frm = new frmSavePerson(_PersonID);
            frm.ShowDialog();
        }
        private void OnSelected_EventHandler(DataGridViewRow PersonRow)
        {
            if (PersonRow != null)
            {
                if (int.TryParse(PersonRow.Cells[0].Value.ToString(), out int result))
                {
                    _PersonID = result;
                    txtPersonID.Text = result.ToString();
                }
            }
        }
        private void lblSelectPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ManegementPeople ManegementPeople = new ManegementPeople();
            //ManegementPeople.OpenItemsListDialogInSelectMode(OnSelected_EventHandler);
        }
    }
}
