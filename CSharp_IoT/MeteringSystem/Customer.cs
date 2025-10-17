using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteringSystem
{
    internal class Customer
    {
        public static string Country = "India";
       public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }

        public Customer()
        {
            ID = 0;
            Name = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            PostalCode = string.Empty;
            Phone = string.Empty;

        }
        public void addCustomer()
        {
            Console.WriteLine("Enter ID:");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();
            Console.WriteLine("Enter City:");
            City = Console.ReadLine();
            Console.WriteLine("Enter Region:");
            Region = Console.ReadLine();
            Console.WriteLine("Enter Postal Code:");
            PostalCode = Console.ReadLine();
            Console.WriteLine("Enter Mobile Number:");
            Phone = Console.ReadLine();
            Console.WriteLine($"Country:{Country}");
            Console.WriteLine("Customer Added Successfully");

        }
        public void DisplayData()
        {
            Console.WriteLine($"Customer ID : {ID}");
            Console.WriteLine($"Customer Name : {Name}");
            Console.WriteLine($"Customer Address : {Address}");
            Console.WriteLine($"City : {City}, Region : {Region}, PostalCode : {PostalCode}");
            Console.WriteLine($"Mobile Number: {Phone}");

        }
    }
}
