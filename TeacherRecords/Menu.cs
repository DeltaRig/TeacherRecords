using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    class Menu
    {
        private TeacherBiz teacherBiz;
        public Menu() {
            teacherBiz = new TeacherBiz();
            /*teacherBiz = new TeacherBiz(
                new List<Teacher>{
                    new Teacher(1L, "Jurema", "200", "Fisic"),
                    new Teacher(2L, "Lucas", "200", "DataBase"),
                    new Teacher(3L, "Jorge", "201", "Math"),
                    new Teacher(4L, "Carlos", "202", "Literature"),
                    new Teacher(5L, "Carlos", "302", "Quimica")
                }
            );*/
        }
        public void Start()
        {
            string option = "";
            do {
                

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWellcome to a Teacher Records's Rainbow School");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. See all teachers \n" +
                                  "2. Search teachers \n" + 
                                  "0. exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("List of teachers: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        printList(teacherBiz.GetAllTeachers());
                        break;
                    case "2":
                        searchBy();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid option, try again");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!option.Equals("0"));

        }

        private void printList(IEnumerable<Teacher> list)
        {
            if (list == null || list.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Not data found");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            foreach(Teacher t in list)
            {
                Console.WriteLine(t);
            }
        }

        private void searchBy()
        {
            string answer = "";
            Console.WriteLine("1. Search teachers by ID\n" +
                             "2. Search teachers by name" +
                             "3. Search teachers by class\n" +
                             "4. Search teachers by section\n" +
                             "0. Come back to menu");
            answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.WriteLine("What is the teacher ID that you want search?");
                    answer = Console.ReadLine();
                    long id = -1L;
                    try
                    {
                        id = long.Parse(answer);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("You should write a numeric, " + ex);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    printList(teacherBiz.GetTeachersByID(id));
                    break;
                case "2":
                    Console.WriteLine("What is the teacher name that you want search?");
                    answer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    printList(teacherBiz.GetTeachersByName(answer));
                    break;
                case "3":
                    Console.WriteLine("What is the class's teacher that you want search?");
                    answer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    printList(teacherBiz.GetTeachersByClass(answer));
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid option, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            
        }
    }
}
