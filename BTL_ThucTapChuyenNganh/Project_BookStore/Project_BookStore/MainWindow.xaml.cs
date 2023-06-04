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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_BookStore
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
        ThucTapChuyenNganhHTTTContext ttcn = new ThucTapChuyenNganhHTTTContext();
        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            var them = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(username.Text));
            var them2 = ttcn.TaiKhoans.SingleOrDefault(tk => tk.MatKhau.Equals(password.Password) && tk.TenDn.Equals(username.Text));
            if (them != null)
            {
                if (them2 != null)
                {
                    DanhMucQuanLy dmql = new DanhMucQuanLy();
                    dmql.Show();
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Tài khoản hoặc mật Khẩu không chính xác. Xin vui lòng thử lại sau.", "Thông Báo");
                }
            }
            else
            { 
                MessageBox.Show("Tên đăng nhập không hợp lệ", "Thông Báo");
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //Window.
        }
    }
}
