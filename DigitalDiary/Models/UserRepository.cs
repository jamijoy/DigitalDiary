using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class UserRepository
    {
        DataAccess data;
        public UserRepository()
        {
            data = new DataAccess();
        }

        public List<user> GetAll()
        {
            string sql = "SELECT * FROM DiaryUser";
            SqlDataReader reader = data.GetData(sql);
            List<user> userList = new List<user>();
            while (reader.Read())
            {
                user u = new user();
                u.Id = Convert.ToInt32(reader["userId"]);
                u.Name = reader["userName"].ToString();
                u.Password = reader["userPassword"].ToString();
                userList.Add(u);
            }
            return userList;
        }

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
        public int Insert(user us)
        {
            string sql = "INSERT INTO DiaryUser(userName,userPassword) VALUES('"+us.Name+"','"+us.Password+"')";
            return data.ExecuteQuery(sql);
        }

        public int Remove(int id)
        {
            string sql = "DELETE FROM DiaryUser WHERE userId="+id;
            return data.ExecuteQuery(sql);
        }
    }
}