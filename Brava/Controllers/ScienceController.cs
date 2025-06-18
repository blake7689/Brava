using Brava.Controllers.Api;
using Brava.Interfaces;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class ScienceController : Controller
    {
        private readonly InfoService _infoService;
        private readonly ILogger<ScienceController> _logger;

        public ScienceController(InfoService infoService, ILogger<ScienceController> logger)
        {
            _infoService = infoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Dictionary<string, string> scienceContent = _infoService.GetScience();

                foreach (KeyValuePair<string, string> content in scienceContent)
                    ViewData[content.Key] = content.Value;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving science content");
                return View("Error");
            }
        }
    }
}