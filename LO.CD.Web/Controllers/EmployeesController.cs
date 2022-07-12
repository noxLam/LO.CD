using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LO.CD.Entities;
using LO.CD.Web.Data;
using AutoMapper;
using LO.CD.Web.Models.Employees;

namespace LO.CD.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context
                                     .Employees
                                     .Include(e => e.Branches)
                                     .ToListAsync();

            var employeesVM = _mapper.Map<List<Employee>, List<EmployeesListViewModel>>(employees);
                 return View(employeesVM);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            var employeeVM = new EmployeeViewModel();
            employeeVM.MultiSelectBranches = new MultiSelectList(_context.Branches, "Id", "Address");
            return View(employeeVM);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                await AddBranchesToEmployeeAsync(employeeVM, employee);

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            employeeVM.MultiSelectBranches = new MultiSelectList(_context.Branches, "Id", "Address", employeeVM.BranchIds);
            return View(employeeVM);
        }

      

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context
                                    .Employees
                                    .Include(e => e.Branches)
                                    .SingleAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeVM = _mapper.Map<Employee, EmployeeViewModel>(employee);

            employeeVM.BranchIds = employee.Branches.Select(bra => bra.Id).ToList();
            

            employeeVM.MultiSelectBranches = new MultiSelectList(_context.Branches, "Id", "Address", employeeVM.BranchIds);
            return View(employeeVM);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();

                    await UpdateBranchesAsync(employeeVM, employee.Id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            employeeVM.MultiSelectBranches = new MultiSelectList(_context.Branches, "Id", "Address", employeeVM.BranchIds);
            return View(employeeVM);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        private async Task AddBranchesToEmployeeAsync(EmployeeViewModel employeeVM, Employee employee)
        {
            
            var branches = await _context
                                     .Branches
                                     .Where(bra => employeeVM.BranchIds.Contains(bra.Id))
                                     .ToListAsync();

            employee.Branches.AddRange(branches);
        }
        private async Task UpdateBranchesAsync(EmployeeViewModel employeeVM, int employeeId)
        {
            var employee = await _context
                                 .Employees
                                 .Include(e => e.Branches)
                                 .Where(e => e.Id == employeeId)
                                 .SingleAsync();
            employee.Branches.Clear();
            var branches = await _context
                                     .Branches
                                     .Where(bra => employeeVM.BranchIds.Contains(bra.Id))
                                     .ToListAsync();

            employee.Branches.AddRange(branches);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
