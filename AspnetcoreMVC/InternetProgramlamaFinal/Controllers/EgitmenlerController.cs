using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetProgramlamaFinal.Context;
using InternetProgramlamaFinal.Models;

namespace InternetProgramlamaFinal.Controllers
{
    public class EgitmenlerController : Controller
    {
        private readonly TableContext _context;

        public EgitmenlerController(TableContext context)
        {
            _context = context;
        }

        // GET: Egitmenler
   

        public async Task<IActionResult> Index(
            string sortOrder,
            string searchString,int? pageNumber, string currentFilter
            )
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            var egitmenlers = from s in _context.Egitmenlers
                select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                egitmenlers = egitmenlers.Where(s => s.EgitmenAdi.Contains(searchString)
                                               || s.EgitmenFoto.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    egitmenlers = egitmenlers.OrderByDescending(s => s.EgitmenAdi);
                    break;
                case "Date":
                    egitmenlers = egitmenlers.OrderBy(s => s.EgitmenFoto);
                    break;
              
               
            }
            return View(await egitmenlers.AsNoTracking().ToListAsync());
        }
        
        
        
        
        
        
        
        
        
        // GET: Egitmenler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers
                .FirstOrDefaultAsync(m => m.EgitmenId == id);
            if (egitmenler == null)
            {
                return NotFound();
            }

            return View(egitmenler);
        }

        // GET: Egitmenler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Egitmenler/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EgitmenId,EgitmenAdi,EgitmenFoto,KursId")] Egitmenler egitmenler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egitmenler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egitmenler);
        }

        // GET: Egitmenler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers.FindAsync(id);
            if (egitmenler == null)
            {
                return NotFound();
            }
            return View(egitmenler);
        }

        // POST: Egitmenler/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EgitmenId,EgitmenAdi,EgitmenFoto,KursId")] Egitmenler egitmenler)
        {
            if (id != egitmenler.EgitmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egitmenler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgitmenlerExists(egitmenler.EgitmenId))
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
            return View(egitmenler);
        }

        // GET: Egitmenler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers
                .FirstOrDefaultAsync(m => m.EgitmenId == id);
            if (egitmenler == null)
            {
                return NotFound();
            }

            return View(egitmenler);
        }

        // POST: Egitmenler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egitmenler = await _context.Egitmenlers.FindAsync(id);
            _context.Egitmenlers.Remove(egitmenler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgitmenlerExists(int id)
        {
            return _context.Egitmenlers.Any(e => e.EgitmenId == id);
        }
    }
}
