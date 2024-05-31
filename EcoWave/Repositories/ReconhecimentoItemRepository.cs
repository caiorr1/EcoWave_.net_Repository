using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoWave.Repositories
{
    public class ReconhecimentoItemRepository : IRepository<ReconhecimentoItem>
    {
        private readonly ApplicationDbContext _context;

        public ReconhecimentoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReconhecimentoItem>> GetAll()
        {
            return await _context.ReconhecimentoItens.ToListAsync();
        }

        public async Task<ReconhecimentoItem> GetById(int id)
        {
            return await _context.ReconhecimentoItens.FindAsync(id);
        }

        public async Task Add(ReconhecimentoItem entity)
        {
            await _context.ReconhecimentoItens.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ReconhecimentoItem entity)
        {
            _context.ReconhecimentoItens.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ReconhecimentoItens.FindAsync(id);
            _context.ReconhecimentoItens.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
