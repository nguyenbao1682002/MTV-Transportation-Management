using System;
using System.Collections.Generic;
using System.Data;

namespace QLPhuongTien.Models
{
    public class TrangThaiContext:QLPTVTdb
    {
        public List<TrangThai> GetAll()
        {
            List<TrangThai> rs = new List<TrangThai>();
            string s = "select * from DM_TRANG_THAI order by STT";
            DataTable dt = GetDataTable(s, null, null);
            foreach(DataRow r in dt.Rows)
            {
                TrangThai obj = new TrangThai();
                obj.TRANG_THAI = r["TRANG_THAI"].ToString();
                obj.MO_TA= r["MO_TA"].ToString();
                obj.STT= (int)r["STT"];
                rs.Add(obj);
            }
            return rs;
        }
    }
}