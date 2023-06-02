﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_BookStore_TTCN.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public int? SoLuongTon { get; set; }
        public string GioiThieu { get; set; }
        public decimal? GiaBan { get; set; }
        public string BaoQuan { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
