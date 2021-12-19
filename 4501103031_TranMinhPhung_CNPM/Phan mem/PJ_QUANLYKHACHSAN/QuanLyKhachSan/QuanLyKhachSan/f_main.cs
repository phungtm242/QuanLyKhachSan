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
    public partial class f_main : Form
    {
        public f_main()
        {
            InitializeComponent();
        }

        private void button_qlphong_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_room f_Room = new f_room();
            f_Room.ShowDialog();
            this.Close();
        }

        private void button_datphongtruoc_Click(object sender, EventArgs e)
        {
            f_book_room f_Book_Room = new f_book_room("");
            f_Book_Room.ShowDialog();
        }

        private void button_qltour_Click(object sender, EventArgs e)
        {
            f_create_tour f_Create_Tour = new f_create_tour();
            f_Create_Tour.ShowDialog();
        }

        private void button_khtour_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển!");
        }

        private void button_datphongtour_Click(object sender, EventArgs e)
        {
            f_book_room_tour f_Book_Room_Tour = new f_book_room_tour();
            f_Book_Room_Tour.ShowDialog();
        }

        private void button_listtour_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_tour f_Tour = new f_tour();
            f_Tour.ShowDialog();
            this.Close();
        }

        private void button_qlnv_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_nhanvien f_Nhanvien = new f_nhanvien();
            f_Nhanvien.ShowDialog();
            this.Close();
        }

        private void erbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển!");
        }

        private void picture_setting_Click(object sender, EventArgs e)
        {
            this.Hide();
            conn_sv Conn_sv = new conn_sv();
            Conn_sv.ShowDialog();
            this.Close();
        }

        private void picture_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_layphongdat_Click(object sender, EventArgs e)
        {
            f_listdatphong f_Listdatphong = new f_listdatphong();
            f_Listdatphong.ShowDialog();
        }

        private void button_ks_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_qlkhachsan f_Qlkhachsan = new f_qlkhachsan();
            f_Qlkhachsan.ShowDialog();
            this.Close();
        }

        private void button_tour_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_qltour f_QLTour = new f_qltour();
            f_QLTour.ShowDialog();
            this.Close();
        }

        private void button_bchd_Click(object sender, EventArgs e)
        {
            this.Hide();
            f_hoadon f_Hoadon = new f_hoadon();
            f_Hoadon.ShowDialog();
            this.Close();
        }

        private void button_doanhthu_Click(object sender, EventArgs e)
        {
            f_doanhthu f_Doanhthu = new f_doanhthu();
            f_Doanhthu.ShowDialog();
        }
    }
}
