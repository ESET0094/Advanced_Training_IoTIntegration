using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteringSystem
{
    internal class MapMeter
    {


        string CustomerID;
        string MeterID;
        public void getData(string customerID, string meterID)
        {
            
            CustomerID = customerID;
            MeterID = meterID;
            Console.WriteLine("Customer mapped to meter");
        }
        public void DisplayData()
        {
           Console.WriteLine($"{CustomerID} {MeterID}"); 

        }

    }
}
