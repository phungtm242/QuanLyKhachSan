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
    public partial class conn_sv : Form
    {
        public conn_sv()
        {
            InitializeComponent();
        }

        private void conn_sv_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxnameserver.Text == "" || textBoxdbname.Text == "" || textBoxusername.Text == "" || textBoxpassword.Text == "")
            {
                MessageBox.Show("Thiếu thông tin cần thiết, vui lòng điền đầy đủ để kết nối!");
            }
            else
            {
                ConnData connDb = new ConnData();
                try
                {
                    connDb.svname = textBoxnameserver.Text;
                    connDb.dbname = textBoxdbname.Text;
                    connDb.username = textBoxusername.Text;
                    connDb.password = textBoxpassword.Text;

                    string str = connDb.strconn();

                    SqlConnection conndb = new SqlConnection(str);
                    conndb.Open();

                    var filename = "dbconfig_qlks.ini";
                    var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var fullpath = Path.Combine(directory_mydoc, filename);

                    if (File.Exists(fullpath))
                    {
                        File.Delete(fullpath);
                        string[] lines =
                                {
                                    connDb.svname, connDb.dbname, connDb.username, connDb.password
                                };
                        using (StreamWriter outputFile = new StreamWriter(fullpath))
                        {
                            foreach (string line in lines)
                                outputFile.WriteLine(line);
                        }
                        MessageBox.Show("Kết nối thành công!");
                    }
                    else
                    {
                        string[] lines =
                                {
                                    connDb.svname, connDb.dbname, connDb.username, connDb.password
                                };
                        using (StreamWriter outputFile = new StreamWriter(fullpath))
                        {
                            foreach (string line in lines)
                                outputFile.WriteLine(line);
                        }
                        MessageBox.Show("Kết nối thành công!");
                    }
                    conndb.Close();
                    this.Hide();
                    f_main mainForm = new f_main();
                    mainForm.ShowDialog();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi kết nối đến csdl, vui lòng kiểm tra lại thông tin đã nhập!");
                }
            }
        }
        public class ConnData
        {
            private string _svname;
            public string svname
            {
                get { return _svname; }
                set { _svname = value; }
            }
            private string _dbname;
            public string dbname
            {
                get { return _dbname; }
                set { _dbname = value; }
            }
            private string _username;
            public string username
            {
                get { return _username; }
                set { _username = value; }
            }
            private string _password;
            public string password
            {
                get { return _password; }
                set { _password = value; }
            }

            //Connect

            public string strconn()
            {
                string conn = "Data Source = " + svname + "; Initial Catalog = " + dbname + "; UID = " + username + "; PWD = " + password + "; Connection Timeout=5";
                return conn;
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
