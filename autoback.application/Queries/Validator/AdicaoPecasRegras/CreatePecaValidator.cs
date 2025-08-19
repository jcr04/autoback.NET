using autoback.application.Pecas.Commands;
using autoback.application.Pecas.Commands.AdicaoPecas;
using FluentValidation;

namespace autoback.application.Pecas.Validators
{
    public class CreatePecaValidator : AbstractValidator<CreatePecaCommand>
    {
        public CreatePecaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(120);
            RuleFor(x => x.Codigo).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Preco).GreaterThanOrEqualTo(0);
        }
    }
}
