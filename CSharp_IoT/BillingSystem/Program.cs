using System.Diagnostics.CodeAnalysis;

namespace BillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------Billing System----------");
            string ZoneCode; string Tariff; double Units;
            (ZoneCode, Tariff, Units) = getBillingData();
            Zone_Select(ZoneCode, Tariff, Units);

        }
        public static (string zone, string tariff, double units) getBillingData()
        {
            Console.WriteLine("Enter your Zone Code : [Z1/Z2/Z3]");
            string ZoneCode = Console.ReadLine();
            Console.WriteLine("Enter Tariff: [LT1/LT2/LT3]");  // LT1 - Domestic LT2 - Commercial LT3 - Agriculture
            string Tariff = Console.ReadLine();
            Console.WriteLine("Total Units Consumed:");
            double Units = Convert.ToDouble(Console.ReadLine());
            return (ZoneCode, Tariff, Units);
        }
        public static void Select_Tariff(string Tariff, double units, int[] dTariff, int[] cTariff, int[] aTariff)
        {
            switch (Tariff)
            {
                case "LT1":

                    Calculate_Tariff(units, dTariff);
                    break;
                case "LT2":
                    Calculate_Tariff(units, cTariff);
                    break;
                case "LT3":
                    Calculate_Tariff(units, aTariff);
                    break;
                default:
                    Console.WriteLine("Incorrect Details. Enter Again");
                    break;
            }
        }
        public static void Zone_Select(string ZoneCode, string Tariff, double Units)
        {
            switch (ZoneCode)
            {
                case "Z1":
                    Select_Tariff(Tariff, Units, [1, 2, 3], [1, 2, 4], [0, 1, 2]);
                    break;
                case "Z2":
                    Select_Tariff(Tariff, Units, [2, 3, 4], [1, 2, 4], [0, 0, 1]);
                    break;
                case "Z3":
                    Select_Tariff(Tariff, Units, [1, 2, 3], [1, 2, 3], [0, 1, 2]);
                    break;
                default:
                    Console.WriteLine("Incorrect Details. Enter Again");
                    break;

            }
        }
        public static void Calculate_Tariff(double units, int[] Tariff_Slabs)
        {
            DateTime CurrentTime = DateTime.Now;
            DateTime BillDeadlineDate = CurrentTime.AddDays(10);
            TimeSpan desiredTime = new TimeSpan(23, 59, 59);
            DateTime BillDeadline = BillDeadlineDate.Date.Add(desiredTime);
            string BillString, BillSerial;
            BillString = CurrentTime.ToString("ddMMyyyy");
            Random random_serial = new Random();
            BillSerial = BillString + $"{random_serial.Next(1000, 10000)}";

            if (units < 50)
            {
                double BillAmount = units * Tariff_Slabs[0];
                Console.WriteLine($"Total Bill Amount Generated on {CurrentTime}:Rs.{BillAmount}.\nKindly pay the bill by {BillDeadline} to avoid penalties\n Bill No: {BillSerial}");
            }
            else if (units >= 50 && units < 100)
            {
                double BillAmount = (units - 50) * Tariff_Slabs[1] + 50 * Tariff_Slabs[0];
                Console.WriteLine($"Total Bill Amount Generated on {CurrentTime}:Rs.{BillAmount}.\nKindly pay the bill by {BillDeadline} to avoid penalties\n Bill No: {BillSerial}");

            }
            else
            {
                double BillAmount = 50 *Tariff_Slabs[0] + 50 * Tariff_Slabs[1] + (units - 100) * Tariff_Slabs[2];
                Console.WriteLine($"Total Bill Amount Generated on {CurrentTime}:Rs.{BillAmount}.\nKindly pay the bill by {BillDeadline} to avoid penalties\n Bill No: {BillSerial}");
            }
        }
    }
}
