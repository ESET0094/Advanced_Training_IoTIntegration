using System.Xml.Serialization;

namespace MeteringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();            
            Customer customer = new Customer();
            List<Customer> list = new List<Customer>();
            List<SmartMeter> smartMeterList = new List<SmartMeter>();
            List<Reading> readings = new List<Reading>();
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
                    case 0:
                       
                        break;
                    case 1:
                        customer.addCustomer();
                        list.Add(customer);
                        break;
                    case 2:
                        smartMeter.getInputData();
                        smartMeterList.Add(smartMeter);
                        break;
                    case 3:
                        string custID = Console.ReadLine();
                        string smartMeters = Console.ReadLine();
                        mapMeter.getData(custID, smartMeters);
                        break; 
                    case 4:
                        try
                        {
                            reading.addReading();

                        }
                        catch (SystemException ex)
                        {
                            Console.WriteLine($"Usage Exceed Limit {ex}");
                        }
                       catch (Exception) {
                          Console.WriteLine("Corrupted Reading");
                       }
                        readings.Add(reading);

                        break;
                    case 5:
                        BillSummary(mapMeter, list, smartMeterList,readings);
                        break;
                    case 6:
                        i=1;
                        break;
                }
            }
            }

        // Validation to check existing and new // validation to check unique fields

        public static void BillSummary(MapMeter mapMeter, List<Customer> CustomerList, List<SmartMeter> SmartMeterList, List<Reading> readings)
        {
            Console.WriteLine("Enter Customer ID: ");
            string CustomerID = Console.ReadLine();
            foreach (var customer in CustomerList) {
                if (customer.ID == CustomerID)
                    customer.DisplayData();
            }
            string smartMeterID = mapMeter.returnData(CustomerID);
            foreach (var smartMeter in SmartMeterList)
            {
                if (smartMeter.MeterID == smartMeterID) smartMeter.DisplayData();
            }
            double Usage = 0;
            foreach (var reading in readings)
            {
                if (reading.MeterID == smartMeterID) Usage += reading.Usage;
            }

            
            
            double BillAmount = Usage * 5;
            Console.WriteLine($"Total Consumption: {Usage} kWh");
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
}
