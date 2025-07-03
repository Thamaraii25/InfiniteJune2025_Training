using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    /*
     2. Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input. 
            If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
            If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
            If the given mark is >90, then calculate scholarship amount as 50% of the fees.
            In all the cases return the Scholarship amount, else throw an user exception
     */

    class ScholarshipSystemWithExceptionHandling
    {
        public static void Main()
        {
            ScholarshipCalculation scholarshipCalc = new ScholarshipCalculation();

            try
            {
                float res = scholarshipCalc.GetData();
                Console.WriteLine("ScholarShip Amount: {0}",res);
            }
            catch(ScoreLessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
    class ScholarshipCalculation
    {
        public int Score;
        public int Fees;
        public float GetData()
        {
            Console.WriteLine("Input Score (1-100)");
            Score = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Total Fees ");
            Fees = Convert.ToInt32(Console.ReadLine());
            return Merit(Score, Fees);

        }
        public float Merit(int score,int fees)
        {
            if(Score > 90)
            {
                return (0.5f * fees);
            }
            else if (Score > 80)
            {
               return (0.3f * fees);
            }
            else if (Score >= 70)
            {
                return (0.2f * fees);
            }
            else
            {
                throw new ScoreLessException("Score is Too Less to qualify for the Scholarship Amount");
            }
        }
    }

    class ScoreLessException : ApplicationException
    {
        public ScoreLessException(string message) : base(message) { }
    }

}
