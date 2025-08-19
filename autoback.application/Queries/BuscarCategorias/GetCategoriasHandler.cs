using autoback.application.Categorias.Queries;
using autoback.application.Common.DTOs;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Categorias.Handlers
{
    public class GetCategoriasHandler : IRequestHandler<GetCategoriasQuery, List<LookupDto>>
    {
        private readonly ICategoriaRepository _repo;
        public GetCategoriasHandler(ICategoriaRepository repo) => _repo = repo;

        public async Task<List<LookupDto>> Handle(GetCategoriasQuery request, CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(c => new LookupDto(c.Id, c.Nome)).ToList();
        }
    }
}
