using System;
using System.Collections.Generic;
using System.Data;

namespace QLPhuongTien.Models
{
    public class LoaiNhienLieuContext : QLPTVTdb
    {
        public List<LoaiNhienLieu> GetAll()
        {
            List<LoaiNhienLieu> rs = new List<LoaiNhienLieu>();
            string s = "select * from DM_LOAI_NLIEU order by stt";
            DataTable dt = this.GetDataTable(s, null, null);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiNhienLieu m = new LoaiNhienLieu();
                m.MA_LOAI_NLIEU= dt.Rows[i]["MA_LOAI_NLIEU"].ToString();
                m.TEN_LOAI_NLIEU = dt.Rows[i]["TEN_LOAI_NLIEU"].ToString();
                m.DON_GIA = dt.Rows[i]["DON_GIA"].ToString();
                m.STT = (int)dt.Rows[i]["STT"];
                m.DVT = dt.Rows[i]["DVT"].ToString();
                m.NGUOI_NHAP = dt.Rows[i]["NGUOI_NHAP"].ToString();
                m.NGAY_NHAP = (DateTime)dt.Rows[i]["NGAY_NHAP"];

                rs.Add(m);
            }
            return rs;
        }

        public LoaiNhienLieu GetLoaiNhienLieu(string MA_LOAI_NLIEU)
        {
            LoaiNhienLieu rs = new LoaiNhienLieu();
            string s = "select * from DM_LOAI_NLIEU where MA_LOAI_NLIEU=@MA_LOAI_NLIEU";
            DataTable dt = this.GetDataTable(s, new string[] { "@MA_LOAI_NLIEU" }, new object[] { MA_LOAI_NLIEU });
            if (dt.Rows.Count > 0)
            {
                rs.MA_LOAI_NLIEU = dt.Rows[0]["MA_LOAI_NLIEU"].ToString();
                rs.TEN_LOAI_NLIEU = dt.Rows[0]["TEN_LOAI_NLIEU"].ToString();
                rs.DON_GIA = dt.Rows[0]["DON_GIA"].ToString();
                rs.STT = (int)dt.Rows[0]["STT"];
                rs.DVT = dt.Rows[0]["DVT"].ToString();
                rs.NGUOI_NHAP = dt.Rows[0]["NGUOI_NHAP"].ToString();
                rs.NGAY_NHAP = (DateTime)dt.Rows[0]["NGAY_NHAP"];
            }
            return rs;
        }

        public int Luu(LoaiNhienLieu obj, string username)
        {
            int rs = 0;
            Xoa(obj.MA_LOAI_NLIEU);

            string s = "insert into DM_LOAI_NLIEU (MA_LOAI_NLIEU, TEN_LOAI_NLIEU, DON_GIA, STT, DVT, hl, NGUOI_NHAP, NGAY_NHAP) " +
                " values(@MA_LOAI_NLIEU, @TEN_LOAI_NLIEU, @DON_GIA, @STT, @DVT, @hl, @NGUOI_NHAP, @NGAY_NHAP)";
            rs = this.Execute(s, new string[] { "@MA_LOAI_NLIEU", "@TEN_LOAI_NLIEU","@DON_GIA", "@STT", "@DVT", "@hl", "@NGUOI_NHAP", "@NGAY_NHAP" },
                new object[] { obj.MA_LOAI_NLIEU, obj.TEN_LOAI_NLIEU,obj.DON_GIA, obj.STT, obj.DVT, 1, username, DateTime.Now });
            return rs;
        }

        public int Xoa(string MA_LOAI_NLIEU)
        {
            int rs = 0;
            string s = "delete DM_LOAI_NLIEU where MA_LOAI_NLIEU=@MA_LOAI_NLIEU";
            rs = this.Execute(s, new string[] { "@MA_LOAI_NLIEU" }, new object[] { MA_LOAI_NLIEU });
            return rs;
        }
    }
}