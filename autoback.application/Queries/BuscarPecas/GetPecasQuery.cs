using autoback.domain.Entities;
using MediatR;

namespace autoback.application.Pecas.Queries
{
    public record GetPecasQuery() : IRequest<List<Peca>>;
}
