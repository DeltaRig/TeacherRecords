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
        private long _biggestID;
        private string PATH = "./records.txt";

        public TeacherBiz()
        {
            _teachers = new List<Teacher>();
            UpdateDataCache();
        }

        public void UpdateDataCache()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(PATH);
                foreach (string line in lines)
                {
                    string[] lineToTeacher = line.Split(';');

                    long currentID = long.Parse(lineToTeacher[0]);
                    if (currentID > _biggestID)
                        _biggestID = currentID;

                    teachers.Add(new Teacher(currentID, lineToTeacher[1], lineToTeacher[2], lineToTeacher[3]));

                    Console.WriteLine("\t" + line);
                }
                _teachers = teachers;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                Console.WriteLine("Don't delete this file");
                Console.WriteLine("Creating a new file to solve this, will start empty");

                System.IO.File.Create(PATH);
                _teachers = teachers;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal IEnumerable<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        /**
         * @return teacher by ID
         */
        internal IEnumerable<Teacher> GetTeacherByID(long id)
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
        internal Boolean AddTeacher(string name, string c, string section)
        {
            try
            {
                _biggestID++;
                Teacher t = new Teacher(_biggestID, name, c, section);
                if(_teachers.Count() > 0)
                    File.AppendAllText(PATH, Environment.NewLine);
                File.AppendAllText(PATH,t.ToSaveInFile());
                _teachers.Add(t);
                return true;
            }
            catch (FileNotFoundException e) // to don't broke if someone delete the file while the program is running
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                Console.WriteLine("Creating a new file to solve this, will start empty");

                System.IO.File.Create(PATH);
                
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        // able to remove teacher
        internal Boolean RemoveTeacher(long id)
        {
            return false;

        //        var lines = File.ReadAllLines(usersPath).Where(line => line.Trim() != item).ToArray();
        //      File.WriteAllLines(usersPath, lines);
        }
        // able to update teacher

    }
}
