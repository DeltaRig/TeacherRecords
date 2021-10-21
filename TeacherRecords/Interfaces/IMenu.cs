using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords.Interfaces
{
    interface IMenu
    {
        /// <summary>
        /// Method <c>CanStart</c> is to stop the program if necessary without appear errors to the user.
        /// </summary>
        /// <returns>Return True if can start the menu and False if had some problem</returns>
        Boolean CanStart();

        /// <summary>
        /// Method <c>Start</c> start the menu, and will show the option to the user while don't input '0' to exit.
        /// </summary>
        void Start();

    }
}
