using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;

namespace EPages.ViewModel
{
    public class CityViewModel
    {
        [Required]
        public int CityID { get; set; }
        [Required]
        public int CountryID { get; set; }
        [Required]
        public string CityDesc { get; set; }
        public static List<SelectListItem> Getdefaultcity(List<string> option = null)
        {
            List<SelectListItem> options = new List<SelectListItem>();
          //  options.Add(new SelectListItem { Text = "Karachi", Value = "100" });
            //options.Add(new SelectListItem { Text = "lahore", Value = "200" });
            return options;
        }
    }
}