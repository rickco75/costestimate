using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class Options
    {
        public int Id { get; set; }
        [Required]
        public string OptionName { get; set; }
        [Required]
        public string OptionValue { get; set; }
        public DateTime DateChanged { get; set; } = DateTime.Now;
    }
}
