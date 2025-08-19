using autoback.application.Categorias.Commands;
using autoback.application.Categorias.DTOs;
using autoback.application.Categorias.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace autoback.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriasController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetCategoriasQuery(), ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaRequest dto, CancellationToken ct)
        {
            var id = await _mediator.Send(new CreateCategoriaCommand(dto.Nome), ct);
            return Created($"/api/Categorias/{id}", new { id });
        }
    }
}
