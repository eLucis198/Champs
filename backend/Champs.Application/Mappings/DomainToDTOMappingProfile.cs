using AutoMapper;
using Champs.Application.DTOs;
using Champs.Domain.Entities;

namespace Champs.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Champion, ChampionDTO>().ReverseMap();
            CreateMap<Stat, StatDTO>().ReverseMap();
            CreateMap<Spell, SpellDTO>().ReverseMap();
        }
    }
}