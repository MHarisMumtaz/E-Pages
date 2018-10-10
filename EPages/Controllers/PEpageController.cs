using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPages.ViewModel;

namespace EPages.Controllers
{
    public class PEpageController : Controller
    {
        static bool chk = false;
        static int id = -1;
        [HttpGet]
        public ActionResult Signup()
        {
            return View("Signup");
        }

        [HttpGet]
        public ActionResult NewPage()
        {
            chk = false;
            ViewBag.name = epageController.user.FirstName;
            ViewBag.uid = epageController.user.UserID;
            return View("CreatePage");
        }
        
        [HttpPost]
        public ActionResult NewPage(PageViewModel page)
        {
            if (chk == false)
            {
                page.Create();
                id = page.Page_ID;
                chk = true;
            }
            page.Page_ID = id;
            return View("EPage", page);
        }

        [HttpGet]
        public ActionResult EePage(object id)
        {
            ViewBag.uid = epageController.user.UserID;
            ViewBag.name = epageController.user.FirstName;
            PageViewModel p = new PageViewModel();
            p.FetchPageDetails(Convert.ToInt32(id + ""));
            return View("EPage", p);
        }


        public ActionResult PageUpdate(PageViewModel page)
        {
            return View("EPage");
        }


    }
}
