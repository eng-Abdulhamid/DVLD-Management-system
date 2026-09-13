using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    partial class ctrlFormHeader
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UITheme.OnThemeChanged -= HandleThemeChanged;
                UnhookParentFormEvents();

                if (_parentControlRef != null)
                {
                    _parentControlRef.BackColorChanged -= Parent_BackColorChanged;
                    _parentControlRef = null;
                }

                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlWindowControls = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            pnlWindowControls.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(12, 0, 0, 0);
            lblTitle.Size = new Size(732, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWindowControls
            // 
            pnlWindowControls.AutoSize = true;
            pnlWindowControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlWindowControls.BackColor = Color.Transparent;
            pnlWindowControls.Controls.Add(btnMinimize);
            pnlWindowControls.Controls.Add(btnMaximize);
            pnlWindowControls.Controls.Add(btnClose);
            pnlWindowControls.Dock = DockStyle.Right;
            pnlWindowControls.Location = new Point(732, 0);
            pnlWindowControls.Name = "pnlWindowControls";
            pnlWindowControls.Size = new Size(138, 38);
            pnlWindowControls.TabIndex = 1;
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMinimize.Location = new Point(0, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 38);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "—";
            btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnMaximize
            // 
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Segoe UI", 11F);
            btnMaximize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMaximize.Location = new Point(46, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(46, 38);
            btnMaximize.TabIndex = 1;
            btnMaximize.Text = "🗖";
            btnMaximize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            btnClose.Location = new Point(92, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ctrlFormHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblTitle);
            Controls.Add(pnlWindowControls);
            Name = "ctrlFormHeader";
            Size = new Size(870, 38);
            pnlWindowControls.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Panel pnlWindowControls;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;
    }
}