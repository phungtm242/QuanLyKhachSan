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
    public partial class f_listdatphong : Form
    {
        public f_listdatphong()
        {
            InitializeComponent();
        }

        private void f_listdatphong_Load(object sender, EventArgs e)
        {
            data_listdatphong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            data_listdatphong.DataSource = GetList("").Tables[0];
        }

        DataSet GetList(string data)
        {
            DataSet dataSet = new DataSet();
            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "SELECT madatphong, maphong, makh, tgnhanphong, tgtradukien, tgtraphong, tiencoc FROM datphong";
                if (data != "")
                {
                    query = "SELECT madatphong, maphong, makh, tgnhanphong, tgtradukien, tgtraphong, tiencoc FROM datphong WHERE madatphong LIKE @wh OR makh LIKE @wh";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@wh", data);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            return dataSet;
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f_book_room f_Book_Room = new f_book_room();
            f_Book_Room.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentRow = data_listdatphong.CurrentRow.Index;
            string currentMadatphong = data_listdatphong.Rows[currentRow].Cells[0].Value.ToString();

            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "DELETE FROM datphong WHERE madatphong = @masv";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@masv", currentMadatphong);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa đặt phòng!", "Success!");
                    data_listdatphong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    data_listdatphong.DataSource = GetList("").Tables[0];
                }
                catch
                {
                    MessageBox.Show("Không thể xóa !", "Xóa dữ liệu lỗi");
                }
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            data_listdatphong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            data_listdatphong.DataSource = GetList(textBox_search.Text).Tables[0];
        }

        private void pictureBox_load_Click(object sender, EventArgs e)
        {
            data_listdatphong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            data_listdatphong.DataSource = GetList(textBox_search.Text).Tables[0];
        }

        private void button_layphong_Click(object sender, EventArgs e)
        {
            int currentRow = data_listdatphong.CurrentRow.Index;
            string currentMadatphong = data_listdatphong.Rows[currentRow].Cells[0].Value.ToString();
            string currentMaphong = data_listdatphong.Rows[currentRow].Cells[1].Value.ToString();
            string currentMakh = data_listdatphong.Rows[currentRow].Cells[2].Value.ToString();

            f_use_room f_Use_Room = new f_use_room(currentMaphong, currentMakh, currentMadatphong);
            f_Use_Room.FormClosed += pictureBox_load_Click;
            f_Use_Room.ShowDialog();

        }
    }
}
