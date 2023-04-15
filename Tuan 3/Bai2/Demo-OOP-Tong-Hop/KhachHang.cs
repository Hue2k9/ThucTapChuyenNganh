using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_OOP_Tong_Hop
{
    class KhachHang
    {
        #region Thuộc tính
        private string _HoTen;
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private bool _GioiTinh;
        public bool GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        private int _DonGia;
        public int DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        private int _SoLuongMua;
        public int SoLuongMua
        {
            get { return _SoLuongMua; }
            set { _SoLuongMua = value; }
        }

        #endregion
        public KhachHang() { }
        public KhachHang(string hoTen, bool gioiTinh,
            int soLuongMua, int donGia)
        {
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.SoLuongMua = soLuongMua;
            this.DonGia = donGia;
        }
        public double TinhTongTien()
        {
            if (this.SoLuongMua < 100)
                return (double)SoLuongMua * DonGia;
            else
                return (double)SoLuongMua * DonGia * 0.9;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                this.HoTen, this.GioiTinh, this.SoLuongMua,
                this.DonGia, this.TinhTongTien());
        }

        public void Nhap(string hoTen, bool gioiTinh,
            int soLuongMua, int donGia)
        {
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.SoLuongMua = soLuongMua;
            this.DonGia = donGia;
        }
    
    
    }
}
