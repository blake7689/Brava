using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
