using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;

namespace EPages.ViewModel
{
    public class CountryViewModel
    {
        [Required]
        public int CountryID { get; set; }
        [Required]
        public string CountryDesc { get; set; }
      
    }
}