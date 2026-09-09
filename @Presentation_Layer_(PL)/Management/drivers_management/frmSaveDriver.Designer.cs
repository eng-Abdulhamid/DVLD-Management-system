using System.Drawing;
using System.Windows.Forms;
using NControls;
namespace DVLD.PL.DriversManagement
{
    partial class frmSaveDriver
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
        private NButton btnNext;
        private TabPage tpDriverConfirmation;
        private Label lblMessage;
        private Label lblConfirmPersonName;
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
            btnNext = new NButton();
            tpDriverConfirmation = new TabPage();
            lblMessage = new Label();
            lblConfirmPersonName = new Label();
            btnSave = new NButton();
            btnCancel = new NButton();
            tcWizard.SuspendLayout();
            tpPersonSelection.SuspendLayout();
            gbSearchFilter.SuspendLayout();
            tpDriverConfirmation.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(860, 38);
            headerControl.TitleText = "DVLD / Drivers Management / Register Driver";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Driver";
            // 
            // tcWizard
            // 
            tcWizard.Controls.Add(tpPersonSelection);
            tcWizard.Controls.Add(tpDriverConfirmation);
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
            tpPersonSelection.Controls.Add(btnNext);
            tpPersonSelection.Location = new Point(4, 26);
            tpPersonSelection.Name = "tpPersonSelection";
            tpPersonSelection.Padding = new Padding(12);
            tpPersonSelection.Size = new Size(812, 405);
            tpPersonSelection.TabIndex = 0;
            tpPersonSelection.Text = "1. Select Person";
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
            gbSearchFilter.Text = "Find Person";
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
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.BorderRadius = 8;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Location = new Point(686, 355);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(110, 38);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next >";
            // 
            // tpDriverConfirmation
            // 
            tpDriverConfirmation.BackColor = Color.White;
            tpDriverConfirmation.Controls.Add(lblMessage);
            tpDriverConfirmation.Controls.Add(lblConfirmPersonName);
            tpDriverConfirmation.Location = new Point(4, 26);
            tpDriverConfirmation.Name = "tpDriverConfirmation";
            tpDriverConfirmation.Padding = new Padding(24);
            tpDriverConfirmation.Size = new Size(812, 405);
            tpDriverConfirmation.TabIndex = 1;
            tpDriverConfirmation.Text = "2. Confirmation";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 11.25F);
            lblMessage.ForeColor = Color.FromArgb(71, 85, 105);
            lblMessage.Location = new Point(36, 40);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(410, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "You are about to register the following person as a driver:";
            // 
            // lblConfirmPersonName
            // 
            lblConfirmPersonName.AutoSize = true;
            lblConfirmPersonName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblConfirmPersonName.ForeColor = Color.FromArgb(124, 58, 237);
            lblConfirmPersonName.Location = new Point(36, 75);
            lblConfirmPersonName.Name = "lblConfirmPersonName";
            lblConfirmPersonName.Size = new Size(174, 25);
            lblConfirmPersonName.TabIndex = 1;
            lblConfirmPersonName.Text = "[Selected Person]";
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
            btnSave.Text = "Save Driver";
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
            // frmSaveDriver
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
            Name = "frmSaveDriver";
            Text = "DVLD / Drivers Management / Register Driver";
            Load += frmSaveDriver_Load;
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(tcWizard, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            tcWizard.ResumeLayout(false);
            tpPersonSelection.ResumeLayout(false);
            gbSearchFilter.ResumeLayout(false);
            tpDriverConfirmation.ResumeLayout(false);
            tpDriverConfirmation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}