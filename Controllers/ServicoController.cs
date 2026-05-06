using Microsoft.AspNetCore.Mvc;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Services;

namespace WashApi.Controllers
{
    [Route("/servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoService _service;

        public ServicoController(ServicoService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var servicos = await _service.FindAll();
                return Ok(servicos);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var servico = await _service.FindById(id);
                return Ok(servico);
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] ServicoDto novoServico)
        {
            try
            {
                var servico = await _service.Create(novoServico);
                return Created("", servico);
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServicoUpdateDto servicoDto)
        {
            try
            {
                var servico = await _service.Update(id, servicoDto);
                return Ok(servico);
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _service.Remove(id);
                return NoContent();
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
