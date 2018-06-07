using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostEstimate.Models
{
    public class OptionsValueViewModel
    {
        public List<Options> options;
        public SelectList optionValues;
        public string optionNameValues { get; set; }
    }
}
