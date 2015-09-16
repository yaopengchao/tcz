using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class AgreementService
    {

        private static AgreementDao agreementDao;

        private static AgreementService instance;

        public static AgreementService getInstance()
        {
            if (instance == null)
            {
                instance = new AgreementService();
            }
            if (agreementDao == null)
            {
                agreementDao = new AgreementDao();
            }
            return instance;
        }

        public DataSet listAgreements(Dictionary<string, string> strWheres)
        {
            return agreementDao.listAgreements(strWheres);
        }

    }
}
