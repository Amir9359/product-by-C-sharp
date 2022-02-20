namespace product
{
    partial class listView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mytexbox1 = new product.mytexbox();
            this.myDataGrid1 = new product.myDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // mytexbox1
            // 
            this.mytexbox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mytexbox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.mytexbox1.Location = new System.Drawing.Point(0, 452);
            this.mytexbox1.Name = "mytexbox1";
            this.mytexbox1.Size = new System.Drawing.Size(415, 35);
            this.mytexbox1.TabIndex = 1;
            this.mytexbox1.Click += new System.EventHandler(this.mytexbox1_Click);
            this.mytexbox1.TextChanged += new System.EventHandler(this.mytexbox1_TextChanged);
            this.mytexbox1.Enter += new System.EventHandler(this.mytexbox1_Enter);
            this.mytexbox1.Leave += new System.EventHandler(this.mytexbox1_Leave);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowUserToAddRows = false;
            this.myDataGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.myDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.RowTemplate.Height = 24;
            this.myDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGrid1.Size = new System.Drawing.Size(415, 452);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGrid1_CellDoubleClick);
            this.myDataGrid1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.myDataGrid1_ColumnHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "code";
            this.dataGridViewTextBoxColumn1.HeaderText = "کد";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "title";
            this.dataGridViewTextBoxColumn2.HeaderText = "نام";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "code";
            this.Column2.HeaderText = "کد";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "title";
            this.Column1.HeaderText = "نام";
            this.Column1.Name = "Column1";
            // 
            // listView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 487);
            this.Controls.Add(this.mytexbox1);
            this.Controls.Add(this.myDataGrid1);
            this.Name = "listView";
            this.Text = "listView";
            this.Load += new System.EventHandler(this.listView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private myDataGrid myDataGrid1;
        private mytexbox mytexbox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}