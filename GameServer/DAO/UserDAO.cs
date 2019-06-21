using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GameServer.Model;

namespace GameServer.DAO
{
    class UserDAO
    {
        /// <summary>
        /// 验证用户
        /// </summary>
        public User VerifyUser(MySqlConnection conn,string username,string password)
        {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from user where username =@username and password =@password",conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    //确实有这个用户就返回一个user对象
                    Console.WriteLine("有这个用户,账号密码是对的");
                    return new User(id, username, password);
                }
                else
                {
                    Console.WriteLine("没有这个用户，或者账号密码不对");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyUser方法验证用户失败" + e);
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }
            }
            return null;
        }
    }
}
