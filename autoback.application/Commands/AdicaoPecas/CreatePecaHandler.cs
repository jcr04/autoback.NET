using autoback.domain.Entities;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Commands.AdicaoPecas
{
    public class CreatePecaHandler : IRequestHandler<CreatePecaCommand, int>
    {
        private readonly IPecaRepository _repo;
        public CreatePecaHandler(IPecaRepository repo) => _repo = repo;

        public async Task<int> Handle(CreatePecaCommand request, CancellationToken ct)
        {
            var existente = await _repo.GetByCodigoAsync(request.Codigo, ct);
            if (existente is not null)
                throw new InvalidOperationException("Já existe peça com esse código.");

            var peca = new Peca(request.Nome, request.Codigo, request.Quantidade, request.Preco);
            await _repo.AddAsync(peca, ct);
            await _repo.SaveChangesAsync(ct);
            return peca.Id;
        }
    }
}
