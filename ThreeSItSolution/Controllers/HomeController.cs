using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
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
            SendMail();
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

        public void SendMail()
        {
            try
            {
                //From Address    
                string FromAddress = "pilandupandey@gmail.com";
                string FromAdressTitle = "pilandupandey@gmail.com";
                //To Address    
                string ToAddress = "pilandupandey@gmail.com";
                string ToAdressTitle = "Microsoft ASP.NET Core";
                string Subject = "Tesing";
                string BodyContent = "Testing";

                //Smtp Server    
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number    
                int SmtpPortNumber = 465;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress
                                        (FromAdressTitle,
                                         FromAddress
                                         ));
                mimeMessage.To.Add(new MailboxAddress
                                         (ToAdressTitle,
                                         ToAddress
                                         ));
                mimeMessage.Subject = Subject; //Subject  
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber,true);
                    client.Authenticate(
                        "pilandupandey@gmail.com",
                        "dj310382"
                        );
                    client.SendAsync(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
