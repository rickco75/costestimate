using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class InsulationAndSheetrock
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Display(Name="Insulation")]
        public double Insulation { get; set; }
        [Display(Name = "Roof Insulation")]
        public double RoofInsulation { get; set; }
        [Display(Name = "Sheetrock and Finish")]
        public double SheetrockAndFinish { get; set; }
        [Display(Name = "Sound Proofing")]
        public double Soundproofing { get; set; }
        [Display(Name = "Fire Caulk")]
        public double FireCaulk { get; set; }
    }
}
