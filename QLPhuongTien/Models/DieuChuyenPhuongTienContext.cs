using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLPhuongTien.Models
{
    public class DieuChuyenPhuongTienContext:QLPTVTdb
    {
        public List<DieuChuyenPhuongTien> GetAll()
        {
            List<DieuChuyenPhuongTien> rs = new List<DieuChuyenPhuongTien>();
            string s = "select * from PS_DIEU_CHUYEN order by MADV";
            DataTable dt = this.GetDataTable(s, null, null);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DieuChuyenPhuongTien m = new DieuChuyenPhuongTien();
                m.ID = (int)dt.Rows[i]["ID"];
                m.BKS = dt.Rows[i]["BKS"].ToString();
                m.MADV = dt.Rows[i]["MADV"].ToString();
                m.TENDV = dt.Rows[i]["TENDV"].ToString();
                m.NGAY_HLUC = (DateTime)dt.Rows[i]["NGAY_HLUC"];
                m.GHI_CHU = dt.Rows[i]["GHI_CHU"].ToString();
                m.NGUOI_NHAP = dt.Rows[i]["NGUOI_NHAP"].ToString();
                m.NGAY_NHAP = (DateTime)dt.Rows[i]["NGAY_NHAP"];

                rs.Add(m);
            }
            return rs;
        }
        
        public DieuChuyenPhuongTien GetDieuChuyenPhuongTien(string MADV)
        {
            DieuChuyenPhuongTien rs = new DieuChuyenPhuongTien();
            string s = "select * from PS_DIEU_CHUYEN where MADV=@MADV";
            DataTable dt = this.GetDataTable(s, new string[] { "@MADV" }, new object[] { MADV });
            if (dt.Rows.Count > 0)
            {
                rs.ID = (int)dt.Rows[0]["ID"];
                rs.BKS = dt.Rows[0]["BKS"].ToString();
                rs.MADV = dt.Rows[0]["MADV"].ToString();
                rs.TENDV = dt.Rows[0]["TENDV"].ToString();
                rs.NGAY_HLUC = (DateTime)dt.Rows[0]["NGAY_HLUC"];
                rs.GHI_CHU = dt.Rows[0]["GHI_CHU"].ToString();
                rs.NGUOI_NHAP = dt.Rows[0]["NGUOI_NHAP"].ToString();
                rs.NGAY_NHAP = (DateTime)dt.Rows[0]["NGAY_NHAP"];
            }
            return rs;
        }

        public int Luu(DieuChuyenPhuongTien obj, string username)
        {
            int rs = 0;
            Xoa(obj.MADV);

            string s = "insert into PS_DIEU_CHUYEN (ID, BKS, MADV, TENDV, NGAY_HLUC, GHI_CHU, NGUOI_NHAP, NGAY_NHAP) " +
                " values(@ID, @BKS, @MADV, @TENDV, @NGAY_HLUC, @GHI_CHU, @NGUOI_NHAP, @NGAY_NHAP)";
            rs = this.Execute(s, new string[] { "@ID", "@BKS", "@MADV", "@TENDV", "@NGAY_HLUC", "@GHI_CHU", "@NGUOI_NHAP", "@NGAY_NHAP" },
                new object[] { obj.ID, obj.BKS, obj.MADV, obj.TENDV, DateTime.Now, obj.GHI_CHU, username, DateTime.Now });
            return rs;
        }

        public int Xoa(string MADV)
        {
            int rs = 0;
            string s = "delete PS_DIEU_CHUYEN where MADV=@MADV";
            rs = this.Execute(s, new string[] { "@MADV" }, new object[] { MADV});
            return rs;
        }
    }
}