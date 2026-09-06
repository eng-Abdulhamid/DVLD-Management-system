namespace DVLD.PL
{
    public partial class ctrlListUsers : ctrlListItemsPagenation
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
        private new void InitializeComponent()
        {
            this.modernPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(832, 1);
            // 
            // modernPanel1
            // 
            this.modernPanel1.Size = new System.Drawing.Size(1189, 63);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(1012, 0);
            // 
            // lblItemsLabel
            // 
            this.lblItemsLabel.Size = new System.Drawing.Size(41, 17);
            this.lblItemsLabel.Text = "Users";
            this.lblItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApplyPage
            // 
            // 
            // ctrlListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlListUsers";
            this.Size = new System.Drawing.Size(1207, 578);
            this.modernPanel1.ResumeLayout(false);
            this.modernPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
