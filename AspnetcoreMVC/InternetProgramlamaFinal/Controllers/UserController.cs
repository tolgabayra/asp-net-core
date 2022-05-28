using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetProgramlamaFinal.Context;
using InternetProgramlamaFinal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace InternetProgramlamaFinal.Controllers
{
    public class UserController : Controller
    {
        private readonly TableContext _context;

        public UserController(TableContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(User u)
        {
            var datavalue = _context.Users.FirstOrDefault(x => x.Username == u.Username &&
                                                               x.Password == u.Password
            );
            if (datavalue != null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.Username)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                
                HttpContext.Session.SetString("Username",u.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Kullanici Adi veya Sifre Gecersiz !!!";
                return View();
            }
            
            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }
        
        
    }

        

       


        

     


  
}
