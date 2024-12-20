using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class LoaiNhienLieuController : Controller
    {
        private Models.LoaiNhienLieuContext ctx = new Models.LoaiNhienLieuContext();
        // GET: LoaiPhuongTien
        public ActionResult Index()
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            List<Models.LoaiNhienLieu> list_obj = ctx.GetAll();

            return View(list_obj);
        }

        public ActionResult Edit(string ma_loai_nlieu)
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
            Models.LoaiNhienLieu obj;
            if (ma_loai_nlieu is null)
            {
                obj = new Models.LoaiNhienLieu();
                obj.NGUOI_NHAP = tk.username;
            }
            else
            {
                obj = ctx.GetLoaiNhienLieu(ma_loai_nlieu);
            }

            return View("ChiTiet", obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.LoaiNhienLieu model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action.Equals("Lưu", StringComparison.CurrentCultureIgnoreCase))
                {
                    Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
                    ctx.Luu(model, tk.username);
                }
                else
                {
                    ctx.Xoa(model.MA_LOAI_NLIEU);
                }

            }
            return RedirectToAction("Index");
        }        
    }
}