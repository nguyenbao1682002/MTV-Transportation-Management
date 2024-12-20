using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class LoaiPhuongTienController : Controller
    {
        private Models.LoaiPhuongTienContext lptc = new Models.LoaiPhuongTienContext();
        // GET: LoaiPhuongTien
        public ActionResult Index()
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            List<Models.LoaiPhuongTienModel> list_loai_ptien = lptc.GetAll();

            return View(list_loai_ptien);
        }

        public ActionResult Edit(string ma_loai_ptien)
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
            Models.LoaiPhuongTienModel lpt;
            if (ma_loai_ptien is null)
            {
                lpt = new Models.LoaiPhuongTienModel();
                lpt.ma_loai_ptien = "";
                lpt.ten_loai_ptien = "";
                lpt.stt = 99;
                lpt.nguoi_nhap = tk.username.ToString();
                lpt.ngay_nhap = DateTime.Now;
            }
            else
            {
                lpt = lptc.GetLoaiPhuongTien(ma_loai_ptien);
            }

            return View("ChiTiet", lpt);
        }

        [HttpPost]
        public ActionResult Edit(Models.LoaiPhuongTienModel model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action.Equals("Lưu", StringComparison.CurrentCultureIgnoreCase))
                {
                    Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
                    lptc.Luu(model, tk.username);
                }
                else
                {
                    lptc.Xoa(model.ma_loai_ptien);
                }

            }
            return RedirectToAction("Index");
        }
    }
}