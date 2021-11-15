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

        public Person(string gender, string fullName, string email, int age, string phoneNumber) => (Id, Gender, FullName, Email, Age, PhoneNumber) = (++IdCounter, gender, fullName, email, age, phoneNumber);

        public override string ToString()
        {
            return $"INFO -\n\nID: {Id}.\nGender: {Gender}.\nFull name: {FullName}.\nAge: {Age}{(Age > 1 ? "years" : "year")}.\n\nCONTACT INFO -\nEmail: {Email}.\nPhone number: {PhoneNumber}.";
        }
    }
}
