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
    public partial class f_xuathoadon : Form
    {
        private int stt = 0;
        public int status { get { return stt; } }
        private string _madatphong;
        public f_xuathoadon()
        {
            InitializeComponent();
        }

        public f_xuathoadon(string madatphong) : this()
        {
            _madatphong = madatphong;
        }

        private void f_xuathoadon_Load(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT datphong.maphong as maphong, datphong.makh as makh,  datphong.tgnhanphong as tgnhanphong, datphong.tiencoc as tiencoc, khachhang.tenkh as tenkh, phong.giaphong as giaphong FROM datphong JOIN khachhang ON datphong.makh = khachhang.makh JOIN phong ON datphong.maphong = phong.maphong WHERE datphong.madatphong = @madatphong AND datphong.tgtraphong is null";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@madatphong", _madatphong);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    textBox_tenkh.Text = sqlReader["tenkh"].ToString();
                    textBox_makh.Text = sqlReader["makh"].ToString();
                    textBox_maphong.Text = sqlReader["maphong"].ToString();
                    textBox_coc.Text = sqlReader["tiencoc"].ToString();
                    DateTime time = DateTime.Parse(sqlReader["tgnhanphong"].ToString());
                    date_vao.Value = time;
                    date_ra.Value = localDate;
                    TimeSpan duration = localDate.Subtract(time);
                    int days = duration.Days;
                    int hours = duration.Hours;
                    int minutes = duration.Minutes;
                    if(days > 0) { hours += days * 24; }
                    textBox_tgsudung.Text = hours.ToString() + ":" + minutes;
                    if (minutes > 10) { hours++; }
                    int tongtien = Int32.Parse(sqlReader["giaphong"].ToString()) * hours;
                    textBox_thanhtien.Text = tongtien.ToString();
                    textBox_conlai.Text = (tongtien - Int32.Parse(sqlReader["tiencoc"].ToString())).ToString();
                }
                sqlReader.Close();
            }

        }

        private void button_thanhtoan_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            int intTime = (int)localDate.TimeOfDay.TotalMilliseconds;
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "INSERT INTO hoadon(mahd, thoigian, makh, tong) VALUES (@mahd, @tg, @makh, @tong)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@mahd", "hd" + intTime.ToString());
                sqlCmd.Parameters.AddWithValue("@tg", localDate.ToString("MM/dd/yyyy HH:mm"));
                sqlCmd.Parameters.AddWithValue("@makh", textBox_makh.Text);
                sqlCmd.Parameters.AddWithValue("@tong", Int32.Parse(textBox_conlai.Text));
                sqlConnection.Open();
                try
                {
                    sqlCmd.ExecuteReader();
                    MessageBox.Show("Đã xuất hóa đơn!");
                    this.Close();
                    stt = 1;
                }
                    catch { MessageBox.Show("Lỗi không thể thêm hóa đơn, vui lòng thử lại!" + query, "Error"); this.Close(); }
                sqlConnection.Close();
            }
        }
    }
}