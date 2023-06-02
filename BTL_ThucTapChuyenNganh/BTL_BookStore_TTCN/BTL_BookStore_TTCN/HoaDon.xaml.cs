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
using System.Text.RegularExpressions;
using System.Reflection;
using BTL_BookStore_TTCN.Models;

namespace BTL_BookStore_TTCN
{
   
    public partial class HoaDon : Window
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();

        private void HienThiDuLieu()
        {
            var query = from hd in db.HoaDons select hd;
            dgvHoaDon.ItemsSource = query.ToList();
        }

        private void HienThiCBSanPham()
        {
            var query = from sp in db.SanPhams select sp;
            cboSanPham.ItemsSource = query.ToList();
            cboSanPham.DisplayMemberPath = "TenSp";
            cboSanPham.SelectedValuePath = "MaSp";
            cboSanPham.SelectedIndex = 0;
        }

        private void HienThiCBNhanVien()
        {
            var query = from nv in db.NhanViens select nv;
            cboNhanVien.ItemsSource = query.ToList();
            cboNhanVien.DisplayMemberPath = "TenNv";
            cboNhanVien.SelectedValuePath = "MaNv";
            cboNhanVien.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
            HienThiCBSanPham();
            HienThiCBNhanVien();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
          
           
        }
    }
}
