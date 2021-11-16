using InteractiveMenuDemo.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveMenuDemo.Data
{
    class PersonDaoImpl : IPersonDao
    {
        private readonly Dictionary<int, Person> db = new();

        public List<Person> FindGender(string str)
        {
            List<Person> found = new();
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Value.Gender == str)
                {
                    found.Add(kvp.Value);
                }
            }
            return found;
        }

        List<Person> IPersonDao.FindAll()
        {
            return db.Values.ToList();
        }

        Person IPersonDao.FindById(int id)
        {
            Person toFind = null;
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Key == id && id != 0)
                {
                    toFind = kvp.Value;
                    return toFind;
                }
            }
            return toFind;
        }

        void IPersonDao.Remove(int id)
        {
            db.Remove(id);
        }

        Person IPersonDao.Save(Person person)
        {
            if (!db.ContainsKey(person.Id) && person != null)
            {
                db.Add(person.Id, person);
            }
            return person;
        }
    }
}
