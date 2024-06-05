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
    public class ConfiguracaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfiguracaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Configuracao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Configuracoes.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Configuracao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracoes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ConfiguracaoId == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // GET: Configuracao/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Configuracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // GET: Configuracao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracoes.FindAsync(id);
            if (configuracao == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // POST: Configuracao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (id != configuracao.ConfiguracaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracaoExists(configuracao.ConfiguracaoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // GET: Configuracao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracoes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ConfiguracaoId == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // POST: Configuracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracao = await _context.Configuracoes.FindAsync(id);
            if (configuracao != null)
            {
                _context.Configuracoes.Remove(configuracao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracaoExists(int id)
        {
            return _context.Configuracoes.Any(e => e.ConfiguracaoId == id);
        }
    }
}
