using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostEstimate.Models
{
    public class ProjectsValueViewModel
    {
        public List<Projects> projects;
        public SelectList projectValues;
        public CostModel CostModel { get; set; }
        public string projectNameValues { get; set; }
    }
}
