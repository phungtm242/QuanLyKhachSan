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
    public partial class f_addql : Form
    {
        public f_addql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int gtinh = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "INSERT INTO quanly(maquanly, tenquanly, gtinh) VALUES (@maql, @tenql, @gtinh)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@maql", textBox_maql.Text);
                cmd.Parameters.AddWithValue("@tenql", textBox_tenql.Text);
                cmd.Parameters.AddWithValue("@gtinh", gtinh);
                sqlConnection.Open();
                try
                {
                    cmd.ExecuteReader();
                    MessageBox.Show("Đã tạo quản lý", "Success!");
                }
                catch { MessageBox.Show("Tạo quản lý lỗi, vui lòng thử lại!", "Error"); }
                sqlConnection.Close();
            }
            this.Close();
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
