using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    public class Admin : User
    {
        private static string role;

        public Admin(string name, string email, string password) : base(name, email, password, role)
        {
        }
        public override void DisplayUserDetails()
        {
            Console.WriteLine(string.IsNullOrEmpty(Name) ? "Name is not provided." : $"Admin Name: {Name}");
        }
    }
}
