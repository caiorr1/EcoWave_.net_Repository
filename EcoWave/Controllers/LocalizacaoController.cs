using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class LocalizacoesController : Controller
    {
        private readonly IRepository<Localizacao> _repository;

        public LocalizacoesController(IRepository<Localizacao> repository)
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
            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null) return NotFound();
            return View(localizacao);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizacaoId,NomeLocalizacao,Latitude,Longitude,Descricao")] Localizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null) return NotFound();
            return View(localizacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizacaoId,NomeLocalizacao,Latitude,Longitude,Descricao")] Localizacao localizacao)
        {
            if (id != localizacao.LocalizacaoId) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.Update(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null) return NotFound();
            return View(localizacao);
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
