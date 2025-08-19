using autoback.application.Common.DTOs;
using MediatR;

namespace autoback.application.Categorias.Queries
{
    public record GetCategoriasQuery() : IRequest<List<LookupDto>>;
}
