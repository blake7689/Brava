using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly InfoService _infoService;

        public PrivacyController(InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            Dictionary<string, string> privacyContent = _infoService.GetPrivacy();

            foreach (KeyValuePair<string, string> content in privacyContent)
                ViewData[content.Key] = content.Value;

            return View();
        }
    }
}
