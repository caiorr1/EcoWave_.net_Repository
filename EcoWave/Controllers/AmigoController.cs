using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class AmigoController : Controller
    {
        private readonly IRepository<Amigo> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public AmigoController(IRepository<Amigo> repository, IRepository<Usuario> usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: Amigo
        public async Task<IActionResult> Index()
        {
            var amigos = await _repository.GetAll();
            return View(amigos);
        }

        // GET: Amigo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _repository.GetById(id.Value);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: Amigo/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioRepository.GetAll();
            ViewData["AmigoId"] = new SelectList(usuarios, "UsuarioId", "Email");
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Amigo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,AmigoId,DataAmizade")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(amigo);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["AmigoId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _repository.GetById(id.Value);
            if (amigo == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["AmigoId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // POST: Amigo/Edit/5
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
                    await _repository.Update(amigo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AmigoExists(amigo.UsuarioId))
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
            ViewData["AmigoId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.AmigoId);
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", amigo.UsuarioId);
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _repository.GetById(id.Value);
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
            var amigo = await _repository.GetById(id);
            if (amigo != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AmigoExists(int id)
        {
            var amigo = await _repository.GetById(id);
            return amigo != null;
        }
    }
}
