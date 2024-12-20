using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace QLPhuongTien.Models
{
    public class TaiKhoanContext
    {

        public TaiKhoanModel DangNhap(string username, string password)
        {
             TaiKhoanModel retobj = new TaiKhoanModel();

            if(username=="admin" || password == "123")
            {
                retobj.username = username;
                retobj.madv = "CNTT";
                retobj.isValid = true;
                retobj.ho_ten = "admin";
                
            }           

            return retobj;
        }
    }

    
}