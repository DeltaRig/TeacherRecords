using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeacherRecords
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();

            if(menu.CanStart())
                menu.Start();
            else
            {
                Console.WriteLine("This program will close in 5 seconds.");
                Thread.Sleep(5000);
            }

        }
    }
}
