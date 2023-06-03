using Project_BookStore.Models;
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
    /// Interaction logic for BangThongKeNhanVien.xaml
    /// </summary>
    public partial class BangThongKeNhanVien : Window
    {
        public BangThongKeNhanVien()
        {
            InitializeComponent();
        }

        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();
        private void HienThiDuLieu()
        {
            var query = from nv in db.NhanViens

                        select new
                        {
                            nv.MaNv,
                            nv.TenNv,
                            GioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ",
                            nv.DiaChi,
                            nv.SoDt,
                            nv.Email
                        };
            dgvNhanVien.ItemsSource = query.ToList();
        }


        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            this.Close();
            quanLyNhanVien.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
    }
}
