using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class DataAccess : IDisposable
    {
        SqlConnection conn;
        SqlCommand comm;
        public DataAccess()
        {
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
            this.conn.Open();
        }



        public SqlDataReader GetData(string sql)
        {
            this.comm = new SqlCommand(sql,conn);
            return this.comm.ExecuteReader();
        }
        public SqlDataReader GetData(string sql, int id)
        {
            this.comm = new SqlCommand(sql, conn);
            this.comm.Parameters.AddWithValue("Uid",id);
            return this.comm.ExecuteReader();
        }
        public int ExecuteQuery(string sql)
        {
            this.comm = new SqlCommand(sql, conn);
            return this.comm.ExecuteNonQuery();
        }





        public void Dispose()
        {
            this.conn.Close();
        }
    }
}