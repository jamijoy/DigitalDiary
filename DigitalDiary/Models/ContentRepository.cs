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
            string sql = "select * from DiaryContents where Nid="+id;
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

        public int GetLastNoteNumber()
        {
            int nextID=0;
            string sql = "select Nid from DiaryContents order by Nid asc";
            SqlDataReader reader = data.GetData(sql);
            while (reader.Read())
            {
                nextID = Convert.ToInt32(reader["Nid"]);
            }
            return nextID;
        }

        public string GetImageLink(int noteId)
        {
            string link="";
            string sql = "select Nimage from DiaryContents where Nid="+noteId;
            SqlDataReader reader = data.GetData(sql);
            while (reader.Read())
            {
                link = reader["Nimage"].ToString();
            }
            return link;
        }

        public int Update(Content con)
        {
            string sql = "Update DiaryContents set Nname='" + con.Nname + "', Ntext='" + con.Ntext + "',Nimage='" + con.Nimage + "',Npriority=" + con.Npriority + ",Ndate='" + con.Ndate + "' where Nid=" + con.Nid;
            return data.ExecuteQuery(sql);
        }

        public int Insert(Content con)
        {
            DataAccess dat = new DataAccess();
            string sql = "INSERT INTO DiaryContents(Uid,Nname,Ntext,Nimage,Npriority,Ndate) VALUES('" + con.Uid + "','" + con.Nname + "','" + con.Ntext + "','" + con.Nimage + "'," + con.Npriority + ",'" + con.Ndate + "')";
            return dat.ExecuteQuery(sql);
        }

        public int Remove(int id)
        {
            string sql = "DELETE FROM DiaryContents WHERE Nid=" + id;
            return data.ExecuteQuery(sql);
        }
    }
}