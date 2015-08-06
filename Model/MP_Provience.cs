using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MP_Provience
    {
        /// <summary>
        /// P_ID
        /// </summary>		
        private int _p_id;
        public int P_ID
        {
            get { return _p_id; }
            set { _p_id = value; }
        }
        /// <summary>
        /// P_Name
        /// </summary>		
        private string _p_name;
        public string P_Name
        {
            get { return _p_name; }
            set { _p_name = value; }
        }
    }
}
