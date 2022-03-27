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
    public class ChampionService : IChampionService
    {
        private IChampionRepository _championRepository;
        private readonly IMapper _mapper;

        public ChampionService(IChampionRepository championRepository, IMapper mapper)
        {
            _championRepository = championRepository ?? throw new ArgumentNullException(nameof(championRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChampionDTO>> GetChampions()
        {
            var championsEntity = await _championRepository.GetChampionsAsync();
            return _mapper.Map<IEnumerable<ChampionDTO>>(championsEntity);
        }

        public async Task<ChampionDTO> GetById(int? id)
        {
            var championEntity = await _championRepository.GetByIdAsync(id);
            return _mapper.Map<ChampionDTO>(championEntity);
        }

        public async Task Create(ChampionDTO championDto)
        {
            var championEntity = _mapper.Map<Champion>(championDto);
            await _championRepository.CreateAsync(championEntity);
        }

        public async Task Update(ChampionDTO championDto)
        {
            var championEntity = _mapper.Map<Champion>(championDto);
            await _championRepository.UpdateAsync(championEntity);
        }

        public async Task Delete(int? id)
        {
            var championEntity = _championRepository.GetByIdAsync(id).Result;
            await _championRepository.DeleteAsync(championEntity);
        }
    }
}