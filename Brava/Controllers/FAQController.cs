using Brava.Interfaces;
using Brava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQCategoryRepository _faqCategoryRepository;

        public FAQController( IFAQCategoryRepository faqCategoryRepository)
        {
            _faqCategoryRepository = faqCategoryRepository;
        }

        public IActionResult Index()
        {
            try
            {
                var categories = _faqCategoryRepository.AllFAQCategories?.ToList() ?? new List<FAQCategory>();
                ViewData["faqHeader"] = "Frequently Asked Questions";
                return View(categories);
            }
            catch (Exception) { return View("Error"); }
        }
    }
}