using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
