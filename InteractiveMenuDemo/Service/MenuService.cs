using InteractiveMenuDemo.Entitys;
using InteractiveMenuDemo.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace InteractiveMenuDemo.Service
{
    class MenuService : JsonService
    {

        private readonly InputService input = new();
        private readonly PersonServiceImpl service = new();
        public List<Person> PeopleList { get; set; }

        //Static
        private static readonly string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\Util\PeopleJson\PeopleDB.json");
        //Can't make changes to file if static
        private readonly string FILEPATH = Path.GetFullPath(sFile);

        public void Start()
        {
            Title = "Interactive Menu Demo";
            ReadFromJsonFile();
            RunMainMenu();
        }

        private void ReadFromJsonFile()
        {
            PeopleList = ReadFromJsonFile<List<Person>>(FILEPATH);
            PeopleList.ForEach(p => service.Add(p));
        }

        private void SaveAndExitApplication()
        {
            WriteToJsonFile(FILEPATH, PeopleList);
            Environment.Exit(0);
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
            string[] options = { "Register Person", "Remove Person", "Find Members", "About", "Save & Exit" };
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
                        SaveAndExitApplication();
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
            string[] options = { "Find By Type", "All Members", "Find By ID", "Return To Main Menu" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        DisplayFindByTypeMenu();
                        break;
                    }
                case 1:
                    {
                        PrintOutAllMembers();
                        break;
                    }
                case 2:
                    {
                        FindPersonById();
                        break;
                    }
                case 3:
                    {
                        RunMainMenu();
                        break;
                    }
            }
        }

        private void DisplayFindByTypeMenu()
        {
            CursorVisible = false;
            string prompt = @"
               ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗    ████████╗██╗   ██╗██████╗ ███████╗
               ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝    ╚══██╔══╝╚██╗ ██╔╝██╔══██╗██╔════╝
               █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝        ██║    ╚████╔╝ ██████╔╝█████╗  
               ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝         ██║     ╚██╔╝  ██╔═══╝ ██╔══╝  
               ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║          ██║      ██║   ██║     ███████╗
               ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝          ╚═╝      ╚═╝   ╚═╝     ╚══════╝";
            string[] options = { "Find By Name", "Find By Age", "Find By Gender", "Find By Email", "Find By Phone Number", "Return To Find Menu" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        FindPersonByName();
                        break;
                    }
                case 1:
                    {
                        FindPersonByAge();
                        break;
                    }
                case 2:
                    {
                        FindPersonByGender();
                        break;
                    }
                case 3:
                    {
                        FindPersonByEmail();
                        break;
                    }
                case 4:
                    {
                        FindPersonByPhoneNumber();
                        break;
                    }
                case 5:
                    {
                        DisplayFindMenu();
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

            CreatePerson();
            WriteLine("\t\t\t\tInfo saved...");
            WriteLine("\n\t\t\t\tPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        public void CreatePerson()
        {
            Write("\t\t\t\tEnter in your full name: ");
            string fullName = input.GetString();
            Write("\t\t\t\tEnter in your sex: ");
            string gender = input.GetString();
            Write("\t\t\t\tEnter in your age: ");
            int age = input.GetInt();
            Write("\t\t\t\tEnter in your email: ");
            string email = input.GetString();
            Write("\t\t\t\tEnter in your phone number: ");
            string phone = input.GetString();

            service.Add(new(gender, fullName, email, age, phone));
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
            int id = input.GetInt();
            Person found = service.FindById(id);
            if (found == null)
            {
                WriteLine("\n\t\t\t\t\tPress any key to return to main menu.");
                ReadKey(true);
                RunMainMenu();
            }
            WriteLine($"\t\t\t\t\tPerson to remove :\n{found}");
            Write($"\n\t\t\t\t\tAre you sure you want to delete {found.FullName}? (Yes/No): ");
            string answer = input.GetString().ToLower();
            if (answer == "yes" || answer == "ye" || answer == "y")
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
     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------|| 
");
            PeopleList = service.FindAll();
            foreach (Person p in PeopleList)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void FindPersonByName()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
               ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗    ███╗   ██╗ █████╗ ███╗   ███╗███████╗
               ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝    ████╗  ██║██╔══██╗████╗ ████║██╔════╝
               █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝     ██╔██╗ ██║███████║██╔████╔██║█████╗  
               ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝      ██║╚██╗██║██╔══██║██║╚██╔╝██║██╔══╝  
               ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║       ██║ ╚████║██║  ██║██║ ╚═╝ ██║███████╗
               ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝       ╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                            Enter in the FIRST OR LAST NAME of the person you're looking for.
");
            Write("\t\t\t\t\tName: ");
            string name = input.GetString();
            PeopleList = service.FindByName(name);
            WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
            foreach (Person p in PeopleList)
            {
                WriteLine($"{p}");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindByTypeMenu();
        }

        private void FindPersonByAge()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
                   ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗     █████╗  ██████╗ ███████╗
                   ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝    ██╔══██╗██╔════╝ ██╔════╝
                   █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝     ███████║██║  ███╗█████╗  
                   ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝      ██╔══██║██║   ██║██╔══╝  
                   ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║       ██║  ██║╚██████╔╝███████╗
                   ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝       ╚═╝  ╚═╝ ╚═════╝ ╚══════╝                                                                               
                           Enter in the AGE(Two digits) of the person you're looking for.
");
            Write("\t\t\t\t\tAge: ");
            string age = input.GetString();
            PeopleList = service.FindByAge(age);
            WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
            foreach (Person p in PeopleList)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindByTypeMenu();
        }

        private void FindPersonByGender()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
        ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗    ██████╗ ███████╗███╗   ██╗██████╗ ███████╗██████╗ 
        ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝   ██╔════╝ ██╔════╝████╗  ██║██╔══██╗██╔════╝██╔══██╗
        █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝    ██║  ███╗█████╗  ██╔██╗ ██║██║  ██║█████╗  ██████╔╝
        ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝     ██║   ██║██╔══╝  ██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗
        ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║      ╚██████╔╝███████╗██║ ╚████║██████╔╝███████╗██║  ██║
        ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝       ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝                                                                               
                        Enter in the GENDER(Male/Female) of the person you're looking for.
");
            Write("\t\t\t\t\tGender: ");
            string gender = input.GetString();
            PeopleList = service.FindByGender(gender);
            WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
            foreach (Person p in PeopleList)
            {
                WriteLine($"{p}\n");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindByTypeMenu();
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
                              Enter in the ID of the person you're looking for.
");
            Write("\t\t\t\t\tID: ");
            int id = input.GetInt();
            Person found = service.FindById(id);
            if (found != null)
            {
                WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
                WriteLine($"{found}");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindMenu();
        }

        private void FindPersonByEmail()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
            ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗    ███████╗███╗   ███╗ █████╗ ██╗██╗     
            ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝    ██╔════╝████╗ ████║██╔══██╗██║██║     
            █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝     █████╗  ██╔████╔██║███████║██║██║     
            ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝      ██╔══╝  ██║╚██╔╝██║██╔══██║██║██║     
            ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║       ███████╗██║ ╚═╝ ██║██║  ██║██║███████╗
            ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝       ╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚══════╝
                            Enter in the EMAIL of the person you're looking for.
");
            Write("\t\t\t\t\tEmail: ");
            string email = input.GetString();
            Person found = service.FindByEmail(email);
            if (found != null)
            {
                WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
                WriteLine($"{found}");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindByTypeMenu();
        }

        private void FindPersonByPhoneNumber()
        {
            Clear();
            CursorVisible = true;
            WriteLine(@"
                            ███████╗██╗███╗   ██╗██████╗     ██████╗ ██╗   ██╗
                            ██╔════╝██║████╗  ██║██╔══██╗    ██╔══██╗╚██╗ ██╔╝
                            █████╗  ██║██╔██╗ ██║██║  ██║    ██████╔╝ ╚████╔╝ 
                            ██╔══╝  ██║██║╚██╗██║██║  ██║    ██╔══██╗  ╚██╔╝  
                            ██║     ██║██║ ╚████║██████╔╝    ██████╔╝   ██║   
                            ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═════╝    ╚═╝   
      ██████╗ ██╗  ██╗ ██████╗ ███╗   ██╗███████╗    ███╗   ██╗██╗   ██╗███╗   ███╗██████╗ ███████╗██████╗ 
      ██╔══██╗██║  ██║██╔═══██╗████╗  ██║██╔════╝    ████╗  ██║██║   ██║████╗ ████║██╔══██╗██╔════╝██╔══██╗
      ██████╔╝███████║██║   ██║██╔██╗ ██║█████╗      ██╔██╗ ██║██║   ██║██╔████╔██║██████╔╝█████╗  ██████╔╝
      ██╔═══╝ ██╔══██║██║   ██║██║╚██╗██║██╔══╝      ██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗
      ██║     ██║  ██║╚██████╔╝██║ ╚████║███████╗    ██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██████╔╝███████╗██║  ██║
      ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝    ╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝                                                                                                                                      
                           Enter in the PHONE NUMBER of the person you're looking for.
");
            Write("\t\t\t\t\tPhone Number: ");
            string phoneNumber = input.GetString();
            Person found = service.FindByPhoneNumber(phoneNumber);
            if (found != null)
            {
                WriteLine($"     ||-----------------PERSON-----------------------||-----------------CONTACT INFO---------------------||");
                WriteLine($"{found}");
            }
            WriteLine("\n\t\t\t\t\tPress any key to return to find menu.");
            ReadKey(true);
            DisplayFindByTypeMenu();
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
            WriteLine("\t\t\t\t\tThis demo was created by Anton Edholm ©");
            WriteLine("\n\t\t\tThe demo was created for learning how to create an interactive menu in C#.\n");
            WriteLine("\t\t\t\t\t\tYoutube turtorial -");
            WriteLine("\t\t\t\thttps://www.youtube.com/watch?v=qAWhGEPMlS8&t=1955s\n");
            WriteLine("\t\t\t\t\t\tASCII To Text Generator -");
            WriteLine("\t\t\t\t\t https://patorjk.com/software/taag/\n");
            WriteLine("\n\t\t\t\t\tPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }
    }
}
