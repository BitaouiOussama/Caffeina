using Caffeina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Caffeina.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/Menu")]
        public IActionResult Menu()
        {
            return View();
        }

        [Route("/Services")]
        public IActionResult Services()
        {
            return View();
        }

        [Route("/Commande")]
        public IActionResult Commande()
        {
            return View();
        }


        [Route("/Avis")]
        public IActionResult Avis()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}