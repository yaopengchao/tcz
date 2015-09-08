using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

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

        public DataTable listExamResult(Dictionary<string, string> strWheres) {
            return examResultDao.listExamResults(strWheres).Tables[0];
        }

        public int addOrUpdateExamResult(ExamResult examResult)
        {
            int examResultId = examResult.ExamResultId;
            if (examResultId > 0)
            {
                return examResultDao.updateExamResult(examResult);
            }
            else
            {
                return examResultDao.addExamResult(examResult);
            }  
        }

    }
}
