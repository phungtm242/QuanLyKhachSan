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
    public partial class f_doanhthu : Form
    {
        private int _tong;
        private int _tonghd;
        public f_doanhthu()
        {
            InitializeComponent();
        }

        private void pictureBox_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_baocao_Click(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT tong FROM hoadon WHERE thoigian > @tgdau AND thoigian <@tgcuoi";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@tgdau", date_start.Value.ToString("MM/dd/yyyy"));
                sqlCmd.Parameters.AddWithValue("@tgcuoi", date_end.Value.ToString("MM/dd/yyyy"));
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    _tong += Int32.Parse(sqlReader["tong"].ToString());
                    _tonghd++;
                }
                sqlReader.Close();
            }
            textBox_sohoadon.Text = _tonghd.ToString();
            textBox_tongdoanhthu.Text = _tong.ToString();
        }
    }
}
