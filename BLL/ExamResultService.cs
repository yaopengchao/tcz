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


        public DataTable listExamRightResult(Dictionary<string, string> strWheres)
        {
            return examResultDao.listExamRightResults(strWheres).Tables[0];
        }


        public DataTable getUserExams(Dictionary<string, string> strWheres)
        {
            return examResultDao.getUserExams(strWheres).Tables[0];
        }


        public DataTable getAllUserExams(Dictionary<string, string> strWheres)
        {
            return examResultDao.getAllUserExams(strWheres).Tables[0];
        }

        

        public DataSet listUserExamResult(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return examResultDao.listUserExamResult(strWheres, startIndex, pageSize);
        }


        public DataSet listExams(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return examResultDao.listExams(strWheres, startIndex, pageSize);
        }

        public int countUserExamResult(Dictionary<string, string> strWheres)
        {
            return examResultDao.countUserExamResult(strWheres);
        }

        public int countExams(Dictionary<string, string> strWheres)
        {
            return examResultDao.countExams(strWheres);
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
