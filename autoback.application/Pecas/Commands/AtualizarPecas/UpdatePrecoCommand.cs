using MediatR;

namespace autoback.application.Pecas.Commands.AtualizarPecas
{
    public record UpdatePrecoCommand(int Id, decimal NovoPreco) : IRequest<bool>;
}
