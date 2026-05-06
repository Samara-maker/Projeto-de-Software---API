using Microsoft.AspNetCore.Mvc;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Services;

namespace WashApi.Controllers
{
    [Route("/agendamentos")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoService _service;

        public AgendamentoController(AgendamentoService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var agendamentos = await _service.FindAll();
                return Ok(agendamentos);
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
                var agendamento = await _service.FindById(id);
                return Ok(agendamento);
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
        public async Task<IActionResult> Create([FromBody] AgendamentoDto novoAgendamento)
        {
            try
            {
                var agendamento = await _service.Create(novoAgendamento);
                return Created("", agendamento);
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
        public async Task<IActionResult> Update(int id, [FromBody] AgendamentoUpdateDto agendamentoDto)
        {
            try
            {
                var agendamento = await _service.Update(id, agendamentoDto);
                return Ok(agendamento);
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
