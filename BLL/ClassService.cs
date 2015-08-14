using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ClassService
    {

        private static ClassDao classDao;

        private static UserClassDao userClassDao;

        private static ClassService instance;

        public static ClassService getInstance()
        {
            if (instance == null)
            {
                instance = new ClassService();
            }
            if (classDao == null)
            {
                classDao = new ClassDao();
            }
            if (userClassDao == null)
                userClassDao = new UserClassDao();
            return instance;
        }

        //查询班级列表
        public DataSet listClass(Dictionary<string, string> strWheres)
        {
            return classDao.listClass(strWheres);
        }

        //添加班级
        public int addClass(ClassInfo classInfo)
        {
            return classDao.addClass(classInfo);
        }

        //修改班级
        public int updateClass(ClassInfo classInfo)
        {
            return classDao.updateClass(classInfo);
        }

        //删除班级
        public int deleteClass(int classId)
        {
            return classDao.deleteClass(classId);
        }

        public int getUserCount(int classId)
        {
            return userClassDao.getUsersCountByClassId(classId);
        }

    }
}
