using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{
    /// <summary>
    /// Class <c>Menu</c> is a class to show the menu to user, to interact with TeacherBiz and show what the user choose in menu.
    /// </summary>
    class Menu
    {
        private TeacherBiz _teacherBiz;
        public Menu() {
            _teacherBiz = new TeacherBiz();
        }

        public Boolean CanStart()
        {
            return _teacherBiz.UpdateDataCache();
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
                        ShowAllTeachers();
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
                    case "5":
                        UpdateTeacher();
                        break;
                    case "0":
                        return;
                    default:
                        Default();
                        break;
                }
            } while (!option.Equals("0"));

        }

        private void ShowAllTeachers()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of teachers: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(_teacherBiz.GetAllTeachers());
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
                Console.WriteLine(t.GetToString());
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
                    SearchByID();
                    break;
                case "2":
                    SearchByName();
                    break;
                case "3":
                    SearchByClass();
                    break;
                case "4":
                    SearchBySection();
                    break;
                default:
                    Default();
                    break;
            }
            
        }

        private void SearchByID()
        {
            Console.WriteLine("What is the teacher's ID that you want search?");
            string answer = Console.ReadLine();
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
        }

        private void SearchByName()
        {
            Console.WriteLine("What is the teacher's name that you want search?");
            string answer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of teachers: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(_teacherBiz.GetTeachersByName(answer));
        }

        private void SearchByClass()
        {
            Console.WriteLine("What is the teacher's class that you want search?");
            string answer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of teachers: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(_teacherBiz.GetTeachersByClass(answer));
        }

        private void SearchBySection()
        {
            Console.WriteLine("What is the teacher's section that you want search?");
            string answer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of teachers: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(_teacherBiz.GetTeachersBySection(answer));
        }

        private void Default()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid option, try again");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void AddNewTeacher()
        {
            string verify = "0";
            string name;
            string classe;
            string section;
            do
            {
                Console.WriteLine("What is the teacher's name?");
                name = Console.ReadLine();
                Console.WriteLine("What is the teacher's class?");
                classe = Console.ReadLine();
                Console.WriteLine("What is the teacher's section?");
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

            Console.WriteLine("What is the teacher's ID?");
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
                    
                Console.WriteLine(toRemove.First().GetToString());
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

        private void UpdateTeacher()
        {
            ShowAllTeachers();
            Console.WriteLine("What is the teacher's ID that you want search?");
            String answer = Console.ReadLine();

            long id = -1L;
            try
            {
                id = long.Parse(answer);
                IEnumerable<Teacher> getID = _teacherBiz.GetTeacherByID(id);
                if (getID.Count() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("This is the teacher that will be update:");
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintList(getID);
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Invalid ID");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("You should write a numeric, " + ex);
                return;
            }

            string name = GetInfoToUpdate("name");
            string classe = GetInfoToUpdate("class");
            string section = GetInfoToUpdate("section");

            _teacherBiz.UpdateTeacher(id, name, classe, section);

        }

        private string GetInfoToUpdate(string variable) {
            string answer;
            Console.WriteLine("Do you want update the "+ variable+"?\nY (Yes) or N (No)");
            answer = Console.ReadLine();

            if (answer.Contains("Y"))
            {
                Console.WriteLine("What is the "+ variable + "s teacher?");
                return Console.ReadLine();
            }
            return null;
        }
    }
}
