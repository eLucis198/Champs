using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;

namespace Champs.Application.Interfaces
{
    public interface ISpellService
    {
        Task<IEnumerable<SpellDTO>> GetSpells();
        Task<SpellDTO> GetById(int? id);
        Task Create(SpellDTO spellDto);
        Task Update(SpellDTO spellDto);
        Task Delete(int? id);
    }
}