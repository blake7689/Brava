using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class OurStoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
