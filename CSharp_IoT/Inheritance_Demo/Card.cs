using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Demo
{
    internal class Card
    {
        protected string Id { get; set; }

        public string BankName { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string issuedDate { get; set; }
        public string expiryDate { get; set; }
        public int cvv {  get; set; }
        public string CardHolderName { get; set; }

        public Card(string BankName) {
            Console.WriteLine("base class constructor");
        }
      public Card()
        {

        }
        public abstract void basemethod();
        public virtual void getData()
        {
            Console.WriteLine("Enter CardHolder Name");
            CardHolderName = Console.ReadLine();
            Console.WriteLine("Enter Card NO:");
            Id = (Console.ReadLine());
            Console.WriteLine("Enter CVV");
            cvv = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Expiry");
            expiryDate = Console.ReadLine();


        }
    }
}
