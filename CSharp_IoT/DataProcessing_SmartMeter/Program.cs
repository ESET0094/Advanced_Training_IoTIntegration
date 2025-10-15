using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace DataProcessing_SmartMeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                string MeterData = getInputSample();
                list.Add(MeterData);
            }
            double Usage = 0;
            for (int i=0; i<3;i++)
            {
                string MeterData = list[i];
                if (verifyMeterData(MeterData))
                {
                    string[] Data = MeterData.Split('|');
                    DisplayData(Data);
                    Usage += retrieveUsage(Data[2]);
                }
                else
                {
                    Console.WriteLine($"Invalid Meter Data : {MeterData}");
                    //list.Remove(MeterData);
                    

                }
            }
            Console.WriteLine($"Total Usage : {Usage}");

            double TotalDue = CalculateBillAmount(Usage);
            Console.WriteLine($"Total Bill Amount to be Paid:{TotalDue}");
           

            }
        
        public static string getInputSample()
        {
            string Sample = Console.ReadLine();
            return Sample;
        }
        public static bool verifyMeterData(string MeterData)
        {
            if (MeterData != null)
            {
                if (MeterData.StartsWith("SM"))
                {
                    Console.WriteLine("Valid Meter Data. Can Proceed");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Meter Data. Discarded");
                    return false;
                }
            }
            return false;
        }
        public static void DisplayData(string[] Data) {
            Console.WriteLine($"Meter ID:{Data[0]}");
            //check TimeStamp Format
            Console.WriteLine($"TimeStamp:{Data[1]}");

            //retrieveUsageFunction
            Console.WriteLine($"{Data[2]}");
            //Location Retrieve Function for BUILDING AND FLOOR 
            (int FloorCode, string BuildingCode) = getBuildingFloorCode(Data[3]);
            Console.WriteLine($"Floor : {FloorCode}");
            Console.WriteLine($"Building {BuildingCode}");
            
            }
        /* "SM12345|2025-10-15 14:30|Usage: 34.5 kWh|Location: Floor 2 - Building A",
            "SM12345|2025-10-15 15:00|Usage: 40.2 kWh|Location: Floor 2 - Building A",
            "12345SM|2025-10-15 15:30|Usage: 29.1 kWh|Location: Floor 1 - Building C"   -> Invalid Meter Data*/
        public static double retrieveUsage(string UsageString)
        {
            string[] Data = UsageString.Split();
            double Usage = Convert.ToDouble(Data[1]);
            return Usage;
        }
        public static (int, string) getBuildingFloorCode(string Location)
        {
            string[] Data = Location.Split();
            int FloorCode = Convert.ToInt32(Data[2]);
            string BuildingCode =(Data[5]);   
            return (FloorCode, BuildingCode);
        }
        public static double CalculateUsage(double[] doubles)
        {
            double sum = 0;
            foreach (var i in doubles)
            {
                sum += i;
            }
            return sum;
        }
        public static double CalculateBillAmount(double TotalUsage)
        {
            double TotalBill = TotalUsage * 5;
            return TotalBill ;
        }
    }
}
