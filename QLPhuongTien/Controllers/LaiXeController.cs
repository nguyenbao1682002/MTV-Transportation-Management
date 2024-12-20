using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class LaiXeController : Controller
    {
        // GET: LaiXe
        public ActionResult Index()
        {
            if (Session["taikhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            else
            {
                Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
                ViewBag.user_name = tk.ho_ten;
                ViewBag.avatar = tk.avatar;
                return View();
            }
        }
    }
}