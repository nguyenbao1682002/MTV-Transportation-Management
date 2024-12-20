using System;
using System.Collections.Generic;
using System.Data;

namespace QLPhuongTien.Models
{
    public class FileContext: QLPTVTdb
    {
        public List<File> GetFiles(string loai, string ma_dtuong)
        {
            List<File> rs = new List<File>();
            string s = "select * from FILES where loai=@loai and ma_dtuong=@ma_dtuong";
            DataTable dt = GetDataTable(s, new string[] {"loai","ma_dtuong" }, new object[] {loai, ma_dtuong });
            foreach(DataRow r in dt.Rows)
            {
                File obj = new File();
                obj.ID = (int)r["ID"];
                obj.LOAI = r["LOAI"].ToString();
                obj.MA_DTUONG= r["MA_DTUONG"].ToString();
                obj.MO_TA= r["MO_TA"].ToString();
                obj.TEN_FILE= r["TEN_FILE"].ToString();
                obj.LOAI_FILE= r["LOAI_FILE"].ToString();
                obj.LINK= r["LINK"].ToString();
            }
            return rs;
        }
    }
}