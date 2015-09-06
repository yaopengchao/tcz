﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExaminationDao : CommonDao
    {

        //根据条件进行分页查询
        public DataSet listExams(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select examination_id, exam_name, if (exam_cat='1','理论类','操作类'), start_time, total_mins, exam_cat from ex_examination where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countExams(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_examination where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

        public DataTable getExamByExamId(int examId)
        {
            string strSql = "select a.EXAMINATION_ID, b.EXAMINATION_DETAIL_ID, b.TOPIC_ID, c.CONTENT from ex_examination a INNER JOIN ex_examination_detail b on a.EXAMINATION_ID = b.EXAMINATION_ID ";
            strSql += " INNER JOIN ex_topic c on b.TOPIC_ID = c.TOPIC_ID where a.EXAMINATION_ID = " + examId + " ORDER BY b.TOPIC_ORDER";
            return listEntity(strSql).Tables[0];
        }

        public DataSet getTopicCount(string type)
        {
            string strSql = "select a.TOPIC_CATEGORY, count(1) from ex_topic a ";
            if (type != null && !type.Equals(""))
            {
                strSql += " where a.TOPIC_TYPE = '" + type + "'";
            }
            strSql += " GROUP BY a.TOPIC_CATEGORY ";
            return listEntity(strSql, null);
        }

        public int addExam(Examination exam)
        {
            string strSql = "insert into ex_examination(EXAM_CAT, EXAM_NAME, START_TIME, TOTAL_MINS, SCORES, EX_TYPE) values(?examCat, ?examName, ?startTime, ?totalMins, ?scores, ?exType); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?scores", MySqlDbType.VarChar),
                new MySqlParameter("?exType", MySqlDbType.VarChar)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.Scores;
            parames[5].Value = exam.ExType;
            int examId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            exam.ExaminationId = examId;
            return examId;
        }

        public int updateExam(Examination exam)
        {
            string strSql = "update ex_examination set EXAM_CAT =?examCat, EXAM_NAME = ?examName, START_TIME = ?startTime, TOTAL_MINS = ?totalMins, EX_TYPE = ?exType where examination_id = ?examId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?exType", MySqlDbType.VarChar),
                new MySqlParameter("?examId", MySqlDbType.Int32)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.ExType;
            parames[5].Value = exam.ExaminationId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }

    }
}
