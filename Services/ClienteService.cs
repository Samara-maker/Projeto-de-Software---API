using WashApi.DataContexts; 
using WashApi.Dtos;         
using WashApi.Exceptions;
using WashApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WashApi.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Cliente>> FindAll()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> FindById(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente is null)
                {
                    throw new ErrorServiceException(
                        $"Cliente {id} não encontrado",
                        c => c.NotFound(new { message = $"Cliente #{id} não encontrado" })
                    );
                }

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> Create(ClienteDto data)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(data);

                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> Update(int id, ClienteUpdateDto data)
        {
            try
            {
                var cliente = await FindById(id);

                _mapper.Map(data, cliente);

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                return cliente;
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
                var cliente = await FindById(id);

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}