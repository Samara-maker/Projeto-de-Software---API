using AutoMapper;
using Microsoft.EntityFrameworkCore;
using .DataContexts;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Models;

namespace WashApi.Services
{
    public class CategoriaServicoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaServicoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoriaServico>> FindAll()
        {
            try
            {
                return await _context.CategoriasServico.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoriaServico> FindById(int id)
        {
            try
            {
                var categoria = await _context.CategoriasServico.FirstOrDefaultAsync(x => x.Id == id);

                if (categoria is null)
                {
                    throw new ErrorServiceException($"Categoria #{id} não encontrada",
                        c => c.NotFound(new { message = $"Categoria #{id} não encontrada" }));
                }

                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoriaServico> Create(CategoriaServicoDto data)
        {
            try
            {
                var nomeExiste = await _context.CategoriasServico.AnyAsync(x => x.Nome == data.Nome);

                if (nomeExiste)
                {
                    throw new ErrorServiceException("Nome já cadastrado",
                        c => c.Conflict(new { message = $"Já existe uma categoria com o nome '{data.Nome}'" }));
                }

                var categoria = _mapper.Map<CategoriaServico>(data);

                await _context.CategoriasServico.AddAsync(categoria);
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoriaServico> Update(int id, CategoriaServicoUpdateDto data)
        {
            try
            {
                var categoria = await FindById(id);

                var nomeExiste = await _context.CategoriasServico.AnyAsync(x => x.Nome == data.Nome && x.Id != id);

                if (nomeExiste)
                {
                    throw new ErrorServiceException("Nome já cadastrado",
                        c => c.Conflict(new { message = $"Já existe outra categoria com o nome '{data.Nome}'" }));
                }

                _mapper.Map(data, categoria);

                _context.CategoriasServico.Update(categoria);
                await _context.SaveChangesAsync();

                return categoria;
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
                var categoria = await FindById(id);

                _context.CategoriasServico.Remove(categoria);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
