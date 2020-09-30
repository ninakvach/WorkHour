using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkHour.Data.Models;

namespace WorkHour.Presentation.Controllers
{
    public class ProjectDescriptionsController : Controller
    {
        private readonly WorkHourContext _context;

        public ProjectDescriptionsController(WorkHourContext context)
        {
            _context = context;
        }

        // GET: ProjectDescriptions
        public async Task<IActionResult> Index()
        {
            var workHourContext = _context.ProjectDescription.Include(p => p.Customer);
            return View(await workHourContext.ToListAsync());
        }

        // GET: ProjectDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDescription = await _context.ProjectDescription
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectDescription == null)
            {
                return NotFound();
            }

            return View(projectDescription);
        }

        // GET: ProjectDescriptions/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Adress");
            return View();
        }

        // POST: ProjectDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,CustomerId,Deleted")] ProjectDescription projectDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Adress", projectDescription.CustomerId);
            return View(projectDescription);
        }

        // GET: ProjectDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDescription = await _context.ProjectDescription.FindAsync(id);
            if (projectDescription == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Adress", projectDescription.CustomerId);
            return View(projectDescription);
        }

        // POST: ProjectDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,CustomerId,Deleted")] ProjectDescription projectDescription)
        {
            if (id != projectDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectDescriptionExists(projectDescription.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Adress", projectDescription.CustomerId);
            return View(projectDescription);
        }

        // GET: ProjectDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDescription = await _context.ProjectDescription
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectDescription == null)
            {
                return NotFound();
            }

            return View(projectDescription);
        }

        // POST: ProjectDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectDescription = await _context.ProjectDescription.FindAsync(id);
            _context.ProjectDescription.Remove(projectDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectDescriptionExists(int id)
        {
            return _context.ProjectDescription.Any(e => e.Id == id);
        }
    }
}
