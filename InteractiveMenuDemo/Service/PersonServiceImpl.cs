using InteractiveMenuDemo.Data;
using InteractiveMenuDemo.Entitys;
using InteractiveMenuDemo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InteractiveMenuDemo.Service
{
    class PersonServiceImpl : IPersonService
    {
        private readonly IPersonDao dao = new PersonDaoImpl();
        private readonly InputService input = new();
        public Person Add(Person person)
        {
            Person temp = person;
            if (temp == null)
            {
                WriteLine("\t\t\t\t\tThe object cant be null.");
            }
            return dao.Save(temp);
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

            Add(new(gender, fullName, email, age, phone));
        }

        public void Delete(int id)
        {
            Person toDelete = FindById(id);
            dao.Remove(toDelete.Id);
        }

        public List<Person> FindAll()
        {
            List<Person> temp = dao.FindAll();
            if (temp?.Any() != true)
            {
                WriteLine("\t\t\t\t\tThe database is empty.");
            }
            return temp;
        }

        public List<Person> FindByAge(string str)
        {
            List<Person> temp = dao.FindByAge(str);
            if (temp?.Any() != true)
            {
                WriteLine("\t\t\t\t\tCouldn't find anyone of that age in the database.");
            }
            return temp;
        }

        public Person FindByEmail(string str)
        {
            Person toFind = dao.FindByEmail(str);
            if (toFind == null)
            {
                WriteLine($"\t\t\t\tCouldn't find the person with email: {str} in the database.");
            }
            return toFind;
        }

        public List<Person> FindByGender(string str)
        {
            List<Person> temp = dao.FindByGender(str);
            if (temp?.Any() != true)
            {
                WriteLine("\t\t\t\t\tCouldn't find anyone with that gender in the database.");
            }
            return temp;
        }

        public Person FindById(int id)
        {
            Person toFind = dao.FindById(id);
            if (toFind == null)
            {
                WriteLine($"\t\t\t\t\tCouldn't find the person with Id: {id} in the database.");
            }
            return toFind;
        }

        public List<Person> FindByName(string str)
        {
            List<Person> temp = dao.FindByName(str);
            if (temp?.Any() != true)
            {
                WriteLine("\t\t\t\t\tCouldn't find anyone with that name in the database.");
            }
            return temp;
        }

        public Person FindByPhoneNumber(string str)
        {
            Person toFind = dao.FindByPhoneNumber(str);
            if (toFind == null)
            {
                WriteLine($"\t\t\t\tCouldn't find the person with phone number: {str} in the database.");
            }
            return toFind;
        }
    }
}
