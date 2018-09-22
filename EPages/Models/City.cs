using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace EPages.Models
{
    public class City
    {
        public int CityID { get; set; }

        public int CountryID { get; set; }
        
        public string CityDesc { get; set; }

        public static IEnumerable<City> GetCities(int id)
        {
            IEnumerable<City> ien = DataBase.SelectFromDB<City>("GetCities", new SqlParameter[] { new SqlParameter(@"countryid", id) });
            return ien;
        }
    }
}