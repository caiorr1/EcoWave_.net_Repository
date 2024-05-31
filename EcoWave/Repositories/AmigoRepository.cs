using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoWave.Repositories
{
    public class AmigoRepository : IRepository<Amigo>
    {
        private readonly ApplicationDbContext _context;

        public AmigoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Amigo>> GetAll()
        {
            return await _context.Amigos.ToListAsync();
        }

        public async Task<Amigo> GetById(int id)
        {
            return await _context.Amigos.FindAsync(id);
        }

        public async Task Add(Amigo entity)
        {
            await _context.Amigos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Amigo entity)
        {
            _context.Amigos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Amigos.FindAsync(id);
            _context.Amigos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
