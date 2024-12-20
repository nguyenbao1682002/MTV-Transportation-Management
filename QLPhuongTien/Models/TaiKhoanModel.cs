using System;
using System.Collections.Generic;

namespace QLPhuongTien.Models
{
    public class TaiKhoanModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ho_ten { get; set; }
        public string madv { get; set; }
        public string avatar { get; set; }
        public bool isValid { get; set; }
    }
}