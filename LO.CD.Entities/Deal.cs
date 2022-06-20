using LO.CD.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LO.CD.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public DateTime? DealDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Discount { get; set; }
        public int Total { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
