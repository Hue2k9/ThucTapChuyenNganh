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
using BTL_BookStore_TTCN.Models;

namespace BTL_BookStore_TTCN
{
    /// <summary>
    /// Interaction logic for BangHoaDon.xaml
    /// </summary>
    public partial class BangHoaDon : Window
    {
        public BangHoaDon()
        {
            InitializeComponent();
            HoaDon hd = new HoaDon();
            SanPham sp = new SanPham();
            
        }
    }
}
