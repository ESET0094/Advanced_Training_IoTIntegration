using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;

namespace NumbersOps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
           
            int First = getNumber();
            int Second = getNumber();
            int Third = getNumber();
            if (checkNumberRange(First) && checkNumberRange(Second) && checkNumberRange(Third)) {
                LargestNumber(First, Second, Third);
               
            }
            else { 
                Console.WriteLine("Invalid Number");
            }
        } 
        
        public static int getNumber()
        {
            Console.WriteLine("Enter a three digit number:");
            int x = Convert.ToInt32(Console.ReadLine());
            return x;
        }
        public static bool checkNumberRange(int number)
        {
            if (number>=100 && number <1000)
                return true;
            return false;
        }
        public static void LargestNumber(int First, int Second, int Third)
        {
            if (First > Second && First > Third)
            {
                Console.WriteLine($"The Largest of three numbers {First}, {Second}, {Third}  is {First}");
            }
            else if (Second > Third)
            {
                Console.WriteLine($"The Largest of three numbers {First}, {Second}, {Third}  is {Second}");
            }
            else
            {
                Console.WriteLine($"The Largest of three numbers {First}, {Second}, {Third}  is {Third}");
            }
        }
    }
}
