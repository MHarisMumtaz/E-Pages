using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class Page
    {
        public int Page_ID { get; set; }
        public int UserID { get; set; }
        public string title { get; set; }

        public int CategoryID { get; set; }
        public string P_Desc { get; set; }
        public string P_Cover { get; set; }
        public string P_Contact { get; set; }
        public string P_Addr { get; set; }
        public string Bank_AccNo { get; set; }

        public string Fb_link { get; set; }
        public string Linked_link { get; set; }
        public string Twiter_link { get; set; }

        public string Pstate { get; set; }
        public void getPageid()
        {
           this.Page_ID = DataBase.SelectFromDB("GetPageID", new SqlParameter[] { new SqlParameter("@userid", this.UserID) });  
        }
        public static IEnumerable<Page> FetchAllPages(int categoryID)
        {
            IEnumerable<Page> list = DataBase.SelectFromDB<Page>("PagesByCat", new SqlParameter[] { new SqlParameter("@catid", categoryID) });
            return list;
        }

        public static IEnumerable<Page> FetchTop4ByCategory(int categoryID)
        {
            IEnumerable<Page> list = DataBase.SelectFromDB<Page>("GetTopFourPage", new SqlParameter[] { new SqlParameter("@catid", categoryID) });
            return list;
        }
    }
}