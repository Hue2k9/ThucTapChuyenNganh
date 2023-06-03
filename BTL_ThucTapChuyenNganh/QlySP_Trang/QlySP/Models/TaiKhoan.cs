using System;
using System.Collections.Generic;

#nullable disable

namespace QlySP.Models
{
    public partial class TaiKhoan
    {
        public string TenDn { get; set; }
        public string PhanQuyen { get; set; }
        public string MatKhau { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
