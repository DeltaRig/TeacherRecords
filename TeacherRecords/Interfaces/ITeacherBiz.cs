using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    interface ITeacherBiz
    {
        /// <summary>
        /// The method <c>UpdateDataCache</c> read the text file 'records.txt' and save in cache the teachers data.
        /// </summary>
        /// <returns>Returns True if the file was read or created and False if something wrong happen.</returns>
        Boolean UpdateDataCache();

        /// <summary>
        /// The method <c>GetAllTeachers</c> is to the program could show all teachers that have data.
        /// </summary>
        /// <returns>return all teachers saved in the file</returns>
        IEnumerable<Teacher> GetAllTeachers();

        /// <sumary>
        /// Method <c>GetTeacherById</c> filter the list of teachers by this ID.
        /// </sumary>   
        /// <param name="id">This is the teacher's ID that will be search</param>
        /// <returns>>A list IEnumerable of the teache that have this name</returns>
        IEnumerable<Teacher> GetTeacherByID(long id);

        /// <summary>
        /// Method <c>GetTeacherByName</c> filter the list of teachers by this name.
        /// </summary>
        /// <param name="name">This is the teacher's name that will be search</param>
        /// <returns>A list IEnumerable of the teachers that have this name</returns>
        IEnumerable<Teacher> GetTeachersByName(string name);

        /// <summary>
        /// Method <c>GetTeacherByClass</c> filter the list of teachers by this class.
        /// </summary>
        /// <param name="c">Is the class's name that will be seach</param>
        /// <returns>A list IEnumerable of the teachers that have this class</returns>
        IEnumerable<Teacher> GetTeachersByClass(string c);

        /// <summary>
        /// Method <c>GetTeacherBySection</c> filter the list of teachers by this section.
        /// </summary>
        /// <param name="s">Is the section's name that will be seach</param>
        /// <returns>A list IEnumerable of the teachers that have this section</returns>
        IEnumerable<Teacher> GetTeachersBySection(string s);

        // able to add teacher
        /// <summary>
        /// Method <c>AddTeacher</c> will be a new teacher in the file text and in the cache list.
        /// </summary>
        /// <param name="name">The new teacher's name</param>
        /// <param name="c">The new teacher's class</param>
        /// <param name="section">The new teacher's section</param>
        /// <returns></returns>
        Boolean AddTeacher(string name, string c, string section);

        /// <summary>
        /// Method <c>RemoveTeacher</c> will remove the teacher that receive by parameter.
        /// </summary>
        /// <param name="toRemove">Determine what teacher will be removed</param>
        /// <returns>Return true if remove the teacher and false if fail to remove</returns>
        Boolean RemoveTeacher(Teacher toRemove);

        /// <summary>
        /// Method <c>UpdateTeacher</c> receive all parems of the teacher and will update what receive that is not null by the ID teacher. The ID teacher can't change and is unique.
        /// </summary>
        /// <param name="id">The teacher ID that will be have data update</param>
        /// <param name="name">The teacher's new name if is not null</param>
        /// <param name="classe">The teacher's new class if is not null</param>
        /// <param name="section">The teacher's new section if is not null</param>
        /// <returns></returns>
        Boolean UpdateTeacher(long id, string name, string classe, string section);
    }
}
