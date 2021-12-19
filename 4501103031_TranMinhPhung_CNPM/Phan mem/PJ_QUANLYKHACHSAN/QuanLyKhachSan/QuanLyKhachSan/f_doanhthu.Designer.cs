namespace QuanLyKhachSan
{
    partial class f_doanhthu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_doanhthu));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_home = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date_start = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_tongdoanhthu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_sohoadon = new System.Windows.Forms.TextBox();
            this.button_baocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo doanh thu";
            // 
            // pictureBox_home
            // 
            this.pictureBox_home.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_home.Image = global::QuanLyKhachSan.Properties.Resources.home1;
            this.pictureBox_home.Location = new System.Drawing.Point(22, 8);
            this.pictureBox_home.Name = "pictureBox_home";
            this.pictureBox_home.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_home.TabIndex = 1;
            this.pictureBox_home.TabStop = false;
            this.pictureBox_home.Click += new System.EventHandler(this.pictureBox_home_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(55, 70);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4);
            this.label2.Size = new System.Drawing.Size(86, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày";
            // 
            // date_start
            // 
            this.date_start.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.date_start.CustomFormat = "dd/MM/yyyy";
            this.date_start.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.date_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start.Location = new System.Drawing.Point(140, 68);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(133, 32);
            this.date_start.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(275, 69);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4);
            this.label3.Size = new System.Drawing.Size(95, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày";
            // 
            // date_end
            // 
            this.date_end.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.date_end.CustomFormat = "dd/MM/yyyy";
            this.date_end.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.date_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_end.Location = new System.Drawing.Point(374, 68);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(133, 32);
            this.date_end.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(55, 164);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(183, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổng doanh thu";
            // 
            // textBox_tongdoanhthu
            // 
            this.textBox_tongdoanhthu.Enabled = false;
            this.textBox_tongdoanhthu.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_tongdoanhthu.Location = new System.Drawing.Point(244, 165);
            this.textBox_tongdoanhthu.Name = "textBox_tongdoanhthu";
            this.textBox_tongdoanhthu.Size = new System.Drawing.Size(265, 35);
            this.textBox_tongdoanhthu.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Purple;
            this.label5.Location = new System.Drawing.Point(55, 228);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(135, 36);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số hóa đơn";
            // 
            // textBox_sohoadon
            // 
            this.textBox_sohoadon.Enabled = false;
            this.textBox_sohoadon.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_sohoadon.Location = new System.Drawing.Point(242, 225);
            this.textBox_sohoadon.Name = "textBox_sohoadon";
            this.textBox_sohoadon.Size = new System.Drawing.Size(265, 35);
            this.textBox_sohoadon.TabIndex = 9;
            // 
            // button_baocao
            // 
            this.button_baocao.BackColor = System.Drawing.Color.Purple;
            this.button_baocao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_baocao.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_baocao.ForeColor = System.Drawing.Color.White;
            this.button_baocao.Location = new System.Drawing.Point(145, 106);
            this.button_baocao.Name = "button_baocao";
            this.button_baocao.Size = new System.Drawing.Size(285, 53);
            this.button_baocao.TabIndex = 10;
            this.button_baocao.Text = "Báo cáo doanh thu";
            this.button_baocao.UseVisualStyleBackColor = false;
            this.button_baocao.Click += new System.EventHandler(this.button_baocao_Click);
            // 
            // f_doanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyKhachSan.Properties.Resources.khachsan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(553, 273);
            this.Controls.Add(this.button_baocao);
            this.Controls.Add(this.textBox_sohoadon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_tongdoanhthu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox_home);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_doanhthu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel manager - Doanh Thu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox pictureBox_home;
        private Label label2;
        private DateTimePicker date_start;
        private Label label3;
        private DateTimePicker date_end;
        private Label label4;
        private TextBox textBox_tongdoanhthu;
        private Label label5;
        private TextBox textBox_sohoadon;
        private Button button_baocao;
    }
}