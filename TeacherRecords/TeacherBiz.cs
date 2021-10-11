using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    class TeacherBiz : ITeacherBiz
    {
        private List<Teacher> _teachers;
        private long _biggestID;
        private string FILENAME = "\\records.txt";
        private string path;

        public TeacherBiz()
        {
            string dir = Directory.GetCurrentDirectory();
            path = dir + FILENAME;
            _teachers = new List<Teacher>();
            _biggestID = 0;
        }

        public Boolean UpdateDataCache()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);

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
                    return true;
                }
                else
                {
                    Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                    Console.WriteLine("Don't delete 'records.txt' file");
                    Console.WriteLine("Creating a new file to solve this, will start empty");

                    System.IO.File.Create(path);
                    _teachers = teachers;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong");
            }
            return false;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        /**
         * @return teacher by ID
         */
        public IEnumerable<Teacher> GetTeacherByID(long id)
        {
            var teachersByID = from teacher in _teachers
                                 where teacher.ID == id
                                 select teacher;
            return teachersByID;
        }

        /**
        * @return teacher by name
        */
        public IEnumerable<Teacher> GetTeachersByName(string name)
        {
            var teachersByName = from teacher in _teachers
                                 where teacher.Name.ToUpper() == name.ToUpper()
                                 select teacher;
            return teachersByName;
        }

        public IEnumerable<Teacher> GetTeachersByClass(string c)
        {
            var teachersByClass = from teacher in _teachers
                                 where teacher.Class.ToUpper() == c.ToUpper()
                                  select teacher;
            return teachersByClass;
        }

        public IEnumerable<Teacher> GetTeachersBySection(string s)
        {
            var teachersBySection = from teacher in _teachers
                                  where teacher.Section.ToUpper() == s.ToUpper()
                                    select teacher;
            return teachersBySection;
        }

        // able to add teacher
        public Boolean AddTeacher(string name, string c, string section)
        {
            try
            {
                _biggestID++;
                Teacher t = new Teacher(_biggestID, name, c, section);
                if(_teachers.Count() > 0)
                    File.AppendAllText(path, Environment.NewLine);
                File.AppendAllText(path,t.ToSaveInFile());
                _teachers.Add(t);
                return true;
            }
            catch (FileNotFoundException) // to don't broke if someone delete the file while the program is running
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                Console.WriteLine("Creating a new file to solve this, will start empty");

                System.IO.File.Create(path);
                
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        // able to remove teacher
        public Boolean RemoveTeacher(Teacher toRemove)
        {
            try
            {
                var lines = File.ReadAllLines(path).Where(line => ! line.Equals(toRemove.ToSaveInFile()) ).ToArray();
                File.WriteAllLines(path, lines);
                _teachers.Remove(toRemove);
                return true;

            }
            catch (FileNotFoundException) // to don't broke if someone delete the file while the program is running
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                Console.WriteLine("Creating a new file to solve this, will start empty");

                System.IO.File.Create(path);

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        // able to update teacher
        public Boolean UpdateTeacher(long id, string name, string classe, string section) {
            int position = SearchById(id);
            if(position == -1)
                return false;
            if (!String.IsNullOrEmpty(name))
                _teachers[position].Name = name;
            if (!String.IsNullOrEmpty(classe))
                _teachers[position].Class = classe;
            if (!String.IsNullOrEmpty(section))
                _teachers[position].Section = section;

            try
            {
                File.WriteAllLines(path, PassToString());
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        /// <summary>
        /// Method <c>SearchById</c> search a teacher in the list by ID
        /// </summary>
        /// <param name="search">Is the ID that will be search</param>
        /// <returns>Return the position or -1 if don't find</returns>
        private int SearchById(long search)
        {
            int minNum = 0;
            int maxNum = _teachers.Count() - 1;

            int foundElem = -1;

            while (minNum <= maxNum && foundElem == -1)
            {
                int mid;
                if (search < _teachers.Count())
                    mid = (int)search;
                else
                    mid = (minNum + maxNum) / 2;
                if (search == _teachers[mid].ID)
                {
                    foundElem = mid;
                    break;
                }
                else if (search < _teachers[mid].ID)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return foundElem;
        }

        /// <summary>
        /// Method <c>PassToString</c> convert the teachers's list to a string[] in the format to save in the file
        /// </summary>
        /// <returns>The array of teacher to save in the file</returns>
        private string[] PassToString() {
            string[] teachersString = new string[_teachers.Count()];

            int i = 0;
            foreach(Teacher t in _teachers)
            {
                teachersString[i] = t.ToSaveInFile();
                i++;
            }

            return teachersString;
        }

        void ITeacherBiz.UpdateDataCache()
        {
            throw new NotImplementedException();
        }
    }
}
