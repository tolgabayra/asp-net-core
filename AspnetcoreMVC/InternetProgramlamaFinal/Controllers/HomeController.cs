using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InternetProgramlamaFinal.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InternetProgramlamaFinal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetProgramlamaFinal.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly TableContext _context;
        
        public HomeController(TableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in _context.Salonlars.ToList()
                select new SelectListItem
                {
                    Value = x.SalonId.ToString()
                }).ToList();
            List<SelectListItem> values1 = (from x in _context.Uyelers.ToList()
                select new SelectListItem
                {
                    Value = x.UyeId.ToString()
                }).ToList();
            
            Console.WriteLine(values.Count());
            
            ViewBag.salonsayilari = values.Count();
            ViewBag.uyesayilari = values1.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}