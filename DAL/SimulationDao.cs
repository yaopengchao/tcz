using Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace DAL
{
    public class SimulationDao
    {
        public bool add触诊人设置(触诊模拟人 _触诊模拟人,string user_name)
        {
            
            //检索是否存在该用户的信息
            
            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录没有正确退出
            strSql.Append(" select count(1) from tcz_czmnr ");
            strSql.Append(" where ");
            strSql.Append(" LOGIN_ID=?LOGIN_ID ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
            };

            parameters0[0].Value = user_name;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)//存在更新
            {
                strSql = new StringBuilder();
                strSql.Append(" update tcz_czmnr set 肝脏肿大='" + _触诊模拟人.肝脏肿大+"', ");
                strSql.Append(" 肝脏质地='" + _触诊模拟人.肝脏质地 + "', ");
                strSql.Append(" 脾脏肿大='" + _触诊模拟人.脾脏肿大 + "', ");
                strSql.Append(" 胆囊触痛='" + _触诊模拟人.胆囊触痛 + "', ");
                strSql.Append(" 胆囊肿大='" + _触诊模拟人.胆囊肿大 + "', ");
                strSql.Append(" 胆囊墨菲氏征='" + _触诊模拟人.胆囊墨菲氏征 + "', ");
                strSql.Append(" 压痛胃溃疡='" + _触诊模拟人.压痛胃溃疡 + "', ");
                strSql.Append(" 压痛十二指肠='" + _触诊模拟人.压痛十二指肠 + "', ");
                strSql.Append(" 压痛胰腺='" + _触诊模拟人.压痛胰腺 + "', ");
                strSql.Append(" 压痛阑尾='" + _触诊模拟人.压痛阑尾 + "', ");
                strSql.Append(" 压痛小肠='" + _触诊模拟人.压痛小肠 + "', ");
                strSql.Append(" 乙状结肠='" + _触诊模拟人.乙状结肠 + "', ");
                strSql.Append(" 反跳痛胰腺='" + _触诊模拟人.反跳痛胰腺 + "', ");
                strSql.Append(" 反跳痛阑尾='" + _触诊模拟人.反跳痛阑尾 + "', ");
                strSql.Append(" 反跳痛小肠='" + _触诊模拟人.反跳痛小肠 + "', ");
                strSql.Append(" 肠鸣音='" + _触诊模拟人.肠鸣音 + "', ");
                strSql.Append(" 肾动脉听诊音='" + _触诊模拟人.肾动脉听诊音 + "', ");
                strSql.Append(" 股动脉听诊音='" + _触诊模拟人.股动脉听诊音 + "', ");
                strSql.Append(" 脉搏='" + _触诊模拟人.脉搏 + "', ");
                strSql.Append(" 肠鸣音='" + _触诊模拟人.肠鸣音 + "', ");
                strSql.Append(" 血压收缩压='" + _触诊模拟人.血压收缩压 + "', ");
                strSql.Append(" 血压舒张压='" + _触诊模拟人.血压舒张压 + "' ");
                strSql.Append(" where ");
                strSql.Append(" LOGIN_ID=?LOGIN_ID ");
                MySqlParameter[] parameters1 = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
                };

                parameters1[0].Value = user_name;

                int rows1 = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters1);
                if (rows1 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else//不存在新增
            {
                strSql = new StringBuilder();
                strSql.Append(" insert into tcz_czmnr  ( LOGIN_ID,");
                strSql.Append(" 肝脏肿大,肝脏质地, 脾脏肿大,胆囊触痛, ");
                strSql.Append(" 胆囊肿大,胆囊墨菲氏征,压痛胃溃疡,压痛十二指肠,压痛胰腺,压痛阑尾,压痛小肠, ");
                strSql.Append(" 乙状结肠,反跳痛胰腺,反跳痛阑尾,反跳痛小肠,肠鸣音,肾动脉听诊音,股动脉听诊音,脉搏,血压收缩压,血压舒张压 ");
                strSql.Append(" ) values ( ?LOGIN_ID, ");
                strSql.Append(" '" + _触诊模拟人.肝脏肿大 + "', ");
                strSql.Append(" '" + _触诊模拟人.肝脏质地 + "', ");
                strSql.Append(" '" + _触诊模拟人.脾脏肿大 + "', ");
                strSql.Append(" '" + _触诊模拟人.胆囊触痛 + "', ");
                strSql.Append(" '" + _触诊模拟人.胆囊肿大 + "', ");
                strSql.Append(" '" + _触诊模拟人.胆囊墨菲氏征 + "', ");
                strSql.Append(" '" + _触诊模拟人.压痛胃溃疡 + "', ");
                strSql.Append(" '" + _触诊模拟人.压痛十二指肠 + "', ");
                strSql.Append(" '" + _触诊模拟人.压痛胰腺 + "', ");
                strSql.Append(" '" + _触诊模拟人.压痛阑尾 + "', ");
                strSql.Append(" '" + _触诊模拟人.压痛小肠 + "', ");
                strSql.Append(" '" + _触诊模拟人.乙状结肠 + "', ");
                strSql.Append(" '" + _触诊模拟人.反跳痛胰腺 + "', ");
                strSql.Append(" '" + _触诊模拟人.反跳痛阑尾 + "', ");
                strSql.Append(" '" + _触诊模拟人.反跳痛小肠 + "', ");
                strSql.Append(" '" + _触诊模拟人.肠鸣音 + "', ");
                strSql.Append(" '" + _触诊模拟人.肾动脉听诊音 + "', ");
                strSql.Append(" '" + _触诊模拟人.股动脉听诊音 + "', ");
                strSql.Append(" '" + _触诊模拟人.脉搏 + "', ");
                strSql.Append(" '" + _触诊模拟人.血压收缩压 + "', ");
                strSql.Append(" '" + _触诊模拟人.血压舒张压 + "' ");
                strSql.Append(" ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
                };

                parameters[0].Value = user_name;

                int rows = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public 触诊模拟人 get触诊人设置(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" 肝脏肿大,肝脏质地, 脾脏肿大,胆囊触痛, ");
            strSql.Append(" 胆囊肿大,胆囊墨菲氏征,压痛胃溃疡,压痛十二指肠,压痛胰腺,压痛阑尾,压痛小肠, ");
            strSql.Append(" 乙状结肠,反跳痛胰腺,反跳痛阑尾,反跳痛小肠,肠鸣音,肾动脉听诊音,股动脉听诊音,脉搏,血压收缩压,血压舒张压 ");
            strSql.Append(" from tcz_czmnr ");
            strSql.Append(" where ");
            strSql.Append(" LOGIN_ID = ?LOGIN_ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
            };

            parameters[0].Value = user_name;
          

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count ==1 )
            { 
                触诊模拟人 _触诊模拟人 = new 触诊模拟人();
                _触诊模拟人.肝脏肿大= Convert.ToString(ds.Tables[0].Rows[0]["肝脏肿大"].ToString());
                _触诊模拟人.肝脏质地 = Convert.ToString(ds.Tables[0].Rows[0]["肝脏质地"].ToString());
                _触诊模拟人.脾脏肿大 = Convert.ToString(ds.Tables[0].Rows[0]["脾脏肿大"].ToString());
                _触诊模拟人.胆囊触痛 = Convert.ToString(ds.Tables[0].Rows[0]["胆囊触痛"].ToString());
                _触诊模拟人.胆囊肿大 = Convert.ToString(ds.Tables[0].Rows[0]["胆囊肿大"].ToString());
                _触诊模拟人.胆囊墨菲氏征 = Convert.ToString(ds.Tables[0].Rows[0]["胆囊墨菲氏征"].ToString());
                _触诊模拟人.压痛胃溃疡 = Convert.ToString(ds.Tables[0].Rows[0]["压痛胃溃疡"].ToString());
                _触诊模拟人.压痛十二指肠 = Convert.ToString(ds.Tables[0].Rows[0]["压痛十二指肠"].ToString());
                _触诊模拟人.压痛胰腺 = Convert.ToString(ds.Tables[0].Rows[0]["压痛胰腺"].ToString());
                _触诊模拟人.压痛阑尾 = Convert.ToString(ds.Tables[0].Rows[0]["压痛阑尾"].ToString());
                _触诊模拟人.压痛小肠 = Convert.ToString(ds.Tables[0].Rows[0]["压痛小肠"].ToString());
                _触诊模拟人.乙状结肠 = Convert.ToString(ds.Tables[0].Rows[0]["乙状结肠"].ToString());
                _触诊模拟人.反跳痛胰腺 = Convert.ToString(ds.Tables[0].Rows[0]["反跳痛胰腺"].ToString());
                _触诊模拟人.反跳痛阑尾 = Convert.ToString(ds.Tables[0].Rows[0]["反跳痛阑尾"].ToString());
                _触诊模拟人.反跳痛小肠 = Convert.ToString(ds.Tables[0].Rows[0]["反跳痛小肠"].ToString());
                _触诊模拟人.肠鸣音 = Convert.ToString(ds.Tables[0].Rows[0]["肠鸣音"].ToString());
                _触诊模拟人.肾动脉听诊音 = Convert.ToString(ds.Tables[0].Rows[0]["肾动脉听诊音"].ToString());
                _触诊模拟人.股动脉听诊音 = Convert.ToString(ds.Tables[0].Rows[0]["股动脉听诊音"].ToString());
                _触诊模拟人.脉搏 = Convert.ToString(ds.Tables[0].Rows[0]["脉搏"].ToString());
                _触诊模拟人.血压收缩压 = Convert.ToString(ds.Tables[0].Rows[0]["血压收缩压"].ToString());
                _触诊模拟人.血压舒张压 = Convert.ToString(ds.Tables[0].Rows[0]["血压舒张压"].ToString());

                return _触诊模拟人;
            }
            return null;
        }


        public bool add听诊人设置(听诊模拟人 _听诊模拟人, string user_name)
        {

            //检索是否存在该用户的信息

            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录没有正确退出
            strSql.Append(" select count(1) from tcz_tzmnr ");
            strSql.Append(" where ");
            strSql.Append(" LOGIN_ID=?LOGIN_ID ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
            };

            parameters0[0].Value = user_name;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)//存在更新
            {
                strSql = new StringBuilder();
                strSql.Append(" update tcz_tzmnr set 心前区震颤='" + _听诊模拟人.心前区震颤 + "', ");
                strSql.Append(" 心尖搏动='" + _听诊模拟人.心尖搏动 + "', ");
                strSql.Append(" 二尖瓣听诊区='" + _听诊模拟人.二尖瓣听诊区 + "', ");
                strSql.Append(" 肺动脉瓣听诊区='" + _听诊模拟人.肺动脉瓣听诊区 + "', ");
                strSql.Append(" 主动脉瓣区='" + _听诊模拟人.主动脉瓣区 + "', ");
                strSql.Append(" 主动脉瓣第二听诊区='" + _听诊模拟人.主动脉瓣第二听诊区 + "', ");
                strSql.Append(" 三尖瓣区='" + _听诊模拟人.三尖瓣区 + "', ");
                strSql.Append(" 气管='" + _听诊模拟人.气管 + "', ");
                strSql.Append(" 左肺上='" + _听诊模拟人.左肺上 + "', ");
                strSql.Append(" 左肺中='" + _听诊模拟人.左肺中 + "', ");
                strSql.Append(" 左肺下='" + _听诊模拟人.左肺下 + "', ");
                strSql.Append(" 右肺上='" + _听诊模拟人.右肺上 + "', ");
                strSql.Append(" 右肺中='" + _听诊模拟人.右肺中 + "', ");
                strSql.Append(" 右肺下='" + _听诊模拟人.右肺下 + "' ");
                strSql.Append(" where ");
                strSql.Append(" LOGIN_ID=?LOGIN_ID ");
                MySqlParameter[] parameters1 = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
                };

                parameters1[0].Value = user_name;

                int rows1 = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters1);
                if (rows1 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else//不存在新增
            {
                strSql = new StringBuilder();
                strSql.Append(" insert into tcz_tzmnr  ( LOGIN_ID,");
                strSql.Append(" 心前区震颤,心尖搏动, 二尖瓣听诊区,肺动脉瓣听诊区, ");
                strSql.Append(" 主动脉瓣区,主动脉瓣第二听诊区,三尖瓣区,气管,左肺上,左肺中,左肺下, ");
                strSql.Append(" 右肺上,右肺中,右肺下 ");
                strSql.Append(" ) values ( ?LOGIN_ID, ");
                strSql.Append(" '" + _听诊模拟人.心前区震颤 + "', ");
                strSql.Append(" '" + _听诊模拟人.心尖搏动 + "', ");
                strSql.Append(" '" + _听诊模拟人.二尖瓣听诊区 + "', ");
                strSql.Append(" '" + _听诊模拟人.肺动脉瓣听诊区 + "', ");
                strSql.Append(" '" + _听诊模拟人.主动脉瓣区 + "', ");
                strSql.Append(" '" + _听诊模拟人.主动脉瓣第二听诊区 + "', ");
                strSql.Append(" '" + _听诊模拟人.三尖瓣区 + "', ");
                strSql.Append(" '" + _听诊模拟人.气管 + "', ");
                strSql.Append(" '" + _听诊模拟人.左肺上 + "', ");
                strSql.Append(" '" + _听诊模拟人.左肺中 + "', ");
                strSql.Append(" '" + _听诊模拟人.左肺下 + "', ");
                strSql.Append(" '" + _听诊模拟人.右肺上 + "', ");
                strSql.Append(" '" + _听诊模拟人.右肺中 + "', ");
                strSql.Append(" '" + _听诊模拟人.右肺下 + "' ");
                strSql.Append(" ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
                };

                parameters[0].Value = user_name;

                int rows = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public 听诊模拟人 get听诊人设置(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" 心前区震颤,心尖搏动, 二尖瓣听诊区,肺动脉瓣听诊区, ");
            strSql.Append(" 主动脉瓣区,主动脉瓣第二听诊区,三尖瓣区,气管,左肺上,左肺中,左肺下, ");
            strSql.Append(" 右肺上,右肺中,右肺下 ");
            strSql.Append(" from tcz_tzmnr ");
            strSql.Append(" where ");
            strSql.Append(" LOGIN_ID = ?LOGIN_ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?LOGIN_ID", MySqlDbType.VarChar)
            };

            parameters[0].Value = user_name;


            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count == 1)
            {
                听诊模拟人 _听诊模拟人 = new 听诊模拟人();
                _听诊模拟人.心前区震颤 = Convert.ToString(ds.Tables[0].Rows[0]["心前区震颤"].ToString());
                _听诊模拟人.心尖搏动 = Convert.ToString(ds.Tables[0].Rows[0]["心尖搏动"].ToString());
                _听诊模拟人.二尖瓣听诊区 = Convert.ToString(ds.Tables[0].Rows[0]["二尖瓣听诊区"].ToString());
                _听诊模拟人.肺动脉瓣听诊区 = Convert.ToString(ds.Tables[0].Rows[0]["肺动脉瓣听诊区"].ToString());
                _听诊模拟人.主动脉瓣第二听诊区 = Convert.ToString(ds.Tables[0].Rows[0]["主动脉瓣第二听诊区"].ToString());
                _听诊模拟人.三尖瓣区 = Convert.ToString(ds.Tables[0].Rows[0]["三尖瓣区"].ToString());
                _听诊模拟人.气管 = Convert.ToString(ds.Tables[0].Rows[0]["气管"].ToString());
                _听诊模拟人.左肺上 = Convert.ToString(ds.Tables[0].Rows[0]["左肺上"].ToString());
                _听诊模拟人.左肺中 = Convert.ToString(ds.Tables[0].Rows[0]["左肺中"].ToString());
                _听诊模拟人.左肺下 = Convert.ToString(ds.Tables[0].Rows[0]["左肺下"].ToString());
                _听诊模拟人.右肺上 = Convert.ToString(ds.Tables[0].Rows[0]["右肺上"].ToString());
                _听诊模拟人.右肺中 = Convert.ToString(ds.Tables[0].Rows[0]["右肺中"].ToString());
                _听诊模拟人.右肺下 = Convert.ToString(ds.Tables[0].Rows[0]["右肺下"].ToString());
                return _听诊模拟人;
            }
            return null;
        }



        
    }
}
