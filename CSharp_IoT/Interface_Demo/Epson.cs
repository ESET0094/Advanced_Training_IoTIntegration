using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo
{
    internal class Epson:IPrint
    {
        public void getData(int pageIndex, int pageCount, string pageSize)
        {
            pageIndex = Convert.ToInt32(Console.ReadLine());
            pageSize = Console.ReadLine();
            pageCount = Convert.ToInt32(Console.ReadLine());

        }
    }
}
