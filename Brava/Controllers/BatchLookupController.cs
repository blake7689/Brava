using Brava.Controllers.Api;
using Brava.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class BatchLookupController : Controller
    {
        private readonly ILogger<BatchLookupController> _logger;

        public BatchLookupController(ILogger<BatchLookupController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try { return View(); }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BatchLookupController.Index");
                return View("Error");
            }   
        }
    }
}