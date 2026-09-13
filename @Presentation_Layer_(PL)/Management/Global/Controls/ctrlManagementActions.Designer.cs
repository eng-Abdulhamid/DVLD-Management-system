using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.Management
{
    partial class ctrlManagementActions
    {
        private System.ComponentModel.IContainer components = null;
        private NButton btnAddNew;
        private NButton btnUpdate;
        private NButton btnDelete;
        private NButton btnRefresh;
        private ToolTip toolTip1;

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
            components = new System.ComponentModel.Container();
            btnAddNew = new NButton();
            btnUpdate = new NButton();
            btnDelete = new NButton();
            btnRefresh = new NButton();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.Transparent;
            btnAddNew.BorderRadius = 8;
            btnAddNew.BorderSize = 0;
            btnAddNew.CenterIconWithText = true;
            btnAddNew.Cursor = Cursors.Hand;
            btnAddNew.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAddNew.Location = new Point(0, 3);
            btnAddNew.MiddleIcon = Properties.Resources.add_person;
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(38, 36);
            btnAddNew.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.BorderRadius = 8;
            btnUpdate.BorderSize = 0;
            btnUpdate.CenterIconWithText = true;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.Location = new Point(44, 3);
            btnUpdate.MiddleIcon = Properties.Resources.edit_person;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(38, 36);
            btnUpdate.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BorderRadius = 8;
            btnDelete.BorderSize = 0;
            btnDelete.CenterIconWithText = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.Location = new Point(88, 3);
            btnDelete.MiddleIcon = Properties.Resources.bin;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(38, 36);
            btnDelete.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BorderRadius = 8;
            btnRefresh.BorderSize = 0;
            btnRefresh.CenterIconWithText = true;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(132, 3);
            btnRefresh.MiddleIcon = Properties.Resources.refresh;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(38, 36);
            btnRefresh.TabIndex = 3;
            // 
            // ctrlManagementActions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddNew);
            Name = "ctrlManagementActions";
            Size = new Size(170, 42);
            ResumeLayout(false);
        }
    }
}