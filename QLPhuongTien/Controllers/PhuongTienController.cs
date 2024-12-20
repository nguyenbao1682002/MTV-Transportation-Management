using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class PhuongTienController : Controller
    {

        private Models.PhuongTienContext ctx = new Models.PhuongTienContext();
        public ActionResult Index()
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            List<Models.PhuongTien> models = ctx.GetAll();

            return View(models);
        }

        public ActionResult PhuongTienInfo(string bks="")
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            Models.LoaiPhuongTienContext loaiPhuongTienContext = new Models.LoaiPhuongTienContext();
            Models.LoaiNhienLieuContext loaiNhienLieuContext = new Models.LoaiNhienLieuContext();
            Models.TrangThaiContext trangThaiContext = new Models.TrangThaiContext();
            

            List<Models.LoaiPhuongTienModel> loaiPhuongTiens = loaiPhuongTienContext.GetAll();
            List<Models.LoaiNhienLieu> loaiNhienLieus = loaiNhienLieuContext.GetAll();
            List<Models.TrangThai> trangThais = trangThaiContext.GetAll();


            ViewBag.LoaiPhuongTienList = new SelectList(loaiPhuongTiens, "MA_LOAI_PTIEN", "TEN_LOAI_PTIEN");
            ViewBag.LoaiNhienLieuList = new SelectList(loaiNhienLieus, "MA_LOAI_NLIEU", "TEN_LOAI_NLIEU");
            ViewBag.TrangThaiList = new SelectList(trangThais, "TRANG_THAI", "MO_TA");

            Models.PhuongTien obj;            
            if (bks != "")
            {
                obj = ctx.GetPhuongTien(bks);
            }
            else {
                obj = new Models.PhuongTien();
            }
            
            return View("TaoPhuongTien", obj);
        }
        
        //public ActionResult Index()
        //{
        //    if (Session["taikhoan"] is null)
        //    {
        //        return RedirectToAction("DangNhap", "Home");
        //    }

        //    Models.LoaiPhuongTienContext loaiPhuongTienContext = new Models.LoaiPhuongTienContext();
        //    Models.LoaiNhienLieuContext loaiNhienLieuContext = new Models.LoaiNhienLieuContext();
        //    Models.TrangThaiContext trangThaiContext = new Models.TrangThaiContext();

        //    List<Models.LoaiPhuongTienModel> loaiPhuongTiens = loaiPhuongTienContext.GetAll();
        //    List<Models.LoaiNhienLieu> loaiNhienLieus = loaiNhienLieuContext.GetAll();
        //    List<Models.TrangThai> trangThais = trangThaiContext.GetAll();
        //    List<Models.PhuongTien> list = ctx.GetAll();

        //    ViewBag.LoaiPhuongTienList = new SelectList(loaiPhuongTiens, "MA_LOAI_PTIEN", "MA_LOAI_PTIEN");
        //    ViewBag.LoaiNhienLieuList = new SelectList(loaiNhienLieus, "MA_LOAI_NLIEU", "TEN_LOAI_NLIEU");
        //    ViewBag.TrangThaiList = new SelectList(trangThais, "TRANG_THAI", "MO_TA");

        //    return View("ChiTiet");
        //}


        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        //public ActionResult Edit(string MA_LOAI_PTIEN)
        //{
        //    if (Session["taikhoan"] is null)
        //    {
        //        return RedirectToAction("DangNhap", "Home");
        //    }

        //    Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
        //    Models.PhuongTien obj;
        //    if (MA_LOAI_PTIEN is null)
        //    {
        //        obj = new Models.PhuongTien();
        //        obj.NGUOI_NHAP = tk.username;
        //    }
        //    else
        //    {
        //        obj = ctx.GetPhuongTien(MA_LOAI_PTIEN);
        //    }

        //    return View("ChiTiet", obj);
        //}
        public ActionResult Edit(string BKS)
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
            Models.PhuongTien obj;
            //if (BKS is null)
            //{
            //    obj = new Models.PhuongTien();
            //    obj.NGUOI_NHAP = tk.username;
            //}
            //else
            //{
            //    obj = ctx.GetPhuongTien(BKS);
            //}

            obj = ctx.GetPhuongTien(BKS);

            return View("TaoPhuongTien", obj);
        }

        [HttpPost]
         
        public ActionResult LuuPhuongTien(Models.PhuongTien model, string action)
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
                    ctx.Xoa(model.BKS);
                }
            }
            return RedirectToAction("Index");
        }
    }
}