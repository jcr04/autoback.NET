using MediatR;

namespace autoback.application.Fabricantes.Commands
{
    public record CreateFabricanteCommand(string Nome) : IRequest<int>;
}
