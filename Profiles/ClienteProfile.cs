using AutoMapper;
using WashApi.Dtos;
using WashApi.Models;

namespace WashApi.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
