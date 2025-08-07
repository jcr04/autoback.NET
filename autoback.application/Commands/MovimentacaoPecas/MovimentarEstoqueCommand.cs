using MediatR;

namespace autoback.application.Pecas.Commands
{
    public record MovimentarEstoqueCommand(int IdPeca, int Quantidade, MovimentarEstoqueCommand.TipoMovimentacao Tipo) : IRequest<bool>
    {
        public enum TipoMovimentacao { Entrada, Saida }
    }
}
