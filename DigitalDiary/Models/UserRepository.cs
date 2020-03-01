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

        public List<User> GetAll()
        {
            string sql = "Select * from DiaryUsers";
            SqlDataReader reader = data.GetData(sql);
            List<User> userList = new List<User>();

            while (reader.Read())
            {
                User u = new User();
                u.Uid = Convert.ToInt32(reader["Uid"]);
                u.Uname = reader["Uname"].ToString();
                u.Upassword = reader["Upassword"].ToString();
                userList.Add(u);
            }
            return userList;
        }

        public User Get(int id)
        {
            string sql = "select * form DiaryUsers where Uid=@Uid";
            SqlDataReader reader = data.GetData(sql,id);
            User u = new User();

            while (reader.Read())
            {
                u.Uid = Convert.ToInt32(reader["Uid"]);
                u.Uname = reader["Uname"].ToString();
                u.Upassword = reader["Upassword"].ToString();
            }
            return u;
        }

        public User GetDetailsByName(string name)
        {
            string sql = "select * from DiaryUsers where Uname='" + name + "'";
            SqlDataReader reader = data.GetData(sql);
            User u = new User();

            while (reader.Read())
            {
                u.Uid = Convert.ToInt32(reader["Uid"]);
                u.Uname = reader["Uname"].ToString();
                u.Upassword = reader["Upassword"].ToString();
            }
            return u;
        }

        public int IsValidate(string Uname,string Upassword)
        {
            string sql = "Select count(*) from DiaryUsers where Uname='"+Uname+"' and Upassword='"+Upassword+"'";
            return (int)data.validate(sql);
        }

        public int Update(User us)
        {
            string sql = "Update DiaryUser set Uname='"+us.Uname+"', Upassword='"+us.Upassword+"' where Uid="+us.Uid;
            return data.ExecuteQuery(sql);
        }

        public int Insert(string name, string password)
        {
            string sql = "insert into DiaryUsers values("+null+",'"+name+"','"+password+"')";
            return data.ExecuteQuery(sql);
        }
    }
}