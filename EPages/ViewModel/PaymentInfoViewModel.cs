using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class PaymentInfoViewModel
    {
         [Required]
        public int PayID { get; set; }
         [Required]
        public int PageID { get; set; }
    }
}