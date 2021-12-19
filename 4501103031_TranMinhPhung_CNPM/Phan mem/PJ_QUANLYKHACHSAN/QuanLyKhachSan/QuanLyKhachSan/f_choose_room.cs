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
    public partial class f_choose_room : Form
    {
        public string choose_room { get { return comboBox1.Text; } }
        List<string> roomList = new List<string>();
        public f_choose_room()
        {
            InitializeComponent();
        }

        public f_choose_room(List<string> rooms) : this()
        {
            roomList = rooms;
        }

        private void f_choose_room_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < roomList.Count; i++)
            {
                comboBox1.Items.Add(roomList[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
