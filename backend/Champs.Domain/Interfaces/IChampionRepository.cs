using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Domain.Entities;

namespace Champs.Domain.Interfaces
{
    public interface IChampionRepository
    {
        Task<IEnumerable<Champion>> GetChampionsAsync();
        Task<Champion> GetByIdAsync(int? id);

        Task<Champion> CreateAsync(Champion champion);
        Task<Champion> UpdateAsync(Champion champion);
        Task<Champion> DeleteAsync(Champion champion);
    }
}