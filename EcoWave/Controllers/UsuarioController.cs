using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioController(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await _repository.GetAll();
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _repository.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,NomeUsuario,SenhaHash,Email,DataRegistro,Localizacao,FotoPerfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _repository.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,NomeUsuario,SenhaHash,Email,DataRegistro,Localizacao,FotoPerfil")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UsuarioExists(usuario.UsuarioId))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _repository.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UsuarioExists(int id)
        {
            var usuario = await _repository.GetById(id);
            return usuario != null;
        }
    }
}
