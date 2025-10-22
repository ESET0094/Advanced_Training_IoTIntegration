namespace Inheritance_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {   Card card = new CreditCard();
            card.getData();
            CreditCard creditcard = new CreditCard();
            creditcard.getData();
            creditcard.DisplayData();
         
        }
    }
}
