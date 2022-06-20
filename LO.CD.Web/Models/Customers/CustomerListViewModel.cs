using LO.CD.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Customers
{
    public class CustomerListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
    }
}
