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

namespace Bài_9_5
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

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            string luachon = "";
            if (chk1.IsChecked == true)
                luachon += "Nước cam";
            if (chk2.IsChecked == true)
                luachon += ", Nước Kiwi";
            if (chk3.IsChecked == true)
                luachon += ", Nước Táo";
            if (chk4.IsChecked == true)
                luachon += ", Nước Coca";
            if (chk5.IsChecked == true)
                luachon += ", Nước Pepsi";
            if (luachon == "")
                MessageBox.Show("Bạn chưa order, vui lòng order lại", "Danh sách gọi đồ uống",MessageBoxButton.OK,MessageBoxImage.Information);
            else
            {
                if (luachon.Substring(0, 1) == ",")
                    luachon = luachon.Substring(2, luachon.Length - 2);
                MessageBox.Show("Lựa chọn của bạn là: " + luachon, "Danh sách gọi đồ uống,", MessageBoxButton.OK, MessageBoxImage.Information);
            }    
        }
    }
}
