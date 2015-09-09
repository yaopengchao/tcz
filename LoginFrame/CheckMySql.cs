using System;

namespace TherapeuticApparatus.CommonMethod
{
    public class CheckMySql
    {
        #region ���������Ƿ�װMySql
        ///<summary> 
        /// ����Ƿ�װoffice 
        ///</summary> 
        ///<param name="office_Version"> ��ò����ذ�װ��office�汾</param> 
        ///<returns></returns> 
        public static bool hasInstalledMySql(out string mySql_Version, out string mySql_Path)
        {
            bool result = false;
            string str_MySqlPath = string.Empty;
            string str_MySqlVersion = string.Empty;
            mySql_Version = string.Empty;
            mySql_Path = string.Empty;

            GetMySqlPath(out str_MySqlPath, out str_MySqlVersion);
            if (!string.IsNullOrEmpty(str_MySqlVersion) && !string.IsNullOrEmpty(str_MySqlPath))
            {
                result = true;
                mySql_Version = str_MySqlVersion;
                mySql_Path = str_MySqlPath;
            }
            return result;
        }

        ///<summary> 
        /// ��ȡ�����ص�ǰ��װ��MySql�汾�Ͱ�װ·�� 
        ///</summary> 
        ///<param name="str_OfficePath">MySql�İ�װ·��</param> 
        ///<param name="str_OfficeVersion">MySql�İ�װ�汾</param> 
        private static void GetMySqlPath(out string str_MySqlPath, out string str_MySqlVersion)
        {
            string str_PathResult = string.Empty;
            string str_VersionResult = string.Empty;

            Microsoft.Win32.RegistryKey regKey = null;//��ʾ Windows ע����е���ڵ�(ע������?) 
            Microsoft.Win32.RegistryKey regSubKey = null;
            try
            {
                regKey = Microsoft.Win32.Registry.LocalMachine;//��ȡHKEY_LOCAL_MACHINE�� 
                //ϵͳ���Ƿ����MySQL Sever 5.6
                if (regSubKey == null)
                {
                    string keyPath = @"SOFTWARE\MySQL AB\MySQL Server 5.6";
                    regSubKey = regKey.OpenSubKey(keyPath, false);
                }
                //ϵͳ���Ƿ����MySQL Sever 5.5
                if (regSubKey == null)
                {
                    string keyPath = @"SOFTWARE\MySQL AB\MySQL Server 5.5";
                    regSubKey = regKey.OpenSubKey(keyPath, false);
                }
                //ϵͳ���Ƿ����MySQL Sever 5.4
                if (regSubKey == null)
                {
                    string keyPath = @"SOFTWARE\MySQL AB\MySQL Server 5.4";
                    regSubKey = regKey.OpenSubKey(keyPath, false);
                }
                //ϵͳ���Ƿ����MySQL Sever 5.1
                if (regSubKey == null)
                {
                    string keyPath = @"SOFTWARE\MySQL AB\MySQL Server 5.1";
                    regSubKey = regKey.OpenSubKey(keyPath, false);
                }
                //ϵͳ���Ƿ����MySQL Sever 5.0
                if (regSubKey == null)
                {
                    string keyPath = @"SOFTWARE\MySQL AB\MySQL Server 5.0";
                    regSubKey = regKey.OpenSubKey(keyPath, false);
                }
                //�õ�·���Ͱ汾
                if (regSubKey.GetValue("Location") != null)
                {
                    str_PathResult = regSubKey.GetValue("Location").ToString();
                }
                if (regSubKey.GetValue("Version") != null)
                {
                    str_VersionResult = regSubKey.GetValue("Version").ToString();
                }

            }
            catch (Exception ex)
            {
                
            }

            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                    regKey = null;
                }

                if (regSubKey != null)
                {
                    regSubKey.Close();
                    regSubKey = null;
                }
            }
            str_MySqlPath = str_PathResult;
            str_MySqlVersion = str_VersionResult;
        }
        #endregion
    }
}
