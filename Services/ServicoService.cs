using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WashApi.DataContexts;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Models;

namespace WashApi.Services
{
    public class ServicoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServicoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Servico>> FindAll()
        {
            try
            {
                return await _context.Servicos
                    .Include(s => s.Categoria)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Servico> FindById(int id)
        {
            try
            {
                var servico = await _context.Servicos
                    .Include(s => s.Categoria)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (servico is null)
                {
                    throw new ErrorServiceException($"Serviço #{id} não encontrado",
                        c => c.NotFound(new { message = $"Serviço #{id} não encontrado" }));
                }

                return servico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Servico> Create(ServicoDto data)
        {
            try
            {
                var categoriaExiste = await _context.CategoriasServico.AnyAsync(x => x.Id == data.CategoriaId);

                if (!categoriaExiste)
                {
                    throw new ErrorServiceException("Categoria não encontrada",
                        c => c.NotFound(new { message = $"Categoria #{data.CategoriaId} não encontrada" }));
                }

                var servico = _mapper.Map<Servico>(data);

                await _context.Servicos.AddAsync(servico);
                await _context.SaveChangesAsync();

                return servico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Servico> Update(int id, ServicoUpdateDto data)
        {
            try
            {
                var servico = await FindById(id);

                var categoriaExiste = await _context.CategoriasServico.AnyAsync(x => x.Id == data.CategoriaId);

                if (!categoriaExiste)
                {
                    throw new ErrorServiceException("Categoria não encontrada",
                        c => c.NotFound(new { message = $"Categoria #{data.CategoriaId} não encontrada" }));
                }

                _mapper.Map(data, servico);

                _context.Servicos.Update(servico);
                await _context.SaveChangesAsync();

                return servico;
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
                var servico = await FindById(id);

                var possuiAgendamentos = await _context.AgendamentosServicos.AnyAsync(x => x.ServicoId == id);

                if (possuiAgendamentos)
                {
                    throw new ErrorServiceException("Serviço não pode ser excluído",
                        c => c.Conflict(new { message = $"O serviço #{id} está vinculado a agendamentos e não pode ser excluído." }));
                }

                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
