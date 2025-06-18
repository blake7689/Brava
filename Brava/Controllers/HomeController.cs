using Brava.Controllers.Api;
using Brava.Interfaces;
using Brava.Models;
using Brava.Services;
using Brava.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGummieRepository _gummieRepository;
        private readonly InfoService _infoService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGummieRepository gummieRepository, InfoService infoService, ILogger<HomeController> logger)
        {
            _gummieRepository = gummieRepository;
            _infoService = infoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<Gummie> gummies = _gummieRepository.AllGummies.OrderBy(c => c.GummieID);
                HomeViewModel homeViewModel = new(gummies);

                Dictionary<string, string> homeContent = _infoService.GetHome();

                foreach (KeyValuePair<string, string> content in homeContent)
                    ViewData[content.Key] = content.Value;

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading the home page.");
                return View("Error");
            }
        }
    }
}