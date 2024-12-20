using System;
using System.Collections.Generic;
using System.Data;

namespace QLPhuongTien.Models
{
    public class PhuongTienContext:QLPTVTdb
    {
        private readonly string LOAI = "PTIEN";
        private FileContext fileContext = new FileContext(); 
        

        public List<PhuongTien> GetAll()
        {
            List<PhuongTien> rs = new List<PhuongTien>();
            string s = "select * from DM_PHUONG_TIEN order by BKS";
            DataTable dt = this.GetDataTable(s, null, null);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhuongTien m = new PhuongTien();
                m.TEN_PTIEN= dt.Rows[i]["TEN_PTIEN"].ToString();
                m.MA_LOAI_PTIEN = dt.Rows[i]["MA_LOAI_PTIEN"].ToString();
                m.MA_TSAN = dt.Rows[i]["MA_TSAN"].ToString();
                m.NGAY_HLUC = (DateTime)dt.Rows[i]["NGAY_HLUC"];
                m.HANG_SXUAT = dt.Rows[i]["HANG_SXUAT"].ToString();
                m.NUOC_SXUAT = dt.Rows[i]["NUOC_SXUAT"].ToString();
                m.MA_LOAI_NLIEU = dt.Rows[i]["MA_LOAI_NLIEU"].ToString();
                m.SO_KHUNG = dt.Rows[i]["SO_KHUNG"].ToString();
                m.SO_MAY = dt.Rows[i]["SO_MAY"].ToString();
                m.BKS = dt.Rows[i]["BKS"].ToString();
                m.GHI_CHU = dt.Rows[i]["GHI_CHU"].ToString();   
                m.TRANG_THAI= dt.Rows[i]["TRANG_THAI"].ToString();
                m.NGUOI_NHAP = dt.Rows[i]["NGUOI_NHAP"].ToString();
                m.NGAY_NHAP = (DateTime)dt.Rows[i]["NGAY_NHAP"];

                m.DSFile = fileContext.GetFiles(this.LOAI, m.BKS);
                

                rs.Add(m);
            }
            return rs;
        }
        public List<string> GetTENDV(string TENDV)
        {
            List<string> rs = new List<string>();
            string s = "select * from PS_DIEU_CHUYEN where TENDV=@TENDV";
            DataTable dt = this.GetDataTable(s, new string[] { "@TENDV" }, new object[] { TENDV });
            if (dt.Rows.Count > 0)
            {
                rs.Add(dt.Rows[0]["TENDV"].ToString());
            }
            return rs;
        }
        public PhuongTien GetPhuongTien(string BKS)
        {
            PhuongTien rs = new PhuongTien();
            string s = "select * from DM_PHUONG_TIEN where BKS=@BKS";
            DataTable dt = this.GetDataTable(s, new string[] { "@BKS" }, new object[] { BKS });
            if (dt.Rows.Count > 0)
            {
                rs.TEN_PTIEN = dt.Rows[0]["TEN_PTIEN"].ToString();
                rs.MA_LOAI_PTIEN = dt.Rows[0]["MA_LOAI_PTIEN"].ToString();
                rs.MA_TSAN = dt.Rows[0]["MA_TSAN"].ToString();
                rs.NGAY_HLUC = (DateTime)dt.Rows[0]["NGAY_HLUC"];
                rs.HANG_SXUAT = dt.Rows[0]["HANG_SXUAT"].ToString();
                rs.NUOC_SXUAT = dt.Rows[0]["NUOC_SXUAT"].ToString();
                rs.MA_LOAI_NLIEU = dt.Rows[0]["MA_LOAI_NLIEU"].ToString();
                rs.SO_KHUNG = dt.Rows[0]["SO_KHUNG"].ToString();
                rs.SO_MAY = dt.Rows[0]["SO_MAY"].ToString();
                rs.BKS = dt.Rows[0]["BKS"].ToString();
                rs.GHI_CHU = dt.Rows[0]["GHI_CHU"].ToString();
                rs.TRANG_THAI = dt.Rows[0]["TRANG_THAI"].ToString();
                rs.NGUOI_NHAP = dt.Rows[0]["NGUOI_NHAP"].ToString();
                rs.NGAY_NHAP = (DateTime)dt.Rows[0]["NGAY_NHAP"];

                rs.DSFile = fileContext.GetFiles(this.LOAI, BKS);
                
            }
            return rs;
        }
        public string GetBKSFromTenPhuongTien(string tenPhuongTien)
        {
            string bks = "";          
            string query = "SELECT BKS FROM DM_PHUONG_TIEN WHERE TEN_PTIEN = @TenPhuongTien";
            DataTable dt = this.GetDataTable(query, new string[] { "@TenPhuongTien" }, new object[] { tenPhuongTien });
            if (dt.Rows.Count > 0)
            {
                bks = dt.Rows[0]["BKS"].ToString();
            }
            return bks;
        }

        public int Luu(Models.PhuongTien obj, string username)
        {
            int rs = 0;
            Xoa(obj.BKS);
            string s = "insert into DM_PHUONG_TIEN (MA_LOAI_PTIEN, TEN_PTIEN, BKS, SO_KHUNG, SO_MAY, NGAY_HLUC, NUOC_SXUAT, HANG_SXUAT, MA_LOAI_NLIEU, MA_TSAN, GHI_CHU, TRANG_THAI, NGAY_NHAP, NGUOI_NHAP) " +
                " values(@MA_LOAI_PTIEN, @TEN_PTIEN, @BKS, @SO_KHUNG, @SO_MAY, @NGAY_HLUC, @NUOC_SXUAT, @HANG_SXUAT, @MA_LOAI_NLIEU, @MA_TSAN, @GHI_CHU, @TRANG_THAI, @NGAY_NHAP, @NGUOI_NHAP)";
            rs = this.Execute(s, new string[] { "MA_LOAI_PTIEN", "TEN_PTIEN", "BKS", "SO_KHUNG", "SO_MAY", "NGAY_HLUC", "NUOC_SXUAT", "HANG_SXUAT", "MA_LOAI_NLIEU", "MA_TSAN", "GHI_CHU", "TRANG_THAI", "NGAY_NHAP", "NGUOI_NHAP" },
                new object[] {obj.MA_LOAI_PTIEN, obj.TEN_PTIEN, obj.BKS, obj.SO_KHUNG ,obj.SO_MAY , obj.NGAY_HLUC, obj.NUOC_SXUAT, obj.HANG_SXUAT, obj.MA_LOAI_NLIEU, obj.MA_TSAN, obj.GHI_CHU, obj.TRANG_THAI, DateTime.Now, username });
            return rs;
        }   
        public int Xoa(string BKS)
        {
            int rs = 0;
            string s = "delete DM_PHUONG_TIEN where BKS=@BKS";
            rs = this.Execute(s, new string[] { "@BKS" }, new object[] { BKS });
            return rs;
        }
    }
}