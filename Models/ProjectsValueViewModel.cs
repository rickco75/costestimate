using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostEstimate.Models
{
    public class ProjectsValueViewModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public List<SelectListItem> Projects { get; set; }
        public CostModel CostModel { get; set; }
    }
}
