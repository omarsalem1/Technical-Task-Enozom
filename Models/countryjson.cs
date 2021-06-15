using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Task_Enozom.Models
{
    public class countryjson
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }

        public List<Statejson> States { get; set; }
    }
}
