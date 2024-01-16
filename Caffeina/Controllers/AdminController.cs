using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caffeina.Models;
using Microsoft.EntityFrameworkCore;

namespace Caffeina.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly caffeinaContext _context;

        public AdminController(ILogger<AdminController> logger, caffeinaContext context)
        {
            _logger = logger;
            _context = context;
        }
        //private readonly DataDbContext _context;
        

        //public AdminController(DataDbContext context)
        //{
        //    _context = context;
        //}

        // GET: /<controller>/
        [Route("/admin")]
        public  IActionResult Index()
        {
            //userConnecter = new Utilisateur { IdUtilisateur = userConnecter.IdUtilisateur, Nom = userConnecter.Nom, Email = userConnecter.Email, MotDePasse = userConnecter.MotDePasse };
            return View();
        }
        
        //[Route("/admin/login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}

