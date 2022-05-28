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
    public class EtkinliklerController : Controller
    {
        private readonly TableContext _context;

        public EtkinliklerController(TableContext context)
        {
            _context = context;
        }

        // GET: Etkinlikler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etkinliklers.Include(x=>x.Salonlars).ToListAsync());
        }

        // GET: Etkinlikler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikler = await _context.Etkinliklers.Include(x=>x.Salonlars)
                .FirstOrDefaultAsync(m => m.EtkinlikId == id);
            if (etkinlikler == null)
            {
                return NotFound();
            }

            return View(etkinlikler);
        }

        // GET: Etkinlikler/Create
        public IActionResult Create()
        {
            List<SelectListItem> values = (from x in _context.Salonlars.ToList()
                select new SelectListItem
                {
                    Text = x.SalonAdi,
                    Value = x.SalonId.ToString()
                }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        // POST: Etkinlikler/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtkinlikId,EtkinlikAdi,EtkinlikZamani,SalonId")] Etkinlikler etkinlikler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etkinlikler);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage =  etkinlikler.EtkinlikAdi + "İsimli Etkinlik Oluşturuldu...";
                return RedirectToAction(nameof(Index));
            }
            return View(etkinlikler);
        }

        // GET: Etkinlikler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikler = await _context.Etkinliklers.FindAsync(id);
            if (etkinlikler == null)
            {
                return NotFound();
            }
            return View(etkinlikler);
        }

        // POST: Etkinlikler/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtkinlikId,EtkinlikAdi,EtkinlikZamani,SalonId")] Etkinlikler etkinlikler)
        {
            if (id != etkinlikler.EtkinlikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etkinlikler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtkinliklerExists(etkinlikler.EtkinlikId))
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
            return View(etkinlikler);
        }

        // GET: Etkinlikler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikler = await _context.Etkinliklers
                .FirstOrDefaultAsync(m => m.EtkinlikId == id);
            if (etkinlikler == null)
            {
                return NotFound();
            }

            return View(etkinlikler);
        }

        // POST: Etkinlikler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etkinlikler = await _context.Etkinliklers.FindAsync(id);
            _context.Etkinliklers.Remove(etkinlikler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtkinliklerExists(int id)
        {
            return _context.Etkinliklers.Any(e => e.EtkinlikId == id);
        }
    }
}
