using LO.CD.Entities;
using LO.CD.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Employees
{
    public class EmployeesListViewModel
    {
        public EmployeesListViewModel()
        {
            Branches = new List<Branch>();
            BranchIds = new List<int>();
        }
        public int Id { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        public Gender Gender { get; set; }

        public List<int> BranchIds { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
