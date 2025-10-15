using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "shington, D.C., U.S., on October 14, 2025. |" +
                " Photo Credit: Reuters" +
                "The International Monetary Fund (IMF) in the October outlook increased India’s " +
                "growth projections by 20 basis points to 6.6% for 2025 whilst projecting a decline of the same intensity to 6.2% in 2026. " +
                "Meanwhile, the Washington-headquartered financial institution predicts global growth would edge upwards by 20 basis points to 3.2% this year, with the outlook for 2026 unchanged at 3.1%.  ";

            (string Username, string Password) = getUserCredentials();
            var Len = s.Length; // get the length
            Console.WriteLine($"Number of Words in the given string: {WordCount(s)}");
            Console.WriteLine($"Number of spaces in the given string: {SpaceCount(s)}");
            Console.WriteLine($"Number of of sentences in the given string:{SentenceCount(s)}");
            Console.WriteLine($"First of occurence of a in the given string is {findString(s, "a")}");
            Console.WriteLine("Enter Input:");
            Console.WriteLine($"{CamelCase(Console.ReadLine())}");
            Console.WriteLine($"The number of repetions of a in the given string is {CountChar(s, 'a')}");
            Console.WriteLine("Enter Number Plate:");
            string NumberPlate = Console.ReadLine();   
            (string state, string district) = detPlateNumber(NumberPlate);
            Console.WriteLine($"The state and district of the corresponding Number Plate {NumberPlate} is {state} & {district} ");
        }
        public static int WordCount(string s)
        {
            if (s == null)
            {
                return 0; // Null String returns 0
            }
            else
            {
                string[] words = s.Split(' ');
                return words.Length; // Number of Words in a string 
            }
        }
        public static int SpaceCount(string s)
        {
            return WordCount(s)-1;
        }
        public static int SentenceCount(string s)
        {
            if (s == null)
            {
                return 0;
            }
            else
            {
                return s.Split('.').Length;
            }
        }
        public static int findString(string s, string substr)
        {
            if (!s.Contains(substr))
            {
                return -1;
            }
            else
            {
                return s.IndexOf(substr);
            }
        }
        public static string UpperCase(string s) {
            return s.ToUpper();
                
        }
        public static string CamelCase(string s)
        {
            string[] str_array = s.Split(' ');
            for (int i = 0; i < str_array.Length; i++)
            {
                string new_str = str_array[i];
                string FirstIndex = new_str[0].ToString().ToUpper();
                string SubStr = new_str.Substring(1, new_str.Length - 1);
                str_array[i] = String.Concat(FirstIndex, SubStr);

            }
            return String.Join(' ', str_array);

        }
        public static int CountChar(string s, char ch)
        {
            char[] new_str = s.ToCharArray();
            //Console.WriteLine($"{String.Join(',', new_str)}");
            int count = 0;
            foreach (char str in new_str) {
                if (str == ch)
                {
                    count++;
                }
            }
            return count;
        }
        public static (string,string) getUserCredentials()
        {
            Console.WriteLine("Enter User Name:");
            string UserName = Console.ReadLine();
            verifyCredentials(UserName);
            Console.WriteLine("Enter Password:");
            string Password = Console.ReadLine();
            verifyCredentials(Password);
            if (verifyCredentials(UserName) && verifyCredentials(Password))
                Console.WriteLine("Credetentials Verified Successfully");
            return (UserName, Password); 


        }
        public static bool verifyCredentials (string Cred) 
            {
             if (string.IsNullOrEmpty(Cred))
             {
                Console.WriteLine("Invalid Username or Password");

                return false;
             }
            else if (Cred.Length <8)
            {
                Console.WriteLine("Invalid Credentials. Must be of atleast 8 characters");
                return false;
            }
            else
            {
                
                return true;
            }

            }
        // For the given number plate determine the state.(Consider KA 19 MC 1234)
        public static (string,string) detPlateNumber(string NumberPlate)
        {
            string[] new_str = NumberPlate.Split(' ');
            return (stateCode(new_str[0]), districtCode(new_str[0], new_str[1]));


        }
        public static string stateCode(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str == "KA")
                {
                    return "Karnataka";
                }
                else if (str == "TN")
                {
                    return "Tamil Nadu";
                }
                else
                    return "Invalid State Code";
            }
            else
                return "Code Invalid";
        }
        public static string districtCode(string State, string distCode)
        {
            switch (State)
            {
                case "KA":
                    if (distCode == "19")
                    {
                        return "Mangalore District";
                    }
                    else if (distCode == "20")
                    {
                        return "Udupi District";
                    }
                    else
                        return "Invalid Code";
                    break;
                case "TN":
                    if (distCode == "01")
                    {
                        return "Kanchipuram District";
                    }
                    else if (distCode == "02")
                    {
                        return "Chengalpattu District";
                    }
                    else
                    {
                        return "Invalid Code";
                    }
                    break;
            }
            return "Invalid Code";
            }
        }
    }
