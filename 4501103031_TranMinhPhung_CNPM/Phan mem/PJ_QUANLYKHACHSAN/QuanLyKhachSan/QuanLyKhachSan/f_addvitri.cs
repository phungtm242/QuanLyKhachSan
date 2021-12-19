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
    public partial class f_addvitri : Form
    {
        private string _bophan;
        public f_addvitri()
        {
            InitializeComponent();
        }
        public f_addvitri(string bophan) : this()
        {
            _bophan = bophan;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_addvitri_Load(object sender, EventArgs e)
        {
            label1.Text = "Thêm vị trí nhân viên " + _bophan;
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT maquanly, tenquanly FROM quanly", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["maquanly"].ToString() + '-' + sqlReader["tenquanly"].ToString());
                }
                sqlReader.Close();
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "INSERT INTO vitri(mavitri, bophan, maquanly, tenvitri) VALUES ('"+ textBox_mavitri.Text + "', '"+ _bophan +"', '" + comboBox1.Text.Substring(0, comboBox1.Text.IndexOf("-")) + "', '"+ textBox_tenvitri.Text + "')";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                try
                {
                    cmd.ExecuteReader();
                    MessageBox.Show("Tạo vị trí thành công", "Success!");
                    this.Close();
                }
                catch { MessageBox.Show("Tạo tour lỗi, vui lòng thử lại! " + query, "Error"); }
                sqlConnection.Close();
            }
        }
    }
}
