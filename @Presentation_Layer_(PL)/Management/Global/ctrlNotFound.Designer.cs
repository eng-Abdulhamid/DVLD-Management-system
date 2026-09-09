using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.Management
{
    partial class ctrlNotFound
    {
        private System.ComponentModel.IContainer components = null;
        private NButton btnClearFilter;
        private Label lblEmptyDesc;
        private Label lblEmptyTitle;
        private Label lblEmptyIcon;

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
            btnClearFilter = new NButton();
            lblEmptyDesc = new Label();
            lblEmptyTitle = new Label();
            lblEmptyIcon = new Label();
            SuspendLayout();
            // 
            // lblEmptyIcon
            // 
            lblEmptyIcon.AutoSize = true;
            lblEmptyIcon.Font = new Font("Segoe UI Emoji", 40F);
            lblEmptyIcon.Location = new Point(195, 20);
            lblEmptyIcon.Name = "lblEmptyIcon";
            lblEmptyIcon.Size = new Size(90, 71);
            lblEmptyIcon.TabIndex = 0;
            lblEmptyIcon.Text = "🔍";
            lblEmptyIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyTitle
            // 
            lblEmptyTitle.AutoSize = true;
            lblEmptyTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmptyTitle.Location = new Point(135, 100);
            lblEmptyTitle.Name = "lblEmptyTitle";
            lblEmptyTitle.Size = new Size(210, 21);
            lblEmptyTitle.TabIndex = 1;
            lblEmptyTitle.Text = "No Matching Records Found";
            lblEmptyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyDesc
            // 
            lblEmptyDesc.Font = new Font("Segoe UI", 9.5F);
            lblEmptyDesc.Location = new Point(20, 130);
            lblEmptyDesc.Name = "lblEmptyDesc";
            lblEmptyDesc.Size = new Size(440, 40);
            lblEmptyDesc.TabIndex = 2;
            lblEmptyDesc.Text = "We couldn't find anyone matching your search criteria. Try modifying your filters.";
            lblEmptyDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.Transparent;
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.BorderSize = 1;
            btnClearFilter.CenterIconWithText = false;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearFilter.Location = new Point(180, 180);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(120, 36);
            btnClearFilter.TabIndex = 3;
            btnClearFilter.Text = "Clear Filters";
            // 
            // ctrlNotFound
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnClearFilter);
            Controls.Add(lblEmptyDesc);
            Controls.Add(lblEmptyTitle);
            Controls.Add(lblEmptyIcon);
            Name = "ctrlNotFound";
            Size = new Size(480, 240);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}