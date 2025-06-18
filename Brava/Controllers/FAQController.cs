using Brava.Interfaces;
using Brava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQCategoryRepository _faqCategoryRepository;
        private readonly ILogger<FAQController> _logger;


        public FAQController(IFAQCategoryRepository faqCategoryRepository, ILogger<FAQController> logger)
        {
            _faqCategoryRepository = faqCategoryRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var categories = _faqCategoryRepository.AllFAQCategories?.ToList() ?? new List<FAQCategory>();
                ViewData["faqHeader"] = "Frequently Asked Questions";
                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving FAQ categories.");
                return View("Error");
            }
        }
    }
}