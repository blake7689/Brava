using Brava.Interfaces;
using Brava.Models;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class FAQController : Controller
    {
        private readonly InfoService _infoService;

        public FAQController( InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            //change when DB is implemented//
            Dictionary<string, string> faqContent = _infoService.GetFaq();

            foreach (KeyValuePair<string, string> content in faqContent)
                ViewData[content.Key] = content.Value;

            var faqData = new List<FAQCategory>
            {
                new FAQCategory
                {
                    Name = ViewData["cat1Header"] != null ? ViewData["cat1Header"].ToString() : "cat1Header",
                    FAQs = new List<FAQItem>
                    {
                        new FAQItem 
                        { 
                            Question = ViewData["cat1Q1"] != null ? ViewData["cat1Q1"].ToString() : "cat1Q1", 
                            Answer = ViewData["cat1A1"] != null ? ViewData["cat1A1"].ToString() : "cat1A1"
                        },
                        new FAQItem 
                        { 
                            Question = ViewData["cat1Q2"] != null ? ViewData["cat1Q2"].ToString() : "cat1Q2", 
                            Answer = ViewData["cat1A2"] != null ? ViewData["cat1A2"].ToString() : "cat1A2"
                        }
                    }
                },
                new FAQCategory
                {
                    Name = ViewData["cat2Header"] != null ? ViewData["cat2Header"].ToString() : "cat2Header",
                    FAQs = new List<FAQItem>
                    {
                        new FAQItem 
                        { 
                            Question = ViewData["cat2Q1"] != null ? ViewData["cat2Q1"].ToString() : "cat2Q1", 
                            Answer = ViewData["cat2A1"] != null ? ViewData["cat2A1"].ToString() : "cat2A1"
                        },
                        new FAQItem 
                        { 
                            Question = ViewData["cat2Q2"] != null ? ViewData["cat2Q2"].ToString() : "cat2Q2", 
                            Answer = ViewData["cat2A2"] != null ? ViewData["cat2A2"].ToString() : "cat2A2"
                        }
                    }
                }
            };

            return View(faqData);
        }
    }
}
