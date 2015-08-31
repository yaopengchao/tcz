using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

//常量定义类
namespace LoginFrame
{
    class Constant
    {
        public static string RoleTeacher = "2";//老师角色
        public static string RoleManager = "1";//管理员角色
        public static string RoleStudent = "3";//学生角色

        public static int zhCN= 0;//简体中文
        public static int En= 1;//英文

        public static string[] TOPIC_PRE = { "A", "B", "C", "D", "E", "F", "G" };

        public static List<TopicType> getTopicType()
        {
            List<TopicType> list = new List<TopicType>();
            TopicType topicType1 = new TopicType();
            topicType1.Id = "";
            topicType1.Name = "";
            list.Add(topicType1);

            TopicType topicType2 = new TopicType();
            topicType2.Id = "1";
            topicType2.Name = "理论类";
            list.Add(topicType2);

            TopicType topicType3 = new TopicType();
            topicType3.Id = "2";
            topicType3.Name = "操作类";
            list.Add(topicType3);

            return list;
        }

        public static string 开机验证码 = "FF000000000000PASSWORDFD";


    }
}
