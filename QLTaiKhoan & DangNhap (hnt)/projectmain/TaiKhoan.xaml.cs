using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using projectmain.Models;
namespace projectmain
{
    /// <summary>
    /// Interaction logic for TaiKhoan.xaml
    /// </summary>
    public partial class TaiKhoan : Window
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }

        ThucTapChuyenNganhHTTTContext ttcn = new ThucTapChuyenNganhHTTTContext();
        private void HienThi()
        {
            var query = from tk in ttcn.TaiKhoans
                        select new
                        {
                            tk.TenDn,
                            tk.MatKhau,
                            tk.PhanQuyen,
                            tk.MaNv
                        };
            data.ItemsSource = query.ToList();
        }
        //Kiem tra da nhap du lieu hay chua
        private bool KT()
        {
            if (username.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập Tên Đăng Nhập", "Thông Báo");
                username.Focus();
                return false;
            }
            if (password.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mật khẩu", "Thông Báo");
                password.Focus();
                return false;
            }
            if (phanquyen.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập Phân Quyền", "Thông Báo");
                phanquyen.Focus();
                return false;
            }
            if(manv.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập Mã NV", "Thông Báo");
                manv.Focus();
                return false;
            }
            return true;
        }
        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KT())
                {
                    var them = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(username.Text));
                    if (them == null)
                    {
                        TaiKhoan tk1 = new TaiKhoan();
                        tk1.TenDn = username.Text;
                        tk1.MatKhau = password.Text;
                        tk1.phanquyen = phanquyen.Text;
                        tk1.manv = manv.Text;
                        ttcn.TaiKhoans.Add(tk1);
                        ttcn.SaveChanges();
                        MessageBox.Show("Đã thêm thành công", "Thông báo");
                        HienThi();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }

        private void btn22_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KT())
                {
                    var sua = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(username.Text));
                    if (sua != null)
                    {
                        sua.TenDn = username.Text;
                        sua.MatKhau = password.Text;
                        sua.PhanQuyen = phanquyen.Text;
                        sua.MaNv = manv.Text;
                        ttcn.SaveChanges();
                        HienThi();
                        MessageBox.Show("Sửa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Tài Khoản", "Thông báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }

        }

        private void btn33_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KT())
                {
                    var xoa = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(username.Text));
                    if (xoa != null)
                    {
                        MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Thông báo", MessageBoxButton.YesNo);
                        if (rs == MessageBoxResult.Yes)
                        {
                            ttcn.TaiKhoans.Remove(xoa);
                            ttcn.SaveChanges();
                            HienThi();
                            MessageBox.Show("Bạn đã xóa thành công", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Tài Khoản", "Thông báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
        }
    }
}
