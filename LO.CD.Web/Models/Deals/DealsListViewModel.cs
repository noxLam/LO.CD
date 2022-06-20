using LO.CD.Entities;
using LO.CD.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Deals
{
    public class DealsListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Deal Date")]
        public DateTime? DealDate { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        public string? Discount { get; set; }
        public int Total { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public string? CarFullName { get; set; }
    }
}
