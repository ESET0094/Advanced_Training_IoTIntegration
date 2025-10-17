using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteringSystem
{
    internal class Reading
    {
        public string MeterID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string BillCode { get; set; }
        public double Usage { get; set; }   

        public void addReading()
        {
            Console.WriteLine("Enter Meter Serial : ");
            MeterID = Console.ReadLine();
            TimeStamp = DateTime.Now;
            string BillString, BillSerial;
            BillString = TimeStamp.ToString("ddMMyyyy");
            Random random_serial = new Random();
            BillCode = BillString + $"{random_serial.Next(1000, 10000)}";
            Console.WriteLine("Enter Usage");
            Usage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Reading added Successfully");

        }
        public (string, DateTime, string BillCode, double usage)getReading()
        {
            return (MeterID, TimeStamp, BillCode,Usage);
        }
    }
}
