namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first;
            int second;
            int[] myarray = new int[10];
            first = Convert.ToInt32(Console.ReadLine());
            second = Convert.ToInt32(Console.ReadLine());
            int result;
            int result1;
            int result2;
            try
            {
                result = first / second;
                try
                {
                    result1 = first / second;

                }
                catch (DivideByZeroException ex)
                {
                    throw ex;

                    Console.WriteLine("At 1");
                }
                try
                {
                    result2 = second / first;
                    
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("At 2");
                    throw ex;
                }


            }
            catch (Exception e) {
                throw e;
                Console.WriteLine("Exception Found"); }
            finally
            {
                Console.WriteLine("Finally");
            }
            Console.WriteLine("Program Terminating.....");
        }
    }
}
