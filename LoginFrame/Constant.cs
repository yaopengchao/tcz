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

        public static string 开机验证码 = "开机验证码";

        //触诊模拟人通信
        public static string 获取命令 = "获取命令";
        public static string 触诊通信标识码返回 = "触诊通信标识码返回";
        public static string 归零 = "归零";
        public static string 归零成功 = "归零成功";
        public static string 归零失败 = "归零失败";
        public static string 肝脏无肿大 = "肝脏无肿大";
        public static string 肝脏有肿大1 = "肝脏有肿大1";
        public static string 肝脏有肿大2 = "肝脏有肿大2";
        public static string 肝脏有肿大3 = "肝脏有肿大3";
        public static string 肝脏有肿大4 = "肝脏有肿大4";
        public static string 肝脏有肿大5 = "肝脏有肿大5";
        public static string 肝脏有肿大6 = "肝脏有肿大6";
        public static string 肝脏有肿大7 = "肝脏有肿大7";
        public static string 肝脏有肿大成功 = "肝脏有肿大成功";
        public static string 肝脏有肿大失败 = "肝脏有肿大失败";
        public static string 肝脏质地质软 = "肝脏质地质软";
        public static string 肝脏质地质硬 = "肝脏质地质硬";
        public static string 肝脏质地成功 = "肝脏质地成功";
        public static string 肝脏质地失败 = "肝脏质地失败";
        public static string 脾脏无肿大 = "脾脏无肿大";
        public static string 脾脏有肿大1 = "脾脏有肿大1";
        public static string 脾脏有肿大2 = "脾脏有肿大2";
        public static string 脾脏有肿大3 = "脾脏有肿大3";
        public static string 脾脏有肿大4 = "脾脏有肿大4";
        public static string 脾脏有肿大5 = "脾脏有肿大5";
        public static string 脾脏有肿大6 = "脾脏有肿大6";
        public static string 脾脏有肿大7 = "脾脏有肿大7";
        public static string 脾脏有肿大成功 = "脾脏有肿大成功";
        public static string 脾脏有肿大失败 = "脾脏有肿大失败";
        public static string 胆囊无肿大 = "胆囊无肿大";
        public static string 胆囊有肿大 = "胆囊有肿大";
        public static string 胆囊有肿大成功 = "胆囊有肿大成功";
        public static string 胆囊有肿大失败 = "胆囊有肿大失败";
        public static string 胆囊有触痛 = "胆囊有触痛";
        public static string 胆囊无触痛 = "胆囊无触痛";
        public static string 胆囊触痛成功 = "胆囊触痛成功";
        public static string 胆囊触痛失败 = "胆囊触痛失败";
        public static string 胆囊墨菲氏征有 = "胆囊墨菲氏征有";
        public static string 胆囊墨菲氏征无 = "胆囊墨菲氏征无";
        public static string 胆囊墨菲氏征成功 = "胆囊墨菲氏征成功";
        public static string 胆囊墨菲氏征失败 = "胆囊墨菲氏征失败";
        public static string 胃部压痛有 = "胃部压痛有";
        public static string 胃部压痛无 = "胃部压痛无";
        public static string 胃部压痛成功 = "胃部压痛成功";
        public static string 胃部压痛失败 = "胃部压痛失败";
        public static string 十二指肠有 = "十二指肠有";
        public static string 十二指肠无 = "十二指肠无";
        public static string 十二指肠成功 = "十二指肠成功";
        public static string 十二指肠失败 = "十二指肠失败";
        public static string 胰腺有 = "胰腺有";
        public static string 胰腺无 = "胰腺无";
        public static string 胰腺成功 = "胰腺成功";
        public static string 胰腺失败 = "胰腺失败";
        public static string 阑尾有 = "阑尾有";
        public static string 阑尾无 = "阑尾无";
        public static string 阑尾成功 = "阑尾成功";
        public static string 阑尾失败 = "阑尾失败";
        public static string 小肠有 = "小肠有";
        public static string 小肠无 = "小肠无";
        public static string 小肠成功 = "小肠成功";
        public static string 小肠失败 = "小肠失败";
        public static string 乙状结肠有 = "乙状结肠有";
        public static string 乙状结肠无 = "乙状结肠无";
        public static string 乙状结肠成功 = "乙状结肠成功";
        public static string 乙状结肠失败 = "乙状结肠失败";
        public static string 胰腺反跳痛有 = "胰腺反跳痛有";
        public static string 胰腺反跳痛无 = "胰腺反跳痛无";
        public static string 胰腺反跳痛成功 = "胰腺反跳痛成功";
        public static string 胰腺反跳痛失败 = "胰腺反跳痛失败";
        public static string 阑尾反跳痛有 = "阑尾反跳痛有";
        public static string 阑尾反跳痛无 = "阑尾反跳痛无";
        public static string 阑尾反跳痛成功 = "阑尾反跳痛成功";
        public static string 阑尾反跳痛失败 = "阑尾反跳痛失败";
        public static string 小肠反跳痛有 = "小肠反跳痛有";
        public static string 小肠反跳痛无 = "小肠反跳痛无";
        public static string 小肠反跳痛成功 = "小肠反跳痛成功";
        public static string 小肠反跳痛失败 = "小肠反跳痛失败";
        public static string 脉搏设置 = "脉搏设置";
        public static string 脉搏设置成功 = "脉搏设置成功";
        public static string 脉搏设置失败 = "脉搏设置失败";
        public static string 血压设置收缩压 = "血压设置收缩压";
        public static string 血压设置收缩压成功 = "血压设置收缩压成功";
        public static string 血压设置收缩压失败 = "血压设置收缩压失败";
        public static string 血压设置舒张压 = "血压设置舒张压";
        public static string 血压设置舒张压成功 = "血压设置舒张压成功";
        public static string 血压设置舒张压失败 = "血压设置舒张压失败";
        public static string 血压校准开始校准信号 = "血压校准开始校准信号";

        //听诊模拟人通信
        public static string 听诊通信标识码获取命令 = "听诊通信标识码获取命令";
        public static string 听诊通信标识码返回 = "听诊通信标识码返回";
        public static string 心前区震颤有 = "心前区震颤有";
        public static string 心前区震颤无 = "心前区震颤无";
        public static string 心前区震颤成功 = "心前区震颤成功";
        public static string 心前区震颤失败 = "心前区震颤失败";
        public static string 心尖搏动有 = "心尖搏动有";
        public static string 心尖搏动无 = "心尖搏动无";
        public static string 心尖搏动成功 = "心尖搏动成功";
        public static string 心尖搏动失败 = "心尖搏动失败";
        public static string 肺部开启听诊模式 = "肺部开启听诊模式";
        public static string 肺部关闭听诊模式 = "肺部关闭听诊模式";
        public static string 肺部接受听诊标签位置 = "肺部接受听诊标签位置";//TZLB0001代表标签1号
        public static string 肺部发送声音序号 = "肺部发送声音序号"; //TZSN1001代表听诊声音1001，1001声音文件名。

        public static string 腹部开启听诊模式 = "腹部开启听诊模式";
        public static string 腹部关闭听诊模式 = "腹部关闭听诊模式";
        public static string 腹部接受听诊标签位置 = "腹部接受听诊标签位置"; //CZLB0101 代表标签101号
        public static string 腹部发送声音序号 = "腹部发送声音序号"; //CZSN3001代表听诊声音3001，3001声音文件名。


    }
}
