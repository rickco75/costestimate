using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostEstimate.Models
{
    public class FramingAndDryIn
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Framing Material")]
        public double FramingMaterial { get; set; }
        [Display(Name = "Framing Labor")]
        public double FramingLabor { get; set; }
        [Display(Name = "Windows / Sliders")]
        public double WindowsSliders { get; set; }
        [Display(Name = "Exterior Doors")]
        public double ExteriorDoors { get; set; }
        [Display(Name = "Front Door")]
        public double FrontDoor { get; set; }
        [Display(Name = "Roof Material Shingle")]
        public double RoofMaterialShingle { get; set; }
        [Display(Name = "Roof Labor")]
        public double RoofLabor { get; set; }
        [Display(Name = "Exterior Deck Material")]
        public double ExteriorDeckMaterial { get; set; }
        [Display(Name = "Exterior Deck Labor")]
        public double ExteriorDeckLabor { get; set; }
        [Display(Name = "Exterior Deck Balusters")]
        public double ExteriorDeckBalusters { get; set; }
        [Display(Name = "Covered Decks")]
        public double CoveredDecks { get; set; }
        [Display(Name = "Covered Decks Labor")]
        public double CoveredDecksLabor { get; set; }
        [Display(Name = "Additional Decks")]
        public double AdditionalDecks { get; set; }
        [Display(Name = "Front Porch")]
        public double FrontPorch { get; set; }
        [Display(Name = "Stone Veneer")]
        public double StoneVeneer { get; set; }
        [Display(Name = "Garage Door")]
        public double GarageDoor { get; set; }
        [Display(Name = "Sliding Labor")]
        public double SlidingLabor { get; set; }
        [Display(Name = "Sliding Material")]
        public double SlidingMaterial { get; set; }
        [Display(Name = "Nail and Misc")]
        public double NailAndMisc { get; set; }
        [Display(Name = "Fire Places")]
        public double FirePlaces { get; set; }


    }
}
