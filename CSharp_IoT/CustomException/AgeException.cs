using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class AgeException :Exception
    {
        public AgeException(string dateofBirth) : base(dateofBirth)
        {
            DateTime Dob;
            DateTime.TryParse(dateofBirth, out Dob);
            DateTime today = DateTime.Today;
            int age = today.Year - Dob.Year;
            int code = 100;
            int eligible_age = 18 - age;
            string description = $"Age Insufficient for Eligibility Please try after {eligible_age} Years";
            Console.WriteLine($"{DateTime.Now} Exception Code:{code} {description}");

        }

    }
    }

