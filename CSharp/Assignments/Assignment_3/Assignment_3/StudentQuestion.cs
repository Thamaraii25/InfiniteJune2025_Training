using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    /*
     2. Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )

            -Pass the details of student like rollno, name, class, SEM, branch in constructor

            -For marks write a method called GetMarks() and give marks for all 5 subjects

            -Write a method called displayresult, which should calculate the average marks

            -If marks of any one subject is less than 35 print result as failed
            -If marks of all subject is >35,but average is < 50 then also print result as failed
            -If avg > 50 then print result as passed.

            -Write a DisplayData() method to display all object members values.

     */
    class Student
    {
        int RollNo;
        string Name;
        string Class;
        string Semester;
        string Branch;
        int[] Marks = new int[5];
        float Average;
        string Result;

        public Student(int rollNo, string name, string cl,string sem, string branch)
        {
            this.RollNo = rollNo;
            this.Name = name;
            this.Class = cl;
            this.Semester = sem;
            this.Branch = branch;
        }

        public void GetMarks()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter Subject {0} Mark: ",i+1);
                Marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int Sum = 0;
            foreach(int i in Marks)
            {
                if (i < 35)
                {
                    Result = "Failed";
                    Console.WriteLine("Failed");
                    break;
                }
                Sum += i;
            }

            Average = Sum / 5.0f;
            if(Average < 50)
            {
                Result = "Failed";
                Console.WriteLine("Failed");
            }
            else
            {
                Result = "Pass";
                Console.WriteLine("Pass");
            }
        }

        public string DisplayData()
        {
            return ($"Roll No: {RollNo} , Name: {Name} , Class: {Class} , Semester: {Semester} , Branch: {Branch} ," +
                $"Marks in 5 Subjects:  {String.Join(", ",Marks)} , Result: {Result}");
        }
    }
    class StudentQuestion
    {
        public static void Main()
        {

            Student s = new Student(1806636, "Thamarai", "UG", "VIII", "IT");
            s.GetMarks();
            s.DisplayResult();
            Console.WriteLine(s.DisplayData());

            Console.Read();
        }
    }
}
