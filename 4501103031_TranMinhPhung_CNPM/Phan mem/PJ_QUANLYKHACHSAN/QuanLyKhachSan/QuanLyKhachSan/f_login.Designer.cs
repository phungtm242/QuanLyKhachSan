namespace QuanLyKhachSan
{
    partial class f_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_login));
            this.lablepm = new System.Windows.Forms.Label();
            this.labellogin = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.textbox_pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lablepm
            // 
            this.lablepm.AutoSize = true;
            this.lablepm.BackColor = System.Drawing.Color.Transparent;
            this.lablepm.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lablepm.ForeColor = System.Drawing.Color.Navy;
            this.lablepm.Location = new System.Drawing.Point(12, 9);
            this.lablepm.Name = "lablepm";
            this.lablepm.Size = new System.Drawing.Size(373, 32);
            this.lablepm.TabIndex = 0;
            this.lablepm.Text = "Phần mềm quản lý khách sạn";
            // 
            // labellogin
            // 
            this.labellogin.AutoSize = true;
            this.labellogin.BackColor = System.Drawing.Color.Transparent;
            this.labellogin.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labellogin.ForeColor = System.Drawing.Color.Purple;
            this.labellogin.Location = new System.Drawing.Point(476, 35);
            this.labellogin.Name = "labellogin";
            this.labellogin.Size = new System.Drawing.Size(195, 42);
            this.labellogin.TabIndex = 1;
            this.labellogin.Text = "Đăng nhập";
            // 
            // textbox_name
            // 
            this.textbox_name.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_name.Location = new System.Drawing.Point(476, 100);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.PlaceholderText = "Tên đăng nhập";
            this.textbox_name.Size = new System.Drawing.Size(285, 39);
            this.textbox_name.TabIndex = 2;
            // 
            // textbox_pass
            // 
            this.textbox_pass.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_pass.Location = new System.Drawing.Point(476, 154);
            this.textbox_pass.Name = "textbox_pass";
            this.textbox_pass.PlaceholderText = "Mật khẩu";
            this.textbox_pass.Size = new System.Drawing.Size(285, 39);
            this.textbox_pass.TabIndex = 3;
            this.textbox_pass.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(593, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // f_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::QuanLyKhachSan.Properties.Resources.khachsan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox_pass);
            this.Controls.Add(this.textbox_name);
            this.Controls.Add(this.labellogin);
            this.Controls.Add(this.lablepm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HM - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lablepm;
        private Label labellogin;
        private TextBox textbox_name;
        private TextBox textbox_pass;
        private Button button1;
    }
}