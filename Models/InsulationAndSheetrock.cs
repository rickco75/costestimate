using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class InsulationAndSheetrock
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public double Insulation { get; set; }
        public double RoofInsulation { get; set; }
        public double SheetrockAndFinish { get; set; }
        public double Soundproofing { get; set; }
        public double FireCaulk { get; set; }
    }
}
