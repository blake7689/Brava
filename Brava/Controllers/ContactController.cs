using Brava.Interfaces;
using Brava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Brava.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IEmailService _emailService;

        public ContactController(ILogger<ContactController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try { return View(); }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading contact form.");
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _emailService.Send(
                        "bravanutrients@gmail.com",
                        "Brava Contact Form Submission",
                        $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}"
                    );

                    ViewBag.Message = "Your message has been sent!";
                    ModelState.Clear();
                    return View();
                }
                catch
                {
                    ModelState.AddModelError("", "Error sending email. Please try again later.");
                }
            }

            try { return View(model); }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing contact form submission.");
                return View("Error");
            }
        }
    }
}