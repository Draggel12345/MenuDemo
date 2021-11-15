using InteractiveMenuDemo.Data;
using InteractiveMenuDemo.Entitys;
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
        public Person Add(Person person)
        {
            Person temp = person;
            if(temp == null)
            {
                WriteLine("The object cant be null.");
            }
            return dao.Save(temp);
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
                WriteLine("The database is empty.");
            }
            return temp;
        }

        public Person FindById(int id)
        {
            Person toFind = dao.FindById(id);
            if(toFind == null)
            {
                WriteLine($"Could not find person with ID:{id} in the database.");
            }
            return toFind;
        }
    }
}
