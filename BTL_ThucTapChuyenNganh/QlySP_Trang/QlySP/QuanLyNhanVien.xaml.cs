using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using QlySP.Models;
using System.Text.RegularExpressions; // Dung khi check DL
using System.Reflection; // DUng khi hcon dong
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace QlySP
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
                            GioiTinh = (bool)nv.GioiTinh ? "Nu" : "Nam",
                            nv.DiaChi,
                            nv.SoDt,
                            nv.Email
                        };
                       
                           
                       
            dgvNhanVien.ItemsSource = query.ToList();
        }
        private void HienthiCB()
        {
            var query = from lnv in db.NhanViens select lnv;
            cboDiaChi.ItemsSource = query.ToList();
            cboDiaChi.DisplayMemberPath = "DiaChi";
            cboDiaChi.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
            HienthiCB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Kiem tra khong cho nhap trung ma nhan vien
            var query = db.NhanViens.SingleOrDefault(t => t.MaNv.Equals(txtMa.Text));
            if(query != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo");
                HienThiDuLieu();
            }
            else
            {
                NhanVien nvMoi = new NhanVien();
                nvMoi.MaNv = txtMa.Text;
                nvMoi.TenNv = txtTen.Text;
               // nvMoi.GioiTinh = ;
                NhanVien itemSelected = (NhanVien)cboDiaChi.SelectedItem;
                nvMoi.DiaChi = itemSelected.DiaChi;
                nvMoi.SoDt = txtDienThoai.Text;
                nvMoi.Email = txtEmail.Text;
                db.NhanViens.Add(nvMoi);
                db.SaveChanges();//Lưu thay đổi vào CSDL
                MessageBox.Show("Thêm mới thành công", "Thong bao");
            }
        }

        

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            //Xác định 1 nhân viên cần xóa theo Mã
            var nvXoa = db.NhanViens.SingleOrDefault(t => t.MaNv.Equals(txtMa.Text));
            if(nvXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thong bao", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.NhanViens.Remove(nvXoa);
                    db.SaveChanges();
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không có nhân viên để xóa!", "Thông báo");
            }
        }

        private void dgvNhanVien_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgvNhanVien.SelectedItem != null)
            {
                try
                {
                    Type t = dgvNhanVien.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMa.Text = p[0].GetValue(dgvNhanVien.SelectedValue).ToString();
                    txtTen.Text = p[1].GetValue(dgvNhanVien.SelectedValue).ToString();

                    cboDiaChi.SelectedValue = p[3].GetValue(dgvNhanVien.SelectedValue).ToString();
                    txtDienThoai.Text = p[4].GetValue(dgvNhanVien.SelectedValue).ToString();
                    txtEmail.Text = p[5].GetValue(dgvNhanVien.SelectedValue).ToString();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng" + ex.Message, "Thông báo");
                }
            }
        }

        private bool CheckDL()
        {
            string tb = "";
            if(txtMa.Text=="" || txtTen=="" || r)
        }
        //Chọn dòng trong DataGrid

    }
}
