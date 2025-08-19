using autoback.application.Common.DTOs;
using MediatR;

namespace autoback.application.Fabricantes.Queries
{
    public record GetFabricantesQuery() : IRequest<List<LookupDto>>;
}
