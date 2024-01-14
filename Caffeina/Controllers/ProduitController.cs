using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caffeina.Models;

namespace Caffeina.Controllers
{
    public class ProduitController : Controller
    {
        private readonly caffeinaContext _context;
        private static int IDPRODUIT = 0;

        public ProduitController(caffeinaContext context)
        {
            IDPRODUIT++;
            _context = context;
        }

        // GET: Produit
        [Route("/admin/list-produits")]
        public async Task<IActionResult> Index()
        {
            var caffeinaContext = _context.Produits.Include(p => p.IdCategorieNavigation);
            return View(await caffeinaContext.ToListAsync());
        }

        // GET: Produit/Details/5
        [Route("/admin/detail-produit/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.IdCategorieNavigation)
                .FirstOrDefaultAsync(m => m.IdProduit == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produit/Create
        [Route("/admin/ajouter-produit")]
        public IActionResult Create()
        {
            //ViewBag.listescateg = _context.Categories.ToList();
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie");
            return View();
        }

        // POST: Produit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/admin/ajouter-produit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduit,NomProduit,Description,SourceImage,Prix,Stock,IdCategorie")] Produit produit)
        {
            produit.IdProduit = IDPRODUIT;
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", produit.IdCategorie);
            return View(produit);
        }

        // GET: Produit/Edit/5
        [Route("/admin/modifier-produit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", produit.IdCategorie);
            return View(produit);
        }

        // POST: Produit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/admin/modifier-produit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduit,NomProduit,Description,SourceImage,Prix,Stock,IdCategorie")] Produit produit)
        {
            if (id != produit.IdProduit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.IdProduit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", produit.IdCategorie);
            return View(produit);
        }

        // GET: Produit/Delete/5
        [Route("/admin/supprimmer-produit/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.IdCategorieNavigation)
                .FirstOrDefaultAsync(m => m.IdProduit == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produit/Delete/5
        [Route("/admin/supprimmer-produit/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produits == null)
            {
                return Problem("Entity set 'caffeinaContext.Produits'  is null.");
            }
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
          return (_context.Produits?.Any(e => e.IdProduit == id)).GetValueOrDefault();
        }
    }
}
