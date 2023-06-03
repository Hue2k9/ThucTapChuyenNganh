using System;
using System.Collections.Generic;

#nullable disable

namespace QlySP.Models
{
    public partial class HoaDon
    {
        public string MaHd { get; set; }
        public DateTime? ThoiGianMua { get; set; }
        public int? SoLuong { get; set; }
        public string TrangThaiDon { get; set; }
        public string DiaChi { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string MaSp { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
