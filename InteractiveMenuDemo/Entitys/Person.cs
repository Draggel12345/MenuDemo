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
            return $"\t\t\t\t\tINFO -\n\t\t\t\t\tID: {Id}.\n\t\t\t\t\tGender: {Gender}.\n\t\t\t\t\tFull name: {FullName}.\n\t\t\t\t\tAge: {Age}{(Age > 1 ? "years" : "year")}.\n\t\t\t\t\tCONTACT INFO -\n\t\t\t\t\tEmail: {Email}.\n\t\t\t\t\tPhone number: {PhoneNumber}.";
        }
    }
}
