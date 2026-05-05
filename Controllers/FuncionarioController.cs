using Microsoft.AspNetCore.Mvc;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Services;

namespace WashApi.Controllers
{
    [Route("/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;

        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var funcionarios = await _service.FindAll();
                return Ok(funcionarios);
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
                var funcionario = await _service.FindById(id);
                return Ok(funcionario);
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
        public async Task<IActionResult> Create([FromBody] FuncionarioDto novoFuncionario)
        {
            try
            {
                var funcionario = await _service.Create(novoFuncionario);
                return Created("", funcionario);
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
        public async Task<IActionResult> Update(int id, [FromBody] FuncionarioUpdateDto funcionarioDto)
        {
            try
            {
                var funcionario = await _service.Update(id, funcionarioDto);
                return Ok(funcionario);
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
