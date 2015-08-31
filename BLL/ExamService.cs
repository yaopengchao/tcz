using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ExamService
    {

        private static ExaminationDao examDao;

        private static ExaminationDetailDao examDetailDao;

        private static ExamService instance;

        public static ExamService getInstance()
        {
            if (instance == null)
            {
                instance = new ExamService();
            }
            if (examDao == null)
            {
                examDao = new ExaminationDao();
            }
            if (examDetailDao == null)
            {
                examDetailDao = new ExaminationDetailDao();
            }
            return instance;
        }

    }
}
