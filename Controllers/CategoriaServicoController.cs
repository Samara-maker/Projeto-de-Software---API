using Microsoft.AspNetCore.Mvc;
using WashApi.Dtos;
using WashApi.Exceptions;
using WashApi.Services;

namespace WashApi.Controllers
{
    [Route("/categorias")]
    [ApiController]
    public class CategoriaServicoController : ControllerBase
    {
        private readonly CategoriaServicoService _service;

        public CategoriaServicoController(CategoriaServicoService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var categorias = await _service.FindAll();
                return Ok(categorias);
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
                var categoria = await _service.FindById(id);
                return Ok(categoria);
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
        public async Task<IActionResult> Create([FromBody] CategoriaServicoDto novaCategoria)
        {
            try
            {
                var categoria = await _service.Create(novaCategoria);
                return Created("", categoria);
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
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaServicoUpdateDto categoriaDto)
        {
            try
            {
                var categoria = await _service.Update(id, categoriaDto);
                return Ok(categoria);
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
