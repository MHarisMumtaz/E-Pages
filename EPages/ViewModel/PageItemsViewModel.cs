using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class PageItemsViewModel
    {
      
        public int ItemID { get; set; }

        
        public int Page_ID { get; set; }

        
        public string ItemName { get; set; }

     
         public int ItemPrice { get; set; }

        
        public int ItemQuantity { get; set; }
        
         public string ItemDesc { get; set; }
        
         public string ItemPic { get; set; }

         public void AddItem()
         {
             DataTable dt = ORM.ConvertToDataTable<PageItemsViewModel>(this);
             DataBase.InsertIntoDB("AddnewItem", dt, "@itemtable");
         }

         public static IEnumerable<PageItemsViewModel> GetItems(int pageID)
         {
             IEnumerable<PageItemsViewModel> list = DataBase.SelectFromDB<PageItemsViewModel>("GetItemList", new SqlParameter[] { new SqlParameter("@pid", pageID) });
             return list;
         }
    }
}