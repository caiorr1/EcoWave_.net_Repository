using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoWave.Repositories
{
    public class ConfiguracaoRepository : IRepository<Configuracao>
    {
        private readonly ApplicationDbContext _context;

        public ConfiguracaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Configuracao>> GetAll()
        {
            return await _context.Configuracoes.ToListAsync();
        }

        public async Task<Configuracao> GetById(int id)
        {
            return await _context.Configuracoes.FindAsync(id);
        }

        public async Task Add(Configuracao entity)
        {
            await _context.Configuracoes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Configuracao entity)
        {
            _context.Configuracoes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Configuracoes.FindAsync(id);
            _context.Configuracoes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
