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
    public partial class f_create_tour : Form
    {
        public f_create_tour()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_tentour.Text == "" || textBox_songuoi.Text == "" || textBox_gia.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
            }
            else
            {
                var result = MessageBox.Show("Tạo tour?", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    actionDb db = new actionDb();
                    string strconn = db.connstr();
                    using (SqlConnection sqlConnection = new SqlConnection(strconn))
                    {
                        string query = "INSERT INTO tour(matour, tentour, tgbatdau, tgketthuc, songuoi, giatour, dandoan, trangthai) VALUES (@matour, @tentour, @tgbatdau, @tgketthuc, @songuoi, @gia, @tiepvien, 'xetduyet')";
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        cmd.Parameters.AddWithValue("@matour", textBox_matour.Text);
                        cmd.Parameters.AddWithValue("@tentour", textBox_tentour.Text);
                        cmd.Parameters.AddWithValue("@tgbatdau", dateTimePicker_start.Value.ToString("M/d/yyyy"));
                        cmd.Parameters.AddWithValue("@tgketthuc", dateTimePicker_end.Value.ToString("M/d/yyyy"));
                        cmd.Parameters.AddWithValue("@songuoi", Int32.Parse(textBox_songuoi.Text));
                        cmd.Parameters.AddWithValue("@gia", Int32.Parse(textBox_gia.Text));
                        cmd.Parameters.AddWithValue("@tiepvien", cutManv(comboBox_tiepvien.Text));
                        sqlConnection.Open();
                        try
                        {
                            cmd.ExecuteReader();
                            MessageBox.Show("Tạo tour thành công", "Success!");
                            textBox_matour.Text = String.Empty;
                            textBox_tentour.Text = String.Empty;
                            textBox_songuoi.Text = String.Empty;
                            textBox_gia.Text = String.Empty;
                            comboBox_tiepvien.Text = String.Empty;
                        }
                        catch { MessageBox.Show("Tạo tour lỗi, vui lòng thử lại!", "Error"); }
                        sqlConnection.Close();
                    }
                }
            }
        }


        

        private void f_create_tour_Load(object sender, EventArgs e)
        {
            loadTiepVien();
        }

        private void loadTiepVien()
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT manv, tennv FROM nhanvien", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBox_tiepvien.Items.Add(sqlReader["manv"].ToString() + '-' + sqlReader["tennv"].ToString());
                }
                sqlReader.Close();
            }
        }

        private string cutManv(string str)
        {
            int last = str.IndexOf('-');
            string manv = str.Substring(0, last);
            return manv;
        }
    }
}
