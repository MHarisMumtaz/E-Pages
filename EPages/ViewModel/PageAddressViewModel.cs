using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class PageAddressViewModel
    {
        [Required]
        public int PageAddrID { get; set; }
        [Required]
        public int PageID { get; set; }

        [Display(Name="Address")]
        [Required(ErrorMessage = "Address is required")]
        public string AddrDesc { get; set; }
    }
}