using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoWave.Data;
using EcoWave.Models;

namespace EcoWave.Controllers
{
    public class AmigoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmigoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Amigo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Amigos.Include(a => a.AmigoUsuario).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Amigo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigos
                .Include(a => a.AmigoUsuario)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: Amigo/Create
        public IActionResult Create()
        {
            ViewData["AmigoId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Amigo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,AmigoId,DataAmizade")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmigoId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigos.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }
            ViewData["AmigoId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // POST: Amigo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,AmigoId,DataAmizade")] Amigo amigo)
        {
            if (id != amigo.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigoExists(amigo.UsuarioId))
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
            ViewData["AmigoId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigos
                .Include(a => a.AmigoUsuario)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amigo = await _context.Amigos.FindAsync(id);
            if (amigo != null)
            {
                _context.Amigos.Remove(amigo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmigoExists(int id)
        {
            return _context.Amigos.Any(e => e.UsuarioId == id);
        }
    }
}
