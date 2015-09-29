using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 课件对象类
    /// </summary>
    public class Lesson
    {
        public int lesson_id;
        public int LESSON_ID
        {
            get { return lesson_id; }
            set { lesson_id = value; }
        }

        public string lesson_name;
        public string LESSON_NAME
        {
            get { return lesson_name; }
            set { lesson_name = value; }
        }
        public string lesson_ename;
        public string LESSON_ENAME
        {
            get { return lesson_ename; }
            set { lesson_ename = value; }
        }
        public string lesson_filename;
        public string LESSON_FILEENAME
        {
            get { return lesson_filename; }
            set { lesson_filename = value; }
        }
        public int lesson_class_id;
        public int LESSON_CLASS_ID
        {
            get { return lesson_class_id; }
            set { lesson_class_id = value; }
        }

        public string lesson_music_filename;

        public string LESSON_MUSIC_FILEENAME
        {
            get { return lesson_music_filename; }
            set { lesson_music_filename = value; }
        }


    }
}
