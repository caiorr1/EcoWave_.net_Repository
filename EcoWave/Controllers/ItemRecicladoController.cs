using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class ItemRecicladoController : Controller
    {
        private readonly IRepository<ItemReciclado> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public ItemRecicladoController(IRepository<ItemReciclado> repository, IRepository<Usuario> usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: ItemReciclado
        public async Task<IActionResult> Index()
        {
            var itensReciclados = await _repository.GetAll();
            return View(itensReciclados);
        }

        // GET: ItemReciclado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null)
            {
                return NotFound();
            }

            return View(itemReciclado);
        }

        // GET: ItemReciclado/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "NomeUsuario");
            return View();
        }

        // POST: ItemReciclado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,UsuarioId,TipoItem,DataColeta,Localizacao,Quantidade")] ItemReciclado itemReciclado)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                await _repository.Add(itemReciclado);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "NomeUsuario", itemReciclado.UsuarioId);
            return View(itemReciclado);
        }

        // GET: ItemReciclado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "NomeUsuario", itemReciclado.UsuarioId);
            return View(itemReciclado);
        }

        // POST: ItemReciclado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,UsuarioId,TipoItem,DataColeta,Localizacao,Quantidade")] ItemReciclado itemReciclado)
        {
            if (id != itemReciclado.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(itemReciclado);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ItemRecicladoExists(itemReciclado.ItemId))
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
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "NomeUsuario", itemReciclado.UsuarioId);
            return View(itemReciclado);
        }

        // GET: ItemReciclado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null)
            {
                return NotFound();
            }

            return View(itemReciclado);
        }

        // POST: ItemReciclado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemReciclado = await _repository.GetById(id);
            if (itemReciclado != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ItemRecicladoExists(int id)
        {
            var itemReciclado = await _repository.GetById(id);
            return itemReciclado != null;
        }
    }
}
