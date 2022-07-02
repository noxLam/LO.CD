using LO.CD.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double? Discount { get; set; }
       /* public double Total { get; set; }*/

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CarId { get; set; }
       
        public Car? Car { get; set; }

        [NotMapped]
        public double Total
        {
            get
            {
                if(Car == null)
                {
                    return 0;
                }
                
                return (double)(Car.Price - Discount);
            }
        }

    }
}
