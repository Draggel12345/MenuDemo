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
        Person FindByEmail(string str);
        Person FindByPhoneNumber(string str);
        List<Person> FindAll();
        List<Person> FindByAge(string str);
        List<Person> FindByGender(string str);
        List<Person> FindByName(string str);
        void Remove(int id);
    }
}
