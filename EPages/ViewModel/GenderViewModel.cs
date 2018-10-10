using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;

namespace EPages.ViewModel
{
    public class GenderViewModel
    {
        [Required]
        public int GenderID { get; set; }

        [Required]
        public string GenderDesc { get; set; }

        public static List<SelectListItem> GetGender(List<string> option = null)
        {
            List<SelectListItem> options = new List<SelectListItem>();
            options.Add(new SelectListItem { Text = "Male", Value = "10" });
            options.Add(new SelectListItem { Text = "Female", Value = "11" });
            return options;
        }
    }
}