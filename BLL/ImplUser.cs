using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Model;


namespace BLL
{
    public class ImplUser
    {
        DAOUser daoUser = new DAOUser();

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int ExistsName(string username)
        {
            return daoUser.ExistsName(username);
        }

        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string username, string pwd)
        {
            return daoUser.ExistsPwd(username, pwd);
        }

    }
}
