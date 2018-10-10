using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;
using System.Data;
using EPages.Models;
using System.Data.SqlClient;

namespace EPages.ViewModel
{
    public class UserViewModel
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not Valid")]
        public string Email { get; set; }

        [Required]
        public string Number { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is not Valid")]
        public string Pass { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public int GenderID { get; set; }

        
        [Display(Name = "City")]
        [Required]
        public int CityID { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string UAddress { get; set; }

        public List<PageViewModel> pages { get; set; }

        public string selecteduser { get; set; }

        public void Save()
        {
            User u = new User()
            {
                UserID = this.UserID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                UAddress = this.UAddress,
                Pass = this.Pass,
                CityID = this.CityID,
                GenderID = this.GenderID,
                Number = this.Number
            };
            DataTable dt = ORM.ConvertToDataTable<User>(u);
            this.UserID = DataBase.InsertInto(@"newuser", dt, @"nuser");
            pages = PageViewModel.FetchPages(this.UserID);
        }

       
        public void login()
        {
            if (Email != null && Pass != null)
            {
                List<UserViewModel> list = DataBase.SelectFromDB<UserViewModel>("UserLogin", new SqlParameter[] { new SqlParameter("@email", this.Email), new SqlParameter("@password", this.Pass) });
                if (list.Count != 0)
                {
                    this.UserID = list[0].UserID;
                    this.FirstName = list[0].FirstName;
                    this.LastName = list[0].LastName;
                    this.Email = list[0].Email;
                    this.Number = list[0].Number;
                    this.Pass = list[0].Pass;
                    this.UAddress = list[0].UAddress;
                    this.GenderID = list[0].GenderID;
                    this.CityID = list[0].CityID;
                    pages = PageViewModel.FetchPages(this.UserID);
                }
                else
                {
                    this.UserID = -1;
                }
            }
            else
            {
                this.UserID = -1;
            } 
        }

        public void Update()
        {
            DataBase.UpdateTable("updateuser",
                new SqlParameter[] { 
                    new SqlParameter("@id", this.UserID), 
                    new SqlParameter("@email", this.Email), 
                    new SqlParameter("@number", this.Number), 
                    new SqlParameter("@password", this.Pass), 
                    new SqlParameter("@cityid", this.CityID) ,
                    new SqlParameter("@address",this.UAddress)
                });
        }
        public static List<SelectListItem> Getusers(List<string> option = null)
        {
            List<SelectListItem> options = new List<SelectListItem>();
            options.Add(new SelectListItem { Text = "Seller", Value = "100" });
            options.Add(new SelectListItem { Text = "Buyer", Value = "200" });
            return options;
        }

        public void PlaceOrder(List<cart> list)
        {
            if (list.Count != 0)
            {
                DataTable dt = ORM.ConvertIntoTable<cart>(list);
                DataBase.InsertIntoDB("PlaceOrder", dt, "@carttb", new SqlParameter[] { new SqlParameter("@uid", this.UserID) });
            }
        }
    }
}