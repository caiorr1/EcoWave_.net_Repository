using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class RecompensasController : Controller
    {
        private readonly IRepository<Recompensa> _repository;

        public RecompensasController(IRepository<Recompensa> repository)
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
            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null) return NotFound();
            return View(recompensa);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecompensaId,UsuarioId,Pontos,TipoRecompensa,DataResgate")] Recompensa recompensa)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(recompensa);
                return RedirectToAction(nameof(Index));
            }
            return View(recompensa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null) return NotFound();
            return View(recompensa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecompensaId,UsuarioId,Pontos,TipoRecompensa,DataResgate")] Recompensa recompensa)
        {
            if (id != recompensa.RecompensaId) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.Update(recompensa);
                return RedirectToAction(nameof(Index));
            }
            return View(recompensa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var recompensa = await _repository.GetById(id.Value);
            if (recompensa == null) return NotFound();
            return View(recompensa);
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
