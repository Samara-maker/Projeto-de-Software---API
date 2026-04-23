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

    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<FuncionarioUpdateDto, Funcionario>();
        }
    }

    public class EquipeProfile : Profile
    {
        public EquipeProfile()
        {
            CreateMap<EquipeDto, Equipe>();
            CreateMap<EquipeUpdateDto, Equipe>();
        }
    }

    public class CategoriaServicoProfile : Profile
    {
        public CategoriaServicoProfile()
        {
            CreateMap<CategoriaServicoDto, CategoriaServico>();
            CreateMap<CategoriaServicoUpdateDto, CategoriaServico>();
        }
    }

    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoDto, Servico>();
            CreateMap<ServicoUpdateDto, Servico>();
        }
    }
}
