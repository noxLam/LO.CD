using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LO.CD.Entities
{
    public class Branch
    {
        public Branch()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }
        public string Address { get; set; }

        
        public List<Employee> Employees { get; set; }

        
    }
}
