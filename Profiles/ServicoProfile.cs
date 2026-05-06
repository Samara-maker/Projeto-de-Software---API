using AutoMapper;
using WashApi.Dtos;
using WashApi.Models;

namespace WashApi.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoDto, Servico>();
            CreateMap<ServicoUpdateDto, Servico>();
        }
    }
}
