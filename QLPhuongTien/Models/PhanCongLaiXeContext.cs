using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPhuongTien.Models
{
    public class PhanCongLaiXeContext:QLPTVTdb
    {
            public List<PhanCongLaiXeModel> GetAll()
            {
                List<PhanCongLaiXeModel> rs = new List<PhanCongLaiXeModel>();
                string s = "select * from PS_PCONG_LXE_PTIEN order by BKS";
                DataTable dt = this.GetDataTable(s, null, null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                PhanCongLaiXeModel m = new PhanCongLaiXeModel();
                    m.ID = (int)dt.Rows[i]["ID"];                                      
                    m.TEN_PTIEN = dt.Rows[i]["TEN_PTIEN"].ToString();
                    m.BKS = dt.Rows[i]["BKS"].ToString();      
                    m.NGAY_HLUC = (DateTime)dt.Rows[i]["NGAY_HLUC"];
                    m.GHICHU = dt.Rows[i]["GHICHU"].ToString();
                    m.MADV = dt.Rows[i]["MADV"].ToString();
                    m.HO_TEN = dt.Rows[i]["HO_TEN"].ToString();



                rs.Add(m);
                }
                return rs;
            }

        public PhanCongLaiXeModel GetPhanCongLaiXe(string BKS)
        {
            PhanCongLaiXeModel rs = new PhanCongLaiXeModel();
            string s = "select * from PS_PCONG_LXE_PTIEN where BKS=@BKS";
            DataTable dt = this.GetDataTable(s, new string[] { "@BKS" }, new object[] { BKS });
            if (dt.Rows.Count > 0)
            {
                rs.ID = (int)dt.Rows[0]["ID"];                
                rs.TEN_PTIEN = dt.Rows[0]["TEN_PTIEN"].ToString();
                rs.BKS = dt.Rows[0]["BKS"].ToString();
                rs.NGAY_HLUC = (DateTime)dt.Rows[0]["NGAY_HLUC"];
                rs.GHICHU = dt.Rows[0]["GHICHU"].ToString();
                rs.MADV = dt.Rows[0]["MADV"].ToString();
                rs.HO_TEN = dt.Rows[0]["HO_TEN"].ToString();
            }
            return rs;
        }
        

        public int Luu(PhanCongLaiXeModel obj, string username)
            {
                int rs = 0;
                Xoa(obj.ID);
                string s = "insert into PS_PCONG_LXE_PTIEN (ID,TEN_PTIEN, BKS, MADV , NGAY_HLUC, GHICHU ,HO_TEN ) " +
                    " values(@ID,@TEN_PTIEN, @BKS ,@MADV , @NGAY_HLUC, @GHICHU)";
                rs = this.Execute(s, new string[] { "@ID", "@TEN_PTIEN", "@BKS", "@MADV", "@NGAY_HLUC", "@GHICHU","HO_TEN" },
                    new object[] { obj.ID,obj.TEN_PTIEN, obj.BKS,obj.MADV, DateTime.Now, obj.GHICHU, obj.HO_TEN});
                return rs;
            }

            public int Xoa(int ID)
            {
                int rs = 0;
                string s = "delete PS_PCONG_LXE_PTIEN where ID=@ID";
                rs = this.Execute(s, new string[] { "@ID" }, new object[] { ID });
                return rs;
            }
        }
}