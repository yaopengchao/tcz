using System.Data;
using DAL;

namespace BLL
{
    public class ImplCourses
    {
        DAOCourses daoCourses = new DAOCourses();


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

    }
}
