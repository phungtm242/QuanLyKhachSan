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
    public partial class f_book_room : Form
    {
        private string _room;
        public f_book_room()
        {
            InitializeComponent();
        }

        public f_book_room(string room) : this()
        {
            _room = room;
            if(_room != "")
            {
                panel3.Enabled = false;
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_book_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            int intTime = (int)localDate.TimeOfDay.TotalMilliseconds;
            string mdp = "p";
            if (checkBox_phongdon.Checked) { mdp = "don"; }
            if (checkBox_phongdoi.Checked) { mdp = "doi"; }
            if (checkBox_deluxe.Checked) { mdp = "deluxe"; }
            if ((checkBox_deluxe.Checked == true || checkBox_phongdon.Checked == true || checkBox_phongdoi.Checked == true || _room != "")
                 && textBox_cmnd.Text != "" && textBox_sdt.Text != "" && textBox_tenkh.Text != "")
            {
                List<string> list = new List<string>();
                if (checkBox_phongdon.Checked)
                {
                    getphong("don");
                }
                else if (checkBox_phongdoi.Checked)
                { getphong("doi"); }
                else if(checkBox_deluxe.Checked)
                {
                    getphong("deluxe");
                }
                
                if(_room == "")
                {
                    f_choose_room f_Choose_Room = new f_choose_room(list);
                    f_Choose_Room.ShowDialog();
                    _room = f_Choose_Room.choose_room;
                }

                string getmakh = "";
                actionDb db = new actionDb();
                string strconn = db.connstr();
                using (SqlConnection sqlConnection = new SqlConnection(strconn))
                {
                    string query = "SELECT makh FROM khachhang WHERE cmnd = @cmnd";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                    sqlCmd.Parameters.AddWithValue("@cmnd", Int32.Parse(textBox_cmnd.Text));
                    sqlConnection.Open();
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        getmakh = sqlReader["makh"].ToString();
                    }
                    sqlReader.Close();
                }
                if (getmakh != "")
                {
                    datPhong(getmakh);
                }
                else
                {

                    int gender = 0;
                    if (checkBox_nam.Checked) { gender = 1; }
                    string strconn2 = db.connstr();
                    using (SqlConnection sqlConnection = new SqlConnection(strconn2))
                    {
                        string query = "INSERT INTO khachhang(makh, tenkh, gtinh, cmnd, sdt, email) VALUES (@makh, @tenkh, @gtinh, @cmnd, @sdt, @email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                        sqlCmd.Parameters.AddWithValue("@makh", "kh" + textBox_cmnd.Text);
                        sqlCmd.Parameters.AddWithValue("@tenkh", textBox_tenkh.Text);
                        sqlCmd.Parameters.AddWithValue("@gtinh", gender);
                        sqlCmd.Parameters.AddWithValue("@cmnd", Int32.Parse(textBox_cmnd.Text));
                        sqlCmd.Parameters.AddWithValue("@sdt", Int32.Parse(textBox_sdt.Text));
                        sqlCmd.Parameters.AddWithValue("@email", textBox_email.Text);
                        sqlConnection.Open();
                        try
                        {
                            sqlCmd.ExecuteReader();
                            datPhong("kh" + textBox_cmnd.Text);
                        }
                        catch { MessageBox.Show("Lỗi khi tạo khách hàng mới, vui lòng thử lại!" + query, "Error"); }
                        sqlConnection.Close();
                    }
                }
                void datPhong(string makh)
                {
                    string strconn1 = db.connstr();
                    using (SqlConnection sqlConnection = new SqlConnection(strconn1))
                    {
                        string query = "INSERT INTO datphong(madatphong, maphong,makh, tgnhanphong, tgtradukien, tiencoc) VALUES (@madatphong, @maphong,@makh, @tgnhan, @tgtradk, @tiencoc)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                        sqlCmd.Parameters.AddWithValue("@madatphong", mdp + intTime.ToString());
                        sqlCmd.Parameters.AddWithValue("@maphong", _room);
                        sqlCmd.Parameters.AddWithValue("@makh", makh);
                        sqlCmd.Parameters.AddWithValue("@tgnhan", date_start.Value.ToString("M/d/yyyy") + " " + time_start.Value.ToString("HH:mm"));
                        sqlCmd.Parameters.AddWithValue("@tgtradk", date_end.Value.ToString("M/d/yyyy") + " " + time_end.Value.ToString("HH:mm"));
                        sqlCmd.Parameters.AddWithValue("@tiencoc", Int32.Parse(textBox_tiencoc.Text));
                        sqlConnection.Open();
                        try
                        {
                            sqlCmd.ExecuteReader();
                            MessageBox.Show("Đặt phòng thành công", "Success!");
                            this.Close();
                        }
                        catch { MessageBox.Show("Lỗi, vui lòng thử lại!", "Error"); this.Close(); }
                    }
                }

            //Child function
            void getphong(string loaiphong)
                 {
                        List<string> ls = new List<string>();
                        actionDb db = new actionDb();
                        string strconn = db.connstr();
                        using (SqlConnection sqlConnection = new SqlConnection(strconn))
                        {
                            string query = "SELECT datphong.maphong as maphong FROM datphong JOIN phong ON datphong.maphong = phong.maphong WHERE datphong.tgnhanphong < @tgnhan AND datphong.tgtraphong IS NULL AND phong.loaiphong = @loaiphong";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                            sqlCmd.Parameters.AddWithValue("@tgnhan", date_start.Value.ToString("M/d/yyyy") + " " + time_start.Value.ToString("HH:mm"));
                            sqlCmd.Parameters.AddWithValue("@loaiphong", loaiphong);
                            sqlConnection.Open();
                            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                            while (sqlReader.Read())
                            {
                                ls.Add(sqlReader["maphong"].ToString());
                            }
                            sqlReader.Close();
                        }
                        using (SqlConnection sqlConnection = new SqlConnection(strconn))
                        {
                            string query = "SELECT maphong FROM phong WHERE loaiphong = @loaiphong";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                            sqlCmd.Parameters.AddWithValue("@loaiphong", loaiphong);
                            sqlConnection.Open();
                            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                            while (sqlReader.Read())
                            {
                                list.Add(sqlReader["maphong"].ToString());
                            }
                            sqlReader.Close();
                        }
                        for (int i = 0; i < ls.Count; i++)
                        {
                            list.Remove(ls[i]);
                        }
                }
            } else { MessageBox.Show("Vui long dien day du thong tin!"); }
        }

        private void getMaKh()
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT makh, tenkh, gtinh, sdt, email FROM khachhang WHERE cmnd = @cmnd";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@cmnd", Int32.Parse(textBox_cmnd.Text));
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    textBox_makh.Text = sqlReader["makh"].ToString();
                    textBox_tenkh.Text = sqlReader["tenkh"].ToString();
                    textBox_sdt.Text = sqlReader["sdt"].ToString();
                    textBox_email.Text = sqlReader["email"].ToString();
                    if(sqlReader["gtinh"].ToString() == "0")
                    {
                        checkBox_nu.Checked = true;
                    }
                    else
                    {
                        checkBox_nam.Checked = true;
                    }
                }
                sqlReader.Close();
            }
        }

        private void textBox_cmnd_TextChanged(object sender, EventArgs e)
        {
            getMaKh();
        }

        private void onlynumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void checkBox_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_nam.Checked)
            {
                checkBox_nu.Checked = false;
            }
            else
            {
                checkBox_nu.Checked = true;
            }
        }

        private void checkBox_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_nu.Checked)
            {
                checkBox_nam.Checked = false;
            }
            else
            {
                checkBox_nam.Checked = true;
            }
        }

        private int getGender()
        {
            if (checkBox_nam.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void checkBox_phongdon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_phongdon.Checked)
            {
                checkBox_deluxe.Checked = false;
                checkBox_phongdoi.Checked = false;
            }
        }

        private void checkBox_phongdoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_phongdoi.Checked)
            {
                checkBox_deluxe.Checked = false;
                checkBox_phongdon.Checked = false;
            }
        }

        private void checkBox_nhieuphong_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_deluxe.Checked)
            {
                checkBox_phongdoi.Checked = false;
                checkBox_phongdon.Checked = false;
            }
        }
    }
}
