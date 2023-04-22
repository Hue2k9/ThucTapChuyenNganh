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
using System.Linq;
using bai_test2.Models;
namespace bai_test2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        TRUONGHOCContext th = new TRUONGHOCContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from hs in th.Hocsinhs
                        //join lh in th.Lophocs
                        //on hs.Mahs equals lh.Malop
                        //where lh.Malop = 'L01'
                        select new
                        {
                            hs.Mahs,
                            hs.Ten,
                            hs.Nam,
                            hs.Ngaysinh,
                            hs.Diemtb
                        };
            data.ItemsSource = query.ToList();
        }
    }
}
