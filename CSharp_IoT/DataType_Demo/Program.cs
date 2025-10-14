using System.Collections.Generic;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace DataType_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*  byte byte_variable = 10;
            sbyte sbyte_variable = -45;
            short short_variable = -15000;
            ushort ushort_variable = 60000;
            int integer_variable = -3284709;
            uint uint_variable = 12456U;
            long long_variable = 9238298;
            ulong ulong_variable = 12409108921;
            float float_variable = 234.563F;
            double double_variable = 2341.1231;
            decimal decimal_variable = 34.23425643M;
            int a = 78;
            Console.WriteLine($"The sum of {integer_variable} and {a} is {addition(integer_variable, a)}"); ;

            Console.WriteLine($"byte = {byte_variable} sbyte = {sbyte_variable} short = {short_variable} \n" +
                $"ushort =  {ushort_variable} int = {integer_variable} uint = {uint_variable} \n" +
                $"long = {long_variable} ulong = {ulong_variable} float = {float_variable} \n" +
                $"double = {double_variable} decimal = {decimal_variable}");


            double result=addition(1,2.93);
            Console.WriteLine(result);

            */

            int[] new_array = get_array_data();
            

         /*
            Console.WriteLine("The Array Elements are : ");
            for (int i = 0; i < new_array.Length; i++)
            {
                Console.WriteLine(new_array[i]);
            }
         */
         Console.WriteLine("The array elements are " + array_display(new_array));
           


        }
        static public double addition(int First, double Second)
        {
            int a;
            double sum = ((First) + Second);
            
            //Console.WriteLine($"The sum of {First} and {Second} is {sum}");
            return sum;
        }
        public static int[] get_array_data()
        {
            int[] new_array = new int[5];
            new_array[0] = 1;
            new_array[1] = 2;
            new_array[2] = 3;
            new_array[3] = 4;
            new_array[4] = 5;
            return new_array;
        }
        public static string array_display(int[] numbers)
        {
            return ($"{numbers[0]},{numbers[1]},{numbers[2]},{numbers[3]},{numbers[4]}");
        }
    }
}  
