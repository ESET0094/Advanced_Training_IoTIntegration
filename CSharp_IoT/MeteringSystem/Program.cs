using System.Xml.Serialization;

namespace MeteringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            SmartMeter smartMeter = new SmartMeter();
            Reading reading = new Reading();
            MapMeter mapMeter = new MapMeter();
            int choice;

            int i=0;
            while (i==0)
            {
                choice = choiceselection();
                switch (choice)
                {
                    case 1:
                        customer.addCustomer();
                        break;
                    case 2:
                        smartMeter.getInputData();
                        break;
                    case 3:
                        mapMeter.getData(customer.ID, smartMeter.MeterID);
                        break;
                    case 4:
                        reading.addReading();
                        break;
                    case 5:
                        BillSummary(mapMeter, reading);
                        break;
                    case 6:
                        i=1;
                        break;
                }
            }
            }

        
        public static void BillSummary(MapMeter mapMeter, Reading reading)
        {
            mapMeter.DisplayData();
            double BillAmount = reading.Usage * 5;
            Console.WriteLine($"Total Consumption: {reading.Usage} kWh");
            Console.WriteLine($"Bill Amount: Rs. {BillAmount}"); 
        }
        public static int choiceselection()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("1. Add Customer \n2. Add Smart Meter \n3. Map Meter \n4. Add Reading \n5. Bill Summary");
            Console.WriteLine("Enter Your Choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
