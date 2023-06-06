using ControlzEx.Standard;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using Ookii.Dialogs.Wpf;
using Project_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
using Ookii.Dialogs.Wpf;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Project_BookStore
{
    /// <summary>
    /// Interaction logic for QuanLySanPham.xaml
    /// </summary>
    public partial class QuanLySanPham : Window
    {
        public QuanLySanPham()
        {
            InitializeComponent();
        }
        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();
        private void HienThiSP()
        {
            var query = from sp in db.SanPhams
                        let GiaBan = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sp.GiaBan)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.SoLuongTon,
                            GiaBan,
                            sp.GioiThieu,
                            sp.BaoQuan
                        };
            tblSP.ItemsSource = query.ToList();
        }

        private bool CheckDL()
        {
            
            String tb = "";
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
            }
            if (!Regex.IsMatch(txtSoluong.Text, @"\d+"))
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
                try
                {
                    if (CheckDL())
                    {
                        SanPham spMoi = new SanPham();
                        spMoi.MaSp = GetAutoProductCodeFromSqlServer();
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
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Có lỗi khi thêm " + e1.Message, "Thong bao");
                }
 
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckDL())
                {
                    if (tblSP.SelectedItem != null)
                    {
                        Type t = tblSP.SelectedItem.GetType();
                        PropertyInfo[] p = t.GetProperties();
                        var maSP = p[0].GetValue(tblSP.SelectedValue).ToString();
                        var spSua = db.SanPhams.SingleOrDefault(sp => sp.MaSp.Equals(maSP));
                        if (spSua != null)
                        {
                            if (CheckDL())
                            {
                                spSua.TenSp = txtTen.Text;
                                spSua.SoLuongTon = int.Parse(txtSoluong.Text);
                                spSua.GioiThieu = txtGioithieu.Text;
                                spSua.BaoQuan = txtBaoquan.Text;
                                spSua.GiaBan = decimal.Parse(txtGia.Text);
                                db.SaveChanges();
                                MessageBox.Show("Sửa thành công!", "Thong bao");
                                HienThiSP();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần chọn sản phẩm cần sửa!");
                    }
                }
              
            }
            catch (Exception e1)
            {
                MessageBox.Show("Có lỗi khi sửa " + e1.Message, "Thong bao");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tblSP.SelectedItem != null)
                {
                    Type t = tblSP.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    var maSP = p[0].GetValue(tblSP.SelectedValue).ToString();
                    var spXoa = db.SanPhams.SingleOrDefault(sp => sp.MaSp.Equals(maSP));
                    if (spXoa != null)
                    {
                        MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thong bao", MessageBoxButton.YesNo);
                        if (rs == MessageBoxResult.Yes)
                        {
                            db.SanPhams.Remove(spXoa);
                            db.SaveChanges();
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo");
                            HienThiSP();
                        }
                    }
                }
                else
                    {
                        MessageBox.Show("Bạn cần chọn sản phẩm cần xóa!", "Thong bao");
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa: ", ex.Message);
            }                      
        }

        private void tblSP_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (tblSP.SelectedItem != null)
            {
                try
                {
                    Type t = tblSP.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtTen.Text = p[1].GetValue(tblSP.SelectedValue).ToString();
                    txtSoluong.Text = p[2].GetValue(tblSP.SelectedValue).ToString();
                    txtGioithieu.Text = p[4].GetValue(tblSP.SelectedValue).ToString();
                    txtBaoquan.Text = p[5].GetValue(tblSP.SelectedValue).ToString();
                    string giaBanString = p[3].GetValue(tblSP.SelectedValue).ToString();
                    decimal giaBanDecimal;
                    if (decimal.TryParse(giaBanString, out giaBanDecimal))
                    {
                        int phanNguyen = (int)(giaBanDecimal * 1000);
                        txtGia.Text = phanNguyen.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng " + ex.Message, "Thông báo");
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtTen.Text = "";
            txtSoluong.Text = "";
            txtBaoquan.Text = "";
            txtGioithieu.Text = "";
            txtGia.Text = "";
        }

        private void txtTim_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiSP();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            DanhMucQuanLy danhMucQuanLy = new DanhMucQuanLy();
            this.Close();
            danhMucQuanLy.Show();
        }

        private string GetAutoProductCodeFromSqlServer()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-56A5JQ8;Initial Catalog=ThucTapChuyenNganhHTTT;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.Auto_Products_ProductCode()", connection))
                {
                    // Thực hiện câu truy vấn để lấy giá trị MaHd từ SQL Server
                    string maHd = (string)command.ExecuteScalar();
                    return maHd;
                }
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //Tìm kiếm theo tên sản phẩm
            var check = db.SanPhams.FirstOrDefault(t => t.TenSp.Contains(txtTim.Text));
            if (check != null)
            {
                var query = db.SanPhams.Where(t => t.TenSp.Contains(txtTim.Text)).Select(sp => new
                {
                    sp.MaSp,
                    sp.TenSp,
                    sp.SoLuongTon,
                    GiaBan = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sp.GiaBan),
                    sp.GioiThieu,
                    sp.BaoQuan
                });
                tblSP.ItemsSource = query.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo");
            }
        }

        private void btnImportExcel_Click(object sender, RoutedEventArgs e)
        {
            VistaOpenFileDialog openFileDialog = new VistaOpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    List<SanPham> sanPhams = new List<SanPham>();

                    for (int row = 4; row <= rowCount; row++)
                    {
                        SanPham sanPham = new SanPham();
                        sanPham.MaSp = GetAutoProductCodeFromSqlServer();
                        sanPham.TenSp = worksheet.Cells[row, 1].Value?.ToString();
                        decimal giaBan;
                        if (decimal.TryParse(worksheet.Cells[row, 2].Value?.ToString(), out giaBan))
                        {
                            sanPham.GiaBan = giaBan;
                        }
                        int soLuongTon;
                        if (int.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out soLuongTon))
                        {
                            sanPham.SoLuongTon = soLuongTon;
                        }
                        sanPham.GioiThieu = worksheet.Cells[row, 4].Value?.ToString();
                        sanPham.BaoQuan = worksheet.Cells[row, 5].Value?.ToString();
                    
                        db.SanPhams.Add(sanPham);
                        db.SaveChanges();
                    }
                    HienThiSP();
                    MessageBox.Show("Dữ liệu đã được thêm vào thành công!", "Thông báo");
                }

            }
        }
    }
}
