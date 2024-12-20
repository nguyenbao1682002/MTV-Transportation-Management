using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class DonVi
    {
        public string MADV { get; set; }
        public string TENDV { get; set; }
        

        public DonVi()
        {
            MADV = "";
            TENDV = "";
         
        }
    }
}