using Brava.Controllers.Api;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class TermsController : Controller
    {
        private readonly InfoService _infoService;
        private readonly ILogger<TermsController> _logger;

        public TermsController(InfoService infoService, ILogger<TermsController> logger)
        {
            _infoService = infoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Dictionary<string, string> termsContent = _infoService.GetTerms();

                foreach (KeyValuePair<string, string> content in termsContent)
                    ViewData[content.Key] = content.Value;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving terms content");
                return View("Error");
            }
        }
    }
}