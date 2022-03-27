using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Champs.Application.DTOs;
using Champs.Application.Interfaces;
using Champs.Domain.Entities;
using Champs.Domain.Interfaces;

namespace Champs.Application.Services
{
    public class StatService : IStatService
    {
        private IStatRepository _statRepository;
        private readonly IMapper _mapper;

        public StatService(IStatRepository statRepository, IMapper mapper)
        {
            _statRepository = statRepository ?? throw new ArgumentNullException(nameof(statRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatDTO>> GetStats()
        {
            var statsEntity = await _statRepository.GetStatsAsync();
            return _mapper.Map<IEnumerable<StatDTO>>(statsEntity);
        }

        public async Task<StatDTO> GetById(int? id)
        {
            var statEntity = await _statRepository.GetByIdAsync(id);
            return _mapper.Map<StatDTO>(statEntity);
        }

        public async Task Create(StatDTO statDto)
        {
            var statEntity = _mapper.Map<Stat>(statDto);
            await _statRepository.CreateAsync(statEntity);
        }

        public async Task Update(StatDTO statDto)
        {
            var statEntity = _mapper.Map<Stat>(statDto);
            await _statRepository.UpdateAsync(statEntity);
        }

        public async Task Delete(int? id)
        {
            var statEntity = _statRepository.GetByIdAsync(id).Result;
            await _statRepository.DeleteAsync(statEntity);
        }
    }
}