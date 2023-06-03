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
using QlySP.Models;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace QlySP
{
    /// <summary>
    /// Interaction logic for QlySanPham.xaml
    /// </summary>
    public partial class QlySanPham : Window
    {
        public QlySanPham()
        {
            InitializeComponent();
        }
        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();
        private void HienThiSP()
        {
            var query = from sp in db.SanPhams
                        
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.SoLuongTon,
                            sp.GiaBan,
                            sp.GioiThieu,
                            sp.BaoQuan
                        };
            tblSP.ItemsSource = query.ToList();
        }

        private bool CheckDL()
        {
            String tb = "";
            if (txtMa.Text == "" || txtTen.Text == "" || txtSoluong.Text == "" || txtGia.Text == "")
            {
                tb += "\n Bạn cần nhập đầy đủ dữ liệu!";
            }
            if (!Regex.IsMatch(txtGia.Text, @"\d+"))
            {
                tb += "\n Đơn giá nhập vào phải là số!";
            }
            else
            {
                int dg = int.Parse(txtGia.Text);
                if (dg < 0)
                {
                    tb += "\n Đơn giá nhập vào phải là số dương!";
                }
            } if (!Regex.IsMatch(txtSoluong.Text, @"\d+"))
            {
                tb += "\n Số lượng nhập vào phải là số!";
            }
            else
            {
                int sl = int.Parse(txtSoluong.Text);
                if (sl < 0)
                {
                    tb += "\n Số lượng nhập vào phải là số dương!";
                }
            }
            if (tb != "")
            {
                MessageBox.Show(tb, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            
            //kiem tra xem khong cho nhap trung ma san pham
            var query = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
            if(query != null)
            {
                MessageBox.Show("Max sản phẩm này đã tồn tại!", "Thong bao");
                HienThiSP();
            }
            else
            {
                try
                {
                    if (CheckDL())
                    {
                        SanPham spMoi = new SanPham();
                        spMoi.MaSp = txtMa.Text;
                        spMoi.TenSp = txtTen.Text;
                        spMoi.SoLuongTon = int.Parse(txtSoluong.Text);
                        spMoi.GioiThieu = txtGioithieu.Text;
                        spMoi.BaoQuan = txtBaoquan.Text;
                        spMoi.GiaBan = int.Parse(txtGia.Text);
                        db.SanPhams.Add(spMoi);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thành công!", "Thong bao");
                        HienThiSP();
                    }
                }catch(Exception e1)
                {
                    MessageBox.Show("Có lỗi khi thêm " + e1.Message, "Thong bao");
                }
                
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var spSua = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
                if (spSua != null)
                {
                    if (CheckDL())
                    {
                        spSua.TenSp = txtTen.Text;
                        spSua.MaSp = txtMa.Text;
                        spSua.SoLuongTon = int.Parse(txtTen.Text);
                        spSua.GioiThieu = txtGioithieu.Text;
                        spSua.BaoQuan = txtBaoquan.Text;
                        spSua.GiaBan = int.Parse(txtGia.Text);
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thong bao");
                        HienThiSP();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần sửa!");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Có lỗi khi sửa " + e1.Message, "Thong bao");
            }
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var spXoa = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
            if(spXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thong bao", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(spXoa);
                    db.SaveChanges();
                    HienThiSP();
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm này để xóa!", "Thong bao");
            }
        }

        private void tblSP_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(tblSP.SelectedItem != null)
            {
                try
                {
                    Type t = tblSP.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMa.Text = p[0].GetValue(tblSP.SelectedValue).ToString();
                    txtTen.Text = p[1].GetValue(tblSP.SelectedValue).ToString();
                    txtSoluong.Text = p[2].GetValue(tblSP.SelectedValue).ToString();
                    txtGioithieu.Text = p[3].GetValue(tblSP.SelectedValue).ToString();
                    txtBaoquan.Text = p[4].GetValue(tblSP.SelectedValue).ToString();
                    txtGia.Text = p[5].GetValue(tblSP.SelectedValue).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng " + ex.Message, "Thông báo");
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSoluong.Text = "";
            txtBaoquan.Text = "";
            txtGioithieu.Text = "";
            txtGia.Text = "";
        }

        private void txtTim_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
