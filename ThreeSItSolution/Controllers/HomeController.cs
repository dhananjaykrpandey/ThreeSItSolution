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
        //private readonly ILogger<HomeController> _logger;
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
            //SendMail();
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
        public IActionResult AboutUs()
        {
          
            return View();
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
            
            //_context.MContactUs.Add(mContactUs);
            //_context.SaveChanges();
            
            SendMail(mContactUs.CEmailId, mContactUs.CSubject, mContactUs.CMessage);
          
          
           return RedirectToAction("ContactUsThanks", new { Name = mContactUs.CName, Email = mContactUs.CEmailId });
        }
        public IActionResult ContactUsThanks(string Name, string Email)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            return View();
        }
    
        public void SendMail(string ToAddress, string Subject, string BodyContent)
        {
            try
            {
                //From Address    
                string FromAddress = "donotreply@3s-itsolutions.co.za";
                string FromAdressTitle = "Do Not Reply";
                //To Address    
                //string ToAddress = "pilandupandey@gmail.com";
                //string ToAdressTitle = "Microsoft ASP.NET Core";
                //string Subject = "Tesing";
                //string BodyContent = "Testing";

                //Smtp Server    
                string SmtpServer = "mail.3s-itsolutions.co.za";
                //Smtp Port Number    
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress
                                        (FromAdressTitle,
                                         FromAddress
                                         ));
                mimeMessage.To.Add(new MailboxAddress
                                         (ToAddress,
                                         ToAddress
                                         ));
                /*mimeMessage.Cc.Add(new MailboxAddress
                                       ("Dhananjay Kumar Pandey",
                                        "dhananjayp@3s-itsolutions.co.za"
                                        ));*/
                mimeMessage.Subject = Subject; //Subject  
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber,MailKit.Security.SecureSocketOptions.Auto);
                    client.Authenticate(
                        "donotreply@3s-itsolutions.co.za",
                        "Sk#19112018"
                        );
                    client.Send(mimeMessage);
                    //Console.WriteLine("The mail has been sent successfully !!");
                    //Console.ReadLine();
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
