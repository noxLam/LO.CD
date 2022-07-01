using LO.CD.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace LO.CD.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public KnownColor? Color { get; set; }
        public FuelType? FuelType { get; set; }

        public string? Mileage { get; set; }
        public double? Price { get; set; }

        public string? Image { get; set; }
        public string? Logo { get; set; }


        public Deal? Deal { get; set; }

        [NotMapped]
        public string CarFullName
        {
            get
            {
                return $"{Make} {Model} {Year} {Color}";
            }
        }
    }
}