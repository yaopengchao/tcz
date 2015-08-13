using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
    public class ClassDao : CommonDao
    {
        //查询所有班级不进行分页
        public DataSet listClass(Dictionary<string, string> strWheres)
        {
            string strSql = "select class_id, class_name from sys_class where 1 = 1 ";
            return listEntity(strSql, strWheres);
        }

    }
}
