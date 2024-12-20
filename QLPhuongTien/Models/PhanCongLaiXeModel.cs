using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class PhanCongLaiXeModel
    {
        public int ID { get; set; }
        public string TEN_PTIEN { get; set; }
        public string BKS { get; set; }

        [Display(Name = "Tên Đơn Vị")]
        public string MADV { get; set; }

        [Display(Name = "Ngày bắt đầu sử dụng")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NGAY_HLUC { get; set; }
        public string GHICHU { get; set; }

        [Display(Name = "Lái Xe")]        
        
        public string HO_TEN { get; set; }
        public PhanCongLaiXeModel()
        {
            ID = 0;
            BKS = "";
            TEN_PTIEN = "";
            MADV = "";
            NGAY_HLUC = DateTime.Now;
            GHICHU = "";
            HO_TEN = "";
           
        }
    }
}