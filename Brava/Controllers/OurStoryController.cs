using Brava.Controllers.Api;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class OurStoryController : Controller
    {
        private readonly InfoService _infoService;
        private readonly ILogger<OurStoryController> _logger;

        public OurStoryController(InfoService infoService, ILogger<OurStoryController> logger)
        {
            _infoService = infoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Dictionary<string, string> aboutContent = _infoService.GetOurStory();

                foreach (KeyValuePair<string, string> content in aboutContent)
                    ViewData[content.Key] = content.Value;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving our story content");
                return View("Error");
            }
        }
    }
}