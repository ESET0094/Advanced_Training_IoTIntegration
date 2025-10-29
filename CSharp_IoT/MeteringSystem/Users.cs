using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteringSystem
{
    internal class Users
    {
        public string Username { get; set; }
        public string Password { get; set;}
        public string Status { get; set;}

     
            
        public void CreateCredential()
        {
            Username = checkLimit(Username);
            Password = createPassword(Password);
            Status = Console.ReadLine();
        }

        public static string checkLimit(string Cred) // Validity of Username/Password Length
        {
            Console.WriteLine($"Enter {nameof(Cred)}:");
            Cred = Console.ReadLine();
            if (Cred.Length > 8) ;
            else
            {
                Console.WriteLine($"{nameof(Cred)} Must be atleast 8 characters. Please enter a new {nameof(Cred)}");
                Cred = checkLimit(Cred);
            }
            return Cred;
        }
        public static string createPassword(string password)
        {

            string temp, temp1;
            temp = checkLimit(password);
            Console.WriteLine("Re-enter your password:");
            temp1 = Console.ReadLine();
            if (temp1 == temp)
            {
                password = temp;

            }
            else
            {
                Console.WriteLine("Password do not match. Try Again");
                createPassword(temp1);

            }
            return password;
        }
    }
}
