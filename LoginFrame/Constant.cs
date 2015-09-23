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

        public static List<ExamType> getExamType()
        {
            List<ExamType> list = new List<ExamType>();
            //ExamType examType1 = new ExamType();
            //examType1.Id = "";
            //examType1.Name = "";
            //list.Add(examType1);

            ExamType examType2 = new ExamType();
            examType2.Id = "1";
            examType2.Name = "随机选题";
            list.Add(examType2);

            ExamType examType3 = new ExamType();
            examType3.Id = "2";
            examType3.Name = "手动选题";
            list.Add(examType3);

            return list;
        }

        public static string 开机验证码 = "1";

        //触诊模拟人通信
        public static string 获取命令 = "2";
        public static string 触诊通信标识码返回 = "3";
        public static string 归零 = "4";
        public static string 归零成功 = "5";
        public static string 归零失败 = "6";
        public static string 肝脏无肿大 = "7";
        public static string 肝脏有肿大1 = "8";
        public static string 肝脏有肿大2 = "9";
        public static string 肝脏有肿大3 = "10";
        public static string 肝脏有肿大4 = "11";
        public static string 肝脏有肿大5 = "12";
        public static string 肝脏有肿大6 = "13";
        public static string 肝脏有肿大7 = "14";
        public static string 肝脏有肿大成功 = "15";
        public static string 肝脏有肿大失败 = "16";
        public static string 肝脏质地质软 = "17";
        public static string 肝脏质地质硬 = "18";
        public static string 肝脏质地成功 = "19";
        public static string 肝脏质地失败 = "20";
        public static string 脾脏无肿大 = "21";
        public static string 脾脏有肿大1 = "22";
        public static string 脾脏有肿大2 = "23";
        public static string 脾脏有肿大3 = "24";
        public static string 脾脏有肿大4 = "25";
        public static string 脾脏有肿大5 = "25";
        public static string 脾脏有肿大6 = "26";
        public static string 脾脏有肿大7 = "27";
        public static string 脾脏有肿大成功 = "28";
        public static string 脾脏有肿大失败 = "29";
        public static string 胆囊无肿大 = "30";
        public static string 胆囊有肿大 = "31";
        public static string 胆囊有肿大成功 = "32";
        public static string 胆囊有肿大失败 = "33";
        public static string 胆囊有触痛 = "34";
        public static string 胆囊无触痛 = "35";
        public static string 胆囊触痛成功 = "36";
        public static string 胆囊触痛失败 = "37";
        public static string 胆囊墨菲氏征有 = "38";
        public static string 胆囊墨菲氏征无 = "39";
        public static string 胆囊墨菲氏征成功 = "40";
        public static string 胆囊墨菲氏征失败 = "41";
        public static string 胃部压痛有 = "42";
        public static string 胃部压痛无 = "43";
        public static string 胃部压痛成功 = "44";
        public static string 胃部压痛失败 = "45";
        public static string 十二指肠有 = "46";
        public static string 十二指肠无 = "47";
        public static string 十二指肠成功 = "48";
        public static string 十二指肠失败 = "49";
        public static string 胰腺有 = "50";
        public static string 胰腺无 = "51";
        public static string 胰腺成功 = "52";
        public static string 胰腺失败 = "53";
        public static string 阑尾有 = "54";
        public static string 阑尾无 = "55";
        public static string 阑尾成功 = "56";
        public static string 阑尾失败 = "57";
        public static string 小肠有 = "58";
        public static string 小肠无 = "59";
        public static string 小肠成功 = "60";
        public static string 小肠失败 = "61";
        public static string 乙状结肠有 = "62";
        public static string 乙状结肠无 = "63";
        public static string 乙状结肠成功 = "64";
        public static string 乙状结肠失败 = "65";
        public static string 胰腺反跳痛有 = "66";
        public static string 胰腺反跳痛无 = "67";
        public static string 胰腺反跳痛成功 = "68";
        public static string 胰腺反跳痛失败 = "69";
        public static string 阑尾反跳痛有 = "70";
        public static string 阑尾反跳痛无 = "71";
        public static string 阑尾反跳痛成功 = "72";
        public static string 阑尾反跳痛失败 = "73";
        public static string 小肠反跳痛有 = "74";
        public static string 小肠反跳痛无 = "75";
        public static string 小肠反跳痛成功 = "76";
        public static string 小肠反跳痛失败 = "77";
        public static string 脉搏设置 = "78";
        public static string 脉搏设置成功 = "79";
        public static string 脉搏设置失败 = "80";
        public static string 血压设置收缩压 = "81";
        public static string 血压设置收缩压成功 = "82";
        public static string 血压设置收缩压失败 = "83";
        public static string 血压设置舒张压 = "84";
        public static string 血压设置舒张压成功 = "85";
        public static string 血压设置舒张压失败 = "86";
        public static string 血压校准开始校准信号 = "87";

        //听诊模拟人通信
        public static string 听诊通信标识码获取命令 = "88";
        public static string 听诊通信标识码返回 = "89";
        public static string 心前区震颤有 = "90";
        public static string 心前区震颤无 = "91";
        public static string 心前区震颤成功 = "92";
        public static string 心前区震颤失败 = "93";
        public static string 心尖搏动有 = "94";
        public static string 心尖搏动无 = "95";
        public static string 心尖搏动成功 = "96";
        public static string 心尖搏动失败 = "97";
        public static string 肺部开启听诊模式 = "98";
        public static string 肺部关闭听诊模式 = "99";
        public static string 肺部接受听诊标签位置 = "100";//TZLB0001代表标签1号
        public static string 肺部发送声音序号 = "101"; //TZSN1001代表听诊声音1001，1001声音文件名。

        public static string 腹部开启听诊模式 = "102";
        public static string 腹部关闭听诊模式 = "103";
        public static string 腹部接受听诊标签位置 = "104"; //CZLB0101 代表标签101号
        public static string 腹部发送声音序号 = "105"; //CZSN3001代表听诊声音3001，3001声音文件名。


    }
}
