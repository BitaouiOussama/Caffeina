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
    public class CategorieController : Controller
    {
        private readonly caffeinaContext _context;
        private static int IDCATEGORIE = 0;
        public CategorieController(caffeinaContext context)
        {
            IDCATEGORIE++;
            _context = context;
        }

        // GET: Categorie
        [Route("/admin/list-categorie")]
        public async Task<IActionResult> Index()
        {
              return _context.Categories != null ? 
                          View(await _context.Categories.ToListAsync()) :
                          Problem("Entity set 'caffeinaContext.Categories'  is null.");
        }

        // GET: Categorie/Details/5
        [Route("/admin/detail-categorie/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.IdCategorie == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categorie/Create
        [Route("/admin/ajouter-categorie")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/admin/ajouter-categorie")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategorie,Designation,SourceImage,DateAjout")] Categorie categorie)
        {
            categorie.DateAjout = DateTime.Now;
            categorie.IdCategorie = IDCATEGORIE;
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorie/Edit/5
        [Route("/admin/modifier-categorie/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/admin/modifier-categorie/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategorie,Designation,SourceImage,DateAjout")] Categorie categorie)
        {
            if (id != categorie.IdCategorie)
            {
                return NotFound();
            }
            categorie.DateAjout = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.IdCategorie))
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
            return View(categorie);
        }

        // GET: Categorie/Delete/5
        [Route("/admin/supprimmer-categorie/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.IdCategorie == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categorie/Delete/5
        [Route("/admin/supprimmer-categorie/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'caffeinaContext.Categories'  is null.");
            }
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
          return (_context.Categories?.Any(e => e.IdCategorie == id)).GetValueOrDefault();
        }
    }
}
