using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 3.	Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
Write a program for following requirement
    a.	To display all employees data
    b.	To display all employees data whose salary is greater than 45000
    c.	To display all employees data who belong to Bangalore Region
    d.	To display all employees data by their names is Ascending order
 */
namespace Assignment_7
{
    class EmployeeQuestion
    {
        public static void Main(String[] args)
        {
            Employee employee = new Employee();

            int ch = 0;
            do
            {
                Console.WriteLine("\nInput Choice: ");
                Console.WriteLine("1. To Add Employee");
                Console.WriteLine("2. To display all employees data");
                Console.WriteLine("3. To display all employees data whose salary is greater than 45000");
                Console.WriteLine("4. To display all employees data who belong to Bangalore Region");
                Console.WriteLine("5. To display all employees data by their names is Ascending order\n");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        employee.getData();
                        break;
                    case 2:
                        employee.DisplayData(employee.employeeList);
                        break;
                    case 3:
                        Console.WriteLine("\nEmployee Salary Greater than 45000");
                        var highSalary = employee.employeeList.Where(e => e.EmpSalary > 45000);
                        employee.DisplayData(highSalary);
                        break;
                    case 4:
                        Console.WriteLine("\nEmployees data who belong to Bangalore Region ");
                        var fromBangalore = employee.employeeList.Where(e => !string.IsNullOrEmpty(e.EmpCity) && e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
                        employee.DisplayData(fromBangalore);
                        break;
                    case 5:
                        Console.WriteLine("\nEmployees data by their names is Ascending order");
                        var sortedByName = employee.employeeList.OrderBy(e => employee.EmpName);
                        employee.DisplayData(sortedByName);
                        break;
                    default:
                        break;

                }
            } while (ch < 6);

            Console.Read();
        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }


        public List<Employee> employeeList = new List<Employee>();

        public void getData()
        {
            Console.WriteLine("\n------------Getting Employee Details---------");
            Console.WriteLine("Input Emp Id: ");
            int I_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Emp Name: ");
            string I_Name = Console.ReadLine();
            Console.WriteLine("Input Emp City: ");
            string I_City = Console.ReadLine();
            Console.WriteLine("Input Emp Salary: ");
            int I_Salary = Convert.ToInt32(Console.ReadLine());

            AddData(new Employee { EmpId = I_Id, EmpName = I_Name, EmpCity = I_City, EmpSalary = I_Salary });
        }


        public void AddData(Employee emp)
        {
            employeeList.Add(emp);
        }

        public void DisplayData(IEnumerable<Employee> employees)
        {
            Console.WriteLine("\n---------List of Employee Details-------");
            foreach(var item in employees)
            {
                Console.WriteLine($"{item.EmpId}, {item.EmpName}, {item.EmpCity}, {item.EmpSalary}");
            }
        }
    }
}
