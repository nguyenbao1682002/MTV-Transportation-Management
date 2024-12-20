using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace QLPhuongTien.Models
{
    public class PhuongTien
    {
        [Display(Name ="Mã loại phương tiện")]
        public string MA_LOAI_PTIEN { get; set; }

        [Display(Name = "Tên phương tiện")]
        public string TEN_PTIEN { get; set; }

        [Display(Name = "Biển kiểm soát")]
        public string BKS { get; set; }
        [Display(Name = "Số khung")]
        public string SO_KHUNG { get; set; }
        [Display(Name = "Số máy")]
        public string SO_MAY { get; set; }

        [Display(Name = "Ngày bắt đầu sử dụng")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime NGAY_HLUC { get; set; }

        [Display(Name = "Nước SX")]
        public string NUOC_SXUAT { get; set; }

        [Display(Name = "Hãng SX")]
        public string HANG_SXUAT { get; set; }

        [Display(Name = "Mã tài sản")]
        public string MA_TSAN { get; set; }

        [Display(Name = "Loại nhiên liệu")]
        public string MA_LOAI_NLIEU { get; set; }

        [Display(Name = "Ghi chú")]
        public string GHI_CHU { get; set; }

        [Display(Name = "Trạng thái")]
        public string TRANG_THAI { get; set; }

        [Display(Name = "Ngày nhập")]
        public DateTime NGAY_NHAP { get; set; }

        [Display(Name = "Người nhập")]
        public string NGUOI_NHAP { get; set; }

        
        public List<File> DSFile { get; set; }

        public PhuongTien()
        {
            MA_LOAI_PTIEN = "";
            TEN_PTIEN = "";
            BKS = "";
            SO_KHUNG = "";
            SO_MAY = "";
            NGAY_HLUC = DateTime.Today;
            NUOC_SXUAT = "";
            HANG_SXUAT = "";
            MA_LOAI_NLIEU = "";
            MA_TSAN = "";
            GHI_CHU = "";
            TRANG_THAI = "";
            NGAY_NHAP = DateTime.Now;
            NGUOI_NHAP = "";
            DSFile = new List<File>();
           
            
        }

    }
}