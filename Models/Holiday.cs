using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Task_Enozom.Models
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [ForeignKey("Country")]
        [Required]
        public string CountryName { get; set; }

        public Country country { get; set; }
    }
}
