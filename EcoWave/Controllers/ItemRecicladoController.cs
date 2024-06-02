using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class ItensRecicladosController : Controller
    {
        private readonly IRepository<ItemReciclado> _repository;

        public ItensRecicladosController(IRepository<ItemReciclado> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null) return NotFound();
            return View(itemReciclado);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,UsuarioId,TipoItem,DataColeta,Localizacao,Quantidade")] ItemReciclado itemReciclado)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(itemReciclado);
                return RedirectToAction(nameof(Index));
            }
            return View(itemReciclado);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null) return NotFound();
            return View(itemReciclado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,UsuarioId,TipoItem,DataColeta,Localizacao,Quantidade")] ItemReciclado itemReciclado)
        {
            if (id != itemReciclado.ItemId) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.Update(itemReciclado);
                return RedirectToAction(nameof(Index));
            }
            return View(itemReciclado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var itemReciclado = await _repository.GetById(id.Value);
            if (itemReciclado == null) return NotFound();
            return View(itemReciclado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
