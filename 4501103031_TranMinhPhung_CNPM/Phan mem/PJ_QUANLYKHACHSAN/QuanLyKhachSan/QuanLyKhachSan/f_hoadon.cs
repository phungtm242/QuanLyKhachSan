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
    public partial class f_hoadon : Form
    {
        public f_hoadon()
        {
            InitializeComponent();
        }

        private void pictureBox_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_main f_Main = new f_main();
            f_Main.ShowDialog();
            this.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            data_hoadon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            data_hoadon.DataSource = GetHoaDon(textBox_search.Text).Tables[0];
        }

        private void f_hoadon_Load(object sender, EventArgs e)
        {
            data_hoadon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            data_hoadon.DataSource = GetHoaDon("").Tables[0];
        }

        DataSet GetHoaDon(string data)
        {
            DataSet dataSet = new DataSet();
            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "SELECT * FROM hoadon";
                if (data != "")
                {
                    query = "SELECT * FROM hoadon WHERE mahd LIKE @mahd OR makh LIKE @mahd";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mahd", data);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            return dataSet;
        }
    }
}
