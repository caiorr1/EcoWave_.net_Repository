using EcoWave.Data;
using EcoWave.Models;
using EcoWave.Repositories;
using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoWave.Repositories
{
    public class ItemRecicladoRepository : IRepository<ItemReciclado>
    {
        private readonly ApplicationDbContext _context;

        public ItemRecicladoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemReciclado>> GetAll()
        {
            return await _context.ItensReciclados.ToListAsync();
        }

        public async Task<ItemReciclado> GetById(int id)
        {
            return await _context.ItensReciclados.FindAsync(id);
        }

        public async Task Add(ItemReciclado entity)
        {
            await _context.ItensReciclados.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ItemReciclado entity)
        {
            _context.ItensReciclados.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ItensReciclados.FindAsync(id);
            _context.ItensReciclados.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
