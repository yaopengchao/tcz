using System.Data;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class ImplCourses
    {

        private static ImplCourses instance;

        private static DAOCourses daoCourses;

        public static ImplCourses getInstance()
        {
            if (instance == null)
            {
                instance = new ImplCourses();
            }
            if (daoCourses == null)
            {
                daoCourses = new DAOCourses();
            }
            return instance;
        }




        public DataSet getAllCourses()
        {
            return daoCourses.getAllCourses();
        }


        public DataSet getCourses(string parentid)
        {
            return daoCourses.getCourses(parentid);
        }


        public DataSet getLessons(string parentid)
        {
            return daoCourses.getLessons(parentid);
        }


        public DataSet getSounds(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return daoCourses.getSounds(strWheres, startIndex, pageSize);
        }


        public int countSounds(Dictionary<string, string> strWheres)
        {
            return daoCourses.countSounds(strWheres);
        }

    }
}
