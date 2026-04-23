using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WashApi.DataContexts;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Models;

namespace WashApi.Services
{
    public class EquipeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EquipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Equipe>> FindAll()
        {
            try
            {
                return await _context.Equipes.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Equipe> FindById(int id)
        {
            try
            {
                var equipe = await _context.Equipes.FirstOrDefaultAsync(x => x.Id == id);

                if (equipe is null)
                {
                    throw new ErrorServiceException($"Equipe #{id} não encontrada",
                        c => c.NotFound(new { message = $"Equipe #{id} não encontrada" }));
                }

                return equipe;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Equipe> Create(EquipeDto data)
        {
            try
            {
                var nomeExiste = await _context.Equipes.AnyAsync(x => x.Nome == data.Nome);

                if (nomeExiste)
                {
                    throw new ErrorServiceException("Nome já cadastrado",
                        c => c.Conflict(new { message = $"Já existe uma equipe com o nome '{data.Nome}'" }));
                }

                var equipe = _mapper.Map<Equipe>(data);

                await _context.Equipes.AddAsync(equipe);
                await _context.SaveChangesAsync();

                return equipe;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Equipe> Update(int id, EquipeUpdateDto data)
        {
            try
            {
                var equipe = await FindById(id);

                var nomeExiste = await _context.Equipes.AnyAsync(x => x.Nome == data.Nome && x.Id != id);

                if (nomeExiste)
                {
                    throw new ErrorServiceException("Nome já cadastrado",
                        c => c.Conflict(new { message = $"Já existe outra equipe com o nome '{data.Nome}'" }));
                }

                _mapper.Map(data, equipe);

                _context.Equipes.Update(equipe);
                await _context.SaveChangesAsync();

                return equipe;
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
                var equipe = await FindById(id);

                _context.Equipes.Remove(equipe);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
