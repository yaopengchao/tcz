using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginFrame
{
    public class WinServiceUtil
    {
        #region 检查服务存在的存在性  
        /// <summary>  
        /// 检查服务存在的存在性  
        /// </summary>  
        /// <param name=" NameService ">服务名</param>  
        /// <returns>存在返回 true,否则返回 false;</returns>  
        public static bool IsServiceIsExisted(string NameService)
        {
            return false;
        }
        #endregion



        #region 判断window服务是否启动  
        /// <summary>  
        /// 判断某个Windows服务是否启动  
        /// </summary>  
        /// <returns></returns>  
        public static bool IsServiceStart(string serviceName)
        {
            return false;
        }
        #endregion



        #region 启动服务  
        public static bool StartService(string serviceName)
        {
            return false;
         }
        #endregion
    }
}
