using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RailwayReservationADO
{
    class GetSQLConnection
    {
        public static SqlConnection getConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            return con;
        }
    }
}
