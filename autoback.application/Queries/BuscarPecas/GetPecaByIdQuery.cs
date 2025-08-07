using autoback.domain.Entities;
using MediatR;

namespace autoback.application.Pecas.Queries
{
    public record GetPecaByIdQuery(int Id) : IRequest<Peca?>;
}
