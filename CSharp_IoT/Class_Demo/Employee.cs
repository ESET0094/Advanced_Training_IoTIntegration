using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Demo
{
    internal class Employee
    {
        int Emp_id { get; set; }
        string Emp_name { get; set; }
        string Emp_dob { get; set; }
        string Emp_doj { get; set; }
        string Emp_dept { get; set; }
        double Emp_salary { get; set; }
        string currentLocation { get; set; }    
        bool isActive { get; set; }

        bool isBenched {  get; set; }   

       /* public Employee(int emp_ID, string emp_name, string emp_dob, string emp_doj, string emp_dept, double emp_salary)
        {
           Emp_id = emp_ID;
            Emp_name = emp_name;
            Emp_dob = emp_dob;
            Emp_doj = emp_doj;
            Emp_dept = emp_dept;
            Emp_salary = emp_salary;
            
            
        }*/
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee ID : {Emp_id}");
            Console.WriteLine($"Employee Name :{Emp_name}");
            Console.WriteLine($"Employee Date Of Birth : {Emp_dob}");
            Console.WriteLine($"Employee Date of Joining : {Emp_doj}");
            Console.WriteLine($"Department : {Emp_dept}");
        }
        public void getEmployeeData()
        {
            Console.WriteLine("Enter Employee ID:");
            Emp_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            Emp_name = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth:");
            Emp_dob = Console.ReadLine();
            Console.WriteLine("Enter Date of Joining");
            Emp_doj = Console.ReadLine();
        }


        



        
        

    }
}
