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

        Person IPersonDao.FindById(int id)
        {
            foreach (KeyValuePair<int, Person> kvp in db)
            {
                if (kvp.Key == id && id != 0)
                {
                    return kvp.Value;
                }
            }
            return null;
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
