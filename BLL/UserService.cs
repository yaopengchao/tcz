using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class UserService
    {

        private static UserDao userDao;

        private static UserService instance;

        public static UserService getInstance()
        {
            if (instance == null)
            {
                instance = new UserService();
            }
            if (userDao == null)
            {
                userDao = new UserDao();
            }
            return instance;
        }

        public DataSet listUsers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return userDao.listUsers(strWheres, startIndex, pageSize);
        }

        public int countUsers(Dictionary<string, string> strWheres)
        {
            return userDao.countUsers(strWheres);
        }

    }
}
