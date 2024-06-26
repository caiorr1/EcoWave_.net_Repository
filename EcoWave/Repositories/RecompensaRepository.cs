﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EcoWave.Data;
using EcoWave.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Repositories
{
    public class RecompensaRepository : IRepository<Recompensa>
    {
        private readonly ApplicationDbContext _context;

        public RecompensaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recompensa>> GetAll()
        {
            return await _context.Recompensas.Include(r => r.Usuario).ToListAsync();
        }

        public async Task<Recompensa> GetById(int id)
        {
            return await _context.Recompensas.Include(r => r.Usuario).FirstOrDefaultAsync(r => r.RecompensaId == id);
        }

        public async Task Add(Recompensa entity)
        {
            await _context.Recompensas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Recompensa entity)
        {
            _context.Recompensas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Recompensas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
