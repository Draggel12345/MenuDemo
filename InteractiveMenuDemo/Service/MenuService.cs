using InteractiveMenuDemo.Entitys;
using InteractiveMenuDemo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace InteractiveMenuDemo.Service
{
    class MenuService : InputService
    {
        private readonly PersonServiceImpl service = new();
        public void Start()
        {
            Title = "Interactive Menu Demo";
            service.Add(new Person("male", "Anton Edholm", "anton@mail.com", 26, "123456789"));
            service.Add(new Person("female", "Anna Hjulstrom", "anna@mail.com", 18, "987654321"));
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            CursorVisible = false;
            string prompt = @"
                                          ███╗   ███╗ █████╗ ██╗███╗   ██╗
                                          ████╗ ████║██╔══██╗██║████╗  ██║
                                          ██╔████╔██║███████║██║██╔██╗ ██║
                                          ██║╚██╔╝██║██╔══██║██║██║╚██╗██║
                                          ██║ ╚═╝ ██║██║  ██║██║██║ ╚████║
                                          ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝                                                                     
                              Use the up and down arrow keys to navigate in the menu
                                          and press enter to interact.";
            string[] options = { "Register Person", "Remove Person", "Find Members", "About", "Exit" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();
            
            switch (selectedIndex)
            {
                case 0:
                    {
                        Register();
                        break;
                    }
                case 1:
                    {
                        RemovePerson();
                        break;
                    }
                case 2:
                    {
                        DisplayFindMenu();
                        break;
                    }
                case 3:
                    {
                        DisplayAboutMenu();
                        break;
                    }
                case 4:
                    {
                        ExitApplication();
                        break;
                    }
            }
        }

        private void DisplayFindMenu()
        {
            CursorVisible = false;
            string prompt = @"
                                           ███████╗██╗███╗   ██╗██████╗ 
                                           ██╔════╝██║████╗  ██║██╔══██╗
                                           █████╗  ██║██╔██╗ ██║██║  ██║
                                           ██╔══╝  ██║██║╚██╗██║██║  ██║
                                           ██║     ██║██║ ╚████║██████╔╝
                                           ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝ ";
            string[] options = { "All Members", "Find All Males", "Find All Females", "Find By Id", "Return To Main Menu" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        PrintOutAllMembers();
                        break;
                    }
                case 1:
                    {
                        PrintOutAllMales();
                        break;
                    }
                case 2:
                    {
                        PrintOutAllFemales();
                        break;
                    }
                case 3:
                    {
                        FindPersonById();
                        break;
                    }
                case 4:
                    {
                        RunMainMenu();
                        break;
                    }
            }
        }

        private void Register()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@" 
                                ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗ 
                                ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
                                ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝
                                ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗
                                ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║
                                ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝
");
            Write("\t\t\t\tEnter in your full name: ");
            string fullName = GetString();
            Write("\t\t\t\tEnter in your sex: ");
            string gender = GetString().ToLower();
            Write("\t\t\t\tEnter in your age: ");
            int age = GetInt();
            Write("\t\t\t\tEnter in your email: ");
            string email = GetString();
            Write("\t\t\t\tEnter in your phone number: ");
            string phone = GetString();
            service.Add(new(gender, fullName, email, age, phone));
            WriteLine("\t\t\t\tInfo saved...");
            WriteLine("\n\t\t\t\tPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void RemovePerson()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
                                      ██████╗ ███████╗███╗   ███╗ ██████╗ ██╗   ██╗███████╗
                                      ██╔══██╗██╔════╝████╗ ████║██╔═══██╗██║   ██║██╔════╝
                                      ██████╔╝█████╗  ██╔████╔██║██║   ██║██║   ██║█████╗  
                                      ██╔══██╗██╔══╝  ██║╚██╔╝██║██║   ██║╚██╗ ██╔╝██╔══╝  
                                      ██║  ██║███████╗██║ ╚═╝ ██║╚██████╔╝ ╚████╔╝ ███████╗
                                      ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝   ╚═══╝  ╚══════╝                                                    
                                        Enter in the persons ID to remove them");
            Write("\t\t\t\t\tID: ");
            int id = GetInt();
            Person found = service.FindById(id);
            if (found == null)
            {
                WriteLine("\n\t\t\t\t\tPress any key to return to main menu.");
                ReadKey(true);
                RunMainMenu();
            }
            WriteLine($"\t\t\t\t\tPerson to remove :\n{found}");
            Write($"\n\t\t\t\t\tAre you sure you want to delete {found.FullName}? (Yes/No): ");
            string answer = GetString().ToLower();
            if (answer == "yes")
            {
                service.Delete(found.Id);
                WriteLine("\t\t\t\t\tThe person have been deleted from the list.");
            }

            WriteLine("\t\t\t\t\tPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void PrintOutAllMembers()
        {
            Clear();
            WriteLine(@"
                                         ███╗   ███╗███████╗███╗   ███╗██████╗ ███████╗██████╗ ███████╗
                                         ████╗ ████║██╔════╝████╗ ████║██╔══██╗██╔════╝██╔══██╗██╔════╝
                                         ██╔████╔██║█████╗  ██╔████╔██║██████╔╝█████╗  ██████╔╝███████╗
                                         ██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗╚════██║
                                         ██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║██████╔╝███████╗██║  ██║███████║
                                         ╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝
");
            List<Person> temp = service.FindAll();
            foreach (Person p in temp)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void PrintOutAllMales()
        {
            Clear();
            WriteLine(@"
                                        ███╗   ███╗ █████╗ ██╗     ███████╗███████╗
                                        ████╗ ████║██╔══██╗██║     ██╔════╝██╔════╝
                                        ██╔████╔██║███████║██║     █████╗  ███████╗
                                        ██║╚██╔╝██║██╔══██║██║     ██╔══╝  ╚════██║
                                        ██║ ╚═╝ ██║██║  ██║███████╗███████╗███████║
                                        ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝
");
            List<Person> temp = service.FindAllMale();
            foreach (Person p in temp)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void PrintOutAllFemales()
        {
            Clear();
            WriteLine(@"
                                        ███████╗███████╗███╗   ███╗ █████╗ ██╗     ███████╗███████╗
                                        ██╔════╝██╔════╝████╗ ████║██╔══██╗██║     ██╔════╝██╔════╝
                                        █████╗  █████╗  ██╔████╔██║███████║██║     █████╗  ███████╗
                                        ██╔══╝  ██╔══╝  ██║╚██╔╝██║██╔══██║██║     ██╔══╝  ╚════██║
                                        ██║     ███████╗██║ ╚═╝ ██║██║  ██║███████╗███████╗███████║
                                        ╚═╝     ╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝
");
            List<Person> temp = service.FindAllFemale();
            foreach (Person p in temp)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void FindPersonById()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
                                        ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗    ██╗██████╗ 
                                        ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝    ██║██╔══██╗
                                        █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝     ██║██║  ██║
                                        ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝      ██║██║  ██║
                                        ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║       ██║██████╔╝
                                        ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝       ╚═╝╚═════╝ 
                                          Enter in the persons ID to find them :
");
            Write("\t\t\t\t\tID: ");
            int id = GetInt();
            Person found = service.FindById(id);
            if (found != null)
            {
                WriteLine($"\t\t\t\t\tPerson found :\n{found}");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void DisplayAboutMenu()
        {
            Clear();
            WriteLine(@"
                                          █████╗ ██████╗  ██████╗ ██╗   ██╗████████╗
                                         ██╔══██╗██╔══██╗██╔═══██╗██║   ██║╚══██╔══╝
                                         ███████║██████╔╝██║   ██║██║   ██║   ██║   
                                         ██╔══██║██╔══██╗██║   ██║██║   ██║   ██║   
                                         ██║  ██║██████╔╝╚██████╔╝╚██████╔╝   ██║   
                                         ╚═╝  ╚═╝╚═════╝  ╚═════╝  ╚═════╝    ╚═╝
");
            WriteLine("\t\t\t\tThis demo was created by Anton Edholm.");
            WriteLine("\t\t\t\tYoutube turtorial - https://www.youtube.com/watch?v=qAWhGEPMlS8&t=1955s.");
            WriteLine("\t\t\t\tThe demo was created for learning how to created an interactive menu in C#.");
            WriteLine("\n\t\t\t\tPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
