﻿using System;
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

            var dealVM = _mapper.Map<Deal, DealViewModel>(deal);
            return View(dealVM);
        }

        // GET: Deals/Create
        public IActionResult Create()
        {
            

            ViewData["CarId"] = new SelectList(_context.Cars.Where(x => x.Deal == null), "Id", "CarFullName");
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
            ViewData["CarId"] = new SelectList(_context.Cars.Where(x => x.Deal == null), "Id", "CarFullName", deal.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", deal.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", deal.EmployeeId);

            var dealVM = _mapper.Map<Deal, DealEditViewModel>(deal);
            return View(dealVM);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DealEditViewModel dealVM)
        {
            if (id != dealVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var deal = _mapper.Map<DealEditViewModel, Deal>(dealVM);
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "CarFullName", dealVM.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", dealVM.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", dealVM.EmployeeId);
            return View(dealVM);
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

        public IActionResult Search()
        {
            var deals = new List<DealsListViewModel>();
            return View(deals);
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keyword)
        {
            var deals = await _context
                                .Deals
                                .Include(deals => deals.Car)
                                .Where(deal =>
                                               deal.Car.Make.Contains(keyword)
                                               ||
                                               deal.Customer.PhoneNumber.Contains(keyword)
                                               ||
                                               deal.Customer.FirstName.Contains(keyword)
                                               ||
                                               deal.Car.Model.Contains(keyword)
                                             )
                                .ToListAsync();

            var dealVMs = _mapper.Map<List<Deal>, List<DealsListViewModel>>(deals);
            return View(dealVMs);
        }

        private bool DealExists(int id)
        {
          return (_context.Deals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
