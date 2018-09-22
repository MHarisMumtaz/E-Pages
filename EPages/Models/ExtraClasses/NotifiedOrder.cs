using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace EPages.Models
{
    public class NotifiedOrder
    {
        public int Page_ID { get; set; }
        public int OrderID { get; set; }

        public string title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UAddress { get; set; }
        public string Number { get; set; }

        public static IEnumerable<NotifiedOrder> GetNotified(int userID)
        {
            IEnumerable<NotifiedOrder> list = DataBase.SelectFromDB<NotifiedOrder>("notfiedorder", new SqlParameter[] { new SqlParameter("@uid", userID) });
            return list;
        }
    }
}