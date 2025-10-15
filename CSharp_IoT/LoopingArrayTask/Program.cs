using System.ComponentModel.Design;

namespace LoopingArrayTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr1, arr2;//, arr3, arr4, arr5, arr6 ;
            //Console.WriteLine("Enter Array - 1:");
            arr1 = getRandomIntArray(10);
            //Console.WriteLine("Enter Array - 2:");
            arr2 = [1, 2, 3,4];
            /*(arr3,arr4)= splitArray(arr1);
            (arr5, arr6) = splitArray(arr2);
            int sum_arr3 = sumofArray(arr3);
            int sum_arr4 = sumofArray(arr4);
            int sum_arr5 = sumofArray(arr5);
            int sum_arr6 = sumofArray(arr6);
            int[] new_array = sumArrays(arr1, arr2);
            int even_Sum = evenSum(new_array);
            int sumofdigits = digitSum(even_Sum);*/
            
            Console.WriteLine($"Array {string.Join(',', arr2)}");
            int[] revArray = reverseArray(arr2);
            Console.WriteLine($"Reverse Array {string.Join(',', revArray)}");
        }

        public static int[] reverseArray(int[] arr)
        {
            if (arr.Length % 2 == 0)
            {
                int temp;
                for (int i = 0; i < arr.Length/2; i++)
                {

                    (arr[i], arr[arr.Length - i - 1]) = (arr[arr.Length - i - 1], arr[i]);
                    

                }

            }
           
            return arr;
            
            
            }
        public static (int[], int[]) splitArray(int[] array)
        {
            (int len1, int len2) = countelements(array);
            int[] evenArray = new int[len1];
            int[] oddArray = new int[len2];
            int i = 0;
            while (i < len1)
            {
                for (int j = 0; j < array.Length; j++) {
                    if (array[j] % 2 == 0)
                    {
                        evenArray[i] = array[j];
                        i++;
                    }
                } 
            }
            i = 0;
            while (i < len2)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] % 2!=0)
                    {
                        oddArray[i] = array[j];
                        i++;
                    }
                }
            }
            Console.WriteLine($"Even Array : [{string.Join(',', evenArray)}], \nOdd Array : [{string.Join(',', oddArray)}] \nfor the given Array [{string.Join(',', array)}");
            return (evenArray, oddArray);

        }           
                  
        public static (int,int) countelements(int[] array)
        {

            int countEven = 0;
            int countOdd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    countEven += 1;
                }
                else
                {
                    countOdd += 1;

                }
            }
            return (countEven, countOdd);
            
        }

        
        public static int[] getRandomIntArray(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(11,100);
            }
            return array;
        }
        
        public static int[] getInput(int len)
        {
            int[] input = new int[len];
            for (int i = 0; i < input.Length; i++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                input[i] = x;
            }
            return input;
        }
        public static int[] sumArrays(int[] arr1, int[] arr2)
        {
            int[] sum;
            sum = new int[arr1.Length];
            if (arr1.Length != arr2.Length)
            {
                Console.WriteLine("Arrays of different Length cannot be added");

            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    sum[i] = arr1[i] + arr2[i];
                }

            }
            Console.WriteLine($"Sum of Two Arrays ({string.Join(',', arr1)}) & ({string.Join(',', arr2)}) :{string.Join(',', sum)}");

            return sum;
        }
        public static int evenSum(int[] arr) {
            int sum = 0;
            foreach (var i in arr)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Sum of even elements in {string.Join(',', arr)} is {sum}");

            return sum;
        }
        public static int sumofArray(int[] arr)
        {
            int sum = 0;
            foreach (var i in arr)
                sum+=i;
            Console.WriteLine($"The sum of elements in {string.Join(',', arr)} is {sum}");
            digitSum(sum);
            return sum;


        }
        public static int digitSum(int element)
        {
            int rem = 0;
            int sum = 0;
            while (element > 0) {
                rem = element % 10;
                sum += rem;
                element /= 10;
            }
            Console.WriteLine($"Sum of digits in the given element is {sum}");

            return sum;
        }
        

    }
}
