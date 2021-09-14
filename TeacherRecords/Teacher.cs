﻿using System;
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
        private string _class;
        private string _section;

        public Teacher(long id,string name, string c, string section)
        {
            _id = id;
            _name = name;
            _class = c;
            _section = section;

        }

        //getters and setters
        public long ID
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Class
        {
            get => _class;
            set => _class = value;
        }

        public string Section
        {
            get => _section;
            set => _section = value;
        }

        public override string ToString()
        {
            return "[" + _id + "] Name:" + _name + "; Class:" + _class + "; Section:" + _section + ";";
        }
    }
}