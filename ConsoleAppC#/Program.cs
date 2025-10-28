namespace ConsoleAppCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starts...");
            //CollectionsPractice collectionsPractice = new CollectionsPractice();
            //collectionsPractice.DoPractice();
            //ValueTypeExample.Maine();
            NullableType.Maine();
        }
    }

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
    public class Customer : User

    {
        private static string role;
        Dictionary<DateOnly, Order> _orders = new Dictionary<DateOnly, Order>();
        public Customer(string name, string email, string password) : base(name, email, password, role)
        {

        }
        public override void DisplayUserDetails()
        {
            Console.WriteLine(string.IsNullOrEmpty(Name) ? "Name is not provided." : $"Customer Name: {Name}");
        }

        public class Order
        {
            public DateOnly OrderDate { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public Order(DateOnly orderDate, string productName, int quantity)
            {
                OrderDate = orderDate;
                ProductName = productName;
                Quantity = quantity;
            }
        }
    }
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