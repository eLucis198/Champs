using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;

namespace Champs.Application.Interfaces
{
    public interface IChampionService
    {
        Task<IEnumerable<ChampionDTO>> GetChampions();
        Task<ChampionDTO> GetById(int? id);
        Task Create(ChampionDTO championDto);
        Task Update(ChampionDTO championDto);
        Task Delete(int? id);
    }
}