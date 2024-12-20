using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace QLPhuongTien.Models
{
    public class DieuChuyenPhuongTien
    {
        public int ID { get; set; }
        public string BKS { get; set; }
        public string TEN_PTIEN { get; set; }
        public string MADV { get; set; }
        public string TENDV { get; set; }
        [Display(Name = "Ngày bắt đầu sử dụng")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NGAY_HLUC { get; set; }
        public string GHI_CHU { get; set; }
        public DateTime NGAY_NHAP { get; set; }
        public string NGUOI_NHAP { get; set; }

        public DieuChuyenPhuongTien()
        {
            ID = 0;
            BKS = "";
            TEN_PTIEN = "";
            MADV = "";
            TENDV = "";
            NGAY_HLUC = DateTime.MinValue;
            GHI_CHU = "";
            NGAY_NHAP = DateTime.Now;
            NGUOI_NHAP = "";
        }
    }
}