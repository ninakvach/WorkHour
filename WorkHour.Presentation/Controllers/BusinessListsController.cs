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
    public class BusinessListsController : Controller
    {
        private readonly WorkHourContext _context;

        public BusinessListsController(WorkHourContext context)
        {
            _context = context;
        }

        // GET: BusinessLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessList.ToListAsync());
        }

        // GET: BusinessLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessList = await _context.BusinessList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessList == null)
            {
                return NotFound();
            }

            return View(businessList);
        }

        // GET: BusinessLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BusinessName,Time,Status,Explanation,TaskExplanation,StartDate,EndDate,CreatorPersonel,CreationDate,PersonelId,Deleted,CustomerId,ProjectDescriptionId,BusinessPriority,StatusId,IsApproved,LastDateStudied")] BusinessList businessList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessList);
        }

        // GET: BusinessLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessList = await _context.BusinessList.FindAsync(id);
            if (businessList == null)
            {
                return NotFound();
            }
            return View(businessList);
        }

        // POST: BusinessLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessName,Time,Status,Explanation,TaskExplanation,StartDate,EndDate,CreatorPersonel,CreationDate,PersonelId,Deleted,CustomerId,ProjectDescriptionId,BusinessPriority,StatusId,IsApproved,LastDateStudied")] BusinessList businessList)
        {
            if (id != businessList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessListExists(businessList.Id))
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
            return View(businessList);
        }

        // GET: BusinessLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessList = await _context.BusinessList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessList == null)
            {
                return NotFound();
            }

            return View(businessList);
        }

        // POST: BusinessLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessList = await _context.BusinessList.FindAsync(id);
            _context.BusinessList.Remove(businessList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessListExists(int id)
        {
            return _context.BusinessList.Any(e => e.Id == id);
        }
    }
}
