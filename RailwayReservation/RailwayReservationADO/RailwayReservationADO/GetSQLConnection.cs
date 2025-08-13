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
            string connString = "Data Source = ICS-LT-5HK96V3\\SQLEXPRESS; Initial Catalog = RailwayReservation; user id = sa; password = Thamarai2514@#";
            SqlConnection con = new SqlConnection(connString);
            return con;
        }
    }
}
