using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class ProjectCostViewModel : Projects
    {
        public Projects Projects { get; set; }
        public CostModel CostModel { get; set; }
    }
}
