using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caffeina.Models;
using Caffeina.Data;
using Microsoft.EntityFrameworkCore;

namespace Caffeina.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataDbContext _context;
        

        public AdminController(DataDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Route("/admin")]
        public  IActionResult Index()
        {
           return View();
        }
        [Route("/admin/ajouterproduits")]

        [HttpGet]
        public IActionResult AjouterProduit()
        {
            ViewBag.listcateg = _context.categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterProduit([Bind("IdProd,Labelle,Prix,IdCateg,ImageSource,DateAjout")] Produit produit)
        {
            if (ModelState.IsValid)
            {
               /* if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        produit.ImageSource = memoryStream.ToArray();
                    }
                }*/

                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListeProduits");
            }
            return View(produit);
        }

        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> AjouterProduit([Bind("IdProd,Labelle,Prix,IdCateg,ImageSource,DateAjout")] Produit produit, IFormFile file)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            if (file != null && file.Length > 0)
                            {
                                if (!file.ContentType.StartsWith("image"))
                                {
                                    ModelState.AddModelError("file", "Le fichier doit être une image.");
                                    return View(produit);
                                }

                                using (var memoryStream = new MemoryStream())
                                {
                                    await file.CopyToAsync(memoryStream);
                                    produit.ImageSource = memoryStream.ToArray();
                                }
                            }

                            _context.Add(produit);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("ListeProduits");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Loguer l'exception ou effectuer toute autre action nécessaire pour la gestion des erreurs
                        ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'ajout du produit.");
                    }

                    return View(produit);
                }*/


        /*[Route("/admin/listesproduits")]*/
        public IActionResult ListeProduits()
        {
            return View();
        }


        


/*Les Actions du model Categorie*/




        /*[Route("/admin/ajoutercategories")]*/

        [HttpGet]
        public IActionResult AjouterCategorie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterCategorie([Bind("IdCateg,Designation,DateAjout")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListeCategorie");
            }
            return View(categorie);
        }

        /*[Route("/admin/listescategories")]*/
        public async Task<IActionResult> ListeCategorie()
        {
            return _context.categories != null ?
                  View(await _context.categories.ToListAsync()) :
                  Problem("Entity set 'ProduitDBContext.produits'  is null.");
        }


        // GET: Produits/Edit/5
        [HttpGet]
        public async Task<IActionResult> ModifierCategorie(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierCategorie(int id, [Bind("IdCateg,Designation,DateAjout")] Categorie categorie)
        {
            if (id != categorie.IdCateg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.IdCateg))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListeCategorie");
            }
            return View(categorie);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> SupprimerCategorie(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var produit = await _context.produits
                .FirstOrDefaultAsync(m => m.IdCateg == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("SupprimerCategorie")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupprimerCategorieConfirmed(int id)
        {
            if (_context.produits == null)
            {
                return Problem("Entity set 'ProduitDBContext.produits'  is null.");
            }
            var produit = await _context.produits.FindAsync(id);
            if (produit != null)
            {
                _context.produits.Remove(produit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ListeCategorie");
        }



        [Route("/admin/login")]
        public IActionResult Login()
        {
            return View();
        }

        private bool CategorieExists(int id)
        {
            return (_context.categories?.Any(e => e.IdCateg == id)).GetValueOrDefault();
        }
    }
}

