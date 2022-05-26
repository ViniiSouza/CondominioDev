using AutoMapper;
using CondominioDevAPI.DTOs;
using CondominioDevAPI.Models;

namespace CondominioDevAPI.Mapper
{
    public class HabitanteProfile : Profile
    {
        public HabitanteProfile()
        {
            CreateMap<HabitantePostDTO, Habitante>()
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.Replace(".", "").Replace("-", "")))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => DateTime.ParseExact(src.DataNascimento, "dd/MM/yyyy", null)));
        }
    }
}
