using BTL_BookStore.Models;
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

namespace BTL_BookStore
{
    /// <summary>
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : Window
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();

        private void HienThiDuLieu()
        {
            var query = from hd in db.HoaDons
                        select hd;
            dgvHoaDon.ItemsSource = query.ToList();
        }

        private void HienThiCBSanPham()
        {
            var query = from sp in db.SanPhams select sp;
            cbSanPham.ItemsSource = query.ToList();
            cbSanPham.DisplayMemberPath = "TenSp";
            cbSanPham.SelectedValuePath = "MaSp";
            cbSanPham.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
            HienThiCBSanPham();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
