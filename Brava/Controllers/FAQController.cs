using Brava.Models;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            var faqData = new List<FAQCategory>
        {
            new FAQCategory
            {
                Name = "Shipping",
                FAQs = new List<FAQItem>
                {
                    new FAQItem { Question = "Where do you ship?", Answer = "We ship worldwide!" },
                    new FAQItem { Question = "How long does shipping take?", Answer = "3-7 business days depending on your location." }
                }
            },
            new FAQCategory
            {
                Name = "Returns & Refunds",
                FAQs = new List<FAQItem>
                {
                    new FAQItem { Question = "Can I return my order?", Answer = "Yes, within 30 days of receipt." },
                    new FAQItem { Question = "How are refunds processed?", Answer = "Refunds are credited back to your original payment method." }
                }
            }
        };

            return View(faqData);
        }
    }
}
