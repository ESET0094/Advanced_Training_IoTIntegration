namespace LoopingArrayTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] arr1 , arr2 ;
            Console.WriteLine("Enter Array - 1:");
            arr1 = getInput(3);
            Console.WriteLine("Enter Array - 2:");
            arr2 = getInput(3);
            int[] new_array = sumArrays(arr1, arr2);
            Console.WriteLine($"Sum of Two Arrays ({string.Join(',',arr1)}) & ({string.Join(',', arr2)}) :{string.Join(',', new_array)}");
            int even_Sum = evenSum(new_array);
            Console.WriteLine($"Sum of even elements in {string.Join(',', new_array)} is {even_Sum}");
            int sumofdigits = digitSum(even_Sum);
            Console.WriteLine($"Sum of digits in the given element is {sumofdigits}");
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
            return sum;
        }
        

    }
}
