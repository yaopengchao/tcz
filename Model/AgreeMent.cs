using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 模拟人所有协议
    /// </summary>
    public class AgreeMent
    {


        public string agreement_id;


        public string Agreement_id
        {
            get { return agreement_id; }
            set { agreement_id = value; }
        }

        public string agreement_name;
        public string Agreement_name
        {
            get { return agreement_name; }
            set { agreement_name = value; }
        }
        public string agreement_ename;
        public string Agreement_ename
        {
            get { return agreement_ename; }
            set { agreement_ename = value; }
        }
        public string agreement_type;
        public string Agreement_type
        {
            get { return agreement_type; }
            set { agreement_type = value; }
        }
        public string agreement;
        public string Agreement
        {
            get { return agreement; }
            set { agreement = value; }
        }
    }
}
