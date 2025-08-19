using autoback.application.Fabricantes.Commands;
using autoback.domain.Entities;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Fabricantes.Handlers
{
    public class CreateFabricanteHandler : IRequestHandler<CreateFabricanteCommand, int>
    {
        private readonly IFabricanteRepository _repo;
        public CreateFabricanteHandler(IFabricanteRepository repo) => _repo = repo;

        public async Task<int> Handle(CreateFabricanteCommand request, CancellationToken ct)
        {
            var existente = await _repo.GetByNomeAsync(request.Nome, ct);
            if (existente is not null)
                throw new InvalidOperationException("Já existe fabricante com esse nome.");

            var fabricante = new Fabricante(request.Nome);
            await _repo.AddAsync(fabricante, ct);
            await _repo.SaveChangesAsync(ct);
            return fabricante.Id;
        }
    }
}
