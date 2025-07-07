using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPriceCalculation
{
    public class ConcessionCalculator
    {
        public const int TotalFare = 500;
        public void CalculateConcession(int age)
        {
            if(age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if(age > 60)
            {
                float discountPrice = (TotalFare * 0.3f);
                Console.WriteLine("Senior Citizen " + (TotalFare - discountPrice));
            }
            else
            {
                Console.WriteLine("Ticket Booked " + TotalFare);
            }
        }
    }
}
