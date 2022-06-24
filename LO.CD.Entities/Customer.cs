using LO.CD.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LO.CD.Entities
{
    public class Customer
    {
        public Customer()
        {
            Deals = new List<Deal>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public List<Deal> Deals { get; set; }

       /* [NotMapped]
        public string CustomerFullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        } */

        [NotMapped]
        public int Age
        {
            get
            {
                if (DOB.HasValue == false)
                {
                    throw new Exception("Customer has no Date of Birth");
                }
                    return DateTime.Now.Year - DOB.Value.Year;
            }
            
        }
    }
}
