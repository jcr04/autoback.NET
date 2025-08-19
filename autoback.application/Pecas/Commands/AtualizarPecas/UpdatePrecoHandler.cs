using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Pecas.Commands.AtualizarPecas
{
    public class UpdatePrecoHandler : IRequestHandler<UpdatePrecoCommand, bool>
    {
        private readonly IPecaRepository _repo;
        public UpdatePrecoHandler(IPecaRepository repo) => _repo = repo;

        public async Task<bool> Handle(UpdatePrecoCommand request, CancellationToken ct)
        {
            var peca = await _repo.GetByIdAsync(request.Id, ct)
                ?? throw new KeyNotFoundException("Peça não encontrada.");

            peca.AtualizarPreco(request.NovoPreco);
            await _repo.UpdateAsync(peca, ct);
            return await _repo.SaveChangesAsync(ct);
        }
    }
}
