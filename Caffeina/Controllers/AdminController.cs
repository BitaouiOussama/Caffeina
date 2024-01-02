using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace Caffeina.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/admin/ajouterproduits")]
        public IActionResult AjouterProduit()
        {
            return View();
        }
        [Route("/admin/listesproduits")]
        public IActionResult ListeProduits()
        {
            return View();
        }
        [Route("/admin/ajoutercategories")]
        public IActionResult AjouterCategorie()
        {
            return View();
        }
        [Route("/admin/listescategories")]
        public IActionResult ListeCategorie()
        {
            return View();
        }
        [Route("/admin/login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}

