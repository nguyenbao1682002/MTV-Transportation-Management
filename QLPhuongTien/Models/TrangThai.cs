using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class TrangThai
    {
        public string TRANG_THAI { get; set; }
        public string MO_TA { get; set; }
        public int STT { get; set; }

        public TrangThai() 
        {
            TRANG_THAI = "";
            MO_TA = "";
            STT = 0;
        }

    }
}