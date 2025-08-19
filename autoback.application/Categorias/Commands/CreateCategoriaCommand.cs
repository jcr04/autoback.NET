using MediatR;

namespace autoback.application.Categorias.Commands
{
    public record CreateCategoriaCommand(string Nome) : IRequest<int>;
}
