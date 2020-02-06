using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThreeSItSolution.Models;

namespace ThreeSItSolution.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly Db3SItSoultion _context;

        public EnquiryController(Db3SItSoultion context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MEnquiry mEnquiry)
        {
            if (!ModelState.IsValid)
            {
                return View(mEnquiry);
            }
            _context.MEnquiry.Add(mEnquiry);
            _context.SaveChanges();
            TempData["Success"] = "Your Enquiry Save Successfully We'll Contact Back!!";
            ModelState.Clear();
            return View();

        }
    }
}