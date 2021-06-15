using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Services;

namespace Technical_Task_Enozom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepo _repo;
        public CountryController(ICountryRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _repo.GetCountries();
            return Ok(countries);
        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetHoliday(string countryName)
        {
            var holidays = await _repo.GetHolidays(countryName);
            if (holidays != null)
            {
                return Ok(holidays);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
