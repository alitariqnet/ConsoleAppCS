using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
        public virtual void PrintName()
        {
            Console.WriteLine($"Name: {Name}");
        }
        public virtual void PrintEmail()
        {
            Console.WriteLine($"Email: {Email}");
        }
        public virtual void PrintPassword()
        {
            Console.WriteLine($"Password: {Password}");
        }
        public virtual void PrintRole()
        {
            Console.WriteLine($"Role: {Role}");
        }
        public abstract void DisplayUserDetails();
    }
}
