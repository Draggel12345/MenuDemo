using InteractiveMenuDemo.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveMenuDemo.Service
{
    interface IPersonService
    {
        Person Add(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        void Delete(int id);
    }
}
