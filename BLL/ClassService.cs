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
            return instance;
        }

        public DataSet listClass(Dictionary<string, string> strWheres)
        {
            return classDao.listClass(strWheres);
        }

        public int addClass(ClassInfo classInfo)
        {
            return classDao.addClass(classInfo);
        }

    }
}
