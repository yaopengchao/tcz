using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class DU_UserInfo
    {

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public int ExistsName(string U_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from users");
            strSql.Append(" where ");
            strSql.Append(" username = ?username  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?username", MySqlDbType.VarChar)
};
            parameters[0].Value = U_Name;

            return Convert.ToInt32(DBHelp.ExecuteScalar(strSql.ToString(), parameters));
        }


        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string username, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select username,truename,roleid from users");
            strSql.Append(" where ");
            strSql.Append(" username = ?username and password=?password ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?username", MySqlDbType.VarChar),
                    new MySqlParameter("?password", MySqlDbType.VarChar)
};
            parameters[0].Value = username;
            parameters[1].Value = pwd;

            DataSet ds = DBHelp.DateSet(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 根据用户名和密保问题查询出密码
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ShowPwd(string U_Name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 U_PassWord from U_UserInfo");
            strSql.Append(" where ");
            strSql.Append(" U_Name = @U_Name and U_PsdAnswer=@U_PsdAnswer ");
            SqlParameter[] parameters = {
					new SqlParameter("@U_Name", SqlDbType.VarChar,50),
                    new SqlParameter("@U_PsdAnswer", SqlDbType.VarChar,50)
};
            parameters[0].Value = U_Name;
            parameters[1].Value = pwd;

            DataSet ds = DBHelp.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MU_UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into U_UserInfo(");
            strSql.Append("U_LoginTime,U_RoleType,U_Name,U_Sex,U_PassWord,U_Birthday");
            strSql.Append(") values (");
            strSql.Append("@U_LoginTime,@U_RoleType,@U_Name,@U_Sex,@U_PassWord,@U_Birthday");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@U_LoginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@U_RoleType", SqlDbType.Int,4) ,            
                        new SqlParameter("@U_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_Sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@U_PassWord", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_Birthday", SqlDbType.DateTime)         
              
            };

            parameters[0].Value = model.U_LoginTime;
            parameters[1].Value = model.U_RoleType;
            parameters[2].Value = model.U_Name;
            parameters[3].Value = model.U_Sex;
            parameters[4].Value = model.U_PassWord;
            parameters[5].Value = model.U_Birthday;

            object obj = DBHelp.ExecuteNonQuery(strSql.ToString(), parameters);

            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        public bool UpdatePassword(string pwd, string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append(" password = ?password ");
            strSql.Append(" where username=?username ");

            MySqlParameter[] parameters = {
			            new MySqlParameter("?password", MySqlDbType.VarChar) ,            
                        new MySqlParameter("?username", MySqlDbType.VarChar)         
              
            };

            parameters[0].Value = pwd;
            parameters[1].Value = username;

            int rows = DBHelp.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更改密保
        /// </summary>
        /// <param name="type">密保类型</param>
        /// <param name="ask">密保回答</param>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public bool UpdateU_PsdAnswer(int type, string ask, long key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update U_UserInfo set ");
            strSql.Append(" U_PsdType= @U_PsdType,U_PsdAnswer=@U_PsdAnswer ");
            strSql.Append(" where U_Id=@U_Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@U_Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@U_PsdType", SqlDbType.Int),
                        new SqlParameter("@U_PsdAnswer", SqlDbType.VarChar,50) 
              
            };

            parameters[0].Value = key;
            parameters[1].Value = type;
            parameters[2].Value = ask;

            int rows = DBHelp.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MU_UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update U_UserInfo set ");

            strSql.Append(" U_NativePlace = @U_NativePlace , ");
            strSql.Append(" U_Address = @U_Address , ");
            strSql.Append(" U_Telephone = @U_Telephone , ");
            strSql.Append(" U_Email = @U_Email , ");
            strSql.Append(" U_PostalId = @U_PostalId , ");
            strSql.Append(" U_Position = @U_Position , ");
            strSql.Append(" U_RelName = @U_RelName , ");
            strSql.Append(" U_Sex = @U_Sex , ");
            strSql.Append(" U_Birthday = @U_Birthday , ");
            strSql.Append(" U_IdCard = @U_IdCard,  ");
            strSql.Append(" U_Image = @U_Image ,");
            strSql.Append(" U_QQ = @U_QQ ");
            strSql.Append(" where U_Id=@U_Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@U_Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@U_NativePlace", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@U_Address", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_Telephone", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_PostalId", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@U_Position", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@U_RelName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U_Sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@U_Birthday", SqlDbType.DateTime) ,            
                        new SqlParameter("@U_IdCard", SqlDbType.VarChar,20),
                        new SqlParameter("@U_Image", SqlDbType.Image),
                        new SqlParameter("@U_QQ", SqlDbType.VarChar,50)
              
            };

            parameters[0].Value = model.U_Id;
            parameters[1].Value = model.U_NativePlace;
            parameters[2].Value = model.U_Address;
            parameters[3].Value = model.U_Telephone;
            parameters[4].Value = model.U_Email;
            parameters[5].Value = model.U_PostalId;
            parameters[6].Value = model.U_Position;
            parameters[7].Value = model.U_RelName;
            parameters[8].Value = model.U_Sex;
            parameters[9].Value = model.U_Birthday;
            parameters[10].Value = model.U_IdCard;
            parameters[11].Value = model.U_Image;
            parameters[12].Value = model.U_QQ;

            int rows = DBHelp.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int U_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from U_UserInfo ");
            strSql.Append(" where U_Id=@U_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@U_Id", SqlDbType.Int,4)
};
            parameters[0].Value = U_Id;


            int rows = DBHelp.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string U_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from U_UserInfo ");
            strSql.Append(" where ID in (" + U_Idlist + ")  ");
            int rows = DBHelp.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MU_UserInfo GetModel(int U_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from U_UserInfo ");
            strSql.Append(" where U_Id=@U_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@U_Id", SqlDbType.Int,4)
};
            parameters[0].Value = U_Id;


            MU_UserInfo model = new MU_UserInfo();
            DataSet ds = DBHelp.DateSet(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["U_Id"].ToString() != "")
                {
                    model.U_Id = int.Parse(ds.Tables[0].Rows[0]["U_Id"].ToString());
                }
                model.U_NativePlace = ds.Tables[0].Rows[0]["U_NativePlace"].ToString();
                model.U_Address = ds.Tables[0].Rows[0]["U_Address"].ToString();
                model.U_Telephone = ds.Tables[0].Rows[0]["U_Telephone"].ToString();
                model.U_Email = ds.Tables[0].Rows[0]["U_Email"].ToString();
                model.U_PostalId = ds.Tables[0].Rows[0]["U_PostalId"].ToString();
                model.U_Position = ds.Tables[0].Rows[0]["U_Position"].ToString();
                model.U_Reamrk = ds.Tables[0].Rows[0]["U_Reamrk"].ToString();
                if (ds.Tables[0].Rows[0]["U_LoginTime"].ToString() != "")
                {
                    model.U_LoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["U_LoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["U_RoleType"].ToString() != "")
                {
                    model.U_RoleType = int.Parse(ds.Tables[0].Rows[0]["U_RoleType"].ToString());
                }
                model.U_Name = ds.Tables[0].Rows[0]["U_Name"].ToString();
                model.U_RelName = ds.Tables[0].Rows[0]["U_RelName"].ToString();
                if (ds.Tables[0].Rows[0]["U_Sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["U_Sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["U_Sex"].ToString().ToLower() == "true"))
                    {
                        model.U_Sex = true;
                    }
                    else
                    {
                        model.U_Sex = false;
                    }
                }
                model.U_PassWord = ds.Tables[0].Rows[0]["U_PassWord"].ToString();
                if (ds.Tables[0].Rows[0]["U_Birthday"].ToString() != "")
                {
                    model.U_Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["U_Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["U_PsdType"].ToString() != "")
                {
                    model.U_PsdType = int.Parse(ds.Tables[0].Rows[0]["U_PsdType"].ToString());
                }
                model.U_PsdAnswer = ds.Tables[0].Rows[0]["U_PsdAnswer"].ToString();
                model.U_IdCard = ds.Tables[0].Rows[0]["U_IdCard"].ToString();
                if (ds.Tables[0].Rows[0]["U_Image"].ToString() != "")
                {
                    model.U_Image = (byte[])ds.Tables[0].Rows[0]["U_Image"];
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM U_UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelp.DateSet(strSql.ToString());
        }

        /// <summary>
        /// 查询所有密保问题
        /// </summary>
        /// <returns></returns>
        public DataSet GetMP_PasswordType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from P_PasswordType");

            return DBHelp.DateSet(strSql.ToString());
        }

        /// <summary>
        /// 查询所有管理员| 用户信息
        /// </summary>
        /// <param name="roletype">1:普通用户 2:管理员</param>
        /// <returns></returns>
        public DataSet SelectAdmin(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U_Id as 用户编号,");
            strSql.Append(" U_Name as 用户名,U_RelName as 真实姓名,(case  U_Sex  when '0' then '男' when '1' then '女'  else ''  end  ) as 性别,");
            strSql.Append(" U_Birthday as 出身日期, U_IdCard as 身份证号,U_Address as 家庭住址,U_Telephone as 联系电话");
            strSql.Append(" from U_UserInfo");
            if (where != "")
            {
                strSql.Append(" where " + where);
            }
            return DBHelp.DateSet(strSql.ToString());
        }
    }
}
