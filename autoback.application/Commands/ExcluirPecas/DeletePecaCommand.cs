using MediatR;

namespace autoback.application.Pecas.Commands
{
    public record DeletePecaCommand(int Id) : IRequest<bool>;
}
