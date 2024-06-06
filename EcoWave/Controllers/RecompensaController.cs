using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class RecompensaController : Controller
    {
        private readonly IRepository<Recompensa> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public RecompensaController(IRepository<Recompensa> repository, IRepository<Usuario> usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: Recompensa
        public async Task<IActionResult> Index()
        {
            var recompensas = await _repository.GetAll();
            return View(recompensas);
        }

        // GET: Recompensa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null)
            {
                return NotFound();
            }

            return View(recompensa);
        }

        // GET: Recompensa/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Recompensa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecompensaId,UsuarioId,Pontos,TipoRecompensa,DataResgate")] Recompensa recompensa)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(recompensa);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", recompensa.UsuarioId);
            return View(recompensa);
        }

        // GET: Recompensa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", recompensa.UsuarioId);
            return View(recompensa);
        }

        // POST: Recompensa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecompensaId,UsuarioId,Pontos,TipoRecompensa,DataResgate")] Recompensa recompensa)
        {
            if (id != recompensa.RecompensaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(recompensa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RecompensaExists(recompensa.RecompensaId))
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

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", recompensa.UsuarioId);
            return View(recompensa);
        }

        // GET: Recompensa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null)
            {
                return NotFound();
            }

            return View(recompensa);
        }

        // POST: Recompensa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recompensa = await _repository.GetById(id);
            if (recompensa != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RecompensaExists(int id)
        {
            var recompensa = await _repository.GetById(id);
            return recompensa != null;
        }
    }
}
