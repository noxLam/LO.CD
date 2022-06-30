using LO.CD.Entities;
using LO.CD.Utils.Enums;
using LO.CD.Web.Models.Cars;
using LO.CD.Web.Models.Deals;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Customers
{
    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel()
        {
            Deals = new List<DealViewModel>();
            Cars = new List<CarViewModel>();
        }
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        
        public List<CarViewModel>? Cars { get; set; }
        public List<DealViewModel>? Deals { get; set; }

        
        public string? CarFullName { get; set; }
    }
}
