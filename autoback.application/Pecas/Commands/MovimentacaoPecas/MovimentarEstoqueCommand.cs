using MediatR;

namespace autoback.application.Pecas.Commands.MovimentacaoPecas
{
    public record MovimentarEstoqueCommand(int IdPeca, int Quantidade, MovimentarEstoqueCommand.TipoMovimentacao Tipo) : IRequest<bool>
    {
        public enum TipoMovimentacao { Entrada, Saida }
    }
}
