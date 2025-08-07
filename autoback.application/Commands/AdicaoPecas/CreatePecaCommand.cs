using MediatR;

namespace autoback.application.Commands.AdicaoPecas
{
    public record CreatePecaCommand(string Nome, string Codigo, int Quantidade, decimal Preco) : IRequest<int>;
}
