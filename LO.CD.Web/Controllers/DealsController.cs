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
using LO.CD.Web.Models.Deals;

namespace LO.CD.Web.Controllers
{
    public class DealsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DealsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Deals
        public async Task<IActionResult> Index()
        {
            var deals = await _context
                                  .Deals
                                  .Include(d => d.Car)
                                  .Include(d => d.Customer)
                                  .Include(d => d.Employee)
                                  .ToListAsync();
            var dealsVM = _mapper.Map<List<Deal>, List<DealsListViewModel>>(deals);
            return View(dealsVM);

            /*var applicationDbContext = _context.Deals.Include(d => d.Car).Include(d => d.Customer).Include(d => d.Employee);
            return View(await applicationDbContext.ToListAsync());*/
        }

        // GET: Deals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals
                .Include(d => d.Car)
                .Include(d => d.Customer)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Deals/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "CarFullName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            return View();
        }

        // POST: Deals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DealViewModel dealVM)
        {
            if (ModelState.IsValid)
            {
                var deal = _mapper.Map<DealViewModel, Deal>(dealVM);

                deal.DealDate = DateTime.Now;
                _context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "CarFullName", dealVM.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", dealVM.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", dealVM.EmployeeId);
            return View(dealVM);
        }

        // GET: Deals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", deal.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", deal.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", deal.EmployeeId);
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DealDate,PaymentMethod,Discount,Total,CustomerId,EmployeeId,CarId")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", deal.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", deal.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", deal.EmployeeId);
            return View(deal);
        }

        // GET: Deals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals
                .Include(d => d.Car)
                .Include(d => d.Customer)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Deals'  is null.");
            }
            var deal = await _context.Deals.FindAsync(id);
            if (deal != null)
            {
                _context.Deals.Remove(deal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
          return (_context.Deals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
