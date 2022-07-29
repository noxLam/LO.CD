using LO.CD.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace LO.CD.Web.Models.Cars
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public KnownColor Color { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        public string Mileage { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        

        public string? CarFullname 
        { 
            get
            {
                return $"{Make} {Model} {Year}";
            }
        
        }
    }
}
