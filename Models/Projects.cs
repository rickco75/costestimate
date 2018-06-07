using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [Required]
        public string JobName { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Cell { get; set; }
        public string Fax { get; set; }
        public string SubdivisionName { get; set; }
        public string LotNumber { get; set; }
        public string LegalDescription { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
