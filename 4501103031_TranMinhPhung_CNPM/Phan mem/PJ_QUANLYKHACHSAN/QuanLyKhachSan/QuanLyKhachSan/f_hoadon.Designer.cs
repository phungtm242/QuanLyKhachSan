namespace QuanLyKhachSan
{
    partial class f_hoadon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_hoadon));
            this.pictureBox_home = new System.Windows.Forms.PictureBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.data_hoadon = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_hoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_home
            // 
            this.pictureBox_home.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_home.Image = global::QuanLyKhachSan.Properties.Resources.home1;
            this.pictureBox_home.Location = new System.Drawing.Point(23, 12);
            this.pictureBox_home.Name = "pictureBox_home";
            this.pictureBox_home.Size = new System.Drawing.Size(60, 48);
            this.pictureBox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_home.TabIndex = 0;
            this.pictureBox_home.TabStop = false;
            this.pictureBox_home.Click += new System.EventHandler(this.pictureBox_home_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_search.Location = new System.Drawing.Point(133, 28);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(426, 32);
            this.textBox_search.TabIndex = 1;
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Purple;
            this.button_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_search.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(565, 28);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(88, 32);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Tìm";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // data_hoadon
            // 
            this.data_hoadon.BackgroundColor = System.Drawing.Color.White;
            this.data_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_hoadon.Location = new System.Drawing.Point(8, 92);
            this.data_hoadon.Name = "data_hoadon";
            this.data_hoadon.RowTemplate.Height = 25;
            this.data_hoadon.Size = new System.Drawing.Size(664, 432);
            this.data_hoadon.TabIndex = 3;
            // 
            // f_hoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyKhachSan.Properties.Resources.khachsan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 536);
            this.Controls.Add(this.data_hoadon);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.pictureBox_home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_hoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel manager - Hóa đơn";
            this.Load += new System.EventHandler(this.f_hoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_hoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox_home;
        private TextBox textBox_search;
        private Button button_search;
        private DataGridView data_hoadon;
    }
}