using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Champs.Domain.Entities;
using Champs.Domain.Interfaces;
using Champs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Champs.Infra.Data.Repositories
{
    public class ChampionRepository : IChampionRepository
    {
        private readonly ApplicationDbContext _context;

        public ChampionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Champion>> GetChampionsAsync()
        {
            return await _context.Champions.ToListAsync();
        }

        public async Task<Champion> GetByIdAsync(int? id)
        {
            return await _context.Champions.FindAsync(id);
        }

        public async Task<Champion> CreateAsync(Champion champion)
        {
            _context.Add(champion);
            await _context.SaveChangesAsync();
            return champion;
        }

        public async Task<Champion> UpdateAsync(Champion champion)
        {
            _context.Update(champion);
            await _context.SaveChangesAsync();
            return champion;
        }

        public async Task<Champion> DeleteAsync(Champion champion)
        {
            _context.Remove(champion);
            await _context.SaveChangesAsync();
            return champion;
        }
    }
}