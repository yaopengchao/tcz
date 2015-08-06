using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BU_UserInfo
    {
        DU_UserInfo UserInfo = new DU_UserInfo();
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public int ExistsName(string U_Name)
        {
            return UserInfo.ExistsName(U_Name);
        }


        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string U_Name, string pwd)
        {
            return UserInfo.ExistsPwd(U_Name, pwd);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MU_UserInfo model)
        {
            return UserInfo.Add(model);
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        public bool UpdatePassword(string pwd, string username)
        {
            return UserInfo.UpdatePassword(pwd, username);
        }

        /// <summary>
        /// 查询所有密保问题
        /// </summary>
        /// <returns></returns>
        public DataSet GetMP_PasswordType()
        {
            return UserInfo.GetMP_PasswordType();
        }


        /// <summary>
        /// 根据用户名和密保问题查询出密码
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ShowPwd(string U_Name, string pwd)
        {
            return UserInfo.ShowPwd(U_Name, pwd);
        }

        /// <summary>
        /// 更改密保
        /// </summary>
        /// <param name="type">密保类型</param>
        /// <param name="ask">密保回答</param>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public bool UpdateU_PsdAnswer(int type, string ask, int key)
        {
            return UserInfo.UpdateU_PsdAnswer(type, ask, key);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MU_UserInfo GetModel(int U_Id)
        {
            return UserInfo.GetModel(U_Id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MU_UserInfo model)
        {
            return UserInfo.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int U_Id)
        {
            return UserInfo.Delete(U_Id);
        }

        /// <summary>
        /// 查询所有管理员| 用户信息
        /// </summary>
        /// <param name="roletype">1:普通用户 2:管理员</param>
        /// <returns></returns>
        public DataSet SelectAdmin(string where)
        {
            return UserInfo.SelectAdmin(where);
        }
    }
}
