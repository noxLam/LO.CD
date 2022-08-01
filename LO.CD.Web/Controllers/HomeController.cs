using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Data;
using LO.CD.Web.Models;
using LO.CD.Web.Models.Employees;
using LO.CD.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LO.CD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var HomePageVM = new HomePageViewModel();

            HomePageVM.TopRatedEmloyees = await GetTopRatedEmployees();

            return View(HomePageVM);
        }

        private async Task<List<EmployeesListViewModel>> GetTopRatedEmployees()
        {
            var top3ratedEmployees = await _context
                                                          .Employees
                                                          .OrderByDescending(e => e.Rating)
                                                          .Take(3)
                                                          .ToListAsync();

            var top3ratedEmployeesVMs = _mapper.Map<List<Employee>, List<EmployeesListViewModel>>(top3ratedEmployees);
            return top3ratedEmployeesVMs;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}