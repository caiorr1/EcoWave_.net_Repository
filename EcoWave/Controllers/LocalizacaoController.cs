using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class LocalizacaoController : Controller
    {
        private readonly IRepository<Localizacao> _repository;

        public LocalizacaoController(IRepository<Localizacao> repository)
        {
            _repository = repository;
        }

        // GET: Localizacao
        public async Task<IActionResult> Index()
        {
            var localizacoes = await _repository.GetAll();
            return View(localizacoes);
        }

        // GET: Localizacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // GET: Localizacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizacao/Create
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

        // GET: Localizacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null)
            {
                return NotFound();
            }
            return View(localizacao);
        }

        // POST: Localizacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizacaoId,NomeLocalizacao,Latitude,Longitude,Descricao")] Localizacao localizacao)
        {
            if (id != localizacao.LocalizacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(localizacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LocalizacaoExists(localizacao.LocalizacaoId))
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
            return View(localizacao);
        }

        // GET: Localizacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _repository.GetById(id.Value);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // POST: Localizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizacao = await _repository.GetById(id);
            if (localizacao != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LocalizacaoExists(int id)
        {
            var localizacao = await _repository.GetById(id);
            return localizacao != null;
        }
    }
}
