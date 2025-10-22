using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Demo
{
    internal class CreditCard:Card
    {
        public int Limit { get; set; }
        public int Status { get; set; }

       public CreditCard(string BankName):base(BankName)
        {
            Console.WriteLine("Derived Class Constructor");
        }
        public CreditCard() { }
        public override void getData()
        {
            Console.WriteLine("jasdflj");
        }
        public void DisplayData()
        {
            Console.WriteLine($"Cardholder name :  {CardHolderName} \n " + $"{Id}"+
                $"CVV : {cvv} \n" +
                $"Expiry :{expiryDate}");

        }


    }
}
