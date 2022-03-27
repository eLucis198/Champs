using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Domain.Entities;

namespace Champs.Domain.Interfaces
{
    public interface IStatRepository
    {
        Task<IEnumerable<Stat>> GetStatsAsync();
        Task<Stat> GetByIdAsync(int? id);

        Task<Stat> CreateAsync(Stat stat);
        Task<Stat> UpdateAsync(Stat stat);
        Task<Stat> DeleteAsync(Stat stat);
    }
}