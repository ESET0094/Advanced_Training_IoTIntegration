using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Excepsion:Exception
    {
        public Excepsion(string codes):base(codes)
           
        {
            string short_description = string.Empty;
            if (codes == null) throw new ArgumentNullException("code");
            if (codes == "100")
            {
                short_description = "Negative Value Entered";
            }
            if (codes == "200")
            { short_description = "Cannot Accept Floating Values for Age"; }

            Console.WriteLine($"{DateTime.Now} Exception Code:{codes} {short_description}");
        }
    }
}
