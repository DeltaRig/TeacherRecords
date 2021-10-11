using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    interface ITeacherBiz
    {
        void UpdateDataCache();

        IEnumerable<Teacher> GetAllTeachers();

        /**
         * @return teacher by ID
         */
        IEnumerable<Teacher> GetTeacherByID(long id);

        IEnumerable<Teacher> GetTeachersByName(string name);

        IEnumerable<Teacher> GetTeachersByClass(string c);

        IEnumerable<Teacher> GetTeachersBySection(string s);

        // able to add teacher
        Boolean AddTeacher(string name, string c, string section);

        // able to remove teacher
        Boolean RemoveTeacher(Teacher toRemove);

        Boolean UpdateTeacher(long id, string name, string classe, string section);
    }
}
