using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPriceCalculation;

namespace Assignment_7
{
    class TravelBooking
    {
        public static void Main() {
            ConcessionCalculator concession = new ConcessionCalculator();
            Console.WriteLine("Input Age: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            concession.CalculateConcession(Age);

            Console.Read();
        }
    }
}
