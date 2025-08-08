using autoback.application.Pecas.DTOs;
using autoback.application.Pecas.Queries;
using autoback.domain.Interfaces;
using Mapster;
using MediatR;

namespace autoback.application.Pecas.Handlers
{
    public class GetPecasPagedHandler : IRequestHandler<GetPecasPagedQuery, PagedResult<PecaDto>>
    {
        private readonly IPecaRepository _repo;
        public GetPecasPagedHandler(IPecaRepository repo) => _repo = repo;

        public async Task<PagedResult<PecaDto>> Handle(GetPecasPagedQuery request, CancellationToken ct)
        {
            var total = await _repo.CountAsync(ct);
            var data = await _repo.GetAllPagedAsync(request.Page, request.PageSize, ct);
            var items = data.Adapt<List<PecaDto>>();
            return new PagedResult<PecaDto>(items, total, request.Page, request.PageSize);
        }
    }
}
