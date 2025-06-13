using Brava.Interfaces;
using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class ScienceController : Controller
    {
        private readonly InfoService _infoService;

        public ScienceController(InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            Dictionary<string, string> scienceContent = _infoService.GetScience();

            foreach (KeyValuePair<string, string> content in scienceContent)
                ViewData[content.Key] = content.Value;

            return View();
        }
    }
}
