using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var filename = "dbconfig_qlks.ini";
            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullpath = Path.Combine(directory_mydoc, filename);
            if (File.Exists(fullpath))
            {
                actionDb testFile = new actionDb();
                string strconn = testFile.connstr();
                try
                {
                    SqlConnection testConn = new SqlConnection(strconn);
                    testConn.Open();
                    Application.Run(new f_main());
                        testConn.Close();
                   }catch { Application.Run(new conn_sv());}
            }
            else
            {
                Application.Run(new conn_sv());
            }
        }
        
    }
    public class actionDb
    {
        public string connstr()
        {
            var filename = "dbconfig_qlks.ini";
            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullpath = Path.Combine(directory_mydoc, filename);
            string[] lines = File.ReadAllLines(fullpath);
            string svname = lines[0];
            string dbname = lines[1];
            string username = lines[2];
            string password = lines[3];
            string str = "Data Source = " + svname + "; Initial Catalog = " + dbname + "; UID = " + username + "; PWD = " + password + "; Connection Timeout=5";
            return str;
        }
    }
}