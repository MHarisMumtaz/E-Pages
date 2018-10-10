using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class PageContactViewModel
    {
        [Required]
        public int PageContID { get; set; }

        [Required]
        public int PageID { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact is required")]
        public string ContactDesc { get; set; }
    }
}