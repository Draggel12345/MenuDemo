using InteractiveMenuDemo.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveMenuDemo.Data
{
    interface IPersonDao
    {
        Person Save(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        List<Person> FindGender(string str);
        void Remove(int id);
    }
}
