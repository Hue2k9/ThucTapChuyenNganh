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
using Project_BookStore.Models;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Project_BookStore
{
    /// <summary>
    /// Interaction logic for QuanLyHoaDon.xaml
    /// </summary>
    public partial class QuanLyHoaDon : Window
    {
        public QuanLyHoaDon()
        {
            HoaDon hd = new HoaDon();
            hd.MaHd = "1";

            InitializeComponent();
        }
       
    }
}
