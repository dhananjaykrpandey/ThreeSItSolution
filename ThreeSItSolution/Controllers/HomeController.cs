using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeSItSolution.Models;

namespace ThreeSItSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Db3SItSoultion _context;

        public HomeController(Db3SItSoultion context)
        {
            _context = context;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
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
        public IActionResult ContactUs()
        {
            MContactUs mContactUs = new MContactUs();
            return View(mContactUs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(MContactUs mContactUs)
        {
            if (!ModelState.IsValid)
            {

                return View(mContactUs);
            }
            ViewBag.Name = mContactUs.CName;
            ViewBag.Email = mContactUs.CEmailId;
            _context.MContactUs.Add(mContactUs);
            _context.SaveChanges();
            //mContactUs = null;
         
            ViewBag.TheResult = true;
          
           return RedirectToAction("ContactUsThanks", new { _Name = mContactUs.CName, _Email = mContactUs.CEmailId });
        }
        public IActionResult ContactUsThanks(string _Name, string _Email)
        {
            ViewBag.Name = _Name;
            ViewBag.Email = _Email;
            return View();
        }
    }
}
