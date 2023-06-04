using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_BookStore
{
    /// <summary>
    /// Interaction logic for DanhMucQuanLy.xaml
    /// </summary>
    public partial class DanhMucQuanLy : Window
    {
        public DanhMucQuanLy()
        {
            InitializeComponent();
        }

        private void btn_qlSanPham_Click(object sender, RoutedEventArgs e)
        {
            QuanLySanPham sp = new QuanLySanPham();
            this.Close();
            sp.Show();
        }

        private void btn_QuanLyHoaDon_Click(object sender, RoutedEventArgs e)
        {
            QuanLyHoaDon quanLyHoaDon = new QuanLyHoaDon();
            this.Close();
            quanLyHoaDon.Show();
        }

        private void btn_QuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            QuanLyTaiKhoan quanLyTaiKhoan = new QuanLyTaiKhoan();
            this.Close();
            quanLyTaiKhoan.Show();
        }

        private void btn_QuanLyNhanVien_Click(object sender, RoutedEventArgs e)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            this.Close();
            quanLyNhanVien.Show();
        }

        private void btn_dangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
           
        }
    }
}
