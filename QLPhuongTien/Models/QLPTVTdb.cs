using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QLPhuongTien.Models
{
    public class QLPTVTdb
    {
        public SqlConnection conn;
        public QLPTVTdb()
        {
            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["QLPTVTDB"].ConnectionString);
        }

        public DataTable GetDataTable(string query, string[] names, object[] values,bool isproc = false)
        {
            DataTable rs = new DataTable();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = query;
            if (!isproc)
            {
                comm.CommandType = CommandType.Text;
            }
            else
            {
                comm.CommandType = CommandType.StoredProcedure;
            }

            comm.Parameters.Clear();
            if (names != null)
            {
                for(int i = 0; i < names.Length; i++)
                {
                    comm.Parameters.AddWithValue(names[i], values[i]);
                }
            }
            try
            {
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                rs.Load(dr);
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rs;
        }

        public int Execute(string query, string[] names, object[] values, bool isproc = false)
        {
            int rs = 0;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = query;
            if (!isproc)
            {
                comm.CommandType = CommandType.Text;
            }
            else
            {
                comm.CommandType = CommandType.StoredProcedure;
            }

            comm.Parameters.Clear();
            if (names != null)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    comm.Parameters.AddWithValue(names[i], values[i]);
                }
            }
            try
            {
                conn.Open();
                rs = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rs;
        }
    }
}