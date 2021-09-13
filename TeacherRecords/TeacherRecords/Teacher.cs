using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    class Teacher
    {
        private long _id;
        private string _name;
        private int _class;
        private string _section;

        public Teacher(long id,string name, int c, string section)
        {
            _id = id;
            _name = name;
            _class = c;
            _section = section;

        }
    }
}
