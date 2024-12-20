using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class LaiXeContext : QLPTVTdb
    {
        public List<LaiXeModel> GetAll()
        {
            List<LaiXeModel> rs = new List<LaiXeModel>();
            string s = "select * from DM_LAIXE order by USERNAME";
            DataTable dt = GetDataTable(s, null, null);
            foreach (DataRow r in dt.Rows)
            {
                LaiXeModel obj = new LaiXeModel();
                obj.STT = (int)r["STT"];
                obj.USERNAME = r["USERNAME"].ToString();
                obj.HO_TEN = r["HO_TEN"].ToString();
                obj.MADV = r["MADV"].ToString();
                obj.GHICHU = r["GHICHU"].ToString();

                rs.Add(obj);
            }
            return rs;
        }
    }
}