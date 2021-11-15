using InteractiveMenuDemo.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace InteractiveMenuDemo.Service
{
    class MenuService
    {
        private readonly PersonServiceImpl service = new();
        public void Start()
        {
            Title = "Interactive Menu Demo";
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
            string[] options = { "All Members", "Find By Id", "Return To Main Menu" };
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
                        FindPersonById();
                        break;
                    }
                case 2:
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
╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            Write("\nEnter in your full name: ");
            string fullName = ReadLine();
            Write("Enter in your sex: ");
            string gender = ReadLine();
            Write("Enter in your age: ");
            int age = ToInt32(ReadLine());
            Write("Enter in your email: ");
            string email = ReadLine();
            Write("Enter in your phone number: ");
            string phone = ReadLine();
            service.Add(new(gender, fullName, email, age, phone));
            WriteLine("Info saved...");
            WriteLine("\nPress any key to return to main menu.");
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
            Write("ID: ");
            int id = ToInt32(ReadLine());
            Person found = service.FindById(id);
            if (found == null)
            {
                WriteLine("\nPress any key to return to main menu.");
                ReadKey(true);
                RunMainMenu();
            }
            WriteLine($"Person to remove :\n{found}");
            Write($"\nAre you sure you want to delete {found.FullName}? (Yes/No): ");
            string answer = ReadLine().ToLower();
            if (answer == "yes")
            {
                service.Delete(found.Id);
                WriteLine("\nThe person have been deleted from the list.");
            }

            WriteLine("\nPress any key to return to main menu.");
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
╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝");
            List<Person> temp = service.FindAll();
            foreach (Person p in temp)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\nPress any key to return to find menu.");
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
Enter in the persons ID to find them :");
            Write("ID: ");
            int id = ToInt32(ReadLine());
            Person found = service.FindById(id);
            if (found != null)
            {
                WriteLine($"Person found :\n{found}");
            }
            WriteLine("\nPress any key to return to find menu.");
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
╚═╝  ╚═╝╚═════╝  ╚═════╝  ╚═════╝    ╚═╝");
            WriteLine("\nThis demo was created by Anton Edholm.");
            WriteLine("Youtube turtorial - https://www.youtube.com/watch?v=qAWhGEPMlS8&t=1955s.");
            WriteLine("The demo was created for learning how to created an interactive menu in C#.");
            WriteLine("\nPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
