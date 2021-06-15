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

        public async Task Addcountry(Country country)
        {

            var entry = await _context.Countries.FirstOrDefaultAsync(c =>c.Name ==country.Name);
            if (entry == null)
            {

                await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
            }
            else
            {
                if (country.holidays != null) {
                entry.Code = country.Code;
                HolidayRepo _holirepo = new HolidayRepo(_context);

                foreach(Holiday h in country.holidays)
                {
                  await  _holirepo.updateholiday(h);
                } }

            }
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
