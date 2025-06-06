using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
