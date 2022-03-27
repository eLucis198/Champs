using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Domain.Entities;
using Champs.Domain.Interfaces;
using Champs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Champs.Infra.Data.Repositories
{
    public class StatRepository : IStatRepository
    {
        private readonly ApplicationDbContext _context;

        public StatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stat>> GetStatsAsync()
        {
            return await _context.Stats.ToListAsync();
        }

        public async Task<Stat> GetByIdAsync(int? id)
        {
            return await _context.Stats.FindAsync(id);
        }

        public async Task<Stat> CreateAsync(Stat stat)
        {
            _context.Add(stat);
            await _context.SaveChangesAsync();
            return stat;
        }

        public async Task<Stat> UpdateAsync(Stat stat)
        {
            _context.Update(stat);
            await _context.SaveChangesAsync();
            return stat;
        }

        public async Task<Stat> DeleteAsync(Stat stat)
        {
            _context.Remove(stat);
            await _context.SaveChangesAsync();
            return stat;
        }
    }
}