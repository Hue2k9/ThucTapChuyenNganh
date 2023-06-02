using System;
using System.Collections.Generic;

#nullable disable

namespace Project_BookStore.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string DiaChi { get; set; }
        public string SoDt { get; set; }
        public string Email { get; set; }
        public bool? GioiTinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
