
using QLPhuongTien.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Controllers
{
    public class PhanCongLaiXeController : Controller
    {
        private Models.PhanCongLaiXeContext ctx = new Models.PhanCongLaiXeContext();
        private Models.PhuongTienContext phuongTienContext = new Models.PhuongTienContext();
        public ActionResult Index()
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            List<Models.PhanCongLaiXeModel> list_obj = ctx.GetAll();

            return View(list_obj);
        }
        public ActionResult Edit(string BKS )
        {
            if (Session["taikhoan"] is null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            Models.PhuongTienContext TenPTContext = new Models.PhuongTienContext();
            Models.DonViContext donviContext = new Models.DonViContext();
            Models.LaiXeContext laiXeContext = new Models.LaiXeContext();


            List<Models.LaiXeModel> LaiXeLists = laiXeContext.GetAll();
            List<Models.PhuongTien> PTs = TenPTContext.GetAll();
            List<Models.DonVi> donVis = donviContext.GetAll();
            


            ViewBag.LaiXeList = new SelectList(LaiXeLists,"MADV","HO_TEN");
            ViewBag.TenPTList = new SelectList(PTs, "BKS", "TEN_PTIEN");
            ViewBag.DonViList = new SelectList(donVis,"MADV","TENDV");

            Models.PhanCongLaiXeModel obj;
            if (BKS is null)
            {
                obj = new Models.PhanCongLaiXeModel();
                
            }
            else
            {
                obj = ctx.GetPhanCongLaiXe(BKS);
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
        public ActionResult Edit(Models.PhanCongLaiXeModel pclx, string save1)
        {
            if (ModelState.IsValid)
            {
                if (save1.Equals("Lưu", StringComparison.CurrentCultureIgnoreCase))
                {
                    Models.TaiKhoanModel tk = (Models.TaiKhoanModel)Session["taikhoan"];
                    ctx.Luu(pclx, tk.username);
                }
                else
                {
                    ctx.Xoa(pclx.ID);
                }

            }
            return RedirectToAction("Index");
        }
    }
    
}
