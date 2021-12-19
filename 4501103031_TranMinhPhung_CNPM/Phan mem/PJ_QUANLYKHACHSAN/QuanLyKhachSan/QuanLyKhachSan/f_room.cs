
using System.Data.SqlClient;

namespace QuanLyKhachSan
{

    public partial class f_room : Form
    {
        private List<string> total = new List<string>();
        public f_room()
        {
            InitializeComponent();
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_main f_Main = new f_main();
            f_Main.ShowDialog();
            this.Close();
        }

        private void f_room_Load(object sender, EventArgs e)
        {

            List<string> listdon = new List<string>();
            List<string> listdoi = new List<string>();
            List<string> listdeluxe = new List<string>();
            getphong("don", listdon);
            getphong("doi", listdoi);
            getphong("deluxe", listdeluxe);

            total.AddRange(listdon);
            total.AddRange(listdoi);
            total.AddRange(listdeluxe);
            //Action
            setaction(total);

        }
        private void resetForm (object sender, EventArgs e)
        {
            setaction(total);
        }
        public static string chooseRoom = "";
        private void Control_Clicks(object sender, EventArgs e)
        {
            Control control = (Control)sender;   // Sender gives you which control is clicked.
            chooseRoom = control.Name.ToString().Substring(11);
            string panelset = "panel_" + chooseRoom;

            foreach(var tab in tabControl_phong.Controls.OfType<TabPage>())
            {
                foreach (var panc in tab.Controls.OfType<Panel>())
                {
                    foreach (var pan in panc.Controls.OfType<Panel>())
                    {
                        if (pan.Name == panelset)
                        {
                            if (pan.BackColor == Color.Red)
                            {
                                f_ephong f_Ephong = new f_ephong(chooseRoom);
                                f_Ephong.FormClosed += resetForm;
                                f_Ephong.ShowDialog();
                            }
                            else
                            {
                                f_book_room f_Book_Room = new f_book_room(chooseRoom);
                                f_Book_Room.FormClosed += resetForm;
                                f_Book_Room.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void getphong(string loai, List<string> xuat)
        {
            actionDb db = new actionDb();
            string strconn = db.connstr();
            using (SqlConnection sqlConnection = new SqlConnection(strconn))
            {
                string query = "SELECT maphong FROM phong WHERE loaiphong = @loai";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@loai", loai);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    xuat.Add(sqlReader["maphong"].ToString());
                    
                }
                sqlReader.Close();
            }
        }

        private void setaction(List<string> listset)
        {
            foreach (var tab in tabControl_phong.Controls.OfType<TabPage>())
            {
                foreach (var panc in tab.Controls.OfType<Panel>())
                {
                    foreach (var pan in panc.Controls.OfType<Panel>())
                    {
                        pan.BackColor = Color.Green;
                    }
                }
            }
            // Set now
            DateTime localDate = DateTime.Now;
            for (int i = 0; i < listset.Count; i++)
            {
                string panelset = "panel_" + listset[i];
                actionDb db = new actionDb();
                string strconn = db.connstr();
                using (SqlConnection sqlConnection = new SqlConnection(strconn))
                {
                    string query = "SELECT madatphong FROM datphong WHERE maphong = @maphong AND tgnhanphong < @tgnhan AND tgtraphong is null";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                    sqlCmd.Parameters.AddWithValue("@maphong", listset[i].ToString());
                    sqlCmd.Parameters.AddWithValue("@tgnhan", localDate.ToString("MM/dd/yyyy HH:mm"));
                    sqlConnection.Open();
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        foreach(var tab in tabControl_phong.Controls.OfType<TabPage>())
                        {
                            foreach (var panc in tab.Controls.OfType<Panel>())
                            {
                                foreach (var pan in panc.Controls.OfType<Panel>())
                                {
                                    if (pan.Name == panelset) { pan.BackColor = Color.Red; }
                                }
                            }
                        }
                    }
                    sqlReader.Close();
                }
            }
        }


        //Button chức năng
        private void pictureBox_list_Click(object sender, EventArgs e)
        {
            f_listdatphong f_Listdatphong = new f_listdatphong();
            f_Listdatphong.ShowDialog();
        }

        private void pictureBox_account_Click(object sender, EventArgs e)
        {
            f_book_room f_Book_Room = new f_book_room();
            f_Book_Room.ShowDialog();
        }

        private void pictureBox_lock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển!");
        }

    }
}
