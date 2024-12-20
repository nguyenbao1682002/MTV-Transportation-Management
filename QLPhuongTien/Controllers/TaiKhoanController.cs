using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ThongTinTaiKhoan()
        {
            Models.TaiKhoanModel model = (Models.TaiKhoanModel)Session["taikhoan"];
            return PartialView("TaiKHoanPartialView", model);
        }



        public ActionResult DangXuat()
        {
            Session.Clear();

            return RedirectToAction("DangNhap","Home");
        }
    }
}