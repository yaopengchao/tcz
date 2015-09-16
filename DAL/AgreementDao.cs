using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
    public class AgreementDao : CommonDao
    {

        public DataSet listAgreements(Dictionary<string, string> strWheres)
        {
            string strSql = "select AGREEMENT_ID, AGREEMENT_NAME, AGREEMENT_ENAME, AGREEMENT_TYPE, AGREEMENT from tcz_agreement where 1 = 1 ";
            return listEntity(strSql, strWheres);
        }

    }
}
