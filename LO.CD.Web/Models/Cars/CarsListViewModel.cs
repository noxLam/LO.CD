using LO.CD.Utils.Enums;
using System.Drawing;

namespace LO.CD.Web.Models.Cars
{
    public class CarsListViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        
        public string Mileage { get; set; }
        public double? Price { get; set; }
        public KnownColor Color { get; set; }
    }
}
