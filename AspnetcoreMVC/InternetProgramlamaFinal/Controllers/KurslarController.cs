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
    public class KurslarController : Controller
    {
        private readonly TableContext _context;

        public KurslarController(TableContext context)
        {
            _context = context;
        }

        // GET: Kurslar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurslars
                .Include(x=>x.Salonlars)
                .Include(x=>x.Egitmenlers)
                .ToListAsync());
        }

        // GET: Kurslar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurslar == null)
            {
                return NotFound();
            }

            return View(kurslar);
        }

        // GET: Kurslar/Create
        public IActionResult Create()
        {
        
        List<SelectListItem> values = (from x in _context.Salonlars.ToList()
            select new SelectListItem
            {
                Text = x.SalonAdi,
                Value = x.SalonId.ToString()
            }).ToList();
        ViewBag.v1 = values;
        
        List<SelectListItem> values2 = (from x in _context.Egitmenlers.ToList()
            select new SelectListItem
            {
                Text = x.EgitmenAdi,
                Value = x.EgitmenId.ToString()
            }).ToList();
        ViewBag.v2 = values2;
        
            return View();
        }

        // POST: Kurslar/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KursId,KursAdi,KursAciklama,KursFotografi,KursSeanslari,KursFiyati,SalonId,EgitmenId")] Kurslar kurslar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurslar);
                await _context.SaveChangesAsync();

                ViewBag.KursAdi = kurslar.KursAdi;
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(kurslar);
        }

        // GET: Kurslar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars.FindAsync(id);
            if (kurslar == null)
            {
                return NotFound();
            }
            return View(kurslar);
        }

        // POST: Kurslar/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KursId,KursAdi,KursAciklama,KursFotografi,KursSeanslari,KursFiyati,SalonId,EgitmenId")] Kurslar kurslar)
        {
            if (id != kurslar.KursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurslar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurslarExists(kurslar.KursId))
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
            return View(kurslar);
        }

        // GET: Kurslar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurslar == null)
            {
                return NotFound();
            }

            return View(kurslar);
        }

        // POST: Kurslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurslar = await _context.Kurslars.FindAsync(id);
            _context.Kurslars.Remove(kurslar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurslarExists(int id)
        {
            return _context.Kurslars.Any(e => e.KursId == id);
        }
    }
}
