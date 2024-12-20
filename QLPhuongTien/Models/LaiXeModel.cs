using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class LaiXeModel
    {
        public int STT { get; set; }
        public string USERNAME { get; set; }
        public string HO_TEN { get; set; }
        public string MADV { get; set; }
        public string GHICHU { get; set; }
       



        public LaiXeModel()
        {
            STT = 0;
            USERNAME = "";
            HO_TEN = "";
            MADV = "";
            GHICHU = "";
            

        }
    }
}