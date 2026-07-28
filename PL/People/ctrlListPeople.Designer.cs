namespace DVLDPL
{
    partial class ctrlListPeople
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
            this.modernPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(832, -3);
            // 
            // modernPanel1
            // 
            this.modernPanel1.Size = new System.Drawing.Size(1189, 63);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(1012, -4);
            // 
            // btnApplyPage
            // 
            this.btnApplyPage.Click += new System.EventHandler(this.ApplyPage_Click);
            // 
            // ctrlListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlListPeople";
            this.Size = new System.Drawing.Size(1207, 578);
            this.modernPanel1.ResumeLayout(false);
            this.modernPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
