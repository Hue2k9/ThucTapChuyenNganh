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
using projectmain.Models;
namespace projectmain
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
            /*var querytk = from tk in ttcn.TaiKhoans
                              where tk.TenDn == username.Text
                              select new { tk.TenDn };
            */
            var them = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(username.Text));
            var them2 = ttcn.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(password.Password));
            String pass = (String)password.Password;
           // MessageBox.Show(pass, "Thong bao");
            //MessageBox.Show(querymk.,"Thong bao");
            if (them != null)
            {
                var querymk = from tk in ttcn.TaiKhoans
                              where tk.TenDn == username.Text
                              select new { tk.MatKhau };
               // string mk = querymk.to;
                MessageBox.Show("ten dang nhap hop le", "Thong bao");
                if (them2!=null)
                {
                    MessageBox.Show("pass is ok", "Thông Báo");
                }
                else
                    MessageBox.Show("ko ok", "Thông Báo");
            }
            else
                MessageBox.Show("", "Thông Báo");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
          //Window.
        }
    }
}
