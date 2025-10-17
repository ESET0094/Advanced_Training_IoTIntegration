using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteringSystem
{
    internal class SmartMeter
    {
        string MeterID { get; set; }
        string Model {  get; set; }
       

        List<Reading> ReadingData { get; set; }

        public SmartMeter()
        {
            MeterID = string.Empty;
            Model = string.Empty;
        }

        public void getInputData()
        {
            Console.WriteLine("Enter Meter ID:");
            MeterID = Console.ReadLine();
            Console.WriteLine("Enter the Model of the Smart Meter");
            Model = Console.ReadLine();
        
            

        }
        public void DisplayData()
        {
            Console.WriteLine($"Meter ID {MeterID}");
            Console.WriteLine($"Customer ID {Model}");

            
        }


       
    }
}
