using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class DonViContext:QLPTVTdb
    {
        public List<DonVi> GetAll()
        {
            List<DonVi> rs = new List<DonVi>();
            string s = "select * from DM_DON_VI order by MADV";
            DataTable dt = GetDataTable(s, null, null);
            foreach (DataRow r in dt.Rows)
            {
                DonVi obj = new DonVi();
                obj.MADV = r["MADV"].ToString();
                obj.TENDV = r["TENDV"].ToString();
                
                rs.Add(obj);
            }
            return rs;
        }
    }
}