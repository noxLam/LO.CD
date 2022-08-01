using LO.CD.Web.Models.Customers;
using LO.CD.Web.Models.Employees;

namespace LO.CD.Web.Models.Home
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            var TopRatedEmloyees = new List<EmployeesListViewModel>();
        }

        public List<EmployeesListViewModel> TopRatedEmloyees { get; set; }
    }
}
