namespace product
{
    partial class mymessagbox
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnyes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnno = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(225, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btnyes
            // 
            this.btnyes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnyes.Location = new System.Drawing.Point(343, 176);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(97, 55);
            this.btnyes.TabIndex = 1;
            this.btnyes.Text = "بلی";
            this.btnyes.UseVisualStyleBackColor = false;
            this.btnyes.Visible = false;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnno
            // 
            this.btnno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnno.Location = new System.Drawing.Point(15, 176);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(97, 55);
            this.btnno.TabIndex = 1;
            this.btnno.Text = "خیر";
            this.btnno.UseVisualStyleBackColor = false;
            this.btnno.Visible = false;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // btnok
            // 
            this.btnok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnok.Location = new System.Drawing.Point(182, 176);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(97, 55);
            this.btnok.TabIndex = 1;
            this.btnok.Text = "تایید";
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // mymessagbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 243);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnno);
            this.Controls.Add(this.btnyes);
            this.Controls.Add(this.label1);
            this.Name = "mymessagbox";
            this.Text = "پنجره پیغام";
            this.Load += new System.EventHandler(this.mymessagbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnyes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnno;
        private System.Windows.Forms.Button btnok;
    }
}