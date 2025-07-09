using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_3
{
    /*
     1. Write a program to find the Sum and the Average points scored by the teams in the IPL. 
        Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) 
        that takes no.of matches as input and accepts that many scores from the user. 
        The function should then return the Count of Matches, Average and Sum of the scores.
     */
    class Program
    {
        static void Main(string[] args)
        {
            CricketTeam cricketTeam = new CricketTeam();
            Console.Write("Input No. of Matches: ");
            int numberOfMatches = Convert.ToInt32(Console.ReadLine());
            double average;
            int sumOfScores = cricketTeam.PointsCalculation(numberOfMatches, out average);
            Console.WriteLine();
            Console.WriteLine("No of Matches Playes in IPL: {0} ",numberOfMatches);
            Console.WriteLine("Sum of Scores of all Matches: {0} ",sumOfScores);
            Console.WriteLine("Average Score: {0}",average);
            Console.Read();
        }
    }

    class CricketTeam
    {
        public int PointsCalculation(int no_of_matches,out double average)
        {
            int sumOfScores = 0;
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine("Input Score of Match {0}",i+1);
                int temp = Convert.ToInt32(Console.ReadLine());
                sumOfScores += temp;
            }
            average = (sumOfScores / no_of_matches);
            return sumOfScores;
        }
    }
}
