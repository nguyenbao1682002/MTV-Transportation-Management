using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class File
    {
        public int ID { get; set; }
        public string LOAI { get; set; }
        public string MA_DTUONG { get; set; }
        public string TEN_FILE { get; set; }
        public string MO_TA { get; set; }
        public string LINK { get; set; }
        public string LOAI_FILE { get; set; }
        public DateTime NGAY_NHAP { get; set; }
        public string NGUOI_NHAP { get; set; }

        public File()
        {
            ID = 0;
            LOAI = "";
            MA_DTUONG = "";
            TEN_FILE = "";
            MO_TA = "";
            LINK = "";
            LOAI_FILE = "";
            NGAY_NHAP = DateTime.Now;
            NGUOI_NHAP = "";
        }

    }
}