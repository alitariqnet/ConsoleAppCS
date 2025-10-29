using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    public class Admin : User
    {
        public Admin() : this(string.Empty, string.Empty, string.Empty)
        {
        }
        public Admin(string name, string email, string password) : base(name, email, password, "Admin")
        {
            
        }

        public static Admin CreateAdmin(string name, string email, string password)
        {
            return new Admin(name, email, password);
        }
        public override void DisplayUserDetails()
        {
            Console.WriteLine(string.IsNullOrEmpty(Name) ? "Name is not provided." : $"Admin Name: {Name}");
        }
    }
}
