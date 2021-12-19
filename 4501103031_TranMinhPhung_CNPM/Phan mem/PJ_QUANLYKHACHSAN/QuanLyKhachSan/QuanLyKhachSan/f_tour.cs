using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class f_tour : Form
    {
        public f_tour()
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

        private void f_tour_Load(object sender, EventArgs e)
        {
            dataGridView_tour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_tour.DataSource = GetTour("").Tables[0];
        }
        DataSet GetTour(string data)
        {
            DataSet dataSet = new DataSet();
            actionDb db = new actionDb();
            string strconn = db.connstr();

            using (SqlConnection con = new SqlConnection(strconn))
            {
                con.Open();
                string query = "SELECT * FROM tour";
                if (data != "")
                {
                    query = "SELECT * FROM tour  where matour LIKE @wh OR tentour LIKE @wh";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@wh", data);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            return dataSet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView_tour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_tour.DataSource = GetTour(textBox_search.Text).Tables[0];
        }

    }
}
