using MediatR;

namespace autoback.application.Pecas.Commands.ExcluirPecas
{
    public record DeletePecaCommand(int Id) : IRequest<bool>;
}
