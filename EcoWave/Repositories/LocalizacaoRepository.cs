using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoWave.Repositories
{
    public class LocalizacaoRepository : IRepository<Localizacao>
    {
        private readonly ApplicationDbContext _context;

        public LocalizacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Localizacao>> GetAll()
        {
            return await _context.Localizacoes.ToListAsync();
        }

        public async Task<Localizacao> GetById(int id)
        {
            return await _context.Localizacoes.FindAsync(id);
        }

        public async Task Add(Localizacao entity)
        {
            await _context.Localizacoes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Localizacao entity)
        {
            _context.Localizacoes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Localizacoes.FindAsync(id);
            _context.Localizacoes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
