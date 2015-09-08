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

        public static string 开机验证码 = "FF  0000  0000  0000  PASSWORD  FD";

        //触诊模拟人通信
        public static string 获取命令 = "FF  0000  0000  0000  GetID  FD";
        public static string 触诊通信标识码返回 = "FF  0000  0000  0000  CZ  FD";
        public static string 归零 = "FF  0000  0000  0000  00000000  FD";
        public static string 归零成功 = "FF  0000  0000  0000  11111111  FD";
        public static string 归零失败 = "FF  0000  0000  0000  00000000  FD";
        public static string 肝脏无肿大 = "FF  0000  0000  0000  GanS0000  FD";
        public static string 肝脏有肿大1 = "FF  0000  0000  0000  GanS0001  FD";
        public static string 肝脏有肿大2 = "FF  0000  0000  0000  GanS0002  FD";
        public static string 肝脏有肿大3 = "FF  0000  0000  0000  GanS0003  FD";
        public static string 肝脏有肿大4 = "FF  0000  0000  0000  GanS0004  FD";
        public static string 肝脏有肿大5 = "FF  0000  0000  0000  GanS0005  FD";
        public static string 肝脏有肿大6 = "FF  0000  0000  0000  GanS0006  FD";
        public static string 肝脏有肿大7 = "FF  0000  0000  0000  GanS0007  FD";
        public static string 肝脏有肿大成功 = "FF  0000  0000  0000  PiZD1000  FD";
        public static string 肝脏有肿大失败 = "FF  0000  0000  0000  PiZD1111  FD";
        public static string 肝脏质地质软 = "FF  0000  0000  0000  GanZ0001  FD";
        public static string 肝脏质地质硬 = "FF  0000  0000  0000  GanZ0000  FD";
        public static string 肝脏质地成功 = "FF  0000  0000  0000  GanZ1000  FD";
        public static string 肝脏质地失败 = "FF  0000  0000  0000  GanZ1111  FD";
        public static string 脾脏无肿大 = "FF  0000  0000  0000  PiZD0000  FD";
        public static string 脾脏有肿大1 = "FF  0000  0000  0000  PiZD0001  FD";
        public static string 脾脏有肿大2 = "FF  0000  0000  0000  PiZD0002  FD";
        public static string 脾脏有肿大3 = "FF  0000  0000  0000  PiZD0003  FD";
        public static string 脾脏有肿大4 = "FF  0000  0000  0000  PiZD0004  FD";
        public static string 脾脏有肿大5 = "FF  0000  0000  0000  PiZD0005  FD";
        public static string 脾脏有肿大6 = "FF  0000  0000  0000  PiZD0006  FD";
        public static string 脾脏有肿大7 = "FF  0000  0000  0000  PiZD0007  FD";
        public static string 脾脏有肿大成功 = "FF  0000  0000  0000  PiZD1000  FD";
        public static string 脾脏有肿大失败 = "FF  0000  0000  0000  PiZD1111  FD";
        public static string 胆囊无肿大 = "FF  0000  0000  0000  DNZD0001  FD";
        public static string 胆囊有肿大 = "FF  0000  0000  0000  DNZD0000  FD";
        public static string 胆囊有肿大成功 = "FF  0000  0000  0000  DNZD1000  FD";
        public static string 胆囊有肿大失败 = "FF  0000  0000  0000  DNZD1111  FD";
        public static string 胆囊有触痛 = "FF  0000  0000  0000  DNCT0001  FD";
        public static string 胆囊无触痛 = "FF  0000  0000  0000  DNCT0000 FD";
        public static string 胆囊触痛成功 = "FF  0000  0000  0000  DNCT1000  FD";
        public static string 胆囊触痛失败 = "FF  0000  0000  0000  DNCT1111  FD";
        public static string 胆囊墨菲氏征有 = "FF  0000  0000  0000  MURP0001  FD";
        public static string 胆囊墨菲氏征无 = "FF  0000  0000  0000  MURP0000  FD";
        public static string 胆囊墨菲氏征成功 = "FF  0000  0000  0000  MURP1000  FD";
        public static string 胆囊墨菲氏征失败 = "FF  0000  0000  0000  MURP1111  FD";
        public static string 胃部压痛有 = "FF  0000  0000  0000  WBYT0001  FD";
        public static string 胃部压痛无 = "FF  0000  0000  0000  WBYT0000  FD";
        public static string 胃部压痛成功 = "FF  0000  0000  0000  WBYT1000  FD";
        public static string 胃部压痛失败 = "FF  0000  0000  0000  WBYT1111  FD";
        public static string 十二指肠有 = "FF  0000  0000  0000  SEZC0001  FD";
        public static string 十二指肠无 = "FF  0000  0000  0000  SEZC0000  FD";
        public static string 十二指肠成功 = "FF  0000  0000  0000  SEZC1000  FD";
        public static string 十二指肠失败 = "FF  0000  0000  0000  SEZC1111  FD";
        public static string 胰腺有 = "FF  0000  0000  0000  YXYT0001  FD";
        public static string 胰腺无 = "FF  0000  0000  0000  YXYT0000  FD";
        public static string 胰腺成功 = "FF  0000  0000  0000  YXYT1000  FD";
        public static string 胰腺失败 = "FF  0000  0000  0000  YXYT1111  FD";
        public static string 阑尾有 = "FF  0000  0000  0000  LWYT0001  FD";
        public static string 阑尾无 = "FF  0000  0000  0000  LWYT0000  FD";
        public static string 阑尾成功 = "FF  0000  0000  0000  LWYT1000  FD";
        public static string 阑尾失败 = "FF  0000  0000  0000  LWYT1111  FD";
        public static string 小肠有 = "FF  0000  0000  0000  XCYT0001  FD";
        public static string 小肠无 = "FF  0000  0000  0000  XCYT0000  FD";
        public static string 小肠成功 = "FF  0000  0000  0000  XCYT1000  FD";
        public static string 小肠失败 = "FF  0000  0000  0000  XCYT1111  FD";
        public static string 乙状结肠有 = "FF  0000  0000  0000  YZJC0001  FD";
        public static string 乙状结肠无 = "FF  0000  0000  0000  YZJC0000  FD";
        public static string 乙状结肠成功 = "FF  0000  0000  0000  YZJC1000  FD";
        public static string 乙状结肠失败 = "FF  0000  0000  0000  YZJC1111  FD";
        public static string 胰腺反跳痛有 = "FF  0000  0000  0000  FTTY0001  FD";
        public static string 胰腺反跳痛无 = "FF  0000  0000  0000  FTTY0000  FD";
        public static string 胰腺反跳痛成功 = "FF  0000  0000  0000  FTTY1000  FD";
        public static string 胰腺反跳痛失败 = "FF  0000  0000  0000  FTTY1111  FD";
        public static string 阑尾反跳痛有 = "FF  0000  0000  0000  FTTL0001  FD";
        public static string 阑尾反跳痛无 = "FF  0000  0000  0000  FTTL0000  FD";
        public static string 阑尾反跳痛成功 = "FF  0000  0000  0000  FTTL1000  FD";
        public static string 阑尾反跳痛失败 = "FF  0000  0000  0000  FTTL1111  FD";
        public static string 小肠反跳痛有 = "FF  0000  0000  0000  FTTX0001  FD";
        public static string 小肠反跳痛无 = "FF  0000  0000  0000  FTTX0000  FD";
        public static string 小肠反跳痛成功 = "FF  0000  0000  0000 FTTX1000  FD";
        public static string 小肠反跳痛失败 = "FF  0000  0000  0000  FTTX1111  FD";
        public static string 脉搏设置 = "FF  0000  0000  0000  MBTD0@  FD";
        public static string 脉搏设置成功 = "FF  0000  0000  0000  MBTD1000  FD";
        public static string 脉搏设置失败 = "FF  0000  0000  0000  MBTD1111  FD";
        public static string 血压设置收缩压 = "FF  0000  0000  0000  SSXY0@  FD";
        public static string 血压设置收缩压成功 = "FF  0000  0000  0000  SSXY1000  FD";
        public static string 血压设置收缩压失败 = "FF  0000  0000  0000  SSXY1111  FD";
        public static string 血压设置舒张压 = "FF  0000  0000  0000  SZXY0@  FD";
        public static string 血压设置舒张压成功 = "FF  0000  0000  0000  SZXY1000  FD";
        public static string 血压设置舒张压失败 = "FF  0000  0000  0000  SZXY1111  FD";
        public static string 血压校准开始校准信号 = "FF  0000  0000  0000  XYJZ0000  FD";

        //听诊模拟人通信
        public static string 听诊通信标识码获取命令 = "FF  0000  0000  0000  getID  FD";
        public static string 听诊通信标识码返回 = "FF  0000  0000  0000  TZ  FD";
        public static string 心前区震颤有 = "FF  0000  0000  0000  XQQZ0001  FD";
        public static string 心前区震颤无 = "FF  0000  0000  0000  XQQZ0000  FD";
        public static string 心前区震颤成功 = "FF  0000  0000  0000  XQQZ1000  FD";
        public static string 心前区震颤失败 = "FF  0000  0000  0000  XQQZ1111  FD";
        public static string 心尖搏动有 = "FF  0000  0000  0000  XJBD0001  FD";
        public static string 心尖搏动无 = "FF  0000  0000  0000  XJBD0000  FD";
        public static string 心尖搏动成功 = "FF  0000  0000  0000  XJBD1000  FD";
        public static string 心尖搏动失败 = "FF  0000  0000  0000  XJBD1111  FD";
        public static string 肺部开启听诊模式 = "FF  0000  0000  0000  TZON  FD";
        public static string 肺部关闭听诊模式 = "FF  0000  0000  0000  TZOFF  FD";
        public static string 肺部接受听诊标签位置 = "FF  0000  0000  0000  TZLB0001  FD";//TZLB0001代表标签1号
        public static string 肺部发送声音序号 = "FF  0000  0000  0000  TZSN1001 FD"; //TZSN1001代表听诊声音1001，1001声音文件名。

        public static string 腹部开启听诊模式 = "FF  0000  0000  0000  CZON  FD";
        public static string 腹部关闭听诊模式 = "FF  0000  0000  0000  CZOFF  FD";
        public static string 腹部接受听诊标签位置 = "FF  0000  0000  0000  CZLB0101 FD"; //CZLB0101 代表标签101号
        public static string 腹部发送声音序号 = "FF  0000  0000  0000  CZSN3001 FD"; //CZSN3001代表听诊声音3001，3001声音文件名。


    }
}
