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
        private TeacherBiz _teacherBiz;
        public Menu() {
            _teacherBiz = new TeacherBiz();
            /*_teacherBiz = new _teacherBiz(
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
                Console.WriteLine("1. See all teachers data\n" +
                                  "2. Search teachers \n" + 
                                  "3. Add new teacher data\n" +
                                  "4. Remove teacher data \n" +
                                  "5. Update teacher data \n" +
                                  "0. exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("List of teachers: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        PrintList(_teacherBiz.GetAllTeachers());
                        break;
                    case "2":
                        SearchBy();
                        break;
                    case "3":
                        AddNewTeacher();
                        break;
                    case "4":
                        RemoveTeacher();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid option, try again");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!option.Equals("0"));

        }

        private void PrintList(IEnumerable<Teacher> list)
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

        private void SearchBy()
        {
            string answer = "";
            Console.WriteLine("1. Search teachers by ID\n" +
                             "2. Search teachers by name\n" +
                             "3. Search teachers by class\n" +
                             "4. Search teachers by section\n" +
                             "0. Come back to menu");
            answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.WriteLine("What is the ID's teacher that you want search?");
                    answer = Console.ReadLine();
                    long id = -1L;
                    try
                    {
                        id = long.Parse(answer);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("List of teachers: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        PrintList(_teacherBiz.GetTeacherByID(id));
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("You should write a numeric, " + ex);
                    }

                    break;
                case "2":
                    Console.WriteLine("What is the name's teacher that you want search?");
                    answer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintList(_teacherBiz.GetTeachersByName(answer));
                    break;
                case "3":
                    Console.WriteLine("What is the class's teacher that you want search?");
                    answer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintList(_teacherBiz.GetTeachersByClass(answer));
                    break;
                case "4":
                    Console.WriteLine("What is the section's teacher that you want search?");
                    answer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of teachers: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintList(_teacherBiz.GetTeachersBySection(answer));
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid option, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            
        }

        private void AddNewTeacher()
        {
            string verify = "0";
            string name;
            string classe;
            string section;
            do
            {
                Console.WriteLine("What is the name's teacher?");
                name = Console.ReadLine();
                Console.WriteLine("What is the class's teacher?");
                classe = Console.ReadLine();
                Console.WriteLine("What is the section's teacher?");
                section = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Name: " + name + "\nClass: " + classe + "\nSection: " + section);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Confirm\n" +
                                  "2. Try write again\n" +
                                  "0. Cancel and come back to menu\n");
                verify = Console.ReadLine();
                if (verify.Equals("0"))
                    return;

            } while (!verify.Equals("1"));

            if( _teacherBiz.AddTeacher(name, classe, section))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Teacher added with success!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void RemoveTeacher()
        {
            IEnumerable<Teacher> all = _teacherBiz.GetAllTeachers();
            if(all.Count() == 0)
            {
                Console.WriteLine("No have teachers to remove");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of teachers: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(all);

            Console.WriteLine("What is the ID's teacher?");
            string answer = Console.ReadLine();

            long id = -1L;
            Boolean removed = false;
            try
            {
                id = long.Parse(answer);

                IEnumerable<Teacher> toRemove = _teacherBiz.GetTeacherByID(id);

                if(toRemove.Count() == 0)
                {
                    Console.WriteLine("This don't correspond to a ID from the options");
                    return;
                }
                    
                Console.WriteLine(toRemove.First());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Confirm that you would like remove this teacher from database\n" +
                                  "0. Cancel and come back to menu\n");
                String verify = Console.ReadLine();
                if (verify.Equals("0"))
                    return;
                removed = _teacherBiz.RemoveTeacher(toRemove.First());
            }
            catch (IOException ex)
            {
                Console.WriteLine("You should write a numeric");
            }
            if (removed)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Teacher removed with success!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Problem to remove");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
