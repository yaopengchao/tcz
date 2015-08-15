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
        private static UserClassDao userClassDao;

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
            if (userClassDao == null)
            {
                userClassDao = new UserClassDao();
            }
            return instance;
        }

        //分页查询学生
        public DataSet listUsers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return userDao.listUsers(strWheres, startIndex, pageSize);
        }

        //查询学生数量
        public int countUsers(Dictionary<string, string> strWheres)
        {
            return userDao.countUsers(strWheres);
        }

        //分页查询教师
        public DataSet listTeachers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return userDao.listTeachers(strWheres, startIndex, pageSize);
        }

        //根据条件查询教师数量
        public int countTeachers(Dictionary<string, string> strWheres)
        {
            return userDao.countTeachers(strWheres);
        }

        //添加用户
        public int addUser(User user, int classId)
        {
            int result = 0;
            result = userDao.addUser(user);
            string userType = user.UserType;
            if ("3".Equals(userType))               //如果是学生的话
            {
                UserClass userClass = new UserClass();
                userClass.UserId = user.UserId;
                userClass.ClassId = classId;
                userClassDao.addUserClass(userClass);
            }
            return result;
        }

        //修改用户
        public int updateUser(User user)
        {
            return userDao.updateUser(user);
        }

        public int deleteUser(int userId)
        {
            userClassDao.deleteUserClassByUserId(userId);
            return userDao.deleteUser(userId);
        }

    }
}
