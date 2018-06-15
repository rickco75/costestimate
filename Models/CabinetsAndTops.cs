using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class CabinetsAndTops
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Display(Name="Cabinets Kitchen")]
        public double CabinetsKitchen { get; set; }
        [Display(Name = "Granite CounterTops")]
        public double GraniteCounterTops { get; set; }
        [Display(Name = "Cabinets Baths")]
        public double CabinetsBaths { get; set; }
        [Display(Name = "Counter Top Baths")]
        public double CounterTopBaths { get; set; }
        [Display(Name = "Wet Bar Cabinets")]
        public double WetBarCabinets { get; set; }
        [Display(Name = "Wet Bar")]
        public double WetBar { get; set; }
    }
}
