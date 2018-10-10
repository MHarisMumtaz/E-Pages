using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace EPages.ViewModel
{
    public class PageCategoryViewModel
    {
        [Display(Name="Category")]
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CatDesc { get; set; }

        public static List<SelectListItem> GetCategory(List<string> option = null)
        {
            List<PageCategoryViewModel> options = DataBase.SelectFromDB<PageCategoryViewModel>("GetCategories");
            List<SelectListItem> opt = new List<SelectListItem>();
            foreach (var item in options)
            {
                opt.Add(new SelectListItem { Text = item.CatDesc, Value = item.CategoryID.ToString() });
            }
            return opt;
        }
    }
}