using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPages.ViewModel
{
    public class AccountDetailsViewModel
    {

        [Required]
        public  int AccountID { get; set; }
        [Display(Name="Bank Account No.")]
        [Required(ErrorMessage = "Account No. required")]
        public string AccountNo { get; set; }

        public int PayID { get; set; }
    }
}