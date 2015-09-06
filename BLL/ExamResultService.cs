using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ExamResultService
    {

        private static ExamResultDao examResultDao;

        private static ExamResultService instance;

        public static ExamResultService getInstance()
        {
            if (instance == null)
            {
                instance = new ExamResultService();
            }
            if (examResultDao == null)
            {
                examResultDao = new ExamResultDao();
            }

            return instance;
        }

        public int addExamResult(ExamResult examResult)
        {
            return examResultDao.addExamResult(examResult);
        }

    }
}
