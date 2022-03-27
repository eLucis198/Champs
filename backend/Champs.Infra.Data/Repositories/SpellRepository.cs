using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Domain.Entities;
using Champs.Domain.Interfaces;
using Champs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Champs.Infra.Data.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private readonly ApplicationDbContext _context;

        public SpellRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Spell>> GetSpellsAsync()
        {
            return await _context.Spells.ToListAsync();
        }

        public async Task<Spell> GetByIdAsync(int? id)
        {
            return await _context.Spells.FindAsync(id);
        }

        public async Task<Spell> CreateAsync(Spell spell)
        {
            _context.Add(spell);
            await _context.SaveChangesAsync();
            return spell;
        }

        public async Task<Spell> UpdateAsync(Spell spell)
        {
            _context.Update(spell);
            await _context.SaveChangesAsync();
            return spell;
        }

        public async Task<Spell> DeleteAsync(Spell spell)
        {
            _context.Remove(spell);
            await _context.SaveChangesAsync();
            return spell;
        }
    }
}