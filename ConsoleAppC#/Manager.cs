using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    public class Manager : User
    {
        private static string role;

        public Manager(string name, string email, string password) : base(name, email, password, role)
        {
        }
        public override void DisplayUserDetails()
        {
            Console.WriteLine(string.IsNullOrEmpty(Name) ? "Name is not provided." : $"Admin Name: {Name}");
        }
    }
}
