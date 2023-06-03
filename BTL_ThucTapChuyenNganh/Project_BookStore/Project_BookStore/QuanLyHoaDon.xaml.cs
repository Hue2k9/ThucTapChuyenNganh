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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Globalization;
using MahApps.Metro.Controls.Dialogs;
using Ookii.Dialogs.Wpf;
using System.IO;
using OfficeOpenXml;

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

        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();

        private void HienThiDuLieu()
        {
            var query = from hd in db.HoaDons
                        join sp in db.SanPhams on hd.MaSp equals sp.MaSp
                        let ThanhTien = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", hd.SoLuong * sp.GiaBan)
                        let GiaBan = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sp.GiaBan)
                        select new
                        {
                            hd.MaHd,
                            hd.HoTen,
                            hd.SoDienThoai,
                            hd.DiaChi,
                            hd.TrangThaiDon,
                            hd.MaSp,
                            TenSanPham = sp.TenSp,
                            hd.SoLuong,
                            GiaBan,
                            ThanhTien,
                            hd.MaNv,
                            hd.ThoiGianMua
                        };
            dgvHoaDon.ItemsSource = query.ToList();
        }

        private void HienThiCBSanPham()
        {
            var query = from sp in db.SanPhams select sp;
            cboSanPham.ItemsSource = query.ToList();
            cboSanPham.DisplayMemberPath = "TenSp";
            cboSanPham.SelectedValuePath = "MaSp";
            cboSanPham.SelectedIndex = 0;
        }

        private void HienThiCBNhanVien()
        {
            var query = from nv in db.NhanViens select nv;
            cboNhanVien.ItemsSource = query.ToList();
            cboNhanVien.DisplayMemberPath = "TenNv";
            cboNhanVien.SelectedValuePath = "MaNv";
            cboNhanVien.SelectedIndex = 0;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
            HienThiCBSanPham();
            HienThiCBNhanVien();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaHd = GetAutoOrdersOrderCodeFromSqlServer();
            hoaDon.DiaChi = txtDiaChi.Text;
            hoaDon.SoLuong = int.Parse(txtSoLuong.Text);
            hoaDon.SoDienThoai = txtSoDienThoai.Text;
            hoaDon.ThoiGianMua = DateTime.Now;
            hoaDon.HoTen = txtHoTen.Text;
            hoaDon.TrangThaiDon = txtTrangThaiDon.Text;
            SanPham sanPham = (SanPham) cboSanPham.SelectedItem;
            hoaDon.MaSp = sanPham.MaSp;

            NhanVien nhanVien = (NhanVien)cboNhanVien.SelectedItem;
            hoaDon.MaNv = nhanVien.MaNv;
            
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();
            MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo");
            HienThiDuLieu();

        }
        private string GetAutoOrdersOrderCodeFromSqlServer()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-56A5JQ8;Initial Catalog=ThucTapChuyenNganhHTTT;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.Auto_Orders_OrderCode()", connection))
                {
                    // Thực hiện câu truy vấn để lấy giá trị MaHd từ SQL Server
                    string maHd = (string)command.ExecuteScalar();
                    return maHd;
                }
            }
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            Type t = dgvHoaDon.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            var maHD = p[0].GetValue(dgvHoaDon.SelectedValue).ToString();
            var hdSua = db.HoaDons.SingleOrDefault(hd => hd.MaHd.Equals(maHD));
           if(hdSua != null)
            {
                hdSua.HoTen = txtHoTen.Text;
                hdSua.SoDienThoai = txtSoDienThoai.Text;
                hdSua.DiaChi = txtDiaChi.Text;
                hdSua.SoLuong = int.Parse(txtSoLuong.Text);
                hdSua.TrangThaiDon = txtTrangThaiDon.Text;
                SanPham sanPham = (SanPham)cboSanPham.SelectedItem;
                hdSua.MaSp = sanPham.MaSp;
                NhanVien nhanVien = (NhanVien)cboNhanVien.SelectedItem;
                hdSua.MaNv = nhanVien.MaNv;
                db.SaveChanges();
                MessageBox.Show("Sửa hóa đơn thành công!", "Thông báo");
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa!", "Thông báo");
            }
        }

        private void dgvHoaDon_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvHoaDon.SelectedItem != null)
            {
                try
                {
                    Type t = dgvHoaDon.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtHoTen.Text = p[1].GetValue(dgvHoaDon.SelectedValue).ToString();
                    txtSoDienThoai.Text = p[2].GetValue(dgvHoaDon.SelectedValue).ToString();
                    txtDiaChi.Text = p[3].GetValue(dgvHoaDon.SelectedValue).ToString();
                    //San pham
                    cboSanPham.SelectedValue = p[5].GetValue(dgvHoaDon.SelectedValue).ToString();
                    txtSoLuong.Text = p[7].GetValue(dgvHoaDon.SelectedValue).ToString();
                    txtTrangThaiDon.Text = p[4].GetValue(dgvHoaDon.SelectedValue).ToString();
                    //Nhan vien
                    cboNhanVien.SelectedValue = p[10].GetValue(dgvHoaDon.SelectedValue).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng" + ex.Message, "Thông báo");
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Type t = dgvHoaDon.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            var maHD = p[0].GetValue(dgvHoaDon.SelectedValue).ToString();
            var hdXoa = db.HoaDons.SingleOrDefault(hd => hd.MaHd.Equals(maHD));
            if (hdXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.HoaDons.Remove(hdXoa);
                    db.SaveChanges();
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa!", "Thông báo");
            }
        }

        private void btnXuatFile_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            folderBrowserDialog.Description = "Chọn thư mục để lưu trữ file Excel";
            if (folderBrowserDialog.ShowDialog() == true)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string templateFilePath = @"D:\template.xlsx";
                string fileName = "hoadon.xlsx"; 
                string filePath = System.IO.Path.Combine(folderPath, fileName);
                System.IO.File.Copy(templateFilePath, filePath, true);
                // Ghi dữ liệu vào tệp Excel
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Đặt LicenseContext thành LicenseContext.NonCommercial
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    // Lấy Sheet đầu tiên trong tệp Excel
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    // Ghi dữ liệu vào các ô trong tệp Excel
                    worksheet.Cells["A1"].Value = "Dữ liệu 1";
                    worksheet.Cells["B1"].Value = "Dữ liệu 2";
                    // ...

                    // Lưu và đóng tệp Excel
                    excelPackage.Save();
                }

                MessageBox.Show("Dữ liệu đã được ghi vào tệp Excel!", "Thông báo");
            }
        }

        private void btn_thoat_Click(object sender, RoutedEventArgs e)
        {
            DanhMucQuanLy danhMucQuanLy = new DanhMucQuanLy();
            this.Close();
            danhMucQuanLy.Show();
        }
    }
}
