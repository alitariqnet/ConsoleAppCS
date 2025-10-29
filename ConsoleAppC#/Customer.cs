using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    public class Customer : User

    {
        Dictionary<DateOnly, Order> _orders = new Dictionary<DateOnly, Order>();
        public Customer(string name, string email, string password) : base(name, email, password, "Customer")
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
}
