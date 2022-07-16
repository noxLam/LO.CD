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
using LO.CD.Web.Models.Branches;

namespace LO.CD.Web.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BranchesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var branch = await _context
                                     .Branches
                                     .ToListAsync();

                var branchVM = _mapper.Map<List<Branch>, List<BranchViewModel>>(branch);
                return View(branchVM);
        }

        // GET: Branches/Details/5
        

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BranchViewModel branchVM)
        {
            if (ModelState.IsValid)
            {
                var branch = _mapper.Map<BranchViewModel, Branch>(branchVM);

                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchVM);
        }

        // GET: Branches/Edit/5
        

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Branches/Delete/5
        

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Branches == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Branches'  is null.");
            }
            var branch = await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
          return (_context.Branches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
