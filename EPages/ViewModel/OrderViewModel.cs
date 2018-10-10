using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EPages.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int PageID { get; set; }
        public string title { get; set; }
        public string AccountNo { get; set; }


        public static IEnumerable<OrderViewModel> GetOrders(int userid)
        {
            IEnumerable<OrderViewModel> list = DataBase.SelectFromDB<OrderViewModel>("getorders", new SqlParameter[] { new SqlParameter("@uid", userid) });
            return list;
        }

    }
}