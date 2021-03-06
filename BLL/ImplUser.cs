﻿using System.Data;
using DAL;


namespace BLL
{
    public class ImplUser
    {
        DAOUser daoUser = new DAOUser();


        public string getServerIp()
        {
            return daoUser.getServerIp();
        }
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int ExistsName(string loginId)
        {
            return daoUser.ExistsName(loginId);
        }

        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string loginId, string pwd,string user_type)
        {
            return daoUser.ExistsPwd(loginId, pwd, user_type);
        }

        public DataSet getUsersFromChatroom()
        {
            return daoUser.getUsersFromChatroom();
        }


        public bool logLogin(string username, string loginip)
        {
            return daoUser.logLogin(username, loginip);
        }


        public bool inChatroom(string username, string loginip)
        {
            return daoUser.inChatroom(username, loginip);
        }


        public bool outChatroom(string username)
        {
            return daoUser.outChatroom(username);
        }

        public DataSet getFavorites(string user_name)
        {
            return daoUser.getFavorites(user_name);
        }

        public bool addFavorite(string user_name,  string filename)
        {
            return daoUser.addFavorite(user_name,  filename);
        }

        public bool deleteFavorite(string user_name, string filename)
        {
            return daoUser.deleteFavorite(user_name, filename);
        }
    }
}
