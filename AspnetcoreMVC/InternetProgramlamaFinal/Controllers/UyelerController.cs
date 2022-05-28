using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetProgramlamaFinal.Context;
using InternetProgramlamaFinal.Models;

namespace InternetProgramlamaFinal.Controllers
{
    public class UyelerController : Controller
    {
        private readonly TableContext _context;

        public UyelerController(TableContext context)
        {
            _context = context;
        }

        // GET: Uyeler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyelers
                .Include(x=>x.Egitmenlers)
                .Include(x=>x.Kurslars)
                .ToListAsync());
            
        }

        // GET: Uyeler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers
                .Include(x=>x.Kurslars)
                .Include(x=>x.Egitmenlers)
                .FirstOrDefaultAsync(m => m.UyeId == id);
            if (uyeler == null)
            {
                return NotFound();
            }

            return View(uyeler);
        }

        // GET: Uyeler/Create
        public IActionResult Create()
        {
            List<SelectListItem> values = (from x in _context.Kurslars.ToList()
                select new SelectListItem
                {
                    Text = x.KursAdi,
                    Value = x.KursId.ToString()
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


        public JsonResult egitmengetir(int p)
        {
            var egitmenler = (from x in _context.Egitmenlers
                join y in _context.Kurslars on x.Kurslars.KursId equals y.KursId
                where x.Kurslars.KursId == p
                select new
                {
                    Text = x.EgitmenAdi,
                    Value = x.EgitmenId.ToString()
                }).ToList();
            return Json(egitmenler);
        }
        
        
        
        
        
        
        

        // POST: Uyeler/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UyeId,UyeAdi,UyeSoyadi,UyeTelefon,KursId,EgitmenId")] Uyeler uyeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uyeler);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage =  uyeler.UyeAdi + "İsimli Üye Oluşturuldu...";

                return RedirectToAction(nameof(Index));
            }
            return View(uyeler);
        }

        // GET: Uyeler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> values = (from x in _context.Kurslars.ToList()
                select new SelectListItem
                {
                    Text = x.KursAdi,
                    Value = x.KursId.ToString()
                }).ToList();
            ViewBag.v1 = values;
            
            List<SelectListItem> values2 = (from x in _context.Kurslars.ToList()
                select new SelectListItem
                {
                    Text = x.KursAdi,
                    Value = x.KursId.ToString()
                }).ToList();
            ViewBag.v2 = values2;
            
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers.FindAsync(id);
            if (uyeler == null)
            {
                return NotFound();
            }
            return View(uyeler);
        }

        // POST: Uyeler/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UyeId,UyeAdi,UyeSoyadi,UyeTelefon,KursId,EgitmenId")] Uyeler uyeler)
        {
            if (id != uyeler.UyeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uyeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyelerExists(uyeler.UyeId))
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
            return View(uyeler);
        }

        // GET: Uyeler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers
                .Include(x=>x.Egitmenlers)
                .Include(x=>x.Kurslars)
                .FirstOrDefaultAsync(m => m.UyeId == id);
            if (uyeler == null)
            {
                return NotFound();
            }

            return View(uyeler);
        }

        // POST: Uyeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uyeler = await _context.Uyelers.FindAsync(id);
            _context.Uyelers.Remove(uyeler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UyelerExists(int id)
        {
            return _context.Uyelers.Any(e => e.UyeId == id);
        }
    }
}
