using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    class TeacherBiz
    {
        private List<Teacher> _teachers;

        public TeacherBiz()
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();
                string[] lines = System.IO.File.ReadAllLines(@".\records.txt");
                foreach (string line in lines)
                {
                    string[] lineToTeacher = line.Split(';');
                    teachers.Add(new Teacher(long.Parse(lineToTeacher[0]), lineToTeacher[1], lineToTeacher[2], lineToTeacher[3]));

                    Console.WriteLine("\t" + line);
                }
                _teachers = teachers;
            } catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public TeacherBiz(List<Teacher> teachers)
        {
            _teachers = teachers;
        }

        /**
         * @return all teachers
        */
        public List<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        /**
         * @return teacher by ID
         */
        internal IEnumerable<Teacher> GetTeachersByID(long id)
        {
            var teachersByID = from teacher in _teachers
                                 where teacher.ID == id
                                 select teacher;
            return teachersByID;
        }

        /**
        * @return teacher by name
        */
        internal IEnumerable<Teacher> GetTeachersByName(string name)
        {
            var teachersByName = from teacher in _teachers
                                 where teacher.Name.ToUpper() == name.ToUpper()
                                 select teacher;
            return teachersByName;
        }

        internal IEnumerable<Teacher> GetTeachersByClass(string c)
        {
            var teachersByClass = from teacher in _teachers
                                 where teacher.Class.ToUpper() == c.ToUpper()
                                  select teacher;
            return teachersByClass;
        }

        internal IEnumerable<Teacher> GetTeachersBySection(string s)
        {
            var teachersBySection = from teacher in _teachers
                                  where teacher.Section.ToUpper() == s.ToUpper()
                                    select teacher;
            return teachersBySection;
        }

        // able to add teacher
        // able to update teacher
        // able to remove teacher
    }
}
