using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class ContentRepository
    {
        DataAccess data;
        public ContentRepository()
        {
            data = new DataAccess();
        }

        public List<Content> GetAll(int id)
        {
            string sql = "Select * from DiaryContents where Uid=@Uid";
            SqlDataReader reader = data.GetData(sql,id);
            List<Content> noteList = new List<Content>();

            while (reader.Read())
            {
                Content con = new Content();
                con.Nid = Convert.ToInt32(reader["Nid"]);
                con.Uid = Convert.ToInt32(reader["Uid"]);
                con.Nname = reader["Nname"].ToString();
                con.Ntext = reader["Ntext"].ToString();
                con.Nimage = reader["Nimage"].ToString();
                con.Npriority = Convert.ToInt32(reader["Npriority"]);
                con.Ndate = reader["Ndate"].ToString();
                noteList.Add(con);
            }
            return noteList;
        }

        public Content Get(int id)
        {
            string sql = "select * form DiaryContents where Uid=@Uid";
            SqlDataReader reader = data.GetData(sql, id);
            Content con = new Content();

            while (reader.Read())
            {
                con.Nid = Convert.ToInt32(reader["Nid"]);
                con.Uid = Convert.ToInt32(reader["Uid"]);
                con.Nname = reader["Nname"].ToString();
                con.Ntext = reader["Ntext"].ToString();
                con.Nimage = reader["Nimage"].ToString();
                con.Npriority = Convert.ToInt32(reader["Npriority"]);
                con.Ndate = reader["Ndate"].ToString();
            }
            return con;
        }

        //public int Update(Content con)
        //{
        //    string sql = "Update DiaryUser set Uname='" + us.Uname + "', Upassword='" + us.Upassword + "' where Uid=" + us.Uid;
        //    return data.ExecuteQuery(sql);
        //}
    }
}