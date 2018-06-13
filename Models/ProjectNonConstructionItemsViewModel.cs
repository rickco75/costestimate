using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostEstimate.Models;

namespace CostEstimate.Models
{
    public class ProjectNonConstructionItemsViewModel
    {
        public Projects project { get; set; }
        public NonConstructionItems nonconstructionitems { get; set; }
    }
}
