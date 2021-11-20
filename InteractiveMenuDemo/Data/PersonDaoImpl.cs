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

        List<Person> IPersonDao.FindAll()
        {
            return db.Values.ToList();
        }

        List<Person> IPersonDao.FindByGender(string str)
        {
            List<Person> found = new();
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Value.Gender.StartsWith(str, StringComparison.InvariantCultureIgnoreCase))
                {
                    found.Add(kvp.Value);
                }
            }
            return found;
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

        List<Person> IPersonDao.FindByName(string str)
        {
            List<Person> found = new();
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                //StartsWith, EndsWith & StringComparison.InvariantCultureIgnoreCase methods makes the string NOT case sensitive.
                if (kvp.Value.FullName.StartsWith(str, StringComparison.InvariantCultureIgnoreCase) 
                    || kvp.Value.FullName.EndsWith(str, StringComparison.InvariantCultureIgnoreCase))
                {
                    found.Add(kvp.Value);
                }
            }
            return found;
        }

        List<Person> IPersonDao.FindByAge(string str)
        {
            List<Person> found = new();
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Value.Age.ToString() == str)
                {
                    found.Add(kvp.Value);
                }
            }
            return found;
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

        Person IPersonDao.FindByEmail(string str)
        {
            Person toFind = null;
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Value.Email == str)
                {
                    toFind = kvp.Value;
                    return toFind;
                }
            }
            return toFind;
        }

        Person IPersonDao.FindByPhoneNumber(string str)
        {
            Person toFind = null;
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Value.PhoneNumber == str)
                {
                    toFind = kvp.Value;
                    return toFind;
                }
            }
            return toFind;
        }
    }
}
