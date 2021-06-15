using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;
using Technical_Task_Enozom.Services;

namespace Technical_Task_Enozom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayRepo _repo;
        public HolidayController(IHolidayRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddHoliday(Holiday holiday)
        {
            await _repo.AddHoliday(holiday);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHoliday(int holidayId)
        {
            var res = await _repo.DeleteHoliday(holidayId);
            if (res == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> updateHoliday(Holiday holiday)
        {
            var res = await _repo.updateholiday(holiday);
            if (res == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


    }
}
