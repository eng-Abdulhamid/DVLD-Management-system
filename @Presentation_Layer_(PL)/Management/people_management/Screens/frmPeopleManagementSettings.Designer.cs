using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.PeopleManagement
{
    partial class frmPeopleManagementSettings
    {
        private System.ComponentModel.IContainer components = null;
        private NControls.NCheckBox chkAutoSearch;
        private NControls.NCheckBox chkConfirmDelete;
        private NButton btnSave;
        private NButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            chkAutoSearch = new NControls.NCheckBox();
            chkConfirmDelete = new NControls.NCheckBox();
            btnSave = new NButton();
            btnCancel = new NButton();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(450, 38);
            headerControl.TitleText = "DVLD / People Management / Preferences";
            // 
            // chkAutoSearch
            // 
            chkAutoSearch.AnimationSpeed = 25;
            chkAutoSearch.AutoCheck = true;
            chkAutoSearch.BackColor = Color.Transparent;
            chkAutoSearch.BorderRadius = 4;
            chkAutoSearch.BorderSize = 1;
            chkAutoSearch.BoxBackColor = Color.White;
            chkAutoSearch.BoxBorderColor = Color.FromArgb(200, 205, 212);
            chkAutoSearch.BoxSize = 18;
            chkAutoSearch.CheckAlign = NControls.NCheckAlign.Left;
            chkAutoSearch.Checked = true;
            chkAutoSearch.CheckedColor = Color.FromArgb(124, 58, 237);
            chkAutoSearch.CheckMarkColor = Color.White;
            chkAutoSearch.CheckState = CheckState.Checked;
            chkAutoSearch.CheckThickness = 2F;
            chkAutoSearch.DisabledColor = Color.FromArgb(220, 224, 230);
            chkAutoSearch.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkAutoSearch.EnableAnimation = true;
            chkAutoSearch.EnableRipple = false;
            chkAutoSearch.Font = new Font("Segoe UI", 9.5F);
            chkAutoSearch.ForeColor = Color.FromArgb(30, 41, 59);
            chkAutoSearch.HoverBorderColor = Color.FromArgb(124, 58, 237);
            chkAutoSearch.Location = new Point(80, 75);
            chkAutoSearch.Name = "chkAutoSearch";
            chkAutoSearch.RippleColor = Color.FromArgb(40, 124, 58, 237);
            chkAutoSearch.Size = new Size(290, 24);
            chkAutoSearch.Style = NControls.NCheckBoxStyle.Rounded;
            chkAutoSearch.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkAutoSearch.SwitchThumbColor = Color.White;
            chkAutoSearch.SwitchWidth = 38;
            chkAutoSearch.TabIndex = 1;
            chkAutoSearch.Text = "Enable search as you type";
            chkAutoSearch.TextSpacing = 8;
            chkAutoSearch.ThreeState = false;
            // 
            // chkConfirmDelete
            // 
            chkConfirmDelete.AnimationSpeed = 25;
            chkConfirmDelete.AutoCheck = true;
            chkConfirmDelete.BackColor = Color.Transparent;
            chkConfirmDelete.BorderRadius = 4;
            chkConfirmDelete.BorderSize = 1;
            chkConfirmDelete.BoxBackColor = Color.White;
            chkConfirmDelete.BoxBorderColor = Color.FromArgb(200, 205, 212);
            chkConfirmDelete.BoxSize = 18;
            chkConfirmDelete.CheckAlign = NControls.NCheckAlign.Left;
            chkConfirmDelete.Checked = true;
            chkConfirmDelete.CheckedColor = Color.FromArgb(124, 58, 237);
            chkConfirmDelete.CheckMarkColor = Color.White;
            chkConfirmDelete.CheckState = CheckState.Checked;
            chkConfirmDelete.CheckThickness = 2F;
            chkConfirmDelete.DisabledColor = Color.FromArgb(220, 224, 230);
            chkConfirmDelete.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkConfirmDelete.EnableAnimation = true;
            chkConfirmDelete.EnableRipple = false;
            chkConfirmDelete.Font = new Font("Segoe UI", 9.5F);
            chkConfirmDelete.ForeColor = Color.FromArgb(30, 41, 59);
            chkConfirmDelete.HoverBorderColor = Color.FromArgb(124, 58, 237);
            chkConfirmDelete.Location = new Point(80, 120);
            chkConfirmDelete.Name = "chkConfirmDelete";
            chkConfirmDelete.RippleColor = Color.FromArgb(40, 124, 58, 237);
            chkConfirmDelete.Size = new Size(290, 24);
            chkConfirmDelete.Style = NControls.NCheckBoxStyle.Rounded;
            chkConfirmDelete.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkConfirmDelete.SwitchThumbColor = Color.White;
            chkConfirmDelete.SwitchWidth = 38;
            chkConfirmDelete.TabIndex = 2;
            chkConfirmDelete.Text = "Confirm before deleting records";
            chkConfirmDelete.TextSpacing = 8;
            chkConfirmDelete.ThreeState = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 8;
            btnSave.BorderSize = 0;
            btnSave.CenterIconWithText = false;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSave.Location = new Point(130, 185);
            btnSave.Name = "btnSave";
            btnSave.RightIcon = null;
            btnSave.Size = new Size(105, 38);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.Location = new Point(245, 185);
            btnCancel.Name = "btnCancel";
            btnCancel.RightIcon = null;
            btnCancel.Size = new Size(95, 38);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmPeopleManagementSettings
            // 
            AllowMaximize = false;
            AllowMinimize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 250);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkConfirmDelete);
            Controls.Add(chkAutoSearch);
            Name = "frmPeopleManagementSettings";
            Text = "DVLD / People Management / Preferences";
            Controls.SetChildIndex(chkAutoSearch, 0);
            Controls.SetChildIndex(chkConfirmDelete, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            ResumeLayout(false);
        }
    }
}