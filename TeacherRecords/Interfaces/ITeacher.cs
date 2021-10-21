using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords.Interfaces
{
    interface ITeacher
    {
        /// <summary>
        /// Method <c>ToSaveInFile</c> is to return a string with the format to save in the text file.
        /// </summary>
        /// <returns>A string that contains ID,name,class and section separete by comma</returns>
        string ToSaveInFile();

        /// <summary>
        /// Method <c>GetToString</c> return a string with the teacher's information to show to the user.
        /// </summary>
        /// <returns>This string contains the teacher's information to show to the user</returns>
        string GetToString();
    }
}
