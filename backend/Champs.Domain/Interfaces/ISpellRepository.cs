using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Domain.Entities;

namespace Champs.Domain.Interfaces
{
    public interface ISpellRepository
    {
        Task<IEnumerable<Spell>> GetSpellsAsync();
        Task<Spell> GetByIdAsync(int? id);

        Task<Spell> CreateAsync(Spell spell);
        Task<Spell> UpdateAsync(Spell spell);
        Task<Spell> DeleteAsync(Spell spell);
    }
}