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
    public partial class f_use_room : Form
    {
        private string _madatphong;
        private string _maphong;
        private string _makh;
        public f_use_room()
        {
            InitializeComponent();
        }

        public f_use_room(string Maphong, string makh, string madatphong) : this()
        {
            _madatphong = madatphong;
            _maphong = Maphong;
            _makh = makh;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_use_room_Load(object sender, EventArgs e)
        {
            textBox_cmnd.Enabled = false;
            textBox_ten.Enabled = false;
            textBox_room.Text = _maphong;
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT tenkh, cmnd FROM khachhang WHERE makh = @makh";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@makh", _makh);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    textBox_ten.Text = sqlReader["tenkh"].ToString();
                    textBox_cmnd.Text = sqlReader["cmnd"].ToString();
                }
                sqlReader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "UPDATE datphong SET tgnhanphong = '" + localDate.ToString("MM/dd/yyyy HH:mm") + "' WHERE madatphong = '" + _madatphong + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lấy phòng!", "Success");
                    this.Close();
                    con.Close();
                }
                catch { MessageBox.Show("Không thể sửa, vui lòng kiểm tra lại", "Error!"); };
            }

        }
    }
}
