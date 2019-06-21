using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;
using GameServer.DAO;
using GameServer.Model;

namespace GameServer.Controller
{
    class UserController :BaseController
    {
        UserDAO userDAO = new UserDAO();
        public UserController()
        {
            requestCode = RequestCode.User;
        }

        /// <summary>
        /// 登录请求（枚举类型转成字符串然后用MethodInfo调用这个方法）
        /// </summary>
        public string Login(string data, Client client, Server server)
        {
            string[] dataStrs = data.Split(',');
            User user = userDAO.VerifyUser(client.MySQLConn, dataStrs[0], dataStrs[1]);
            if (user == null)
            {
                //Enum.GetName(typeof(ReturnCode,ReturnCode.Fail));
                return ((int)ReturnCode.Fail).ToString();
            }
            else
            {
                return ((int)ReturnCode.Success).ToString();
            }
        }

    }
}
