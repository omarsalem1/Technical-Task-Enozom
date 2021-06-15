using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;

namespace Technical_Task_Enozom.Services
{
   public interface ICountryRepo
    {
        Task Addcountry(Country country);
        Task<List<Country>> GetCountries();
        Task<List<Holiday>> GetHolidays(string CountryName);

    }
}
