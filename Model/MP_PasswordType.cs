using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class MP_PasswordType
    {
        /// <summary>
        /// P_Id
        /// </summary>		
        private int _p_id;
        public int P_Id
        {
            get { return _p_id; }
            set { _p_id = value; }
        }
        /// <summary>
        /// U_Name
        /// </summary>		
        private string _u_name;
        public string U_Name
        {
            get { return _u_name; }
            set { _u_name = value; }
        }
    }
}
