using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPages.Models;
using System.Data;
using EPages.ViewModel;
using System.Dynamic;
using System.Data.SqlClient;

namespace EPages.Controllers
{
    public class epageController : Controller
    {

        static int pid;
        public static UserViewModel user { get; set; }
        public static List<cart> ItemList = new List<cart>();

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult UserDashboard()
        {
            user.pages= PageViewModel.FetchPages(user.UserID);
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            return View("UserDashboard","_user",user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel u)
        {
            u.login();
            user = u;
            ViewBag.uid = u.UserID;
            ViewBag.name = u.FirstName;
            if (u.UserID == -1)
                return View("Login");
            else
            {
                if (u.selecteduser == "100")
                {
                    return View("UserDashboard", user);
                }
                else
                {
                    user.PlaceOrder(ItemList);
                    ItemList = new List<cart>();
                    return View("BuyDashboard", user);
                }
            }
        }

        [HttpGet]
        public ActionResult editpage(object id)
        {
            PageViewModel pg = new PageViewModel();
            pid = Convert.ToInt32(id + "");
            pg.FetchPageDetails(pid);
            return View("PageSettings", pg);
        }

        [HttpPost]
        public ActionResult Signup(UserViewModel u)
        {
            u.Save();
            user = u;
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            if (u.selecteduser == "100")
            {
                return View("UserDashboard", u);
            }
            else
            {
                u.PlaceOrder(epageController.ItemList);
                return View("BuyDashboard", u);
            }
        }

        [HttpPost]
        public ActionResult PageUpdate(PageViewModel p)
        {
            p.Page_ID = pid;
            p.update();
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            user.pages = PageViewModel.FetchPages(user.UserID);
            return View("UserDashboard", user);
        }

        [HttpGet]
        public ActionResult ShowPage(string id)
        {
            PageViewModel p = new PageViewModel();
            p.FetchPageDetails(Convert.ToInt32(id + ""));
            return View(p);
        }

        [HttpPost]
        public ActionResult addtolist(FormCollection form)
        {
            string id = form["itid"].ToString();
            string qun = form["quantity"].ToString();
            ItemList.Add(new cart() { ItemID = Convert.ToInt32(id), Quantity = Convert.ToInt32(qun) });
            PageViewModel p = new PageViewModel();
            p.FetchPageDetails(Convert.ToInt32(form["pgid"].ToString()));
            return View("ShowPage", p);
        }

        [HttpGet]
        public ActionResult BuyDashboard()
        {
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            return View("BuyDashboard", user);
        }

        [HttpGet]
        public ActionResult settings()
        {
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;   
            return View("Settings", user);
        }

        [HttpGet]
        public ActionResult Buyersetting()
        {
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            return View("BuyerSettings", user);
        }

        [HttpPost]
        public ActionResult settings(UserViewModel use)
        {
            use.UserID = user.UserID;
            use.FirstName = user.FirstName;
            use.LastName = user.LastName;
            use.GenderID = user.GenderID;
            if (use.Pass==null)
                use.Pass = user.Pass;
            user.Email = use.Email;
            user.Pass = use.Pass;
            use.Update();
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            return View("UserDashboard", user);
        }

        [HttpGet]
        public ActionResult Notification()
        {
            ViewBag.uid = user.UserID;
            ViewBag.name = user.FirstName;
            return View("Notification", user);
        }

        [HttpGet]
        public ActionResult Autocomplete(string term)
        {
            var items = DataBase.SelectFromDb("searchpage", new SqlParameter[] { new SqlParameter("@pgtitle", term) });

            var filteredItems = items.Where(
                item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
                );
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Userpage()
        {
            return View("EPage");
        }

        public ActionResult Psettings()
        {
            return View("PageSettings");
        }

        [HttpPost]
        public ActionResult ShowSPage(FormCollection f)
        {
         int id =   DataBase.SelectFromDB("getpageidbytitle", new SqlParameter[] { new SqlParameter("@titl", f["srch"].ToString()) });
         PageViewModel p = new PageViewModel();
         p.FetchPageDetails(id);
         if (p.Page_ID>0)
         {
             return View("ShowPage", p);    
         }
         return View("Index");
         
        }
    }
}
