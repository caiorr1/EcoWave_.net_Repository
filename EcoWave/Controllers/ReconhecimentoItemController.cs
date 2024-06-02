using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoWave.Controllers
{
    public class ReconhecimentoItensController : Controller
    {
        private readonly IRepository<ReconhecimentoItem> _repository;

        public ReconhecimentoItensController(IRepository<ReconhecimentoItem> repository)
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
            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null) return NotFound();
            return View(reconhecimentoItem);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReconhecimentoId,UsuarioId,UrlImagem,TipoItem,DataReconhecimento,Localizacao")] ReconhecimentoItem reconhecimentoItem)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(reconhecimentoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(reconhecimentoItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null) return NotFound();
            return View(reconhecimentoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReconhecimentoId,UsuarioId,UrlImagem,TipoItem,DataReconhecimento,Localizacao")] ReconhecimentoItem reconhecimentoItem)
        {
            if (id != reconhecimentoItem.ReconhecimentoId) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.Update(reconhecimentoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(reconhecimentoItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null) return NotFound();
            return View(reconhecimentoItem);
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

