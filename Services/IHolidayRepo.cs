using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;

namespace Technical_Task_Enozom.Services
{
   public interface IHolidayRepo
    {
        Task AddHoliday(Holiday holiday);
        Task<bool> DeleteHoliday(int holidayId);
        Task<bool> updateholiday(Holiday holiday);
    }
}
