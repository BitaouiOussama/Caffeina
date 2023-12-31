﻿using Caffeina.Models;
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

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/pr")]
        public IActionResult Produit()
        {
            return View();
        }
        [Route("/produit")]
        public IActionResult Categorie()
        {
            return View();
        }

        [Route("/services")]
        public IActionResult Services()
        {
            return View();
        }

        [Route("/commande")]
        public IActionResult Commande()
        {
            return View();
        }


        [Route("/avis")]
        public IActionResult Avis()
        {
            return View();
        }

        [Route("/Dashboard")]
        public IActionResult Dashboard()
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