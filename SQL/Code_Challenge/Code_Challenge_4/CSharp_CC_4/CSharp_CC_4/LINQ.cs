using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CC_4
{
    class LINQ
    {
        static void Main(string[] args)
        {

            List<Employee> employeeList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16-11-1984"), DOJ = DateTime.Parse("08-06-2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20-08-1994"), DOJ = DateTime.Parse("07-07-2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14-11-1987"), DOJ = DateTime.Parse("12-04-2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("03-06-1990"), DOJ = DateTime.Parse("02-02-2016"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("08-03-1991"), DOJ = DateTime.Parse("02-02-2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("07-11-1989"), DOJ = DateTime.Parse("08-08-2014"), City = "Chennai" },

            };


            Console.WriteLine("---------All Employee Details--------");
            Employee.Display(employeeList);

            Console.WriteLine("\nEmployee Whose Location Is Not Mumbai");
            var locationNotMumbai = employeeList.Where(e => e.City != "Mumbai");
            Employee.Display(locationNotMumbai);

            Console.WriteLine("\nFind Employee Title of Assistent Manager");
            var findTitleForAssManager = employeeList.Where(e => e.Title == "AsstManager");
            Employee.Display(findTitleForAssManager);

            Console.WriteLine("\nEmployees whose last name starts with 'S'");
            var lastName = employeeList.Where(e => e.LastName.StartsWith("S"));
            Employee.Display(lastName);

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

        public static void Display(IEnumerable<Employee> employeeList)
        {
            foreach (var e in employeeList)
            {
                Console.WriteLine($" Employee Id: {e.EmployeeID}, First Name : {e.FirstName} , Last Name : {e.LastName}, Title: {e.Title}, DOB: {e.DOB}, DOJ: {e.DOJ}, City: {e.City}");
            }
        }
    }
}