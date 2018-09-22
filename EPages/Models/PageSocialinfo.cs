using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class PageSocialinfo
    {
        public int PageinfoID { get; set; }
        public int PageID { get; set; }

        public string FB { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }

    }
}