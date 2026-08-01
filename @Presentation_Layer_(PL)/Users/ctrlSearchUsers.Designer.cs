using DTOs;
using Services;

namespace DVLDPL
{
    public partial class ctrlUsersSearch : ctrlSearchItems
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // btnClearSearchFiltering
            // 
            this.btnClearSearchFiltering.Location = new System.Drawing.Point(738, 7);
            this.btnClearSearchFiltering.Size = new System.Drawing.Size(137, 55);
            this.btnClearSearchFiltering.Text = "Refresh";
            this.btnClearSearchFiltering.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(195, 36);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(635, 8);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // ctrlUsersSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MinimumSize = new System.Drawing.Size(893, 64);
            this.Name = "ctrlUsersSearch";
            this.Size = new System.Drawing.Size(893, 64);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
