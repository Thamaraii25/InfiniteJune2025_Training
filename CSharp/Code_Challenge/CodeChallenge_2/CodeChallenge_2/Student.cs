using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 1. Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  

Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.

Test the above by creating appropriate objects
 */

namespace CodeChallenge_2
{
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public float Grade;

        public Student(string name, int id, float grade)
        {
            Name = name;
            StudentId = id;
            Grade = grade;
        }

        public abstract bool IsPassed(float grade);
    }

    class UnderGraduate : Student
    {
        public UnderGraduate(string name, int id, float grade) : base(name, id, grade) { }

        public override bool IsPassed(float grade)
        {
            return (grade > 70.0f);
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int id, float grade) : base(name, id, grade) { }

        public override bool IsPassed(float grade)
        {
            return (grade > 80.0f);
        }
    }

    class StudentQuestion
    {
        public static void Main()
        {
            Console.Write("Input Name: ");
            string I_Name = Console.ReadLine();

            Console.Write("Input Id: ");
            int I_Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Grade: ");
            float I_Grade = float.Parse(Console.ReadLine());

            UnderGraduate underGraduate = new UnderGraduate(I_Name, I_Id, I_Grade);
            Console.WriteLine($"Undergraduate Student Passed: {underGraduate.IsPassed(I_Grade)}");

            Graduate graduate = new Graduate(I_Name, I_Id, I_Grade);
            Console.WriteLine($"Graduate Student Passed: {graduate.IsPassed(I_Grade)}");

            Console.Read();
        }
    }
}



