using autoback.application.Pecas.DTOs;
using MediatR;

namespace autoback.application.Pecas.Queries
{
    public record GetPecasPagedQuery(int Page = 1, int PageSize = 20) : IRequest<PagedResult<PecaDto>>;

    public record PagedResult<T>(IReadOnlyList<T> Items, int Total, int Page, int PageSize);
}
