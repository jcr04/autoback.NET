using autoback.application.Categorias.Commands;
using FluentValidation;

namespace autoback.application.Categorias.Validators
{
    public class CreateCategoriaValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(80);
        }
    }
}
