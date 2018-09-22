using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPages
{
    public class ConnectionString
    {
        static SqlConnection con;

        public static SqlConnection Connect()
        {
            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\HM; Initial Catalog = epages; Integrated Security= SSPI; ";
                con.Open();
            }
            return con;
        }
    }
}