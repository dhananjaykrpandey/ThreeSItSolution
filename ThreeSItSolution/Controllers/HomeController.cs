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
            MContactUs ObjmContactUs = new MContactUs();
            return View(ObjmContactUs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(MContactUs ObjmContactUs)
        {
            if (!ModelState.IsValid)
            {

                return View(ObjmContactUs);
            }

            _context.MContactUs.Add(ObjmContactUs);
            _context.SaveChanges();

            SendMail(ObjmContactUs.CEmailId, ObjmContactUs.CSubject, ObjmContactUs.CMessage, ObjmContactUs.CName);


            return RedirectToAction("ContactUsThanks", new { Name = ObjmContactUs.CName, Email = ObjmContactUs.CEmailId });
        }
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult ContactUsThanks(string Name, string Email)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            return View();
        }

        public static void SendMail(string CCAddress, string Subject, string BodyContent, string Name)
        {
            try
            {
                //From Address    
                string FromAddress = "sksingh@3s-itsolutions.arnikainfotech.com";
                string FromAdressTitle = "Do Not Reply";
                //To Address    
                string ToAddress = "info@3s-itsolutions.co.za";
                string ToAdressTitle = "3s-itsolutions Information Desk";
                //string Subject = "Tesing";
                //string BodyContent = "Testing";

                //Smtp Server    
                string SmtpServer = "mail.3s-itsolutions.arnikainfotech.com";
                //Smtp Port Number    
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress
                                        (FromAdressTitle,
                                         FromAddress
                                         ));
                mimeMessage.Cc.Add(new MailboxAddress
                                         (ToAdressTitle,
                                         ToAddress
                                         ));
                mimeMessage.To.Add(new MailboxAddress
                                       (Name,
                                        CCAddress
                                        ));
                mimeMessage.Subject = string.Concat("Contact Us Message", " - ", Subject); //Subject  

                string StrMessage = MessageBody(Subject, BodyContent, Name);
                var builder = new BodyBuilder();
                builder.HtmlBody = StrMessage;
                mimeMessage.Body = builder.ToMessageBody();
             

                using var client = new SmtpClient();
                client.Connect(SmtpServer, SmtpPortNumber, MailKit.Security.SecureSocketOptions.Auto);
                client.Authenticate(
                    "sksingh@3s-itsolutions.arnikainfotech.com",
                    "Welcome#123"
                    );
                client.Send(mimeMessage);
                //Console.WriteLine("The mail has been sent successfully !!");
                //Console.ReadLine();
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static string MessageBody(string Subject, string BodyContent, string Name)
        {
            string MessageBoday = $@"
                    <html xmlns = 'http://www.w3.org/1999/xhtml'><head>
                        <meta http - equiv = 'Content-Type' content = 'text/html; charset=UTF-8'/>
                         <title> 3S IT Training and Business Solutions</title>   
                         <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0'/>
                          </head>
                          <body style = 'margin: 0; padding: 0;'>
                           <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%'>
                            <tr>
                              <td style = 'padding: 10px 0 30px 0;'>
                                  <table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600' style = 'border: 1px solid #cccccc; border-collapse: collapse;'>
                                   <tr>
                                      <td align = 'center' bgcolor = '#ee4c50' style = 'padding: 40px 0 30px 0; color: #153643; font-size: 32px; font - weight: bold; font - family: Arial, sans - serif; color:#ffffff'>3S IT Training and Business Solutions
                                  </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor = '#ffffff' style = 'padding: 40px 30px 40px 30px;'>
                                                      <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%'>
                                                                       <tr>
                                                                            <td style = 'color: #153643; font-family: Arial, sans-serif; font-size: 24px;'>
                                                                                  <b> Thanks For Contacting Us </b>
                                                                                  </td>
                                                                               </tr>
                                                                                <tr>
                                                                                    <td style = 'padding: 20px 0 30px 0; color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'>
                                                              Hello { (object)Name} <br/>   Your Query
                                                             </td>
                                                                                  </tr>
                                                                                  <tr>
                                                                                      <td>
                                                                                         <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%'>
                                                                                                            <tr>
                                                                                                                <td width = '260' valign = 'top'>
                                                                                                                          <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%'>
                                          
                                                                                                  <tr>
                                          
                                                                                                      <td style = 'color: #153643; font-family: Arial, sans-serif; font-size: 24px;'>
                                                                                                           { (object)Subject}
                                                                                                       </td>
                                           
                                                                                                   </tr>
                                           
                                                                                                   <tr>
                                           
                                                                                                       <td style = 'padding: 25px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'>
                                                                                                            { (object)BodyContent}
                                                                                                        </td>
                                            
                                                                                                    </tr>
                                            
                                                                                                </table>
                                            
                                                                                            </td>
                                            
                                                                                            <td style = 'font-size: 0; line-height: 0;' width = '20'>
                                                                                                   &nbsp;

                                                </td>
                                           </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor = '#ee4c50' style = 'padding: 30px 30px 30px 30px;'>
                                  <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%'>
                                                    <tr>
                                                        <td style = 'color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' width = '75%'>
                                                 Mail Us &#64; 3S IT Training and Business Solutions [	info@3s-itsolutions.co.za  ]
									</td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                              </tr>
                                          </table>
                                      </td>
                                 </tr>
                              </table>
             </body>
             </html> ";

            return MessageBoday;
        }

       
        public IActionResult WhyUs()
        {
            return View();
        }

      
        public IActionResult MicorSoft()
        {
            return View();
        }
   
        public IActionResult Oracle()
        {
            return View();
        }

        public IActionResult Cicso()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tableau()
        {
            return View();
        }

        public IActionResult Python()
        {
            return View();
        }
     
        public IActionResult RPrograming()
        {
            return View();
        }
    
        public IActionResult SoftwareServices()
        {
            return View();
        }
    }
}
