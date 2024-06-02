using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class AmigosController : Controller
    {
        private readonly IRepository<Amigo> _repository;

        public AmigosController(IRepository<Amigo> repository)
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
            var amigo = await _repository.GetById(id.Value);
            if (amigo == null) return NotFound();
            return View(amigo);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,AmigoId,DataAmizade")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(amigo);
                return RedirectToAction(nameof(Index));
            }
            return View(amigo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var amigo = await _repository.GetById(id.Value);
            if (amigo == null) return NotFound();
            return View(amigo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,AmigoId,DataAmizade")] Amigo amigo)
        {
            if (id != amigo.UsuarioId) return NotFound(); // Ajustar conforme necessário
            if (ModelState.IsValid)
            {
                await _repository.Update(amigo);
                return RedirectToAction(nameof(Index));
            }
            return View(amigo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var amigo = await _repository.GetById(id.Value);
            if (amigo == null) return NotFound();
            return View(amigo);
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
