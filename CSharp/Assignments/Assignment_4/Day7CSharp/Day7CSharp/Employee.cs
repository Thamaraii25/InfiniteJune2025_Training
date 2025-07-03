using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7CSharp
{

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Department { get; set; }
        public double Salary { get; set; }



        List<Employee> employeeList = new List<Employee>();

        internal void AddNewEmployee(Employee employee)
        {
            employeeList.Add(employee);
            Console.WriteLine("Employee Added Successfully");
        }

        internal void ViewAllEmployee()
        {
            Console.WriteLine("---------Display All Employees---------");

            if(employeeList.Count == 0)
            {
                Console.WriteLine("No Employees Found: Try To Add Employees And Check Again");
            }

            foreach(var item in employeeList)
            {
                Console.WriteLine($"{item.Id} , {item.Name} , {item.Department} , {item.Salary}");
            }
        }

        internal void SearchEmployeeById(int Id)
        {
            foreach(var item in employeeList)
            {
                if(item.Id == Id)
                {
                    Console.WriteLine("Search Result Based On Employee - ID");
                    Console.WriteLine($"{item.Id} , {item.Name} , {item.Department} , {item.Salary}");
                    break;
                }
            }
        }

        internal void UpdateEmployeeDetails(int Id)
        {
            foreach(var item in employeeList)
            {
                if(item.Id == Id)
                {
                    Console.WriteLine("Enter the Updated Details of Employee");
                    Console.WriteLine("Enter Name of Employee-Id {0}",item.Id);
                    string UName = Console.ReadLine();
                    item.Name = UName;
                    Console.WriteLine("Enter Department of Employee-Id {0}", item.Id);
                    string UDept = Console.ReadLine();
                    item.Department = UDept;
                    Console.WriteLine("Enter Salary of Employee-Id {0}", item.Id);
                    double USalary = Convert.ToDouble(Console.ReadLine());
                    item.Salary = USalary;

                    Console.WriteLine("Employee Updated Successfully");
                    break;
                }
            }
        }

        internal void DeleteEmployee(int Id)
        {
            for(int i = 0; i < employeeList.Count; i++)
            {
                if(employeeList[i].Id == Id)
                {
                    employeeList.RemoveAt(i);
                    Console.WriteLine("Employee Deleted Successfully");
                    break;
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            int ch;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Select the Choice from Below");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine();


                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            Console.WriteLine("------Enter the Employee Details----------");
                            Console.Write("Input Employee - Id: ");
                            int I_Id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input Employee - Name: ");
                            string I_Name = Console.ReadLine();
                            Console.Write("Input Employee - Department: ");
                            string I_Department = Console.ReadLine();
                            Console.Write("Input Employee - Salary: ");
                            Double I_Salary = Convert.ToDouble(Console.ReadLine());

                            emp.AddNewEmployee(new Employee { Id = I_Id, Name = I_Name, Department = I_Department, Salary = I_Salary});
                            break;   
                        }
                    case 2:
                        {
                            emp.ViewAllEmployee();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter Employee Id For Searching: ");
                            int UId = Convert.ToInt32(Console.ReadLine());
                            emp.SearchEmployeeById(UId);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Enter Employee Id For Updating: ");
                            int UId = Convert.ToInt32(Console.ReadLine());
                            emp.UpdateEmployeeDetails(UId);
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Enter Employee Id For Deleting: ");
                            int UId = Convert.ToInt32(Console.ReadLine());
                            emp.DeleteEmployee(UId);
                            break;
                        }
                    default:
                        break;

                }
            } while (ch < 6);

            Console.Read();
        }
            
    }

}
