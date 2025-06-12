using Brava.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class TermsController : Controller
    {
        private readonly InfoService _infoService;

        public TermsController(InfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
