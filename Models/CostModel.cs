using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class CostModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public double AveragePerSqFootFinsihed { get; set; }
        public double AvgCostMainLevel { get; set; }
        public double AvgPerSqFtFinBasement { get; set; }
        public double AvgCostGarage { get; set; }
        public double AvgCostUnfinsihedBasement { get; set; }
        public double AvgCostUpperLoft { get; set; }
        public double TotalSquareFtHouse { get; set; }
        public double TotalSquareFtUnderRoof { get; set; }
        public double MainLevelSquareFeet { get; set; }
        public double Garage { get; set; }
        public double FinishedBasement { get; set; }
        public double UpperLevelLoft { get; set; }
        public double BasementUnfinishedSqFeet { get; set; }

    }
}
