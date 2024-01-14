using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caffeina.Models;

namespace Caffeina
{
    public class UtilisateurController : Controller
    {
        private readonly caffeinaContext _context;
        //public static Utilisateur userConnecter;
        public UtilisateurController(caffeinaContext context)
        {
            _context = context;
        }

        // GET: Utilisateur
        public async Task<IActionResult> Index()
        {
              return _context.Utilisateurs != null ? 
                          View(await _context.Utilisateurs.ToListAsync()) :
                          Problem("Entity set 'caffeinaContext.Utilisateurs'  is null.");
        }
        // GET: Utilisateur/Login/
        [Route("/admin/connexion")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // Post: Utilisateur/Login/
        [Route("/admin/connexion")]
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string MotDePasse)
        {
            if (_context.Utilisateurs == null)
            {
                return NotFound();
            }

            var user = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == Email && u.MotDePasse == MotDePasse);
            if (user == null)
            {
                return NotFound();
            }
            //userConnecter = new Utilisateur { IdUtilisateur = user.IdUtilisateur, Nom=user.Nom, Email= user.Email, MotDePasse= user.MotDePasse };
            TempData["MyObject"] = user;
            // new { userConnecter=user }
            return RedirectToAction(nameof(Index), "Admin");
            //return View(utilisateur);
        }
        // GET: Utilisateur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Utilisateur/Create
        [Route("/admin/inscription")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilisateur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/admin/inscription")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtilisateur,Nom,Email,MotDePasse")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

        // GET: Utilisateur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilisateur,Nom,Email,MotDePasse")] Utilisateur utilisateur)
        {
            if (id != utilisateur.IdUtilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.IdUtilisateur))
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
            return View(utilisateur);
        }

        // GET: Utilisateur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utilisateurs == null)
            {
                return Problem("Entity set 'caffeinaContext.Utilisateurs'  is null.");
            }
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
          return (_context.Utilisateurs?.Any(e => e.IdUtilisateur == id)).GetValueOrDefault();
        }
    }
}
