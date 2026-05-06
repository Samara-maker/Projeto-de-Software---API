using AutoMapper;
using WashApi.Dtos;
using WashApi.Models;

namespace WashApi.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<FuncionarioUpdateDto, Funcionario>();
        }
    }
}
