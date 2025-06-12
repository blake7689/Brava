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
            return View();
        }
    }
}
