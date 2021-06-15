using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;

namespace Technical_Task_Enozom.Services
{
    public class HolidayRepo : IHolidayRepo
    {
        private readonly DBtalker _context;
        public HolidayRepo(DBtalker context)
        {
            _context = context;
        }

        public async Task AddHoliday(Holiday holiday)
        {
           await  _context.Holidays.AddAsync(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteHoliday(int holidayId)
        {
            Holiday holiday = await _context.Holidays.FirstOrDefaultAsync(h => h.Id == holidayId);
            if (holiday != null)
            {
                _context.Holidays.Remove(holiday);
              await  _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;

            }
        }

        public async Task<bool> updateholiday(Holiday holiday)
        {
            Holiday selected = await _context.Holidays.FirstOrDefaultAsync(h => h.Id == holiday.Id);
            if (holiday != null)
            {
                selected.Name = holiday.Name;
                selected.CountryName = holiday.CountryName;
                selected.StartDate = holiday.StartDate;
                selected.EndDate = holiday.EndDate;
                
                return true;
            }
            else
            {
                return false;

            }

        }
    }
}
