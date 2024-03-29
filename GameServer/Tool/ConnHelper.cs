﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GameServer.Tool
{
    class ConnHelper
    {
        public const string CONNECTIONSTRING = "datasource=localhost;port=3306;user=root;pwd=;database=game";

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection ConnDB()
        {
            MySqlConnection conn = new MySqlConnection(CONNECTIONSTRING);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("连接数据库发生异常，可能是连接字符串不对" + e);
                return null;
            }

        }

        /// <summary>
        /// 断开连接数据库
        /// </summary>
        public static void CloseConnDB(MySqlConnection conn)
        {
            if (conn!=null)
            {
                conn.Close();
            }
            else
            {
                Console.WriteLine("MySqlConnection-conn---不能关闭空对象");
            }
        }

    }
}
