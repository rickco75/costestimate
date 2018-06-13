using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class NonConstructionItems
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "Construction Loan Fee")]
        public double ConstructionLoanFee { get; set; }
        [Display(Name = "Construction Loan Interest")]
        public double ConstructionLoanInterest { get; set; }
        [Display(Name = "Builders Workman Comp Ins")]
        public double BuildersWorkmanCompIns { get; set; }
        [Display(Name = "Builders Liability Insurances")]
        public double BuildersLiabilityInsurances { get; set; }
        [Display(Name ="Attorney Fee")]
        public double AttorneyFee { get; set; }
        [Display(Name = "Warranty Services")]
        public double WarrantyServices { get; set; }
        [Display(Name = "Property Taxes")]
        public double PropertyTaxes { get; set; }
        [Display(Name = "Workmans Comp Insurances")]
        public double WorkmansCompInsurances { get; set; }
        [Display(Name = "Building Permits")]
        public double BuildingPermits { get; set; }
        [Display(Name = "Water Meter")]
        public double WaterMeter { get; set; }
        [Display(Name = "Builders Risk Insurances")]
        public double BuildersRiskInsurances { get; set; }
        [Display(Name = "Temp Electric Service Meter")]
        public double TempElectricServiceMeter { get; set; }
        [Display(Name="Architect Plans")]
        public double ArchitectPlans { get; set; }
        [Display(Name = "Inspection Fees And CO")]
        public double InspectionFeesAndCO { get; set; }
        public double Misc { get; set; }

        //[ForeignKey("ProjectId")]
        //public Projects Projects { get; set; }
    }
}
