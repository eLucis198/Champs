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
    public class SpellServices : ISpellServices
    {
        private ISpellRepository _spellRepository;
        private readonly IMapper _mapper;

        public SpellServices(ISpellRepository spellRepository, IMapper mapper)
        {
            _spellRepository = spellRepository ?? throw new ArgumentNullException(nameof(spellRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpellDTO>> GetSpells()
        {
            var spellsEntity = await _spellRepository.GetSpellsAsync();
            return _mapper.Map<IEnumerable<SpellDTO>>(spellsEntity);
        }

        public async Task<SpellDTO> GetById(int? id)
        {
            var spellEntity = await _spellRepository.GetByIdAsync(id);
            return _mapper.Map<SpellDTO>(spellEntity);
        }

        public async Task Create(SpellDTO spellDto)
        {
            var spellEntity = _mapper.Map<Spell>(spellDto);
            await _spellRepository.CreateAsync(spellEntity);
        }

        public async Task Update(SpellDTO spellDto)
        {
            var spellEntity = _mapper.Map<Spell>(spellDto);
            await _spellRepository.UpdateAsync(spellEntity);
        }

        public async Task Delete(int? id)
        {
            var spellEntity = _spellRepository.GetByIdAsync(id).Result;
            await _spellRepository.DeleteAsync(spellEntity);
        }
    }
}