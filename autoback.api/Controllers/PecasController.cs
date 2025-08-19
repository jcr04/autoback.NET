using autoback.application.Pecas.Commands.AdicaoPecas;
using autoback.application.Pecas.Commands.AtualizarPecas;
using autoback.application.Pecas.Commands.ExcluirPecas;
using autoback.application.Pecas.Commands.MovimentacaoPecas;
using autoback.application.Pecas.DTOs;
using autoback.application.Pecas.Queries;
using Mapster;
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

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetPecasPagedQuery(page, pageSize), ct);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var peca = await _mediator.Send(new GetPecaByIdQuery(id), ct);
            if (peca is null) return NotFound();
            return Ok(peca.Adapt<PecaDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePecaRequest dto, CancellationToken ct)
        {
            var id = await _mediator.Send(
                new CreatePecaCommand(dto.Nome, dto.Codigo, dto.Quantidade, dto.Preco, dto.CategoriaId, dto.FabricanteId), ct);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPatch("{id:int}/preco")]
        public async Task<IActionResult> UpdatePreco(int id, [FromBody] decimal novoPreco, CancellationToken ct)
        {
            var ok = await _mediator.Send(new UpdatePrecoCommand(id, novoPreco), ct);
            return ok ? NoContent() : Problem("Falha ao atualizar preço");
        }

        public record MovEstoqueDto(int Quantidade, string Tipo);

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
