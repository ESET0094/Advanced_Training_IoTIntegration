using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataEntry
{
    internal class Student
    {   
        static int count = 0;
        int roll_no { get ; set; }
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        int Math_score { get; set; }
        int Physics_score { get; set; }
        int Chemistry_score { get; set; }
        
        public void getData()
        {
            count++;
            Console.WriteLine("Enter Roll No");
            roll_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine
                ("Enter Student name : ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter scores in Math Physics and Chemistry");
            Math_score = Convert.ToInt32(Console.ReadLine());
            Physics_score = Convert.ToInt32(Console.ReadLine());
            Chemistry_score = Convert.ToInt32(Console.ReadLine());

        }
        public void DisplayData()
        {
            Console.WriteLine($"Student Roll Number : {roll_no}");
            Console.WriteLine($"Student Name : {Name}");
            Console.WriteLine($"Mathematics : {Math_score}");
            Console.WriteLine($"Physics: {Physics_score}");
            Console.WriteLine($"Chemistry : {Chemistry_score}");
        }
        public void CalculateTotal()
        {
            int sum = Math_score + Physics_score + Chemistry_score;
            Console.WriteLine($"Total Score is {sum}");
            double avg_score = sum / 3;
            Console.WriteLine($"Average:{avg_score}");
        }
    }
}
