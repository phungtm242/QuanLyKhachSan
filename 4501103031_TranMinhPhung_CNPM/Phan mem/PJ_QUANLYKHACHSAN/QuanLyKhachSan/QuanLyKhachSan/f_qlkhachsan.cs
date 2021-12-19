using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class f_qlkhachsan : Form
    {
        public f_qlkhachsan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_main f_Main = new f_main();
            f_Main.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_addvitri f_Addvitri = new f_addvitri("khach san");
            f_Addvitri.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f_addql f_Addql = new f_addql();
            f_Addql.ShowDialog();
        }
    }
}
