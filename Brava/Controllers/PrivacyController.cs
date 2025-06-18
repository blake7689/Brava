using Brava.Controllers.Api;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly InfoService _infoService;
        private readonly ILogger<PrivacyController> _logger;

        public PrivacyController(InfoService infoService, ILogger<PrivacyController> logger)
        {
            _infoService = infoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Dictionary<string, string> privacyContent = _infoService.GetPrivacy();

                foreach (KeyValuePair<string, string> content in privacyContent)
                    ViewData[content.Key] = content.Value;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving privacy content");
                return View("Error");
            }
        }
    }
}