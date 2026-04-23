using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WashApi.DataContexts;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Models;

namespace WashApi.Services
{
    public class FuncionarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FuncionarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Funcionario>> FindAll()
        {
            try
            {
                return await _context.Funcionarios.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Funcionario> FindById(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario is null)
                {
                    throw new ErrorServiceException($"Funcionário #{id} não encontrado",
                        c => c.NotFound(new { message = $"Funcionário #{id} não encontrado" }));
                }

                return funcionario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Funcionario> Create(FuncionarioDto data)
        {
            try
            {
                var funcionario = _mapper.Map<Funcionario>(data);

                await _context.Funcionarios.AddAsync(funcionario);
                await _context.SaveChangesAsync();

                return funcionario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Funcionario> Update(int id, FuncionarioUpdateDto data)
        {
            try
            {
                var funcionario = await FindById(id);

                _mapper.Map(data, funcionario);

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                return funcionario;
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
                var funcionario = await FindById(id);

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
