using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class PageSocialInfoViewModel
    {
         [Required]
        public int PageinfoID { get; set; }
         [Required]
        public int PageID { get; set; }
        [Display(Name = "Facebook Page URl")]
         [Required]
        public string FB { get; set; }
        [Display(Name="LinkedIn URL")]
         [Required]
        public string LinkedIn { get; set; }
        [Display(Name="Twitter URL")]
         [Required]
        public string Twitter { get; set; }
    }
}