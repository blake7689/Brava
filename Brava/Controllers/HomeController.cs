using Brava.Interfaces;
using Brava.Models;
using Brava.Services;
using Brava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Brava.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGummieRepository _gummieRepository;
        private readonly InfoService _infoService;

        public HomeController(IGummieRepository gummieRepository, InfoService infoService)
        {
            _gummieRepository = gummieRepository;
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            IEnumerable<Gummie> gummies = _gummieRepository.AllGummies.OrderBy(c => c.GummieID);
            HomeViewModel homeViewModel = new(gummies);

            Dictionary<string, string> homeContent = _infoService.GetHome();

            foreach (KeyValuePair<string, string> content in homeContent)
                ViewData[content.Key] = content.Value;

            return View(homeViewModel);
        }
    }
}
