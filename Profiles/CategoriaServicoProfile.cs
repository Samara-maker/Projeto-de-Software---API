using AutoMapper;
using WashApi.Dtos;
using WashApi.Models;

namespace WashApi.Profiles
{
    public class CategoriaServicoProfile : Profile
    {
        public CategoriaServicoProfile()
        {
            CreateMap<CategoriaServicoDto, CategoriaServico>();
            CreateMap<CategoriaServicoUpdateDto, CategoriaServico>();
        }
    }
}
