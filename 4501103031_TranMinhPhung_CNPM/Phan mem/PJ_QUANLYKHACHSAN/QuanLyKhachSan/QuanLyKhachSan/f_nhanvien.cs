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
    public partial class f_nhanvien : Form
    {
        public f_nhanvien()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_main f_Main = new f_main();
            f_Main.ShowDialog();
            this.Close();
        }

        private void f_nhanvien_Load(object sender, EventArgs e)
        {
            dataGridView_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_nhanvien.DataSource = GetNhanVien("").Tables[0];
        }
        DataSet GetNhanVien(string data)
        {
            DataSet dataSet = new DataSet();
            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "SELECT * FROM nhanvien";
                if (data != "")
                {
                    query = "SELECT * FROM tour  where manv LIKE @wh OR tennv LIKE @wh";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@wh", data);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            return dataSet;
        }

        private void button_seaarch_Click(object sender, EventArgs e)
        {
            dataGridView_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_nhanvien.DataSource = GetNhanVien(textBox_search.Text).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_addnv f_Addnv = new f_addnv();
            f_Addnv.FormClosed += new FormClosedEventHandler(dialog_FormClosed);
            f_Addnv.ShowDialog();
        }

        private void dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_nhanvien.DataSource = GetNhanVien("").Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView_nhanvien.CurrentRow.Index;
            string currentManv = dataGridView_nhanvien.Rows[currentRow].Cells[0].Value.ToString();

            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "DELETE FROM nhanvien WHERE manv = @manv";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@manv", currentManv);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa nhân viên!", "Success!");
                    dataGridView_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_nhanvien.DataSource = GetNhanVien("").Tables[0];
                }
                catch
                {
                    MessageBox.Show("Không thể xóa nhân viên này!", "Xóa dữ liệu lỗi");
                }
            }
        }
    }
}
