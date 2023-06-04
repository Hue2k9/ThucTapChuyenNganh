using Microsoft.Data.SqlClient;
using Project_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

namespace Project_BookStore
{
    /// <summary>
    /// Interaction logic for QuanLyNhanVien.xaml
    /// </summary>
    public partial class QuanLyNhanVien : Window
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        ThucTapChuyenNganhHTTTContext db = new ThucTapChuyenNganhHTTTContext();

        private void HienThiDuLieu()
        {
            var query = from nv in db.NhanViens

                        select new
                        {
                            nv.MaNv,
                            nv.TenNv,
                            GioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ",
                            nv.DiaChi,
                            nv.SoDt,
                            nv.Email
                        };
            dgvNhanVien.ItemsSource = query.ToList();
        }

        private void btnThem(object sender, RoutedEventArgs e)
        {  
                NhanVien nvMoi = new NhanVien();
                nvMoi.MaNv = GetAutoStaffCodeFromSqlServer();
                nvMoi.TenNv = txtTen.Text;
                nvMoi.DiaChi = txtDiaChi.Text;
                nvMoi.SoDt = txtDienThoai.Text;
                nvMoi.Email = txtEmail.Text;
            if (radNam.IsChecked == true)
            {
                nvMoi.GioiTinh = true; // Nam
            }
            else if (radNu.IsChecked == true)
            {
                nvMoi.GioiTinh = false; // Nữ
            }
            db.NhanViens.Add(nvMoi);
            db.SaveChanges();
            MessageBox.Show("Thêm mới thành công", "Thong bao");
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Type t = dgvNhanVien.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            var maNV = p[0].GetValue(dgvNhanVien.SelectedValue).ToString();
            var nvXoa = db.NhanViens.SingleOrDefault(nv => nv.MaNv.Equals(maNV));
            if (nvXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.NhanViens.Remove(nvXoa);
                    db.SaveChanges();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo");
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa!", "Thông báo");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            Type t = dgvNhanVien.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            var maNV = p[0].GetValue(dgvNhanVien.SelectedValue).ToString();
            var nvSua = db.NhanViens.SingleOrDefault(nv => nv.MaNv.Equals(maNV));
            if (nvSua != null)
            {
                nvSua.TenNv = txtTen.Text;
                nvSua.DiaChi = txtDiaChi.Text;
                nvSua.SoDt = txtDienThoai.Text;
                nvSua.Email = txtEmail.Text;
                if (radNam.IsChecked == true)
                {
                    nvSua.GioiTinh = true; 
                }
                else if (radNu.IsChecked == true)
                {
                    nvSua.GioiTinh = false; 
                }
                db.SaveChanges();
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo");
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần sửa!", "Thông báo");
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var check = db.NhanViens.FirstOrDefault(t => t.TenNv.Contains(txtTen.Text));
            if (check != null)
            {
                var query = db.NhanViens.Where(t => t.TenNv.Contains(txtTen.Text)).Select(nv => new
                {
                    nv.MaNv,
                    nv.TenNv,
                    GioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ",
                    nv.DiaChi,
                    nv.SoDt,
                    nv.Email
                });
                dgvNhanVien.ItemsSource = query.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo");
            }
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            BangThongKeNhanVien bangThongKeNhanVien = new BangThongKeNhanVien();
            this.Close();
            bangThongKeNhanVien.Show();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            DanhMucQuanLy danhMucQuanLy = new DanhMucQuanLy();
            this.Close();
            danhMucQuanLy.Show();
        }

        private void dgvNhanVien_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            if (dgvNhanVien.SelectedItem != null)
            {
                try
                {
                    Type t = dgvNhanVien.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtTen.Text = p[1].GetValue(dgvNhanVien.SelectedValue).ToString();
                    txtDiaChi.Text = p[3].GetValue(dgvNhanVien.SelectedValue).ToString();        
                    txtDienThoai.Text = p[4].GetValue(dgvNhanVien.SelectedValue).ToString();
                    txtEmail.Text = p[5].GetValue(dgvNhanVien.SelectedValue).ToString();
                    bool gioiTinh = true;
                    string gender = p[2].GetValue(dgvNhanVien.SelectedValue).ToString();
                    if (gender.Equals("Nữ")) gioiTinh = false;

                    if (gioiTinh)
                    {
                        radNam.IsChecked = true;
                        radNu.IsChecked = false;
                    }
                    else
                    {
                        radNam.IsChecked = false;
                        radNu.IsChecked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng" + ex.Message, "Thông báo");
                }
            }
            
        }
        private string GetAutoStaffCodeFromSqlServer()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-56A5JQ8;Initial Catalog=ThucTapChuyenNganhHTTT;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.Auto_Staffs_StaffCode()", connection))
                {
                    // Thực hiện câu truy vấn để lấy giá trị MaHd từ SQL Server
                    string maHd = (string)command.ExecuteScalar();
                    return maHd;
                }
            }
        }
    }
}
