using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ClassInfo
    {

        public int classId;
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        public string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

    }
}
