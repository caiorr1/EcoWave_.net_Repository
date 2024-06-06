using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private readonly IRepository<Configuracao> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public ConfiguracaoController(IRepository<Configuracao> repository, IRepository<Usuario> usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: Configuracao
        public async Task<IActionResult> Index()
        {
            var configuracoes = await _repository.GetAll();
            return View(configuracoes);
        }

        // GET: Configuracao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // GET: Configuracao/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Configuracao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(configuracao);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // GET: Configuracao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarioRepository.GetAll();
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // POST: Configuracao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfiguracaoId,UsuarioId,NomeConfiguracao,ValorConfiguracao")] Configuracao configuracao)
        {
            if (id != configuracao.ConfiguracaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(configuracao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ConfiguracaoExists(configuracao.ConfiguracaoId))
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
            ViewData["UsuarioId"] = new SelectList(usuarios, "UsuarioId", "Email", configuracao.UsuarioId);
            return View(configuracao);
        }

        // GET: Configuracao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracao = await _repository.GetById(id.Value);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // POST: Configuracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracao = await _repository.GetById(id);
            if (configuracao != null)
            {
                await _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ConfiguracaoExists(int id)
        {
            var configuracao = await _repository.GetById(id);
            return configuracao != null;
        }
    }
}
