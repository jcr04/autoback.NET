using autoback.application.Fabricantes.Commands;
using autoback.application.Fabricantes.DTOS;
using autoback.application.Fabricantes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace autoback.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricantesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FabricantesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetFabricantesQuery(), ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFabricanteRequest dto, CancellationToken ct)
        {
            var id = await _mediator.Send(new CreateFabricanteCommand(dto.Nome), ct);
            return Created($"/api/Fabricantes/{id}", new { id });
        }
    }
}
