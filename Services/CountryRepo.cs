using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;

namespace Technical_Task_Enozom.Services
{
    public class CountryRepo : ICountryRepo
    {
        private readonly DBtalker _context;
        public CountryRepo(DBtalker context)
        {
            _context = context;
        }

        public async void Addcountry(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }

        public async Task<List<Holiday>> GetHolidays(string CountryName)
        {
           
            var holidays = await _context.Holidays.Where(h=>h.CountryName==CountryName).ToListAsync();
            return holidays;
        }
    }

    
}
