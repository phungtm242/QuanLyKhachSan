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
    public partial class f_ephong : Form
    {
        private string _maphong;
        public f_ephong()
        {
            InitializeComponent();
        }

        public f_ephong(string maphong) : this()
        {
            _maphong = maphong;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_dichvu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang được phát triển!");
        }

        private void button_traphong_Click(object sender, EventArgs e)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT madatphong FROM datphong WHERE maphong = @maphong AND tgtraphong is null";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@maphong", _maphong);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    f_xuathoadon f_Xuathoadon = new f_xuathoadon(sqlReader["madatphong"].ToString());
                    f_Xuathoadon.ShowDialog();
                    if(f_Xuathoadon.status == 1)
                    {
                        callUpdate(sqlReader["madatphong"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Tạo hóa đơn lỗi, vui lòng thử lại!");
                    }

                }
                sqlReader.Close();
            }
        }
        private void callUpdate(string madatphong)
        {
            DateTime localDate = DateTime.Now;
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "UPDATE datphong SET tgtraphong = @tg WHERE madatphong = @madat";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@tg", localDate.ToString("MM/dd/yyyy HH:mm"));
                sqlCmd.Parameters.AddWithValue("@madat", madatphong);
                sqlConnection.Open();
                try
                {
                    sqlCmd.ExecuteReader();
                    MessageBox.Show("Thanh toán xong!");
                    this.Close();
                }
                catch { MessageBox.Show("Lỗi không thể xuất thanh toán, vui lòng thử lại!" + query, "Error"); this.Close(); }
                sqlConnection.Close();
            }
        }
    }
}
