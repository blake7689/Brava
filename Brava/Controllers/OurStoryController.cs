using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class OurStoryController : Controller
    {
        private readonly InfoService _infoService;

        public OurStoryController(InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            Dictionary<string, string> aboutContent = _infoService.GetHome();

            foreach (KeyValuePair<string, string> content in aboutContent)
                ViewData[content.Key] = content.Value;

            return View();
        }
    }
}
