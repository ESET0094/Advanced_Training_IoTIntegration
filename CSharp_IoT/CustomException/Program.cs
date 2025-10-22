namespace CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //DateTime Dob;
            //string dob;
            Console.WriteLine("Enter your date of birth");
            int age = Convert.ToInt32(Console.ReadLine());
            //dob = Console.ReadLine();
            //DateTime.TryParse(dob, out Dob);
            //DateTime today = DateTime.Today;
            //int age = today.Year - Dob.Year;
            //if (age < 18)
            //    {
            //        //throw new AgeException(age);

            //    }
                if (age < 0)
            {
                throw new Excepsion("100");
            }
            if (age.GetType() == typeof(float))
            {
                throw new Excepsion("200");
            }


            }

        }
    }

