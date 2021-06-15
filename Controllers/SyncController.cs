using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;
using Technical_Task_Enozom.Services;

namespace Technical_Task_Enozom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly ICountryRepo _corepo;
        private readonly IHolidayRepo _holirepo;
        public SyncController(ICountryRepo countryrepo,IHolidayRepo holidayRepo)
        {
            _corepo = countryrepo;
            _holirepo = holidayRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Sync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.printful.com/");
            var response = await client.GetAsync("countries");
            if (response.IsSuccessStatusCode)
            {
               ResponseCountryjson res = JsonConvert.DeserializeObject<ResponseCountryjson>(await response.Content.ReadAsStringAsync());
                foreach (countryjson c in res.result)
                {
                    Country entry=new Country();
                    entry.Name = c.Name;
                    entry.Code = c.Code;
                    await _corepo.Addcountry(entry);
                    var holidayclient = new HttpClient();
                    client.BaseAddress = new Uri("https://www.googleapis.com/calendar/v3/calendars/en." + c.Code + "%23holiday%40group.v.calendar.google.com/events?key=");
                    var responseholiday = await client.GetAsync("AIzaSyBpSZoCr4xUGsNzmAuxVw_WT0Q4hVW9Bos");
                    responsejson result = JsonConvert.DeserializeObject<responsejson>(await responseholiday.Content.ReadAsStringAsync());
                    foreach (Holiday h in result.Items)
                    {

                        h.CountryName = entry.Name;
                        await _holirepo.AddHoliday(h);
                    }



                }
                return Ok(); }
            else
            {
                return NoContent();
            }

            }

        }
}
