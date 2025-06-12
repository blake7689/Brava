using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class FAQController : Controller
    {
        private readonly InfoService _infoService;

        public FAQController(InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
