using Brava.Models;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Brava.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly InfoService _infoService;

        public ContactController(InfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("bravanutrients@gmail.com", "wgwo vqlf hilj auew"),
                        EnableSsl = true,
                    };

                    var mail = new MailMessage
                    {
                        From = new MailAddress("bravanutrients@gmail.com"),
                        Subject = "Brava Contact Form Submission",
                        Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}",
                        IsBodyHtml = false
                    };

                    mail.To.Add("bravanutrients@gmail.com");
                    smtpClient.Send(mail);

                    ViewBag.Message = "Your message has been sent!";
                    ModelState.Clear();
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
