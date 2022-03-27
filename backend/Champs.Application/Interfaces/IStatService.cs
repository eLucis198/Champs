using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;

namespace Champs.Application.Interfaces
{
    public interface IStatService
    {
        Task<IEnumerable<StatDTO>> GetStats();
        Task<StatDTO> GetById(int? id);
        Task Create(StatDTO statDto);
        Task Update(StatDTO statDto);
        Task Delete(int? id);
    }
}