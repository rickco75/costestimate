using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class Foundation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Footing Wall Form Material")]
        public double FootingWallFormMaterial { get; set; }
        [Display(Name = "Concrete For Wall And Footingl")]
        public double ConcreteForWallAndFooting { get; set; }
        [Display(Name = "Labor For Wall And Footing")]
        public double LaborForWallAndFooting { get; set; }
        [Display(Name = "Additional Wall As Needed")]
        public double AdditionalWallAsNeeded { get; set; }
        [Display(Name = "Water Proofing")]
        public double Waterproofing { get; set; }
        [Display(Name = "Termite Treatment")]
        public double TermiteTreatment { get; set; }
        [Display(Name = "Form Material Slab")]
        public double FormMaterialSlab { get; set; }
        [Display(Name = "Concrete For Slab")]
        public double ConcreteForSlab { get; set; }
        [Display(Name = "Concrete Pump As Needed")]
        public double ConcretePumpAsNeeded { get; set; }
        [Display(Name = "Additional Slab As Needed")]
        public double AdditionalSlabAsNeeded { get; set; }
    }
}
