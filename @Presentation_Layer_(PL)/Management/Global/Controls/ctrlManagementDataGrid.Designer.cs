using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Management
{
    partial class ctrlManagementDataGrid
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvResults = new DataGridView();
            cmsColumns = new ContextMenuStrip(components);
            cmsRowActions = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AllowUserToResizeRows = false;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(0, 0);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(800, 450);
            dgvResults.TabIndex = 0;
            // 
            // cmsColumns
            // 
            cmsColumns.Name = "cmsColumns";
            cmsColumns.Size = new Size(61, 4);
            // 
            // cmsRowActions
            // 
            cmsRowActions.Name = "cmsRowActions";
            cmsRowActions.Size = new Size(61, 4);
            // 
            // ctrlManagementDataGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(dgvResults);
            Margin = new Padding(0);
            Name = "ctrlManagementDataGrid";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvResults;
        private ContextMenuStrip cmsColumns;
        private ContextMenuStrip cmsRowActions;
    }
}