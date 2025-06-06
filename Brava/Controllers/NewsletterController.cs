using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class NewsletterController : Controller
    {
        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                TempData["NewsletterStatus"] = "Invalid email address.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            // Here you could save to a DB or integrate with Mailchimp, etc.
            TempData["NewsletterStatus"] = "Thanks for subscribing!";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}