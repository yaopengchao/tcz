using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class BP_Provience
    {
        DP_Provience Dal = new DP_Provience();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return Dal.GetList(strWhere);
        }
    }
}
