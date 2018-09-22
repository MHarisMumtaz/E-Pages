using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EPages.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Pass { get; set; }
        public int GenderID { get; set; }
        public int CityID { get; set; }
        public string UAddress { get; set; }

      
    }
}