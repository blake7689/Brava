using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class ScienceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
