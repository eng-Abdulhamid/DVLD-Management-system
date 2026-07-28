namespace DVLDPL
{
    partial class ctrlCustomDataGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgPeople = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPeople
            // 
            this.dgPeople.AllowUserToAddRows = false;
            this.dgPeople.AllowUserToDeleteRows = false;
            this.dgPeople.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgPeople.BackgroundColor = System.Drawing.Color.White;
            this.dgPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPeople.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPeople.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPeople.Location = new System.Drawing.Point(0, 0);
            this.dgPeople.Name = "dgPeople";
            this.dgPeople.ReadOnly = true;
            this.dgPeople.RowHeadersVisible = false;
            this.dgPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPeople.Size = new System.Drawing.Size(735, 413);
            this.dgPeople.StandardTab = true;
            this.dgPeople.TabIndex = 2;
            // 
            // ctrlCustomDataGridView
            // 
            this.Controls.Add(this.dgPeople);
            this.Name = "ctrlCustomDataGridView";
            this.Size = new System.Drawing.Size(735, 413);
            ((System.ComponentModel.ISupportInitialize)(this.dgPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPeople;
    }
}
