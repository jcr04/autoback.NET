using MediatR;

namespace autoback.application.Pecas.Commands
{
    public record UpdatePrecoCommand(int Id, decimal NovoPreco) : IRequest<bool>;
}
