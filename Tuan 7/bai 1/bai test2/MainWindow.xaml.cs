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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Text.RegularExpressions;
using bai_test2.Models;
namespace bai_test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        TRUONGHOCContext th = new TRUONGHOCContext();
        private void HienThi()
        {
            var query = from hs in th.Hocsinhs
                        select new
                        {
                            hs.Mahs,
                            hs.Ten,
                            hs.Nam,
                            hs.Ngaysinh,
                            hs.Diachi,
                            hs.Diemtb
                        };
            data.ItemsSource = query.ToList();
        }
        private void HTcbo()
        {
            var cb = from lop in th.Lophocs
                     select lop;
            cbo.ItemsSource = cb.ToList();
            cbo.DisplayMemberPath = "Tenlop";
            cbo.SelectedValuePath = "Malop";
            cbo.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
            HTcbo();
        }
        private bool KT()
        {
            if (ma.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã học sinh", "Thông Báo");
                ma.Focus();
                return false;
            }
            if (ten.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên học sinh", "Thông Báo");
                ten.Focus();
                return false;
            }
            if (dc.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập địa chỉ", "Thông Báo");
                dc.Focus();
                return false;
            }
            try
            {
                double diem = double.Parse(dtb.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập sai điểm trung bình", "Thông Báo");
                dtb.Focus();
            }
            return true;
        }
        //
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KT())
                {
                    var them = th.Hocsinhs.SingleOrDefault(hs => hs.Mahs.Equals(ma.Text));
                    if (them == null)
                    {
                        Hocsinh hs1 = new Hocsinh();
                        hs1.Mahs = ma.Text;
                        hs1.Ten = ten.Text;
                        string gt = "";
                        if (radnam.IsChecked == true)
                            gt = "true";
                        else
                            gt = "false";
                        hs1.Nam = gt;
                        hs1.Ngaysinh = (DateTime)ns.SelectedDate;
                        hs1.Diachi = dc.Text;
                        hs1.Diemtb = double.Parse(dtb.Text);
                        th.Hocsinhs.Add(hs1);
                        th.SaveChanges();
                        MessageBox.Show("Đã thêm thành công", "Thông báo");
                        HienThi();
                    }
                    else
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KT())
                {
                    var sua = th.Hocsinhs.SingleOrDefault(hs => hs.Mahs.Equals(ma.Text));
                    if (sua != null)
                    {
                        sua.Ten = ten.Text;
                        string gt = "";
                        if (radnam.IsChecked == true)
                            gt = "true";
                        else
                            gt = "false";
                        sua.Nam = gt;
                        sua.Ngaysinh = ns.SelectedDate;
                        sua.Diachi = dc.Text;
                        sua.Diemtb = double.Parse(dtb.Text);
                        th.SaveChanges();
                        HienThi();
                        MessageBox.Show("Sửa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học sinh", "Thông báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }

        }
    }
}