using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ElectricityBoardBilling
{
    public class Login
    {
        string Email = "admin@gmail.com";
        string Password = "admin@123";

        public bool ValidateLogin(string email,string password)
        {
            if (email == Email && password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // To validate the given units consumed. Units consumed must not be less than zero
    public class BillValidator
    {
        public void ValidateConsumerNumber(string consumerNumber)
        {
            if(!(consumerNumber.StartsWith("EB") && consumerNumber.Length == 7))
            {
                throw new FormatException("Consumer Number is Not in the Correct Format...");
            }
        }

        public string ValidateUnitsConsumed(int UnitsConsumed)
        {
            if(UnitsConsumed < 0)
            {
                return "Given Units Is Invalid";
            }
            return "";
        }   
    }

    // This model object holds the state of the electricity bill at all point-in-time.
    public class ElectricityBill
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get
            {
                return consumerNumber;
            }
            set
            {
                consumerNumber = value;
            }
        }
        public string ConsumerName
        {
            get
            {
                return consumerName;
            }
            set
            {
                consumerName = value;
            }
        }
        public int UnitsConsumed
        {
            get
            {
                return unitsConsumed;
            }
            set
            {
                unitsConsumed = value;
            }
        }
        public double BillAmount
        {
            get
            {
                return billAmount;
            }
            set
            {
                billAmount = value;
            }
        }
    }

    public class ElectricityBoard
    {
        SqlConnection con = DBHandler.GetConnection();
        public double CalculateBill(int unitsConsumed)
        {
            double BillAmount = 0;

            if (unitsConsumed <= 100)
            {
                BillAmount = 0;
            }
            else if (unitsConsumed <= 300)
            {
                BillAmount = (unitsConsumed - 100) * 1.5;
            }
            else if (unitsConsumed <= 600)
            {
                BillAmount = (200 * 1.5) + (unitsConsumed - 300) * 3.5;
            }
            else if (unitsConsumed <= 1000)
            {
                BillAmount = (200 * 1.5) + (300 * 3.5) + (unitsConsumed - 600) * 5.5;
            }
            else
            {
                BillAmount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (unitsConsumed - 1000) * 7.5;
            }
            return BillAmount;
        }

        public string AddBill(ElectricityBill ebill)
        {
            try
            {
                BillValidator validator = new BillValidator();
                validator.ValidateConsumerNumber(ebill.ConsumerNumber);

                string msg = validator.ValidateUnitsConsumed(ebill.UnitsConsumed);
                if(msg != "")
                {
                    return msg;
                }

                con.Open();
                string query = "insert into ElectricityBill(Consumer_number,Consumer_name,Units_consumed,Bill_amount) " +
                    "values(@Consumer_number,@Consumer_name,@Units_consumed,@Bill_amount)";

                SqlCommand insertBill = new SqlCommand(query, con);
                insertBill.Parameters.AddWithValue("@Consumer_number",ebill.ConsumerNumber);
                insertBill.Parameters.AddWithValue("@Consumer_name", ebill.ConsumerName);
                insertBill.Parameters.AddWithValue("@Units_consumed", ebill.UnitsConsumed);
                insertBill.Parameters.AddWithValue("@Bill_amount", ebill.BillAmount);

                int count = insertBill.ExecuteNonQuery();

                if(count > 0)
                {
                    return "Record Inserted Successfully..";
                }
                else
                {
                    return "Some Error Happend..Data Not inserted..";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> eList = new List<ElectricityBill>();

            try
            {
                con.Open();
                string query = "select top (@num) *  from ElectricityBill order by Consumer_number desc";
                SqlCommand selectBill = new SqlCommand(query, con);
                selectBill.Parameters.AddWithValue("@num", num);
                SqlDataReader dr = selectBill.ExecuteReader();

                while (dr.Read())
                {
                    ElectricityBill eb = new ElectricityBill();

                    eb.ConsumerNumber = dr["Consumer_number"].ToString();
                    eb.ConsumerName = dr["Consumer_name"].ToString();
                    eb.UnitsConsumed = Convert.ToInt32(dr["Units_consumed"]);
                    eb.BillAmount = Convert.ToDouble(dr["Bill_amount"]);

                    eList.Add(eb);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return eList;
        }
    }
}