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
            string prompt = "\t\t\t\t\t\t Main Menu\n\t\t\t\tUse the up and down arrow keys to navigate in the menu\n\t\t\t\t\tand press enter to interact with the menu.\n";
            string[] options = { "\t\t\t\t\t\tRegister Person", "\t\t\t\t\t\tRemove Person", "\t\t\t\t\t\tFind Members", "\t\t\t\t\t\tAbout", "\t\t\t\t\t\tExit" };
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
            string prompt = "\t\t\t\t\t\tDemo Start Menu\n";
            string[] options = { "\t\t\t\t\t\tAll Members", "\t\t\t\t\t\tFind By Id", "\t\t\t\t\t\tReturn To Main Menu" };
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
            ConsoleKey keyPressed;
            Clear();
            Write("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tPress Enter to continue or back space to go back to menu.");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            
            if (keyPressed == ConsoleKey.Backspace)
            {
                RunMainMenu();
            }
            Clear();
            CursorVisible = true;
            WriteLine("\t\t\t\t\t\tRegister :\n");
            Write("\t\t\t\tEnter in your full name: ");
            string fullName = ReadLine();
            Write("\t\t\t\tAre you a boy, girl or other?: ");
            string gender = ReadLine();
            Write("\t\t\t\tEnter in your age: ");
            int age = ToInt32(ReadLine());
            Write("\t\t\t\tEnter in your email: ");
            string email = ReadLine();
            Write("\t\t\t\tEnter in your phone number: ");
            string phone = ReadLine();
            service.Add(new(gender, fullName, email, age, phone));
            WriteLine("\t\t\t\tInfo saved...");
            WriteLine("\n\t\t\t\tPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void RemovePerson()
        {
            ConsoleKey keyPressed;
            Clear();
            Write("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tPress Enter to continue or back space to go back to menu.");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Backspace)
            {
                RunMainMenu();
            }
            Clear();
            WriteLine("\t\t\t\t\t\tEnter in the persons ID to remove them :\n");
            Write("\t\t\t\t\tID: ");
            int id = ToInt32(ReadLine());
            Person found = service.FindById(id);
            WriteLine($"\t\t\t\t\tPerson to remove :\n{found}");
            Write($"\n\t\t\t\t\tAre you sure you want to delete {found.FullName}? (Yes/No): ");
            string answer = ReadLine().ToLower();
            if (answer == "yes")
            {
                service.Delete(found.Id);
                WriteLine("\n\t\t\t\t\tThe person have been deleted from the list.");
            }

            WriteLine("\n\t\t\t\t\tPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void PrintOutAllMembers()
        {
            Clear();
            WriteLine("\t\t\t\t\t\tAll members in the register :\n");
            List<Person> temp = service.FindAll();
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
            ConsoleKey keyPressed;
            Clear();
            Write("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tPress Enter to continue or back space to go back to menu.");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Backspace)
            {
                RunMainMenu();
            }
            Clear();
            WriteLine("\t\t\t\t\t\tEnter in the persons ID to find them :\n");
            Write("\t\t\t\t\tID: ");
            int id = ToInt32(ReadLine());
            Person found = service.FindById(id);
            WriteLine($"\t\t\t\t\tPerson found :\n{found}");
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void DisplayAboutMenu()
        {
            Clear();
            WriteLine("\t\t\t\t\t\tAbout :\n");
            WriteLine("\t\t\tThis demo was created by Anton Edholm.");
            WriteLine("\t\t\tYoutube turtorial - https://www.youtube.com/watch?v=qAWhGEPMlS8&t=1955s.");
            WriteLine("\t\t\tThe demo was created for learning how to created an interactive menu in C#.");
            WriteLine("\n\t\t\tPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
