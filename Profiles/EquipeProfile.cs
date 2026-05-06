using AutoMapper;
using WashApi.Dtos;
using WashApi.Models;

namespace WashApi.Profiles
{
    public class EquipeProfile : Profile
    {
        public EquipeProfile()
        {
            CreateMap<EquipeDto, Equipe>();
            CreateMap<EquipeUpdateDto, Equipe>();
        }
    }
}
