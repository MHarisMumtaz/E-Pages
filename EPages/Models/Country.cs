using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace EPages.Models
{
    public class Country
    {
        public int CountryID { get; set; }

        public string CountryDesc { get; set; }

        public static IEnumerable<Country> GetCountries(List<string> option = null)
        {
           IEnumerable<Country> ien= DataBase.SelectFromDB<Country>("GetCountries");
           return ien;
        }

    }
}