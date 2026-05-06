using Microsoft.AspNetCore.Mvc;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Services;

namespace WashApi.Controllers
{
    [Route("/equipes")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly EquipeService _service;

        public EquipeController(EquipeService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var equipes = await _service.FindAll();
                return Ok(equipes);
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
                var equipe = await _service.FindById(id);
                return Ok(equipe);
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
        public async Task<IActionResult> Create([FromBody] EquipeDto novaEquipe)
        {
            try
            {
                var equipe = await _service.Create(novaEquipe);
                return Created("", equipe);
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
        public async Task<IActionResult> Update(int id, [FromBody] EquipeUpdateDto equipeDto)
        {
            try
            {
                var equipe = await _service.Update(id, equipeDto);
                return Ok(equipe);
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
