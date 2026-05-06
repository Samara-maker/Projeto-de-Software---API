using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WashApi.DataContexts;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Models;

namespace WashApi.Services
{
    public class AgendamentoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AgendamentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Agendamento>> FindAll()
        {
            try
            {
                return await _context.Agendamentos
                    .Include(a => a.Cliente)
                    .Include(a => a.Funcionario)
                    .Include(a => a.Equipe)
                    .Include(a => a.AgendamentoServicos)
                    .ThenInclude(s => s.Servico)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Agendamento> FindById(int id)
        {
            try
            {
                var agendamento = await _context.Agendamentos
                    .Include(a => a.Cliente)
                    .Include(a => a.Funcionario)
                    .Include(a => a.Equipe)
                    .Include(a => a.AgendamentoServicos)
                        .ThenInclude(s => s.Servico)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (agendamento is null)
                {
                    throw new ErrorServiceException($"Agendamento #{id} não encontrado",
                        c => c.NotFound(new { message = $"Agendamento #{id} não encontrado" }));
                }

                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Agendamento> Create(AgendamentoDto data)
        {
            try
            {
                var clienteExiste = await _context.Clientes.AnyAsync(x => x.Id == data.ClienteId);

                if (!clienteExiste)
                {
                    throw new ErrorServiceException("Cliente não encontrado",
                        c => c.NotFound(new { message = $"Cliente #{data.ClienteId} não encontrado" }));
                }

                if (data.FuncionarioId.HasValue)
                {
                    var funcionarioExiste = await _context.Funcionarios.AnyAsync(x => x.Id == data.FuncionarioId);

                    if (!funcionarioExiste)
                    {
                        throw new ErrorServiceException("Funcionário não encontrado",
                            c => c.NotFound(new { message = $"Funcionário #{data.FuncionarioId} não encontrado" }));
                    }
                }

                if (data.EquipeId.HasValue)
                {
                    var equipeExiste = await _context.Equipes.AnyAsync(x => x.Id == data.EquipeId);

                    if (!equipeExiste)
                    {
                        throw new ErrorServiceException("Equipe não encontrada",
                            c => c.NotFound(new { message = $"Equipe #{data.EquipeId} não encontrada" }));
                    }
                }

                var agendamento = new Agendamento
                {
                    ClienteId = data.ClienteId,
                    Data = data.Data,
                    HorarioInicio = data.HorarioInicio,
                    HorarioFim = data.HorarioFim,
                    Observacao = data.Observacao,
                    Status = data.Status,
                    FuncionarioId = data.FuncionarioId,
                    EquipeId = data.EquipeId
                };

                await _context.Agendamentos.AddAsync(agendamento);
                await _context.SaveChangesAsync();

                foreach (var servicoId in data.ServicosIds)
                {
                    var servicoExiste = await _context.Servicos.AnyAsync(x => x.Id == servicoId);

                    if (!servicoExiste)
                    {
                        throw new ErrorServiceException("Serviço não encontrado",
                            c => c.NotFound(new { message = $"Serviço #{servicoId} não encontrado" }));
                    }

                    var agendamentoServico = new AgendamentoServico
                    {
                        AgendamentoId = agendamento.Id,
                        ServicoId = servicoId
                    };

                    await _context.AgendamentosServicos.AddAsync(agendamentoServico);
                }

                await _context.SaveChangesAsync();

                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Agendamento> Update(int id, AgendamentoUpdateDto data)
        {
            try
            {
                var agendamento = await FindById(id);

                var clienteExiste = await _context.Clientes.AnyAsync(x => x.Id == data.ClienteId);

                if (!clienteExiste)
                {
                    throw new ErrorServiceException("Cliente não encontrado",
                        c => c.NotFound(new { message = $"Cliente #{data.ClienteId} não encontrado" }));
                }

                agendamento.ClienteId = data.ClienteId;
                agendamento.Data = data.Data;
                agendamento.HorarioInicio = data.HorarioInicio;
                agendamento.HorarioFim = data.HorarioFim;
                agendamento.Observacao = data.Observacao;
                agendamento.Status = data.Status;
                agendamento.FuncionarioId = data.FuncionarioId;
                agendamento.EquipeId = data.EquipeId;

                var servicosAntigos = await _context.AgendamentosServicos
                    .Where(x => x.AgendamentoId == id)
                    .ToListAsync();

                _context.AgendamentosServicos.RemoveRange(servicosAntigos);

                foreach (var servicoId in data.ServicosIds)
                {
                    var servicoExiste = await _context.Servicos.AnyAsync(x => x.Id == servicoId);

                    if (!servicoExiste)
                    {
                        throw new ErrorServiceException("Serviço não encontrado",
                            c => c.NotFound(new { message = $"Serviço #{servicoId} não encontrado" }));
                    }

                    await _context.AgendamentosServicos.AddAsync(new AgendamentoServico
                    {
                        AgendamentoId = agendamento.Id,
                        ServicoId = servicoId
                    });
                }

                _context.Agendamentos.Update(agendamento);
                await _context.SaveChangesAsync();

                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var agendamento = await FindById(id);

                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
