using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int PageItemID { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}