using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_6
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static void Main(string[] args)
        {
            
            InsertEmployee();
            Console.WriteLine();
            UpdateSalary();
            Console.WriteLine();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source = ICS-LT-5HK96V3\\SQLEXPRESS; Initial Catalog = CodeChallenge; user id = sa; password = Thamarai2514@#");
            con.Open();
            return con;
        }

        static void InsertEmployee()
        {
            try
            {
                con = getConnection();

                Console.Write("Input Employee Name: ");
                string I_Name = Console.ReadLine();

                Console.Write("Input Gender: ");
                string I_Gender = Console.ReadLine();

                Console.Write("Input Salary: ");
                float I_Salary = float.Parse(Console.ReadLine());

                cmd = new SqlCommand("sp_InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpName", I_Name);
                cmd.Parameters.AddWithValue("@EmpGender", I_Gender);
                cmd.Parameters.AddWithValue("@EmpSalary", I_Salary);

                SqlParameter param = new SqlParameter();
                param.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int generatedEmpId = Convert.ToInt32(param.Value);
                Console.WriteLine("Generated Employee ID: " + generatedEmpId);

                SqlCommand empDetails = new SqlCommand("select EmpId, Name, Gender,Salary, NetSalary from Employee_Details where EmpId = @EmpId", con);
                empDetails.Parameters.AddWithValue("@EmpId", generatedEmpId);

                dr = empDetails.ExecuteReader();
                Console.WriteLine();
                while (dr.Read())
                {
                    Console.WriteLine("Employee Details");
                    Console.WriteLine("EmpId: " + dr["EmpId"]);
                    Console.WriteLine("Name: " + dr["Name"]);
                    Console.WriteLine("Gender: " + dr["Gender"]);
                    Console.WriteLine("Salary: " + dr["Salary"]);
                    Console.WriteLine("Net Salary: " + dr["NetSalary"]);
                }
                dr.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateSalary()
        {
            try
            {
                con = getConnection();

                Console.Write("Input EmpId to Update Salary: ");
                int empId = Convert.ToInt32(Console.ReadLine());

                SqlCommand EmployeSalaryBeforeUpdation = new SqlCommand("select EmpId, Name,Salary from Employee_Details where EmpId = @EmpId", con);
                EmployeSalaryBeforeUpdation.Parameters.AddWithValue("@EmpId", empId);

                SqlDataReader dr = EmployeSalaryBeforeUpdation.ExecuteReader();
                Console.WriteLine();
                while (dr.Read())
                {
                    Console.WriteLine("Employee Details Before Update:");
                    Console.WriteLine("EmpId: " + dr["EmpId"]);
                    Console.WriteLine("Name: " + dr["Name"]);
                    Console.WriteLine("Salary: " + dr["Salary"]);
                }
                dr.Close();

                cmd = new SqlCommand("sp_GetUpdatedSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);

                SqlParameter param = new SqlParameter("@UpdatedSalary", SqlDbType.Float);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                Console.WriteLine("\nUpdated Salary: " + param.Value);

                SqlCommand EmployeSalaryAfterUpdatation = new SqlCommand("select EmpId, Name, Salary from Employee_Details where EmpId = @EmpId", con);
                EmployeSalaryAfterUpdatation.Parameters.AddWithValue("@EmpId", empId);

                dr = EmployeSalaryAfterUpdatation.ExecuteReader();
                Console.WriteLine();
                while (dr.Read())
                {
                    Console.WriteLine("Employee Details After Update:");
                    Console.WriteLine("EmpId: " + dr["EmpId"]);
                    Console.WriteLine("Name: " + dr["Name"]);
                    Console.WriteLine("Salary: " + dr["Salary"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}







