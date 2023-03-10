using AutoMapper;
using TestApp1.DTOs;
using TestApp1.Models;

namespace TestApp1.Profiles
{
    public class SpellProfile : Profile
    {
        public SpellProfile()
        {
            // Source -> Target
            CreateMap<Spell, SpellReadDTO>();
            CreateMap<SpellCreateDTO, Spell>();
            CreateMap <SpellUpdateDTO, Spell>();
        }
    }
}
