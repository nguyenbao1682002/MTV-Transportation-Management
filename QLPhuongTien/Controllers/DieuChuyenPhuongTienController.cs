using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace QLPhuongTien.Controllers
{
    public class DieuChuyenPhuongTienController : Controller
    {
        private Models.DieuChuyenPhuongTienContext ctx = new Models.DieuChuyenPhuongTienContext();
        // GET: DieuChuyenPhuongTien
        public ActionResult Index()
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            List<Models.DieuChuyenPhuongTien> list_obj = ctx.GetAll();

            return View(list_obj);
        }

        public ActionResult Edit(string MADV)
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            Models.PhuongTienContext TENPTContext = new Models.PhuongTienContext();
            Models.DonViContext donviContext = new Models.DonViContext();

            List<Models.PhuongTien> TENPTs = TENPTContext.GetAll();
            List<Models.DonVi> donVis = donviContext.GetAll();

            ViewBag.TENPTList = new SelectList(TENPTs, "BKS", "TEN_PTIEN");
            ViewBag.DonViList = new SelectList(donVis, "MADV", "TENDV");
            Models.DieuChuyenPhuongTien obj;
            if (MADV is null)
            {
                obj = new Models.DieuChuyenPhuongTien();
                
            }
            else
            {
                obj = ctx.GetDieuChuyenPhuongTien(MADV);
            }

            return View("ChiTiet", obj);
        }
       
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.DieuChuyenPhuongTien model, string action)
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
                    ctx.Xoa(model.MADV);
                }

            }
            return RedirectToAction("Index");
        }
    }
}