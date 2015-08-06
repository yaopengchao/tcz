using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DAL;

namespace LoginFrame
{
    public class Common
    {
        //用户管理  
        public void Show用户管理()
        {
            Frm用户管理 yhgl = new Frm用户管理();
            yhgl.ShowDialog();
        }
        
        //使用帮助
        string FILE_NAME = Application.StartupPath + "\\Regedit";
        public void ShowHelp()
        {
            System.Diagnostics.Process.Start("Notepad.exe", FILE_NAME);
        }
        //关于
        public void ShowAbout()
        {
            Frm关于 about = new Frm关于();
            about.ShowDialog();
        }

        

        //密码修改
        public void UpdatePassword()
        {
            Frm密码修改 about = new Frm密码修改();
            about.ShowDialog();
        }

        //离开挂起
        public void KeepLeve()
        {
            Frm离开挂起 about = new Frm离开挂起();
            about.ShowDialog();
        }

        /// <summary>
        /// 判断身份证是否合法
        /// </summary>
        /// <param name="str">身份证号码</param>
        /// <returns>bool</returns>
        public bool RegexcardID(string str)
        {
            bool error = true;
            string zzbds = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$"; //设置正则表达式 
            Match m = Regex.Match(str, zzbds);//判断并得到结果
            if (!m.Success)//判断如果不符合正则表达式规则设置error为false;
            {
                error = false; ;
            }
            return error;
        }

        /// <summary>
        /// 判断邮箱是否合法
        /// </summary>
        /// <param name="str">邮箱号码</param>
        /// <returns>bool</returns>
        public bool RegexEmail(string str)
        {
            bool error = true;
            string zzbds = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"; //设置正则表达式 
            Match m = Regex.Match(str, zzbds);//判断并得到结果
            if (!m.Success)//判断如果不符合正则表达式规则设置error为false;
            {
                error = false; ;
            }
            return error;
        }

        /// <summary>
        /// 判断电话号码是否合法
        /// </summary>
        /// <param name="str">电话号码</param>
        /// <returns>bool</returns>
        public bool RegexPhone(string str)
        {
            bool error = true;
            string zzbds = @"^1(3[4-9]|5[012789]|8[78])\d{8}$"; //设置正则表达式 
            Match m = Regex.Match(str, zzbds);//判断并得到结果
            if (!m.Success)//判断如果不符合正则表达式规则设置error为false;
            {
                error = false; ;
            }
            return error;
        }


        #region	获得编码    示例为 and，Tcode 选中行的编码，Pcode 选中行的父编码 ，ForderCode，FParentCode 字段名称 Type 1 同级 2 下级 strWhere 条件
        /// <summary>
        /// 获得编码    示例为 and，Tcode 选中行的编码，Pcode 选中行的父编码 ，ForderCode，FParentCode 字段名称 Type 1 同级 2 下级 strWhere 条件
        /// </summary>
        public static string GetCode(string Tcode, string Pcode, string ForderCode, string FParentCode, string TableName, int Type, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(Max(" + ForderCode + "),0) from " + TableName + " ");
            string strCode = "";
            if (Type == 1)//添加同级节点
                strCode = Pcode;
            else
                strCode = Tcode;//添加下级节点
            strSql.Append(" where " + FParentCode + "='" + strCode + "' and " + strWhere + " ");
            DataSet ds = DBHelp.DateSet(strSql.ToString());
            if (Type == 1)
            {
                string Ycode = ds.Tables[0].Rows[0][0].ToString();
                string Rcode = Ycode.Substring(Ycode.Length - 3, 3);
                string Lcode = Ycode.Substring(0, Ycode.Length - 3);

                int Hcode = Convert.ToInt32(Rcode) + 1;
                Tcode = Lcode + Hcode.ToString().PadLeft(3, '0');

            }
            else
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    Tcode = strCode + "001";
                else
                {
                    string Ycode = ds.Tables[0].Rows[0][0].ToString();
                    string Rcode = Ycode.Substring(Ycode.Length - 3, 3);
                    string Lcode = Ycode.Substring(0, Ycode.Length - 3);
                    int Hcode = Convert.ToInt32(Rcode) + 1;
                    Tcode = Lcode + Hcode.ToString().PadLeft(3, '0');
                }
            }
            return Tcode;
        }
        #endregion
    }
}
