using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ClassNumber { get; set; }
        public int AccountId { get; set; }
        public Accounts Accounts = new Accounts();

        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public Person(string firstName, string lastName, string secondName, string address, string phoneNumber, string classNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Address = address;
            PhoneNumber = phoneNumber;
            ClassNumber = classNumber;
        }

        public Person(int id, string firstName, string lastName, string secondName, string address, string phoneNumber, string classNumber, string login, string password, bool isAdmin)
        {
            PersonId = id;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Address = address;
            PhoneNumber = phoneNumber;
            ClassNumber = classNumber;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}

