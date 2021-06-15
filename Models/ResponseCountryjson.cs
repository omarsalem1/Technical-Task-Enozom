using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Task_Enozom.Models
{
    public class ResponseCountryjson
    {
        public string code
        { get; set; }
        public List<countryjson> result
        { get; set; }
    }
}
