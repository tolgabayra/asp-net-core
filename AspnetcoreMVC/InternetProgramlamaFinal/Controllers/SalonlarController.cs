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
    public class SalonlarController : Controller
    {
        private readonly TableContext _context;

        public SalonlarController(TableContext context)
        {
            _context = context;
        }

        // GET: Salonlar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salonlars.ToListAsync());
        }

        // GET: Salonlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars
                .FirstOrDefaultAsync(m => m.SalonId == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // GET: Salonlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salonlar/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalonId,SalonAdi,SalonKonumu")] Salonlar salonlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salonlar);
                await _context.SaveChangesAsync();
                ViewBag.SalonAdi = salonlar.SalonAdi;
                ViewBag.SalonKonumu = salonlar.SalonKonumu;

                return RedirectToAction(nameof(Index));
            }
            return View(salonlar);
        }

        // GET: Salonlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars.FindAsync(id);
            if (salonlar == null)
            {
                return NotFound();
            }
            return View(salonlar);
        }

        // POST: Salonlar/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalonId,SalonAdi,SalonKonumu")] Salonlar salonlar)
        {
            if (id != salonlar.SalonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salonlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonlarExists(salonlar.SalonId))
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
            return View(salonlar);
        }

        // GET: Salonlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars
                .FirstOrDefaultAsync(m => m.SalonId == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // POST: Salonlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salonlar = await _context.Salonlars.FindAsync(id);
            _context.Salonlars.Remove(salonlar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonlarExists(int id)
        {
            return _context.Salonlars.Any(e => e.SalonId == id);
        }
    }
}
