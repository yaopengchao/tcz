﻿using System;
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

        //分页查询题目
        public DataSet listExams(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return examDao.listExams(strWheres, startIndex, pageSize);
        }

        public DataSet listExistDetail(Dictionary<string, string> strWheres)
        {
            return examDetailDao.listExistDetail(strWheres);
        }

        //查询题目数量
        public int countExams(Dictionary<string, string> strWheres)
        {
            return examDao.countExams(strWheres);
        }

        public DataSet getTopicCount(string type)
        {
            return examDao.getTopicCount(type);
        }

        public int addExam(Examination exam, string topicIds)
        {
            int examId = exam.ExaminationId;
            int flag = 0;
            if (examId < 1)
            {
                flag = examDao.addExam(exam);
                examId = exam.ExaminationId;
            }
            else
            {
                flag = examDao.updateExam(exam);
                examDetailDao.deleteExamDetail(exam.ExaminationId);
            }
            
            if (topicIds.IndexOf(",") > -1)
            {
                topicIds = topicIds.Substring(0, topicIds.Length - 1);
                string[] ids = topicIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    ExaminationDetail examDetail = new ExaminationDetail();
                    examDetail.ExaminationId = examId;
                    examDetail.TopicId = Convert.ToInt32(ids[i]);
                    examDetail.TopicOrder = i + 1;
                    examDetailDao.addExamDetail(examDetail);
                }
                
            }

            return flag;
        }

    }
}
