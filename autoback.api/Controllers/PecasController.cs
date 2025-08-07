using autoback.application.Commands.AdicaoPecas;
using autoback.application.Pecas.Commands;
using autoback.application.Pecas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace autoback.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PecasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PecasController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetPecasQuery(), ct);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetPecaByIdQuery(id), ct);
            return result is null ? NotFound() : Ok(result);
        }

        public record CreatePecaDto(string Nome, string Codigo, int Quantidade, decimal Preco);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePecaDto dto, CancellationToken ct)
        {
            var id = await _mediator.Send(new CreatePecaCommand(dto.Nome, dto.Codigo, dto.Quantidade, dto.Preco), ct);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPatch("{id:int}/preco")]
        public async Task<IActionResult> UpdatePreco(int id, [FromBody] decimal novoPreco, CancellationToken ct)
        {
            var ok = await _mediator.Send(new UpdatePrecoCommand(id, novoPreco), ct);
            return ok ? NoContent() : Problem("Falha ao atualizar preço");
        }

        public record MovEstoqueDto(int Quantidade, string Tipo); // "Entrada" ou "Saida"

        [HttpPost("{id:int}/estoque")]
        public async Task<IActionResult> MovimentarEstoque(int id, [FromBody] MovEstoqueDto dto, CancellationToken ct)
        {
            var tipo = dto.Tipo?.Equals("Entrada", StringComparison.OrdinalIgnoreCase) == true
                ? MovimentarEstoqueCommand.TipoMovimentacao.Entrada
                : MovimentarEstoqueCommand.TipoMovimentacao.Saida;

            var ok = await _mediator.Send(new MovimentarEstoqueCommand(id, dto.Quantidade, tipo), ct);
            return ok ? NoContent() : Problem("Falha ao movimentar estoque");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var ok = await _mediator.Send(new DeletePecaCommand(id), ct);
            return ok ? NoContent() : NotFound();
        }
    }
}
