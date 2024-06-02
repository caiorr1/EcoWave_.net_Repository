using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly IRepository<Configuracao> _repository;

        public ConfiguracoesController(IRepository<Configuracao> repository)
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
            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null) return NotFound();
            return View(configuracao);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(configuracao);
                return RedirectToAction(nameof(Index));
            }
            return View(configuracao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null) return NotFound();
            return View(configuracao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (id != configuracao.ConfiguracaoId) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.Update(configuracao);
                return RedirectToAction(nameof(Index));
            }
            return View(configuracao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null) return NotFound();
            return View(configuracao);
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
