using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class f_addnv : Form
    {
        private int gtinh;
        public f_addnv()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "INSERT INTO nhanvien(manv, tennv, gtinh, ngaysinh, ngayvao, cmnd, diachi, sdt, mavitri) VALUES (@manv, @tennv, @gtinh, @ngaysinh, @ngayvao, @cmnd, @diachi, @sdt, @mavitri)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@manv", textBox_manv.Text);
                cmd.Parameters.AddWithValue("@tennv", textBox_tennv.Text);
                cmd.Parameters.AddWithValue("@gtinh", gtinh);
                cmd.Parameters.AddWithValue("@ngaysinh", date_ngaysinh.Value.ToString("M/d/yyyy"));
                cmd.Parameters.AddWithValue("@ngayvao", date_ngayvao.Value.ToString("M/d/yyyy"));
                cmd.Parameters.AddWithValue("@cmnd", Int32.Parse(textBox_cmnd.Text));
                cmd.Parameters.AddWithValue("@diachi", textBox_diachi.Text);
                cmd.Parameters.AddWithValue("@sdt", Int32.Parse(textBox_sdt.Text));
                cmd.Parameters.AddWithValue("@mavitri", comboBox_vitri.Text.Substring(0, comboBox_vitri.Text.IndexOf("-")));
                sqlConnection.Open();
                try
                {
                    cmd.ExecuteReader();
                    MessageBox.Show("Tạo nhân viên thành công", "Success!");
                }
                catch { MessageBox.Show("Tạo nhân viên lỗi, vui lòng thử lại!", "Error"); }
                sqlConnection.Close();
            }
            this.Close();
        }

        private void f_addnv_Load(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT mavitri, tenvitri FROM vitri", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBox_vitri.Items.Add(sqlReader["mavitri"].ToString() + '-' + sqlReader["tenvitri"].ToString());
                }
                sqlReader.Close();
            }
        }

        private void checkBox_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_nam.Checked)
            {
                checkBox_nu.Checked = false;
                gtinh = 1;
            }
        }

        private void checkBox_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_nu.Checked)
            {
                checkBox_nam.Checked = false;
                gtinh = 0;
            }
        }
    }
}
