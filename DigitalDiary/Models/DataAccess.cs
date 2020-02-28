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
        SqlConnection connection;
        SqlCommand command;

        public DataAccess()
        {
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PDB"].ConnectionString);
            this.connection.Open();
        }


        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteReader();
        }
        public SqlDataReader GetData(string sql, int id)
        {
            this.command = new SqlCommand(sql, connection);
            this.command.Parameters.AddWithValue("userId", id);
            return this.command.ExecuteReader();
        }
        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}