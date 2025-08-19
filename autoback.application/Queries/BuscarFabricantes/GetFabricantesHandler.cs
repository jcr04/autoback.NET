using autoback.application.Common.DTOs;
using autoback.application.Fabricantes.Queries;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Fabricantes.Handlers
{
    public class GetFabricantesHandler : IRequestHandler<GetFabricantesQuery, List<LookupDto>>
    {
        private readonly IFabricanteRepository _repo;
        public GetFabricantesHandler(IFabricanteRepository repo) => _repo = repo;

        public async Task<List<LookupDto>> Handle(GetFabricantesQuery request, CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(f => new LookupDto(f.Id, f.Nome)).ToList();
        }
    }
}
