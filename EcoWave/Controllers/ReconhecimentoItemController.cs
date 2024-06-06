using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class ReconhecimentoItemController : Controller
    {
        private readonly IRepository<ReconhecimentoItem> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public ReconhecimentoItemController(IRepository<ReconhecimentoItem> repository, IRepository<Usuario> usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: ReconhecimentoItem
        public async Task<IActionResult> Index()
        {
            var reconhecimentoItens = await _repository.GetAll();
            return View(reconhecimentoItens);
        }

        // GET: ReconhecimentoItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null)
            {
                return NotFound();
            }

            return View(reconhecimentoItem);
        }

        // GET: ReconhecimentoItem/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: ReconhecimentoItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReconhecimentoId,UsuarioId,UrlImagem,TipoItem,DataReconhecimento,Localizacao")] ReconhecimentoItem reconhecimentoItem)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(reconhecimentoItem);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", reconhecimentoItem.UsuarioId);
            return View(reconhecimentoItem);
        }

        // GET: ReconhecimentoItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", reconhecimentoItem.UsuarioId);
            return View(reconhecimentoItem);
        }

        // POST: ReconhecimentoItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReconhecimentoId,UsuarioId,UrlImagem,TipoItem,DataReconhecimento,Localizacao")] ReconhecimentoItem reconhecimentoItem)
        {
            if (id != reconhecimentoItem.ReconhecimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(reconhecimentoItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ReconhecimentoItemExists(reconhecimentoItem.ReconhecimentoId))
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
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", reconhecimentoItem.UsuarioId);
            return View(reconhecimentoItem);
        }

        // GET: ReconhecimentoItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reconhecimentoItem = await _repository.GetById(id.Value);
            if (reconhecimentoItem == null)
            {
                return NotFound();
            }

            return View(reconhecimentoItem);
        }

        // POST: ReconhecimentoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reconhecimentoItem = await _repository.GetById(id);
            if (reconhecimentoItem != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReconhecimentoItemExists(int id)
        {
            var reconhecimentoItem = await _repository.GetById(id);
            return reconhecimentoItem != null;
        }
    }
}
