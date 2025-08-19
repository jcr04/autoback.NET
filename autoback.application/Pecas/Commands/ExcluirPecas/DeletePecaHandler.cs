using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Pecas.Commands.ExcluirPecas
{
    public class DeletePecaHandler : IRequestHandler<DeletePecaCommand, bool>
    {
        private readonly IPecaRepository _repo;
        public DeletePecaHandler(IPecaRepository repo) => _repo = repo;

        public async Task<bool> Handle(DeletePecaCommand request, CancellationToken ct)
        {
            var peca = await _repo.GetByIdAsync(request.Id, ct)
                ?? throw new KeyNotFoundException("Peça não encontrada.");
            await _repo.DeleteAsync(peca, ct);
            return await _repo.SaveChangesAsync(ct);
        }
    }
}
