using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPages.Models;
using System.Web;
using System.Data;
using EPages.ViewModel;
using System.Dynamic;
using System.IO;
using System.Collections;

namespace EPages.Controllers
{
    public class FetchWAController : ApiController
    {

        [HttpGet]
        [ActionName("GetCatPages")]
        public IEnumerable<Page> GetPages(string id)
        {
            IEnumerable<Page> l = Page.FetchAllPages(Convert.ToInt32(id));
            return l;
        }


        [HttpGet]
        [ActionName("Gciti")]
        public IEnumerable<City> Get(string id)
        {
            IEnumerable<City> list = City.GetCities(Convert.ToInt32(id));
            return list;
        }
        [HttpGet]
        [ActionName("GItems")]
        public IEnumerable<PageItemsViewModel> GetItem(string id)
        {
            IEnumerable<PageItemsViewModel> itemlist = PageItemsViewModel.GetItems(Convert.ToInt32(id));
            return itemlist;
        }

        [HttpPost]
        [ActionName("newitem")]
        public void mypost(PageItemsViewModel item)
        {
            item.AddItem();
        }

        [HttpPost]
        [ActionName("deletitem")]
        public void mypost(int ID)
        {
            
        }

        [HttpPost]
        [ActionName("delpage")]
        public void deletePages(IEnumerable arr)
        {
            PageViewModel.Deactivate(arr);
        }


        [HttpPost]
        [ActionName("uploadfile")]
        public void uploadfile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/images"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        [HttpPost]
        [ActionName("delbuyitem")]
        public void delbuyitem(IEnumerable<OrderItemData> arr)
        {
            OrderDetailViewModel.DeleteOrderItem(arr);
        }
    }
}
