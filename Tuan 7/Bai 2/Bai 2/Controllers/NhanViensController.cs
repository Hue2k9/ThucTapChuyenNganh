using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_2.Models;

namespace Bai_2.Controllers
{
    public class NhanViensController : Controller
    {
        // GET: NhanViens
        public ActionResult Index()
        {
            return View();
        }

        List<NhanVien> danhsach = new List<NhanVien>();
        public NhanViensController()
        {
            danhsach.Add(new NhanVien("nv01", "Ha Kim Tien", 30, 100));
            danhsach.Add(new NhanVien("nv02", "Tran Thi Yen", 28, 150));
            danhsach.Add(new NhanVien("nv03", "Le Thi Ha", 20, 200));
            danhsach.Add(new NhanVien("nv04", "Le Van Chung", 25, 130));
            danhsach.Add(new NhanVien("nv05", "Hoang Thi Nga", 27, 120));
        }

        public ActionResult DanhSach1()
        {
            var ds = danhsach.Where(nv => nv.ngaycong > 27).ToList();
            return View(ds);
        }

        public ActionResult Danhsach2()
        {
            var ds = danhsach.Where(nv => nv.luongngay <= 150).ToList();
            return View(ds);
        }

    }
}