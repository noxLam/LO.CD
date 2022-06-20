using LO.CD.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LO.CD.Entities
{
    public class Employee
    {
        public Employee()
        {
            Deals = new List<Deal>();
            Branches = new List<Branch>();
        }
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public List<Deal> Deals { get; set; }

        public List<Branch> Branches { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
