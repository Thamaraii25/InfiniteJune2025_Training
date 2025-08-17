using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace ElectricityBoardBilling
{
    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
    }
}