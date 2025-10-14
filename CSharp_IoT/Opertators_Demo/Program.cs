using System.Numerics;

namespace Opertators_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int first = 19;
            int second = 10;
            double c = first / second;
            Console.WriteLine(c);
            first++;
            Console.WriteLine($"Second before {second}");
            int b = ++second;
            Console.WriteLine($"b={b} second= {second}");

            var Res = (second % 2 == 0) ? "even" : "odd";
            Console.WriteLine($"Result:{Res}");
            */
            Console.WriteLine("Enter Student Details");
            /* string student_01, student_02, student_03;
             string class_01, class_02, class_03;
             
            */
            string[] snames = new string[3];
            string[] sclass = new string[3];
            int[] marks_01, marks_02, marks_03;
            

            (snames[0], sclass[0], marks_01) = get_student_data();
            (snames[1], sclass[1], marks_02) = get_student_data();
            (snames[2], sclass[2], marks_03) = get_student_data();
            string formattedString = String.Format($"{"Name",-10}{"Class",-10}{"Sub-1",-10}{"Sub-2",-10}{"Sub-3",-10}{"Total",-10}{"Average",-10}{"Grade",-10}");
            Console.WriteLine(formattedString);
            print_details(snames[0], sclass[0], marks_01);
            print_details(snames[1], sclass[1], marks_02);
            print_details(snames[2], sclass[2], marks_03);
        }
        public static (string, string, int[]) get_student_data()
        {
            string student_name, student_class;
            int[] marks = new int[3];
            Console.WriteLine("Student Name:");
            student_name = Console.ReadLine();
            Console.WriteLine("Student Class");
            student_class = Console.ReadLine();
            Console.WriteLine("Enter Maths Marks:");
            marks[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Physics Marks:");
            marks[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Chemistry Marks:");
            marks[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------------");
            return (student_name, student_class, marks);

        }
        public static void print_details(string student_name, string student_class,  int[] marks)
        {
             float total_score = marks[0] + marks[1] + marks[2];
            float average_score = total_score / 3;
            
            string formattedString = String.Format($"{student_name,-10}{student_class,-10}{marks[0],-10}{marks[1],-10}{marks[2],-10}{total_score,-10}{average_score,-10}{"NA",-10}");
            Console.WriteLine( formattedString );
        }
       
        
    }
}
