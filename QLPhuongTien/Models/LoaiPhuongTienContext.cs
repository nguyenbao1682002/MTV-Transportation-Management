using System;
using System.Collections.Generic;
using System.Data;


namespace QLPhuongTien.Models
{
    public class LoaiPhuongTienContext : QLPTVTdb
    {
        public List<LoaiPhuongTienModel> GetAll()
        {
            List<LoaiPhuongTienModel> rs = new List<LoaiPhuongTienModel>();
            string s = "select * from DM_LOAI_PTIEN order by stt";
            DataTable dt = this.GetDataTable(s, null, null);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiPhuongTienModel m = new LoaiPhuongTienModel();
                m.ma_loai_ptien = dt.Rows[i]["ma_loai_ptien"].ToString();
                m.ten_loai_ptien = dt.Rows[i]["ten_loai_ptien"].ToString();
                m.stt = (int)dt.Rows[i]["stt"];
                m.nguoi_nhap = dt.Rows[i]["nguoi_nhap"].ToString();
                m.ngay_nhap = (DateTime)dt.Rows[i]["ngay_nhap"];
                rs.Add(m);
            }
            return rs;
        }

        public LoaiPhuongTienModel GetLoaiPhuongTien(string ma_loai_ptien)
        {
            LoaiPhuongTienModel rs = new LoaiPhuongTienModel();
            string s = "select * from DM_LOAI_PTIEN where ma_loai_ptien=@ma_loai_ptien";
            DataTable dt = this.GetDataTable(s, new string[] { "@ma_loai_ptien" }, new object[] { ma_loai_ptien });
            if (dt.Rows.Count > 0)
            {
                rs.ma_loai_ptien = dt.Rows[0]["ma_loai_ptien"].ToString();
                rs.ten_loai_ptien = dt.Rows[0]["ten_loai_ptien"].ToString();
                rs.stt = (int)dt.Rows[0]["stt"];
                rs.nguoi_nhap = dt.Rows[0]["nguoi_nhap"].ToString();
                rs.ngay_nhap = (DateTime)dt.Rows[0]["ngay_nhap"];
            }
            return rs;
        }

        public int Luu(Models.LoaiPhuongTienModel lpt, string username)
        {
            int rs = 0;
            Xoa(lpt.ma_loai_ptien);
            string s = "insert into DM_LOAI_PTIEN (ma_loai_ptien, ten_loai_ptien, stt, hl, nguoi_nhap, ngay_nhap) " +
                " values(@ma_loai_ptien, @ten_loai_ptien, @stt, @hl, @nguoi_nhap, @ngay_nhap)";
            rs = this.Execute(s, new string[] { "@ma_loai_ptien", "@ten_loai_ptien", "@stt", "@hl", "@nguoi_nhap", "@ngay_nhap" },
                new object[] { lpt.ma_loai_ptien, lpt.ten_loai_ptien, lpt.stt, 1, username, DateTime.Now });
            return rs;
        }
        public int Xoa(string ma_loai_ptien)
        {
            int rs = 0;
            string s = "delete DM_LOAI_PTIEN where ma_loai_ptien=@ma_loai_ptien";
            rs = this.Execute(s, new string[] { "@ma_loai_ptien" }, new object[] { ma_loai_ptien });
            return rs;
        }
    }
}