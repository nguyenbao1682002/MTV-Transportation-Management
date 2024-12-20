using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["taikhoan"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
                ViewBag.user_name = tk.ho_ten;
                ViewBag.avatar = tk.avatar;
                return View();
            }
        }

        public ActionResult LoaiPhuongTien()
        {
            return RedirectToAction("Index","LoaiPhuongTien");
        }        

        public ActionResult DangNhap()
        {
            if (Session["taikhoan"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(Models.TaiKhoanModel tk)
        {
            Models.TaiKhoanContext tkc = new Models.TaiKhoanContext();
            Models.TaiKhoanModel tkm = tkc.DangNhap(tk.username, tk.password);

            if (tkm.isValid)
            {
                Session["taikhoan"] = tkm;
                ViewBag.info = "";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.info = "Đăng nhập không hợp lệ ";
                return View();
            }


        }

        


    }
}