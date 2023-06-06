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
using OfficeOpenXml.Style;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

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

        private bool CheckDL()
        {
            string tb = "";
            if (txtHoTen.Text == "" || txtDiaChi.Text=="" || txtSoDienThoai.Text=="" || txtSoLuong.Text=="" || txtTrangThaiDon.Text == "")
            {
                tb += "\nBạn phải nhập đầy đủ dữ liệu";
            }
            else if (int.Parse(txtSoLuong.Text) <= 0)
            {
                tb += "\nSố lượng nhập vào phải là số dương!";
            }
            else if (!Regex.IsMatch(txtSoDienThoai.Text, @"^(03|05|07|08|09)+([0-9]{8})$"))
            {
                tb += "\nSố điện thoại không hợp lệ!";
            }
            if (tb != "")
            {
                MessageBox.Show(tb, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
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
            try
            {

            if (CheckDL())
            {
                    
                     HoaDon hoaDon = new HoaDon();
                    hoaDon.MaHd = GetAutoOrdersOrderCodeFromSqlServer();
                    hoaDon.DiaChi = txtDiaChi.Text;
                    hoaDon.SoLuong = int.Parse(txtSoLuong.Text);
                    hoaDon.SoDienThoai = txtSoDienThoai.Text;
                    hoaDon.ThoiGianMua = DateTime.Now;
                    hoaDon.HoTen = txtHoTen.Text;
                    hoaDon.TrangThaiDon = txtTrangThaiDon.Text;
                    SanPham sanPham = (SanPham)cboSanPham.SelectedItem;
                    hoaDon.MaSp = sanPham.MaSp;

                    NhanVien nhanVien = (NhanVien)cboNhanVien.SelectedItem;
                    hoaDon.MaNv = nhanVien.MaNv;
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-56A5JQ8;Initial Catalog=ThucTapChuyenNganhHTTT;Integrated Security=True"))
                    {
                        connection.Open();
                        string sqlCheckStock = "SELECT SoLuongTon FROM SanPham WHERE MaSp = @MaSp";
                        SqlCommand checkStockCommand = new SqlCommand(sqlCheckStock, connection);
                        checkStockCommand.Parameters.AddWithValue("@MaSp", hoaDon.MaSp);
                        int soLuongTon = (int)checkStockCommand.ExecuteScalar();

                        if (hoaDon.SoLuong > soLuongTon)
                        {
                            MessageBox.Show("Số sản phẩm không đủ!", "Lỗi");
                            return;
                        }
                        string sql = @"
        INSERT INTO HoaDon (MaHd, DiaChi, SoLuong, SoDienThoai, ThoiGianMua, HoTen, TrangThaiDon, MaSp, MaNv)
        VALUES (@MaHd, @DiaChi, @SoLuong, @SoDienThoai, @ThoiGianMua, @HoTen, @TrangThaiDon, @MaSp, @MaNv);

        UPDATE SanPham
        SET SoLuongTon = SoLuongTon - @SoLuong
        WHERE MaSp = @MaSp;
    ";

                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@MaHd", hoaDon.MaHd);
                        command.Parameters.AddWithValue("@DiaChi", hoaDon.DiaChi);
                        command.Parameters.AddWithValue("@SoLuong", hoaDon.SoLuong);
                        command.Parameters.AddWithValue("@SoDienThoai", hoaDon.SoDienThoai);
                        command.Parameters.AddWithValue("@ThoiGianMua", hoaDon.ThoiGianMua);
                        command.Parameters.AddWithValue("@HoTen", hoaDon.HoTen);
                        command.Parameters.AddWithValue("@TrangThaiDon", hoaDon.TrangThaiDon);
                        command.Parameters.AddWithValue("@MaSp", hoaDon.MaSp);
                        command.Parameters.AddWithValue("@MaNv", hoaDon.MaNv);

                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo");
                            HienThiDuLieu();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Có lỗi khi thêm: " + ex.Message, "Lỗi");
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm: ", ex.Message);
            }
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
            try
            {
                if (CheckDL())
                {
                    if (dgvHoaDon.SelectedItem != null)
                    {
                        Type t = dgvHoaDon.SelectedItem.GetType();
                        PropertyInfo[] p = t.GetProperties();
                        var maHD = p[0].GetValue(dgvHoaDon.SelectedValue).ToString();
                        var hdSua = db.HoaDons.SingleOrDefault(hd => hd.MaHd.Equals(maHD));
                        if (hdSua != null)
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

                    }
                    else
                        {
                            MessageBox.Show("Bạn cần chọn sản phẩm cần sửa!", "Thông báo");
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa: " + ex.Message);
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
            try
            {
                if (dgvHoaDon.SelectedItem != null)
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
                            MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo");
                            HienThiDuLieu();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn hóa đơn cần xóa!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi");
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
                string fileName = "hoadon.xlsx" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                string filePath = System.IO.Path.Combine(folderPath, fileName);
                System.IO.File.Copy(templateFilePath, filePath, true);
                // Ghi dữ liệu vào tệp Excel
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                    int rowIndex = 5; 
                    foreach (var item in query)
                    {
                        
                        DuplicateRow(worksheet, rowIndex);
                        worksheet.Cells[rowIndex, 1].Value = item.MaHd;
                        worksheet.Cells[rowIndex, 2].Value = item.HoTen;
                        worksheet.Cells[rowIndex, 3].Value = item.SoDienThoai;
                        worksheet.Cells[rowIndex, 4].Value = item.DiaChi;
                        worksheet.Cells[rowIndex, 5].Value = item.MaSp;
                        worksheet.Cells[rowIndex, 6].Value = item.TenSanPham;
                        worksheet.Cells[rowIndex, 7].Value = item.SoLuong;
                        worksheet.Cells[rowIndex, 8].Value = item.GiaBan;
                        worksheet.Cells[rowIndex, 9].Formula = $"= {worksheet.Cells[rowIndex, 7].Address} * {worksheet.Cells[rowIndex, 8].Address}";
                        worksheet.Cells[rowIndex, 10].Value = item.TrangThaiDon;
                        worksheet.Cells[rowIndex, 11].Value = item.MaNv;
                        worksheet.Cells[rowIndex, 12].Value = item.ThoiGianMua?.ToString("dd/MM/yyyy HH:mm:ss");
                        rowIndex++;
                    }
                    worksheet.Cells[rowIndex, 8].Value = "Tổng tiền";
                    worksheet.Cells[3, 5].Value = "Ngày xuất: "+ DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    worksheet.Cells[rowIndex, 9].Formula = $"=SUM({worksheet.Cells[5, 9].Address}:{worksheet.Cells[rowIndex - 1, 9].Address})";
                    
                    excelPackage.Save();
                }

                MessageBox.Show("Dữ liệu đã được ghi vào tệp Excel!", "Thông báo");
            }
        }

        private void DuplicateRow(ExcelWorksheet worksheet, int sourceRowIndex)
        {
            int targetRowIndex = sourceRowIndex + 1; // Tạo chỉ số hàng đích bằng cách tăng chỉ số hàng nguồn lên 1
            var sourceRow = worksheet.Row(sourceRowIndex);
            var targetRow = worksheet.Row(targetRowIndex);

            // Sao chép style của hàng nguồn sang hàng đích
            targetRow.Style.Font = sourceRow.Style.Font;
            targetRow.Style.Fill = sourceRow.Style.Fill;
            targetRow.Style.Border.Bottom.Style = sourceRow.Style.Border.Bottom.Style;

            // Sao chép các cell trong hàng nguồn sang hàng đích
            for (int colIndex = 1; colIndex <= worksheet.Dimension.Columns; colIndex++)
            {
                var sourceCell = worksheet.Cells[sourceRowIndex, colIndex];
                var targetCell = worksheet.Cells[targetRowIndex, colIndex];

                // Sao chép giá trị của cell
                targetCell.Value = sourceCell.Value;
                targetCell.Style.Font = sourceCell.Style.Font;
                targetCell.Style.Fill.PatternType = sourceCell.Style.Fill.PatternType;

                if (sourceCell.Style.Border.Bottom.Color != null)
                {
                    if (sourceCell.Style.Border.Bottom.Style != null)
                    {
                        targetCell.Style.Border.Bottom.Style = sourceCell.Style.Border.Bottom.Style;

                        if (sourceCell.Style.Border.Bottom.Color != null)
                        {
                            targetCell.Style.Border.Bottom.Color.SetColor(System.Drawing.ColorTranslator.FromHtml(sourceCell.Style.Border.Bottom.Color.Rgb));
                        }
                    }

                }
              
                if (sourceCell.Style.Border.Top.Color != null)
                {
                    if (sourceCell.Style.Border.Top.Style != null)
                    {
                        targetCell.Style.Border.Top.Style = sourceCell.Style.Border.Top.Style;

                        if (sourceCell.Style.Border.Top.Color != null)
                        {
                            targetCell.Style.Border.Top.Color.SetColor(System.Drawing.ColorTranslator.FromHtml(sourceCell.Style.Border.Top.Color.Rgb));
                        }
                    }

                }
            
                if (sourceCell.Style.Border.Left.Color != null)
                {
                    if (sourceCell.Style.Border.Left.Style != null)
                    {
                        targetCell.Style.Border.Left.Style = sourceCell.Style.Border.Left.Style;

                        if (sourceCell.Style.Border.Left.Color != null)
                        {
                            targetCell.Style.Border.Left.Color.SetColor(System.Drawing.ColorTranslator.FromHtml(sourceCell.Style.Border.Left.Color.Rgb));
                        }
                    }

                }
              
                if (sourceCell.Style.Border.Right.Color != null)
                {
                    if (sourceCell.Style.Border.Right.Style != null)
                    {
                        targetCell.Style.Border.Right.Style = sourceCell.Style.Border.Right.Style;

                        if (sourceCell.Style.Border.Right.Color != null)
                        {
                            targetCell.Style.Border.Right.Color.SetColor(System.Drawing.ColorTranslator.FromHtml(sourceCell.Style.Border.Right.Color.Rgb));
                        }
                    }

                }
              
            }
        }

        private void btn_thoat_Click(object sender, RoutedEventArgs e)
        {
            DanhMucQuanLy danhMucQuanLy = new DanhMucQuanLy();
            this.Close();
            danhMucQuanLy.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            txtSoLuong.Text = "";
            txtTrangThaiDon.Text = "";
        }
    }
}
