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

namespace Bai_9_3
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

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            string hoten, gt, tthn, sothich = "";
            hoten = ten.Text;
            if (raNam.IsChecked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (rachuakh.IsChecked == true)
                tthn = "Chưa kết hôn";
            else
                tthn = "Đã kết hôn";
            if (chk1.IsChecked == true)
                sothich += "Bóng đá";
            if (chk2.IsChecked == true)
                sothich += ", Bóng rổ";
            if (chk3.IsChecked == true)
                sothich += ", Bóng chuyền";
            if (chk4.IsChecked == true)
                sothich += ", Bóng bàn";
            if (sothich.Substring(0, 1) == ",")
                sothich = sothich.Substring(2, sothich.Length - 2);// cắt bỏ 2 ký tự đầu là , và space
            txt.Items.Clear();
            txt.Items.Add("Họ tên: " + hoten);
            txt.Items.Add("Giới tính: " + gt);
            txt.Items.Add("Tình trạng hôn nhân: " + tthn);
            txt.Items.Add("Sở thích: " + sothich);
        } 
    }
}
