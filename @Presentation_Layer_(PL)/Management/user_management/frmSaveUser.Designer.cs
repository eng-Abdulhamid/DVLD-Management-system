using System.Drawing;
using System.Windows.Forms;
using NControls;
namespace DVLD.PL.UsersManagement
{
    partial class frmSaveUser
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TabControl tcWizard;
        private TabPage tpPersonSelection;
        private GroupBox gbSearchFilter;
        private NTextBox txtSearchNationalNo;
        private NButton btnSearchPerson;
        private NButton btnAddNewPerson;
        private DVLD.PL.PeopleManagement.ctrlPersonCard ctrlPersonCard1;
        private LinkLabel lnkEditPerson;
        private NButton btnNext;
        private TabPage tpLoginInfo;
        private Label lblUserName;
        private NTextBox txtUserName;
        private Label lblPassword;
        private NTextBox txtPassword;
        private Label lblConfirmPassword;
        private NTextBox txtConfirmPassword;
        private NControls.NCheckBox chkIsActive;
        private NButton btnSave;
        private NButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            tcWizard = new TabControl();
            tpPersonSelection = new TabPage();
            gbSearchFilter = new GroupBox();
            txtSearchNationalNo = new NTextBox();
            btnSearchPerson = new NButton();
            btnAddNewPerson = new NButton();
            ctrlPersonCard1 = new DVLD.PL.PeopleManagement.ctrlPersonCard();
            lnkEditPerson = new LinkLabel();
            btnNext = new NButton();
            tpLoginInfo = new TabPage();
            lblUserName = new Label();
            txtUserName = new NTextBox();
            lblPassword = new Label();
            txtPassword = new NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new NTextBox();
            chkIsActive = new NControls.NCheckBox();
            btnSave = new NButton();
            btnCancel = new NButton();
            tcWizard.SuspendLayout();
            tpPersonSelection.SuspendLayout();
            gbSearchFilter.SuspendLayout();
            tpLoginInfo.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(860, 38);
            headerControl.TitleText = "DVLD / Users Management / Save User";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New User";
            // 
            // tcWizard
            // 
            tcWizard.Controls.Add(tpPersonSelection);
            tcWizard.Controls.Add(tpLoginInfo);
            tcWizard.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tcWizard.Location = new Point(20, 85);
            tcWizard.Name = "tcWizard";
            tcWizard.SelectedIndex = 0;
            tcWizard.Size = new Size(820, 435);
            tcWizard.TabIndex = 1;
            // 
            // tpPersonSelection
            // 
            tpPersonSelection.BackColor = Color.White;
            tpPersonSelection.Controls.Add(gbSearchFilter);
            tpPersonSelection.Controls.Add(ctrlPersonCard1);
            tpPersonSelection.Controls.Add(lnkEditPerson);
            tpPersonSelection.Controls.Add(btnNext);
            tpPersonSelection.Location = new Point(4, 26);
            tpPersonSelection.Name = "tpPersonSelection";
            tpPersonSelection.Padding = new Padding(12);
            tpPersonSelection.Size = new Size(812, 405);
            tpPersonSelection.TabIndex = 0;
            tpPersonSelection.Text = "1. Person Selection";
            // 
            // gbSearchFilter
            // 
            gbSearchFilter.Controls.Add(txtSearchNationalNo);
            gbSearchFilter.Controls.Add(btnSearchPerson);
            gbSearchFilter.Controls.Add(btnAddNewPerson);
            gbSearchFilter.ForeColor = Color.FromArgb(71, 85, 105);
            gbSearchFilter.Location = new Point(16, 8);
            gbSearchFilter.Name = "gbSearchFilter";
            gbSearchFilter.Size = new Size(780, 75);
            gbSearchFilter.TabIndex = 0;
            gbSearchFilter.TabStop = false;
            gbSearchFilter.Text = "Search Person";
            // 
            // txtSearchNationalNo
            // 
            txtSearchNationalNo.Location = new Point(16, 24);
            txtSearchNationalNo.Name = "txtSearchNationalNo";
            txtSearchNationalNo.PlaceholderText = "National Number...";
            txtSearchNationalNo.Size = new Size(260, 38);
            txtSearchNationalNo.TabIndex = 0;
            // 
            // btnSearchPerson
            // 
            btnSearchPerson.BackColor = Color.Transparent;
            btnSearchPerson.BorderRadius = 8;
            btnSearchPerson.Cursor = Cursors.Hand;
            btnSearchPerson.Location = new Point(286, 24);
            btnSearchPerson.MiddleIcon = Properties.Resources.search;
            btnSearchPerson.Name = "btnSearchPerson";
            btnSearchPerson.Size = new Size(40, 38);
            btnSearchPerson.TabIndex = 1;
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.BackColor = Color.Transparent;
            btnAddNewPerson.BorderRadius = 8;
            btnAddNewPerson.Cursor = Cursors.Hand;
            btnAddNewPerson.Location = new Point(334, 24);
            btnAddNewPerson.MiddleIcon = Properties.Resources.add_person;
            btnAddNewPerson.Name = "btnAddNewPerson";
            btnAddNewPerson.Size = new Size(40, 38);
            btnAddNewPerson.TabIndex = 2;
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(16, 90);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(780, 260);
            ctrlPersonCard1.TabIndex = 1;
            // 
            // lnkEditPerson
            // 
            lnkEditPerson.AutoSize = true;
            lnkEditPerson.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkEditPerson.LinkColor = Color.FromArgb(124, 58, 237);
            lnkEditPerson.Location = new Point(18, 365);
            lnkEditPerson.Name = "lnkEditPerson";
            lnkEditPerson.Size = new Size(106, 17);
            lnkEditPerson.TabIndex = 2;
            lnkEditPerson.TabStop = true;
            lnkEditPerson.Text = "Edit Person Info";
            lnkEditPerson.Visible = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.BorderRadius = 8;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Location = new Point(686, 355);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(110, 38);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next >";
            // 
            // tpLoginInfo
            // 
            tpLoginInfo.BackColor = Color.White;
            tpLoginInfo.Controls.Add(lblUserName);
            tpLoginInfo.Controls.Add(txtUserName);
            tpLoginInfo.Controls.Add(lblPassword);
            tpLoginInfo.Controls.Add(txtPassword);
            tpLoginInfo.Controls.Add(lblConfirmPassword);
            tpLoginInfo.Controls.Add(txtConfirmPassword);
            tpLoginInfo.Controls.Add(chkIsActive);
            tpLoginInfo.Location = new Point(4, 26);
            tpLoginInfo.Name = "tpLoginInfo";
            tpLoginInfo.Padding = new Padding(24);
            tpLoginInfo.Size = new Size(812, 405);
            tpLoginInfo.TabIndex = 1;
            tpLoginInfo.Text = "2. Login Credentials";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.ForeColor = Color.FromArgb(71, 85, 105);
            lblUserName.Location = new Point(36, 32);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 17);
            lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(36, 55);
            txtUserName.MaxLength = 20;
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Enter unique username...";
            txtUserName.Size = new Size(320, 38);
            txtUserName.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(36, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(36, 133);
            txtPassword.MaxLength = 20;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter password...";
            txtPassword.Size = new Size(320, 38);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblConfirmPassword.Location = new Point(36, 188);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(118, 17);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(36, 211);
            txtConfirmPassword.MaxLength = 20;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Repeat password...";
            txtConfirmPassword.Size = new Size(320, 38);
            txtConfirmPassword.TabIndex = 4;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // chkIsActive
            // 
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(36, 275);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(160, 24);
            chkIsActive.TabIndex = 5;
            chkIsActive.Text = "Is Active User";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 8;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(716, 530);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save User";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 8;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Location = new Point(584, 530);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            // 
            // frmSaveUser
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(860, 585);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(tcWizard);
            Controls.Add(lblTitle);
            Name = "frmSaveUser";
            Text = "DVLD / Users Management / Save User";
            Load += frmSaveUser_Load;
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(tcWizard, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            tcWizard.ResumeLayout(false);
            tpPersonSelection.ResumeLayout(false);
            tpPersonSelection.PerformLayout();
            gbSearchFilter.ResumeLayout(false);
            tpLoginInfo.ResumeLayout(false);
            tpLoginInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}