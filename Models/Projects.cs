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
        [Display(Name="Job Name")]
        public string JobName { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Cell { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Subdivision Name")]
        public string SubdivisionName { get; set; }
        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }
        [Display(Name = "Legal Description")]
        public string LegalDescription { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
