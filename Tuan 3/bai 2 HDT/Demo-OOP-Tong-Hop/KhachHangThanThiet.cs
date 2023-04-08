using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_OOP_Tong_Hop
{
    class KhachHangThanThiet:KhachHang
    {
        public int MaTheThanhVien { get; set; }
        public KhachHangThanThiet() { }
        public KhachHangThanThiet(string hoTen, bool gioiTinh,
            int soLuongMua, int donGia, int maTheThanhVien)
            :base(hoTen,gioiTinh,soLuongMua,donGia)
        {
            this.MaTheThanhVien = maTheThanhVien;
        }
        public string XacDinhQuaTang()
        {
            if (this.TinhTongTien() <= 1000)
                return "Coupon 200";
            else
                return "Coupon 500";
        }
        public override string ToString()
        {
            return base.ToString() +
                "\t" + this.MaTheThanhVien + "\t" 
                + this.XacDinhQuaTang();
        }
    }
}
