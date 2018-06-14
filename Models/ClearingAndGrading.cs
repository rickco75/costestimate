using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class ClearingAndGrading
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Survey Cost")]
        public double SurveyCost { get; set; }

        [Display(Name = "Rough Grade")]
        public double RoughGrade { get; set; }

        [Display(Name = "Basement Grade")]
        public double BasementGrade { get; set; }

        [Display(Name = "Septic System")]
        public double SepticSystem { get; set; }

        [Display(Name = "Gravel Pads and Fabric")]
        public double GravelPadsAndFabric { get; set; }

        [Display(Name = "Eros.control materials")]
        public double ErosControlMaterials { get; set; }

        [Display(Name = "Eros. control sub labor")]
        public double ErosControlSubLabor { get; set; }

        [Display(Name = "Culvert")]
        public double Culvert { get; set; }

        [Display(Name = "Initial Walls Backfill")]
        public double InitialWallsBackfill { get; set; }

        [Display(Name = "Water Line")]
        public double WaterLine { get; set; }
    }
}
