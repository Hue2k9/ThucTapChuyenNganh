using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_2.Models
{
    public class NhanVien
    {
        public string manv { get; set; }
        public string hoten { get; set; }
        public int ngaycong { get; set; }
        public int luongngay { get; set; }
        public int tongtien
        {
            get { return ngaycong * luongngay; }
        }
        public NhanVien() { }
        public NhanVien(string manv, string hoten, int ngaycong, int luongngay)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.ngaycong = ngaycong;
            this.luongngay = luongngay;
        }
    }
}