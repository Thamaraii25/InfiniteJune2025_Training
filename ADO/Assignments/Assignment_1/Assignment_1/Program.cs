using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            List<Employee> employeeList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-6-8"), City = "Mumbai"},
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("1994-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1987-11-14"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1990-06-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1991-03-08"), DOJ = DateTime.Parse("2016-02-02"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("1989-11-07"), DOJ = DateTime.Parse("2014-08-08"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("1989-12-02"), DOJ = DateTime.Parse("2015-06-01"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("1993-11-11"), DOJ = DateTime.Parse("2014-11-06"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("1992-08-12"), DOJ = DateTime.Parse("2014-12-03"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("1991-04-12"), DOJ = DateTime.Parse("2016-01-02"), City = "Pune" }
            };

            //Query 1
            //Display a list of all the employee who have joined before 1/1/2015
            var q1 = from e in employeeList
                     where e.DOJ < DateTime.Parse("2015-01-01")
                     select e;
            Console.WriteLine("\nList of all the employee who have joined before 1/1/2015");
            emp.DisplayEmployee(q1);

            //Query 2
            //Display a list of all the employee whose date of birth is after 1/1/1990
            var q2 = from e in employeeList
                     where e.DOB > DateTime.Parse("1990-01-01")
                     select e;
            Console.WriteLine("\nList of all the employee whose date of birth is after 1/1/1990");
            emp.DisplayEmployee(q2);

            //Query 3
            //Display a list of all the employee whose designation is Consultant and Associate
            var q3 = from e in employeeList
                     where e.Title == "Consultant" || e.Title == "Associate"
                     select e;
            Console.WriteLine("\nList of all the employee whose designation is Consultant and Associate");
            emp.DisplayEmployee(q3);

            //Query 4
            //Display total number of employees
            int q4 = (from e in employeeList
                     select e).Count();
            Console.WriteLine("\nTotal number of employees: {0}",q4);


            //Query 5
            //Display total number of employees belonging to “Chennai”
            int q5 = (from e in employeeList
                      where e.City == "Chennai"
                      select e).Count();
            Console.WriteLine("\nTotal number of employees belonging to Chennai: {0}",q5);

            //Query 6
            //Display highest employee id from the list
            int q6 = (from e in employeeList
                      select e.EmployeeID).Max();
            Console.WriteLine("\nHighest Employee Id: {0}",q6);

            //Query 7
            //Display total number of employee who have joined after 1/1/2015
            int q7 = (from e in employeeList
                      where e.DOJ > DateTime.Parse("2015-01-01")
                      select e).Count();
            Console.WriteLine("\nTotal number of employee who have joined after 1/1/2015: {0}",q7);

            //Query 8
            //Display total number of employee whose designation is not “Associate”
            int q8 = (from e in employeeList
                      where e.Title != "Associate"
                      select e).Count();
            Console.WriteLine("\nTotal number of employee whose designation is not Associate: {0}",q8);

            //Query 9
            //Display total number of employee based on City
            var q9 = from e in employeeList
                     group e by e.City into g
                     select new { City = g.Key, Count = g.Count() };
            Console.WriteLine("\nTotal number of employees based on City:");
            foreach (var g in q9)
            {
                Console.WriteLine($"{g.City}: {g.Count}");
            }

            //Query 10
            //Display total number of employee based on city and title
            var q10 = (from e in employeeList
                       group e by new { e.City, e.Title } into g
                       select new { g.Key.City, g.Key.Title, Count = g.Count() });
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            foreach (var g in q10)
            {
                Console.WriteLine($"{g.City}, {g.Title}, {g.Count}");
            }

            //Query 11
            //Display total number of employee who is youngest in the list
            var youngestDOB = (from e in employeeList
                          select e.DOB).Max();
            var q11 = from e in employeeList
                      where e.DOB == youngestDOB
                      select e;
            Console.WriteLine("\nDetails of the youngest employee:");
            emp.DisplayEmployee(q11);
            Console.Read();

        }
    }

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public void DisplayEmployee(IEnumerable<Employee> employeeList)
        {
            foreach (var e in employeeList)
            {
                Console.WriteLine($"Employee Id: {e.EmployeeID}, First Name: {e.FirstName}, Last Name: {e.LastName}, Title: {e.Title}, DOB: {e.DOB:dd-MM-yyyy}, DOJ: {e.DOJ:dd-MM-yyyy}, City: {e.City}");
            }
        }

    }
}
