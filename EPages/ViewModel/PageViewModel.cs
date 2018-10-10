using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EPages.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EPages.ViewModel
{
    public class PageViewModel : UserViewModel
    {
       [Required]
       
        public int Page_ID { get; set; }

        [ForeignKey("user")]
        public int UserID { get; set; }
        public virtual UserViewModel user { get; set; }
   
        [Display(Name="Category")]
        [Required(ErrorMessage = "Category is required")]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual PageCategoryViewModel Category { get; set; }

        [Display(Name="Title")]
        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

       [Display(Name="Select Page Cover")]
       [Required(ErrorMessage = "Cover is required")]
        public string CoverURL { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Pstate { get; set; }
        public string CatDesc { get; set; }

        public virtual AccountDetailsViewModel accountdetail { get; set; }
        public virtual PageAddressViewModel addressdetail { get; set; }
        public virtual PageContactViewModel contactdetail { get; set; }
        public virtual PageSocialInfoViewModel socialinfo { get; set; }
        

        public void Create()
        {
            this.UserID = EPages.Controllers.epageController.user.UserID;
            this.user = EPages.Controllers.epageController.user;
            Page page = ConvertIntoPageModel();
            DataTable dt = ORM.ConvertToDataTable<Page>(page);
            DataBase.InsertIntoDBAndGetID("CreatePage", dt, "@pages");
            page.getPageid();
            this.Page_ID = page.Page_ID;
        }
        private Page ConvertIntoPageModel()
        {
            Page page = new Page();
            page.title = this.title;
            page.UserID = this.UserID;
            page.P_Desc = this.Description;
            page.P_Cover = this.CoverURL;
            page.P_Contact = this.contactdetail.ContactDesc;
            page.P_Addr = this.addressdetail.AddrDesc;
            page.Bank_AccNo = this.accountdetail.AccountNo;
            page.CategoryID = this.CategoryID;
            page.Fb_link = this.socialinfo.FB;
            page.Linked_link = this.socialinfo.LinkedIn;
            page.Twiter_link = this.socialinfo.Twitter;
            page.Page_ID = this.Page_ID;
            page.Pstate = "active";
            return page;
        }

        private void ConvertIntoViewModel(Page p)
        {
            this.Page_ID = p.Page_ID;
            this.title = p.title;
            this.CategoryID = p.CategoryID;
            this.Description = p.P_Desc;
            this.addressdetail = new PageAddressViewModel() { AddrDesc = p.P_Addr };
            this.contactdetail = new PageContactViewModel() { ContactDesc = p.P_Contact };
            this.CoverURL = p.P_Cover;
            this.accountdetail = new AccountDetailsViewModel() { AccountNo = p.Bank_AccNo };
            this.socialinfo = new PageSocialInfoViewModel()
            {
                FB = p.Fb_link,
                Twitter = p.Twiter_link,
                LinkedIn = p.Linked_link
            };
        }

        public static List<PageViewModel> FetchPages(int userid)
        {
            List<PageViewModel> list = DataBase.SelectFromDB<PageViewModel>("getpages", new SqlParameter[] { new SqlParameter("@uid", userid) });
            return list;
        }

        public void FetchPageDetails(int pageid)
        {
            List<Page> p = DataBase.SelectFromDB<Page>("pagedetails", new SqlParameter[] { new SqlParameter("@pid", pageid) });
            ConvertIntoViewModel(p[0]);
            this.Page_ID = pageid;
        }

        public void update()
        {
           Page p = ConvertIntoPageModel();
           DataTable dt = ORM.ConvertToDataTable<Page>(p);
           DataBase.InsertIntoDB("editpage", dt, "@page");
        }

        public static void Deactivate(IEnumerable list)
        {
            foreach (var item in list)
            {
                DataBase.UpdateTable("deactivatePage", new SqlParameter[] { new SqlParameter("@pid", Convert.ToInt32(item.ToString())) });
            }
            
        }

    }
}