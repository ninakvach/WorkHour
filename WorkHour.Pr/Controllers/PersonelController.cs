using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkHour.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Business.DataAccess.Concrete.EntityFramework;

namespace WorkHour.Pr.Controllers
{
    public class PersonelController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly WorkHourContext _context;

        public PersonelController(WorkHourContext context)
        {
            _context = context;
        }

        // GET: Personels
       

        public IActionResult Index()
        {
            return View();
        }
        // GET: Personels
        public async Task<IActionResult> GetData()
        {
            List<Personel> perList = _context.Personel.ToList();
            return Json(new { data = perList });
        }
       
        [Microsoft.AspNetCore.Mvc.HttpPost]
       
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }
           // return View(personel);
            return Json(new { success = true, message = "Deleted Successfully" });
        }

        // POST: Personels/Delete/5
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.ActionName("Delete")]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personel.FindAsync(id);
            _context.Personel.Remove(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return _context.Personel.Any(e => e.Id == id);
        }
    }
}
