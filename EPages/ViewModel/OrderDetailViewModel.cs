using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EPages.Models;

namespace EPages.ViewModel
{
    public class OrderDetailViewModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
        public string Ostate { get; set; }
        public DateTime Odate { get; set; }
        
        public static IEnumerable<OrderDetailViewModel> GetOrderItems(int Orderid,int Pageid)
        {
            IEnumerable<OrderDetailViewModel> list = DataBase.SelectFromDB<OrderDetailViewModel>("getorderitems", new SqlParameter[] { new SqlParameter("@pid", Pageid), new SqlParameter("@oid", Orderid) });
            return list;
        }

        public static void DeleteOrderItem(IEnumerable<OrderItemData> itemdata)
        {
            foreach (var item in itemdata)
            {
                DataBase.DeleteRecord("DeleteOrderItem", new SqlParameter[] { new SqlParameter("@oid", item.OrderID), new SqlParameter("@itemid", item.ItemID) });
            }
        }
    }

    
}