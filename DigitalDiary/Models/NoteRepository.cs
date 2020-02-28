using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class NoteRepository
    {
        DataAccess data;
        public NoteRepository()
        {
            data = new DataAccess();
        }

        public List<Note> GetAllNote()
        {
            string sql = "SELECT * FROM DiaryContent";
            SqlDataReader reader = data.GetData(sql);
            List<Note> noteList = new List<Note>();
            while (reader.Read())
            {
                Note n = new Note();
                n.contentNumber = Convert.ToInt32(reader["contentNumber"]);
                n.userId = Convert.ToInt32(reader["userId"]);
                n.contentText = reader["contentText"].ToString();
                n.contentLink = reader["contentLink"].ToString();
                n.contentPriority = reader["contentPriority"].ToString();
                n.contentDate = reader["contentDate"].ToString();
                noteList.Add(n);
            }
            return noteList;
        }
        /*
        public user Get(int id)
        {
            string sql = "SELECT * FROM DiaryUser WHERE userId=@userId";
            SqlDataReader reader = data.GetData(sql,id);
            user u = new user();
            if(reader.Read())
            {
                
                u.Id = Convert.ToInt32(reader["userId"]);
                u.Name = reader["userName"].ToString();
                u.Password = reader["userPassword"].ToString();
                
            }
            return u;
        }

        public int Update(user us)
        {
            string sql = "UPDATE DiaryUser SET userName='"+us.Name+"',userPassword='"+us.Password+"' WHERE userId="+us.Id;
            return data.ExecuteQuery(sql);
        }
         * */
        public int Insert(Note nt)
        {
            string sql = "INSERT INTO DiaryContent VALUES(" + nt.contentNumber + "," + nt.userId + ",'" + nt.contentText + "','" + nt.contentLink + "','" + nt.contentPriority + "','" + nt.contentDate + "')";
            return data.ExecuteQuery(sql);
        }
        /*
        public int Remove(int id)
        {
            string sql = "DELETE FROM DiaryUser WHERE userId="+id;
            return data.ExecuteQuery(sql);
        }
         */
    }
}