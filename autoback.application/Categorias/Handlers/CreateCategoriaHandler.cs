using autoback.application.Categorias.Commands;
using autoback.domain.Entities;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Categorias.Handlers
{
    public class CreateCategoriaHandler : IRequestHandler<CreateCategoriaCommand, int>
    {
        private readonly ICategoriaRepository _repo;
        public CreateCategoriaHandler(ICategoriaRepository repo) => _repo = repo;

        public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken ct)
        {
            var existente = await _repo.GetByNomeAsync(request.Nome, ct);
            if (existente is not null)
                throw new InvalidOperationException("Já existe categoria com esse nome.");

            var categoria = new Categoria(request.Nome);
            await _repo.AddAsync(categoria, ct);
            await _repo.SaveChangesAsync(ct);
            return categoria.Id;
        }
    }
}
