using autoback.application.Pecas.Commands;
using autoback.domain.Interfaces;
using MediatR;
using static autoback.application.Pecas.Commands.MovimentarEstoqueCommand;

namespace autoback.application.Commands.MovimentacaoPecas
{
    public class MovimentarEstoqueHandler : IRequestHandler<MovimentarEstoqueCommand, bool>
    {
        private readonly IPecaRepository _repo;
        public MovimentarEstoqueHandler(IPecaRepository repo) => _repo = repo;

        public async Task<bool> Handle(MovimentarEstoqueCommand request, CancellationToken ct)
        {
            var peca = await _repo.GetByIdAsync(request.IdPeca, ct)
                ?? throw new KeyNotFoundException("Peça não encontrada.");

            if (request.Tipo == TipoMovimentacao.Entrada)
                peca.AdicionarEstoque(request.Quantidade);
            else
                peca.RemoverEstoque(request.Quantidade);

            await _repo.UpdateAsync(peca, ct);
            return await _repo.SaveChangesAsync(ct);
        }
    }
}
