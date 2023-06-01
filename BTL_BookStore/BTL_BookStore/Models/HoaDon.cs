using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_BookStore.Models
{
    public partial class HoaDon
    {
        public string MaHd { get; set; }
        public string ThoiGianMua { get; set; }
        public decimal? ThanhTien { get; set; }
        public string TrangThaiDon { get; set; }
        public string PtgiaoHang { get; set; }
        public string PtvanChuyen { get; set; }
        public string MaSp { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
