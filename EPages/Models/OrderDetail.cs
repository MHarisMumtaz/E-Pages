using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
    }
}