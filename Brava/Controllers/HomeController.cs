using Brava.Interfaces;
using Brava.Models;
using Brava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Brava.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGummieRepository _gummieRepository;

        public HomeController(IGummieRepository gummieRepository)
        {
            _gummieRepository = gummieRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Gummie> gummies = _gummieRepository.AllGummies.OrderBy(c => c.GummieID);
            HomeViewModel homeViewModel = new(gummies);
            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult ContactUs(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //todo
                    //set up email info 
                    var smtpClient = new SmtpClient("smtp.yourserver.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("your@email.com", "yourpassword"),
                        EnableSsl = true,
                    };

                    var mail = new MailMessage
                    {
                        From = new MailAddress("your@email.com"),
                        Subject = "Brava Contact Form Submission",
                        Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}",
                        IsBodyHtml = false
                    };

                    mail.To.Add("your@email.com");
                    smtpClient.Send(mail);

                    ViewBag.Message = "Your message has been sent!";
                    return View();
                }
                catch
                {
                    ModelState.AddModelError("", "Error sending email. Please try again later.");
                }
            }

            return View(model);
        }
    }
}
