using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class PageItems
    {
        public int ItemID { get; set; }
        public int PageID { get; set; }
        public string Name { get; set; }
        public int price { get; set; }

        public int Quantity { get; set; }
        public string Desc { get; set; }

        public string PicName { get; set; }
    }
}