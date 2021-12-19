namespace QuanLyKhachSan
{
    partial class f_ephong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ephong));
            this.button_exit = new System.Windows.Forms.Button();
            this.button_dichvu = new System.Windows.Forms.Button();
            this.button_traphong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_exit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_exit.ForeColor = System.Drawing.Color.White;
            this.button_exit.Location = new System.Drawing.Point(12, 12);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(140, 50);
            this.button_exit.TabIndex = 0;
            this.button_exit.Text = "THOÁT";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_dichvu
            // 
            this.button_dichvu.BackColor = System.Drawing.Color.DarkGreen;
            this.button_dichvu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_dichvu.ForeColor = System.Drawing.Color.White;
            this.button_dichvu.Location = new System.Drawing.Point(181, 12);
            this.button_dichvu.Name = "button_dichvu";
            this.button_dichvu.Size = new System.Drawing.Size(140, 50);
            this.button_dichvu.TabIndex = 1;
            this.button_dichvu.Text = "DỊCH VỤ";
            this.button_dichvu.UseVisualStyleBackColor = false;
            this.button_dichvu.Click += new System.EventHandler(this.button_dichvu_Click);
            // 
            // button_traphong
            // 
            this.button_traphong.BackColor = System.Drawing.Color.Purple;
            this.button_traphong.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_traphong.ForeColor = System.Drawing.Color.White;
            this.button_traphong.Location = new System.Drawing.Point(347, 12);
            this.button_traphong.Name = "button_traphong";
            this.button_traphong.Size = new System.Drawing.Size(140, 50);
            this.button_traphong.TabIndex = 2;
            this.button_traphong.Text = "TRẢ PHÒNG";
            this.button_traphong.UseVisualStyleBackColor = false;
            this.button_traphong.Click += new System.EventHandler(this.button_traphong_Click);
            // 
            // f_ephong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 76);
            this.Controls.Add(this.button_traphong);
            this.Controls.Add(this.button_dichvu);
            this.Controls.Add(this.button_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_ephong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel manager";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_exit;
        private Button button_dichvu;
        private Button button_traphong;
    }
}