using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveMenuDemo.Entitys
{

    class Person
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        //You need to tell Json witch constructor to use when creating a new person
        [JsonConstructor]
        public Person(string gender, string fullName, string email, int age, string phoneNumber) => (Id, Gender, FullName, Email, Age, PhoneNumber) = (++IdCounter, gender, fullName, email, age, phoneNumber);

        //When using Json IO you need a defualt constructor for safety.
        public Person() { }

        public override string ToString()
        {
            return $"\tID: {Id}.\n\tGender: {Gender}.\n\tFull name: {FullName}. Age: {Age}{(Age > 1 ? " years old." : "year old.")}\tEmail: {Email}. Phone number: {PhoneNumber}.";
        }
    }
}
